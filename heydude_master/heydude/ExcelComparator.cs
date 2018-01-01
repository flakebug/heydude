///*
// * Created by SharpDevelop.
// * User: 53785
// * Date: 2017/12/18
// * Time: 下午 02:48
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System;
//using System.IO;
//using System.Data;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Drawing;
//using System.Linq;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//namespace xlsxcomp
//{
//	/// <summary>
//	/// Description of CompareXlsxCore.
//	/// </summary>
//	public class ExcelComparator
//	{
//		private ExcelPackage _updatedExcelPackage;
//		private ExcelPackage _previousExcelPackage;
//		private FileStream _updatedFilestream;
//		private FileStream _previousFilestream;
//		private ExcelWorkbook _updatedWorkbook;
//		private ExcelWorkbook _previousWorkbook;
//		private List<worksheetInfo> _updatedWorkSheets;
//		private List<worksheetInfo> _previousWorkSheets;
//		//private DataTable _resultDataTable;	//the final result to be exported
//		//private List<string> _resultStatus;	//the comparison result(new/updated/deleted) of _resultDataTable
//		private string _updatedFileFullPath;
//		private string _previousFileFullPath;
//		private string _resultFileFullPath;
//		private const int _headerRowNumber = 1;
//		private const int _dataColumnStartNumber = 1;
//		
//		public ExcelWorkbook UpdatedWorkbook {
//			get { return _updatedWorkbook; }
//		}
//		public ExcelWorkbook PreviousWorkbook {
//			get { return _previousWorkbook; }
//		}
//		
//		public string UpdatedFileFullPath {
//			get{ return _updatedFileFullPath; }
//			set{ _updatedFileFullPath = value; }
//		}
//		
//		
//		public string PreviousFileFullPath {
//			get{ return _previousFileFullPath; }
//			set{ _previousFileFullPath = value; }
//		}
//		
//		
//		public string ResultFileFullPath {
//			get{ return _resultFileFullPath; }
//			set{ _resultFileFullPath = value; }
//		}
//		
//		private class worksheetDifference
//		{
//			public worksheetInfo UpdatedWorksheet;
//			public worksheetInfo PreviousWorksheet;
//			public enum DataStatus
//			{
//				New,
//				Unchange,
//				Update,
//				Delete,
//				Unknown
//			}
//			//private DataTable _resultDataTable;
//			private int _currentResultRowNumber = 1;
//			private int _resultColumnCount;
//			
//			//Define the result table column's source
//			//<ResultTableColumnNumber, Column status>
//			private Dictionary<int, WorksheetColumnStatus> _resultDataTableColumnRelation;
//			private List<CellStatus> _resultDataTableCellStatus;
//			private int _deletedColumnCount;
//			private int _addedColumnCount;
//			
//			public struct CellStatus
//			{
//				public int RowNumber;
//				public int ColumnNumber;
//				public DataStatus Status;
//				public string UpdatedText;
//				public string PreviousText;
//			}
//			
//			public struct WorksheetColumnStatus
//			{
//				public int ColumnNumber;
//				public string UserDefinedColumnName;
//				public DataStatus Status;
//			}
//			
//			public List<CellStatus> ResultDataTableCellStatus {
//				get { return _resultDataTableCellStatus; }
//			}
//			
//			
//			public worksheetDifference(
//				worksheetInfo UpdatedWorksheet,
//				worksheetInfo PreviousWorksheet)
//			{
//				//if there is no any key column in worksheet
//				//comparison cannot be proceed
//				//throw exception
//				if (UpdatedWorksheet.KeyColumn == 0) {
//					string msg = 
//						"Updated workbook " +
//						"[" + UpdatedWorksheet.Worksheet.Name + "] " +
//						" key column is not available";
//					InvalidKeyColumn ex = new InvalidKeyColumn(msg);
//					throw ex;
//				}
//				if (PreviousWorksheet.KeyColumn == 0) {
//					string msg = 
//						"Previous workbook " +
//						"[" + PreviousWorksheet.Worksheet.Name + "] " +
//						" key column is not available";
//					InvalidKeyColumn ex = new InvalidKeyColumn(msg);
//					throw ex;
//				}				
//				this.UpdatedWorksheet = UpdatedWorksheet;
//				this.PreviousWorksheet = PreviousWorksheet;
//				
//				List<string> resultColumn = new List<string>();
//				
//				//initializeResultDataTableColumnAndHeader();
//				_resultDataTableColumnRelation = new Dictionary<int, WorksheetColumnStatus>();
//				this._resultColumnCount = 1;	//initialize the first column
//				Queue<string> deletedColumnName = new Queue<string>();
//				this._deletedColumnCount = 0;
//				for (int prevColIndx = 1; 
//				    prevColIndx <= this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary.Count; 
//				    prevColIndx++) {
//					string prevKeyText = this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[prevColIndx];
//
//					if (!this.UpdatedWorksheet.HeaderRowCellTextDictionary.ContainsKey(prevKeyText)) {
//						Console.WriteLine("Deleted header column : " + this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[prevColIndx]);
//						//_resultDataTable.Columns.Add(columnNamePrefix + resultColIndx.ToString(), typeof(string));
//						this._deletedColumnCount++;
//						deletedColumnName.Enqueue(this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[prevColIndx]);
//						//deletedColIndxList.Add(prevColIndx);
//						WorksheetColumnStatus wksc;
//						wksc.ColumnNumber = this._resultColumnCount;
//						wksc.Status = DataStatus.Delete;
//						wksc.UserDefinedColumnName = this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[prevColIndx];
//						resultColumn.Add(this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[prevColIndx]);
//						_resultDataTableColumnRelation.Add(this._resultColumnCount, wksc);
//						this._resultColumnCount++;
//					}
//				}		
//				
//				Queue<string> updatedColumnName = new Queue<string>();
//				this._deletedColumnCount = 0;
//				for (int updatedColIndx = 1; 
//				    updatedColIndx <= this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary.Count; 
//				    updatedColIndx++) {
//					string updatedKeyText = this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx];
//
//					if (!this.PreviousWorksheet.HeaderRowCellTextDictionary.ContainsKey(updatedKeyText)) {
//						Console.WriteLine("New header column : " + this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx]);
//						//_resultDataTable.Columns.Add(columnNamePrefix + resultColIndx.ToString(), typeof(string));
//						this._addedColumnCount++;
//						WorksheetColumnStatus wksc;
//						wksc.ColumnNumber = this._resultColumnCount;
//						wksc.Status = DataStatus.New;
//						wksc.UserDefinedColumnName = this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx];
//						_resultDataTableColumnRelation.Add(this._resultColumnCount, wksc);
//						resultColumn.Add(this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx]);
//					} else {
//						if (resultColumn.Contains(updatedKeyText)) {
//							WorksheetColumnStatus wksc;
//							wksc.ColumnNumber = this._resultColumnCount;
//							wksc.Status = DataStatus.New;
//							wksc.UserDefinedColumnName = this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx];
//							_resultDataTableColumnRelation.Add(this._resultColumnCount, wksc);
//							resultColumn.Add(this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx]);
//
//						} else {
//							WorksheetColumnStatus wksc;
//							wksc.ColumnNumber = this._resultColumnCount;
//							wksc.Status = DataStatus.Unchange;
//							wksc.UserDefinedColumnName = this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx];
//							_resultDataTableColumnRelation.Add(this._resultColumnCount, wksc);							
//							resultColumn.Add(this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx]);
//
//						}
//
//						
//					}
//					this._resultColumnCount++;
//				}						
////				this._resultColumnCount = this.UpdatedWorksheet.TrueEndColumn + this._deletedColumnCount;
////				_resultDataTableColumnRelation = new Dictionary<int, WorksheetColumnStatus>();
////				for(int resultColIndx = 1;
////				    resultColIndx <= this._resultColumnCount;
////				    resultColIndx++) {
////					WorksheetColumnStatus wksc;
////					wksc.ColumnNumber = resultColIndx;
////					
////					if (resultColIndx <= this._deletedColumnCount) {
////						wksc.Status = DataStatus.Delete;
////						wksc.UserDefinedColumnName = deletedColumnName.Dequeue();
////					}
////					else
////						wksc.Status = DataStatus.Unknown;
////					_resultDataTableColumnRelation.Add(resultColIndx, wksc);					
////				}
//
//
//				_resultDataTableCellStatus = new List<CellStatus>();
//				findAndRenderDeleteRow();
//				compareAndRenderRemainingRow();
//			}
//			
//			//			public DataTable ResultDataTable {
//			//				get { return _resultDataTable; }
//			//			}
//			
//			//			private int addNewRowToResultDataTable(Queue<string> RawText)
//			//			{
//			//				DataRow dr;
//			//				int colIndx = 0;
//			//				dr = _resultDataTable.NewRow();
//			//				while (RawText.Count > 0) {
//			//					dr[colIndx] = RawText.Dequeue();
//			//					colIndx++;
//			//				}
//			//				_resultDataTable.Rows.Add(dr);
//			//				return _resultDataTable.Rows.Count - 1;	//return the last index of result datatable
//			//			}
//			
//			//manipulate all the row in updated worksheet
//			//tagging the new row / updated cell
//			//and render all the rows to result table
//			private void compareAndRenderRemainingRow()
//			{
//				int updatedRowIndx;
//				string updatedRowKeyText;
//				string resultCellText;
//				//int resultTableRowIndx = this._resultDataTable.Rows.Count;
//				Queue<string> rawTextQueue = new Queue<string>();
//				for (updatedRowIndx = _headerRowNumber + 1;
//				     updatedRowIndx <= this.UpdatedWorksheet.TrueEndRow;
//				     updatedRowIndx++) {
//					updatedRowKeyText = this.UpdatedWorksheet.KeyColumnCellRowNumberDictionary[updatedRowIndx];
//					
//					//if the key column of updated worksheet is not exist in previous worksheet
//					//then it means the column not processed
//					//because the deleted rows has been processed in findAndRenderDeleteRow()
//					if (this.PreviousWorksheet.KeyColumnCellTextDictionary.ContainsKey(updatedRowKeyText)) {
//						//existing row handling
//						int previousRowKeyIndx = this.PreviousWorksheet.KeyColumnCellTextDictionary[updatedRowKeyText];
//						
//						rawTextQueue.Clear();
//						CellStatus cellstatus;
//						for (int resultTableColIndx = 1;
//						     resultTableColIndx <= this._resultColumnCount;
//						     resultTableColIndx++) {
//							int updatedColIndx = _resultDataTableColumnRelation[resultTableColIndx].ColumnNumber;
//							resultCellText = "";
//							
//							DataStatus columnStatus = this._resultDataTableColumnRelation[resultTableColIndx].Status;
//							if (columnStatus == DataStatus.Delete) {
//								//the row is exist, but column has deleted
//								//Console.Write("DEL |");
//								resultCellText = this.PreviousWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//								cellstatus.Status = DataStatus.Delete;
//								cellstatus.UpdatedText = "";
//								cellstatus.PreviousText = resultCellText;
//							} else if (columnStatus == DataStatus.New) {
//								//Console.Write("NEW |");
//								resultCellText = this.UpdatedWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//								cellstatus.Status = DataStatus.New;
//								cellstatus.UpdatedText = resultCellText;
//								cellstatus.PreviousText = "";								
//							} else {
//								string updatedColName = _resultDataTableColumnRelation[resultTableColIndx].UserDefinedColumnName;
//								int previousColIndx = this.PreviousWorksheet.HeaderRowCellTextDictionary[updatedColName];
//								resultCellText = this.UpdatedWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//								if (resultCellText == this.PreviousWorksheet.Worksheet.Cells[previousRowKeyIndx, previousColIndx].Text) {
//									//Console.Write("SME |");
//									cellstatus.Status = DataStatus.Unchange;
//									cellstatus.UpdatedText = this.UpdatedWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//									cellstatus.PreviousText = this.UpdatedWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//								} else {
//									//Console.Write("UPD |");
//									cellstatus.Status = DataStatus.Update;
//									cellstatus.UpdatedText = this.UpdatedWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//									cellstatus.PreviousText = this.PreviousWorksheet.Worksheet.Cells[previousRowKeyIndx, previousColIndx].Text;
//								}
//							}
//							rawTextQueue.Enqueue(resultCellText);
//							cellstatus.RowNumber = _currentResultRowNumber;
//							cellstatus.ColumnNumber = resultTableColIndx;
//							this._resultDataTableCellStatus.Add(cellstatus);
//							_currentResultRowNumber++;
//						}
//						//addNewRowToResultDataTable(rawTextQueue);
//						//Console.WriteLine();
//					} else {
//						//new row handling
//						rawTextQueue.Clear();
//						CellStatus cellstatus;
//						for (int resultTableColIndx = 1;
//						     resultTableColIndx <= this._resultColumnCount;
//						     resultTableColIndx++) {
//							int updatedColIndx = _resultDataTableColumnRelation[resultTableColIndx].ColumnNumber;
//							resultCellText = "";
//							
//							DataStatus columnStatus = this._resultDataTableColumnRelation[resultTableColIndx].Status;
//							if (columnStatus == DataStatus.Delete) {
//								//column deleted
//								//Console.Write("DEL |");
//								cellstatus.Status = DataStatus.Delete;
//								cellstatus.UpdatedText = "";
//								cellstatus.PreviousText = "";
//								resultCellText = "";
//							} else {
//								//Console.Write("NEW |");
//								resultCellText = this.UpdatedWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//								cellstatus.Status = DataStatus.New;
//								cellstatus.UpdatedText = this.UpdatedWorksheet.Worksheet.Cells[updatedRowIndx, updatedColIndx].Text;
//								cellstatus.PreviousText = "";
//							}
//							rawTextQueue.Enqueue(resultCellText);
//							cellstatus.RowNumber = _currentResultRowNumber;
//							cellstatus.ColumnNumber = resultTableColIndx;
//							this._resultDataTableCellStatus.Add(cellstatus);
//							_currentResultRowNumber++;
//						}
//						//addNewRowToResultDataTable(rawTextQueue);
//						//Console.WriteLine();						
//					}
//				}
//			}
//				
//			//manipulate all the row in previous worksheet
//			//and render the deleted rows to result table
//			private void findAndRenderDeleteRow()
//			{
//				int resultTableRowIndx = 2; //set variable as 2 of the starting of data row, because row 1 = header
//				int prevRowIndx;
//				string prevRowKeyText;
//				Queue<string> rawTextQueue;
//				for (prevRowIndx = _headerRowNumber + 1; 
//				    prevRowIndx <= this.PreviousWorksheet.TrueEndRow; //plus one for the skipping of header column 
//				    prevRowIndx++) {
//					
//					prevRowKeyText = this.PreviousWorksheet.KeyColumnCellRowNumberDictionary[prevRowIndx];
//					
//					//if the key column of previous worksheet is not exist in updated worksheet
//					//then it means the column has been deleted
//					if (!this.UpdatedWorksheet.KeyColumnCellTextDictionary.ContainsKey(prevRowKeyText)) {
//						Console.WriteLine("Deleted rows : " + this.PreviousWorksheet.KeyColumnCellRowNumberDictionary[prevRowIndx]);
//						rawTextQueue = new Queue<string>();
//						CellStatus cellstatus;
//						for (int colIndx = 1;
//						     colIndx <= this._resultColumnCount;
//						     colIndx++) {
//							int colTargetNumber = 0;
//							string colTargetName = "";
//							int rowTarget = 0;
//							string textTarget = "";
//							
//							switch (_resultDataTableColumnRelation[colIndx].Status) {
//								case DataStatus.Delete:
//									//handling the deleted columns
//									colTargetNumber = _resultDataTableColumnRelation[colIndx].ColumnNumber;
//									textTarget = this.PreviousWorksheet.Worksheet.Cells[prevRowIndx, colTargetNumber].Text;
//									rawTextQueue.Enqueue(textTarget);
//									cellstatus.UpdatedText = "";
//									cellstatus.PreviousText = textTarget;
//									break;
//								case DataStatus.New:
//									//handling the new columns
//									textTarget = "";
//									rawTextQueue.Enqueue("");  //add blank cell to added column of previous sheet
//									cellstatus.UpdatedText = "";
//									cellstatus.PreviousText = "";
//									break;
//								default:
//									//handling the unchanged and updated columns
//									colTargetNumber = _resultDataTableColumnRelation[colIndx].ColumnNumber;
//									colTargetName = _resultDataTableColumnRelation[colIndx].UserDefinedColumnName;
//									rowTarget = this.PreviousWorksheet.KeyColumnCellTextDictionary[prevRowKeyText];
//									if (this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary.ContainsKey(colTargetNumber)) {
//										//if the result column is for unchanged
//										//the data cell comes from original "previous" table
//										textTarget = this.PreviousWorksheet.GetCellTextByKey(prevRowKeyText, colTargetName);
//									} else {
//										//the deleted column has handled before
//										//but during iteration of the result table, it will iterate again
//										//in this case, fill the result cell by "updated" table
//										textTarget = this.UpdatedWorksheet.GetCellTextByKey(prevRowKeyText, colTargetName);
//									}
//									rawTextQueue.Enqueue(textTarget);
//									cellstatus.UpdatedText = "";
//									cellstatus.PreviousText = textTarget;									
//									break;
//									
//							}
//							cellstatus.ColumnNumber = colIndx;
//							cellstatus.RowNumber = _currentResultRowNumber;
//							cellstatus.Status = DataStatus.Delete;
//							_resultDataTableCellStatus.Add(cellstatus);
//							
//						}
//						//addNewRowToResultDataTable(rawTextQueue);	
//						resultTableRowIndx++;
//						_currentResultRowNumber++;
//					}
//				}
//			}
//			
//
//		
//			//			private void initializeResultDataTableColumnAndHeader()
//			//			{
//			//				_resultDataTable = new DataTable();
//			//				int resultColIndx = 1;
//			//				const string columnNamePrefix = "__sys__c";
//			//
//			//				//find deleted columns
//			//				//int deletedColCount = 0;
//			//				int prevColIndx;
//			//				string prevKeyText;
//			//				List<int> deletedColIndxList = new List<int>();
//			//				this._deletedColumnCount = 0;
//			//				for (prevColIndx = 1;
//			//				    prevColIndx <= this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary.Count;
//			//				    prevColIndx++) {
//			//					prevKeyText = this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[prevColIndx];
//			//					if (!this.UpdatedWorksheet.HeaderRowCellTextDictionary.ContainsKey(prevKeyText)) {
//			//						Console.WriteLine("Deleted header column : " + this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[prevColIndx]);
//			//						//_resultDataTable.Columns.Add(columnNamePrefix + resultColIndx.ToString(), typeof(string));
//			//						this._deletedColumnCount++;
//			//						deletedColIndxList.Add(prevColIndx);
//			//					}
//			//				}
//			//
//			//
//			//				//find added columns
//			//				//int addedColCount = 0;
//			//				int updatedColIndx;
//			//				string updatedKeyText;
//			//				List<int> addedColIndxList = new List<int>();
//			//				this._addedColumnCount = 0;
//			//				for (updatedColIndx = 1;
//			//				    updatedColIndx <= this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary.Count;
//			//				    updatedColIndx++) {
//			//					updatedKeyText = this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx];
//			//					if (!this.PreviousWorksheet.HeaderRowCellTextDictionary.ContainsKey(updatedKeyText)) {
//			//						Console.WriteLine("Added header column : " + this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[updatedColIndx]);
//			//						//_resultDataTable.Columns.Add(columnNamePrefix + resultColIndx.ToString(), typeof(string));
//			//						this._addedColumnCount++;
//			//						addedColIndxList.Add(updatedColIndx);
//			//					}
//			//				}
//			//
//			//				//make result table column structure
//			////				for (resultColIndx = 1;
//			////				     resultColIndx <= this.UpdatedWorksheet.TrueEndColumn + this._deletedColumnCount;
//			////				     resultColIndx++) {
//			////					_resultDataTable.Columns.Add(columnNamePrefix + resultColIndx.ToString(), typeof(string));
//			////				}
//			//				this._resultColumnCount = this.UpdatedWorksheet.TrueEndColumn + this._deletedColumnCount;
//			//				//make the column relationship table
//			//				resultColIndx = 1;
//			//				_resultDataTableColumnRelation = new Dictionary<int, WorksheetColumnStatus>();
//			//				WorksheetColumnStatus wkscForDeleted;
//			//				//set the relationship of result table of deleted columns
//			//				//wksc.Worksheet = this.PreviousWorksheet;
//			//				foreach (int deletedColIndxItem in deletedColIndxList) {
//			//					wkscForDeleted.ColumnNumber = deletedColIndxItem;
//			//					//wkscForDeleted.PreviousWorksheetColumnNumber = deletedColIndxItem;
//			//					//wkscForDeleted.UpdatedWorksheetColumnNumber = 0;
//			//					wkscForDeleted.UserDefinedColumnName = this.PreviousWorksheet.HeaderRowCellColumnNumberDictionary[deletedColIndxItem];
//			//					wkscForDeleted.Status = DataStatus.Delete;
//			//					_resultDataTableColumnRelation.Add(resultColIndx, wkscForDeleted);
//			//					resultColIndx++;
//			//				}
//			//
//			//
//			//				//set the relationship of result table of remain columns
//			//				//wksc.Worksheet = this.UpdatedWorksheet;
//			//				WorksheetColumnStatus wkscForRegular;
//			//				for (resultColIndx = resultColIndx;
//			//				    resultColIndx <= this.UpdatedWorksheet.TrueEndColumn + this._deletedColumnCount;
//			//				    resultColIndx++) {
//			//					wkscForRegular.ColumnNumber = resultColIndx - this._deletedColumnCount;
//			//					//wkscForRegular.UpdatedWorksheetColumnNumber = resultColIndx - this._deletedColumnCount;
//			//					//wkscForRegular.PreviousWorksheetColumnNumber = resultColIndx;
//			//					if (this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary.ContainsKey(
//			//						    resultColIndx - this._deletedColumnCount)) {
//			//						wkscForRegular.UserDefinedColumnName = this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[resultColIndx - this._deletedColumnCount];
//			//						if (this.PreviousWorksheet.HeaderRowCellTextDictionary.ContainsKey(
//			//							    this.UpdatedWorksheet.HeaderRowCellColumnNumberDictionary[resultColIndx - this._deletedColumnCount]))
//			//							wkscForRegular.Status = DataStatus.Unchange;
//			//						else
//			//							wkscForRegular.Status = DataStatus.New;
//			//
//			//					} else {
//			//						wkscForRegular.UserDefinedColumnName = "";
//			//						wkscForRegular.Status = DataStatus.Unknown;
//			//					}
//			//					_resultDataTableColumnRelation.Add(resultColIndx, wkscForRegular);
//			//				}
//			//
//			//				//add the header row to first row of datatable
//			//				Queue<string> columnQueue = new Queue<string>();
//			//				for (int resultIndx = 1;
//			//				    resultIndx <= _resultDataTable.Columns.Count;
//			//				    resultIndx++) {
//			//					CellStatus cellstatus;
//			//					cellstatus.ColumnNumber = resultIndx;
//			//					cellstatus.RowNumber = 1;
//			//					cellstatus.Status = _resultDataTableColumnRelation[resultIndx].Status;
//			//					switch (_resultDataTableColumnRelation[resultIndx].Status) {
//			//						case DataStatus.New:
//			//							cellstatus.UpdatedText = _resultDataTableColumnRelation[resultIndx].UserDefinedColumnName;
//			//							cellstatus.PreviousText = "";
//			//							break;
//			//						case DataStatus.Delete:
//			//							cellstatus.UpdatedText = "";
//			//							cellstatus.PreviousText = _resultDataTableColumnRelation[resultIndx].UserDefinedColumnName;
//			//							break;
//			//						default:
//			//							cellstatus.UpdatedText = _resultDataTableColumnRelation[resultIndx].UserDefinedColumnName;
//			//							cellstatus.PreviousText = _resultDataTableColumnRelation[resultIndx].UserDefinedColumnName;
//			//							break;
//			//					}
//			//
//			//					_resultDataTableCellStatus.Add(cellstatus);
//			//					columnQueue.Enqueue(this._resultDataTableColumnRelation[resultIndx].UserDefinedColumnName);
//			//					this._currentResultRowNumber++;
//			//				}
//			//				addNewRowToResultDataTable(columnQueue);
//			//
//			//			}
//		}
//
//		private class worksheetInfo
//		{
//			
//			private ExcelWorksheet _worksheet;
//			private int _trueEndRow;
//			private int _trueEndColumn;
//			private int _systemEndRow;
//			private int _systemEndColumn;
//			private int _keyColumn;
//			//stores <CellText, RowNumber> for key column
//			private Dictionary<string,int> _keyColumnCellTextDictionary;
//			//stores <RowNumber, CellText> for key column
//			private Dictionary<int,string> _keyColumnCellRowNumberDictionary;
//			//stores <CellText, RowNumber> for header row
//			private Dictionary<string,int> _headerRowCellTextDictionary;
//			//stores <RowNumber, CellText> for header row
//			private Dictionary<int,string> _headerRowCellColumnNumberDictionary;
//			
//			public ExcelWorksheet Worksheet {
//				get { return _worksheet; }
//			}
//			
//			public int KeyColumn {
//				get { return _keyColumn; }
//			}
//			
//			public Dictionary<string,int> KeyColumnCellTextDictionary {
//				get {
//					return _keyColumnCellTextDictionary;
//				}
//			}
//		
//			public Dictionary<int,string> KeyColumnCellRowNumberDictionary {
//				get {
//					return _keyColumnCellRowNumberDictionary;
//				}
//			}
//			
//			public Dictionary<string,int> HeaderRowCellTextDictionary {
//				get {
//					return _headerRowCellTextDictionary;
//				}
//			}
//		
//			public Dictionary<int,string> HeaderRowCellColumnNumberDictionary {
//				get {
//					return _headerRowCellColumnNumberDictionary;
//				}
//			}
//			public int TrueEndRow {
//				get {
//					return _trueEndRow;
//				}
//			}
//			public int TrueEndColumn {
//				get {
//					return _trueEndColumn;
//				}
//			}
//			public int SystemEndRow {
//				get {
//					return _systemEndRow;
//				}
//			}
//			public int SystemEndColumn {
//				get {
//					return _systemEndColumn;
//				}
//			}
//			
//			public worksheetInfo(ExcelWorksheet Worksheet)
//			{
//				_worksheet = Worksheet;
//				_trueEndRow = 0;
//				_trueEndColumn = 0;
//				if (Worksheet.Dimension == null) {
//					_systemEndRow = 0;
//					_systemEndColumn = 0;
//				} else {
//					_systemEndRow = Worksheet.Dimension.End.Row;
//					_systemEndColumn = Worksheet.Dimension.End.Column;
//				}
//
//				findTrueEndRowAndColumn();
//				findKeyColumn();
//				initializeHeaderRow();
//			}
//			
//			private void initializeHeaderRow()
//			{
//				int colIndx;
//				
//				//prepare header row
//				_headerRowCellTextDictionary = new Dictionary<string,int>();
//				_headerRowCellColumnNumberDictionary = new Dictionary<int, string>();
//				for (colIndx = 1; colIndx <= this.TrueEndColumn; colIndx++) {
//					string celltext = this.Worksheet.Cells[_headerRowNumber, colIndx].Text;
//					Console.WriteLine("Header text : " + celltext);
//					if (!_headerRowCellTextDictionary.ContainsKey(celltext)) {
//						_headerRowCellTextDictionary.Add(
//							this.Worksheet.Cells[_headerRowNumber, colIndx].Text,
//							colIndx
//						);
//						_headerRowCellColumnNumberDictionary.Add(
//							colIndx,
//							this.Worksheet.Cells[_headerRowNumber, colIndx].Text
//						);
//					}
//				}
//			}
//			
//			
//			private void findKeyColumn()
//			{
//				int rowIndx;
//				int colIndx;
//				List<int> keyColumnCandidate = new List<int>();
//				HashSet<string> keySet;
//				bool duplicated;
//				string cellText;
//				
//				//make the key column candidates
//				for (colIndx = 1; colIndx <= this.SystemEndColumn; colIndx++) {
//					duplicated = false;
//					keySet = new HashSet<string>();
//					for (rowIndx = 1; rowIndx <= this.SystemEndRow; rowIndx++) {
//						cellText = this.Worksheet.Cells[rowIndx, colIndx].Text;
//						if (cellText.Trim() == "")
//							continue;
//						keySet.Add(cellText);
//						if (keySet.Count != rowIndx) {
//							duplicated = true;
//							break;
//						}
//					}
//					if (duplicated)
//						keyColumnCandidate.Add(0);
//					else
//						keyColumnCandidate.Add(keySet.Count);
//				}
//				
//				//Here find the key column result by their weight
//				int keyColumnMaxIndx = -1;
//				int keyColumnMaxWeight = 0;
//				int keyIndx;
//				for (keyIndx = 0; keyIndx < keyColumnCandidate.Count; keyIndx++) {
//					if (keyColumnMaxWeight < keyColumnCandidate[keyIndx])
//					if (keyColumnCandidate[keyIndx] > 1) {
//						keyColumnMaxWeight = keyColumnCandidate[keyIndx];
//						keyColumnMaxIndx = keyIndx;
//					}
//				}
//				this._keyColumn = keyColumnMaxIndx + 1;
////				if (this._keyColumn < 1) {
////					string msg = 
////						"Worksheet : " + this.Worksheet.Name + " " +
////						" key column is not available";
////					InvalidKeyColumn ex = new InvalidKeyColumn(msg);
////					
////					throw ex;
////				}
//				
//				//prepare key column
//				_keyColumnCellTextDictionary = new Dictionary<string,int>();
//				_keyColumnCellRowNumberDictionary = new Dictionary<int, string>();
//
//				if (this.KeyColumn > 0) {
//					for (rowIndx = 2; rowIndx <= this.TrueEndRow; rowIndx++) {
//						_keyColumnCellTextDictionary.Add(
//							this.Worksheet.Cells[rowIndx, this.KeyColumn].Text,
//							rowIndx
//						);
//						_keyColumnCellRowNumberDictionary.Add(
//							rowIndx,
//							this.Worksheet.Cells[rowIndx, this.KeyColumn].Text
//						);
//					}
//				}
//			}
//			
//			private void findTrueEndRowAndColumn()
//			{
//				int colIndx;
//				int rowIndx;
//				int colMax = 0;
//				int rowMax = 0;
//				
//				//find true end column
//				for (rowIndx = 1; rowIndx <= this.SystemEndRow; rowIndx++) {
//					for (colIndx = colMax + 1; colIndx <= this.SystemEndColumn; colIndx++) {
//						if (this.Worksheet.Cells[rowIndx, colIndx].Text.Length > 0)
//							colMax = colIndx;
//						if (colMax >= this.SystemEndColumn)
//							break;
//					}
//					if (colMax >= this.SystemEndColumn)
//						break;					
//				}
//				_trueEndColumn = colMax;
//				
//				//find true end row
//				for (colIndx = 1; colIndx <= this.SystemEndColumn; colIndx++) {
//					for (rowIndx = rowMax + 1; rowIndx <= this.SystemEndRow; rowIndx++) {
//						if (this.Worksheet.Cells[rowIndx, colIndx].Text.Length > 0)
//							rowMax = rowIndx;
//						if (rowMax >= this.SystemEndRow)
//							break;
//					}
//					if (rowMax >= this.SystemEndRow)
//						break;					
//				}	
//				_trueEndRow = rowMax;
//			}
//		
//			private void findTrueEndRowAndColumn_Parallel()
//			{
//				
//				
//				int colMax = 0;
//				int rowMax = 0;
//				
//				Parallel.For(1, this.SystemEndRow, (int rowIndxParallel, ParallelLoopState loopState) => {
//					int colIndx;
//					for (colIndx = colMax + 1; colIndx <= this.SystemEndColumn; colIndx++) {
//						if (colMax >= this.SystemEndColumn)
//							loopState.Stop();
//						if (this.Worksheet.Cells[rowIndxParallel, colIndx].Text.Length > 0)
//							colMax = colIndx;
//					}
//				});
//				_trueEndColumn = colMax;
//			
//				//find true end row
//				Parallel.For(1, this.SystemEndColumn, (int colIndxParallel, ParallelLoopState loopState) => {
//					int rowIndx;
//					for (rowIndx = rowMax + 1; rowIndx <= this.SystemEndRow; rowIndx++) {
//						if (rowMax >= this.SystemEndRow)
//							loopState.Stop();
//						if (this.Worksheet.Cells[rowIndx, colIndxParallel].Text.Length > 0)
//							rowMax = rowIndx;
//					}
//				});	
//				_trueEndRow = rowMax;
//			}
//			
//			public string GetCellTextByKey(string RowKeyText, string ColumnKeyText)
//			{
//				int colNum = this._headerRowCellTextDictionary[ColumnKeyText];
//				int rowNum = this._keyColumnCellTextDictionary[RowKeyText];
//				return this.Worksheet.Cells[rowNum, colNum].Text;
//				
//			}
//		}
//		
//		
//		
//		//		private Dictionary<string,int> getDeletedRowsOfPreviousWorksheet(worksheetInfo UpdatedWorksheet, worksheetInfo PreviousWorksheet)
//		//		{
//		//			Dictionary<string,int> result = new Dictionary<string,int>();
//		//			foreach(KeyValuePair<string,int> updatedKey in PreviousWorksheet.KeyColumnDictionary)
//		//			{
//		//				if (UpdatedWorksheet.KeyColumnDictionary.ContainsKey(updatedKey.Key))
//		//				{
//		//
//		//				}
//		//			}
//		//
//		//
//		//			int prevKeyColDictCount = PreviousWorksheet.KeyColumnDictionary.Count;
//		//			int prevKeyColDictIndx;
//		//			for(prevKeyColDictIndx = 0; prevKeyColDictIndx < prevKeyColDictCount; prevKeyColDictIndx++){
//		//				if(
//		//					UpdatedWorksheet.KeyColumnDictionary.ContainsKey(
//		//						//PreviousWorksheet.KeyColumnDictionary.Keys.
//		//					)
//		//				)
//		//				{
//		//
//		//				}
//		//			}
//		//		}
//		
//
//		
//		public ExcelComparator()
//		{
//		}
//		
//
//		
//
//		
//		private bool verifyTwinWorksheet(
//			ExcelWorksheet UpdatedExcelWorksheetObject,
//			ExcelWorksheet PreviousExcelWorksheetObject)
//		{
//			return false;
//		}
//		
//		private DataTable getDataTableFromWorksheet(
//			ExcelWorksheet ExcelWorksheetObject)
//		{
//			//Parallel-For import has to implement
////			int startrow = _excelDataTable.Address.Start.Row;
////			int startcol = _excelDataTable.Address.Start.Column;
////			int endrow = _excelDataTable.Address.End.Row;
////			int endcol = _excelDataTable.Address.End.Column;
////			int x, y;
////			string tmpString;
////			DataRow drow;
////
////			for (x = startcol; x <= endcol; x++) {
////				tmpString = _excelDataTable.WorkSheet.Cells[startrow, x].Text;
////
////				_dataTable.Columns.Add(tmpString.Trim(), typeof(string));
////			}
////
////			for (y = startrow + 1; y <= endrow; y++) { //start row plus one to skip the header
////				drow = _dataTable.NewRow();
////				for (x = startcol; x <= endcol; x++) {
////					tmpString = _excelDataTable.WorkSheet.Cells[y, x].Text;
////					drow[x - startcol] = tmpString.Trim();
////				}
////				_dataTable.Rows.Add(drow);
////			}			
//			return new DataTable();
//		}
//		
//		private void executeComparison(
//			DataTable UpdatedTable, 
//			DataTable PreviousTable)
//		{
//			//Parallel-For compare has to implement
//			//Populate the object variable for final result
//			//No return value
//		}
//		
//		private void populateDeletedRowsToResult(
//			Dictionary<string,int> PreviousDataViewIndex, 
//			DataView PreviousDataView)
//		{
//			//the result datatable must be initialized before populate the deleted rows
//		}
//		
//		private void populateNewDataTableToResult(
//			Dictionary<string,int> UpdatedDataViewIndex,
//			DataTable UpdatedTable,
//			DataView PreviousDataView)
//		{
//			
//		}
//		
//		public void OutputResultFile(string FileNameFullPath)
//		{
////			worksheetDifference wksd = 
////				new worksheetDifference(_updatedWorkSheets[0]., _previousWorkSheets[0]);
//			worksheetDifference wksd = new worksheetDifference(_updatedWorkSheets[0], _previousWorkSheets[0]);
//			
//			string filename = FileNameFullPath;
//			if (File.Exists(filename)) {
//				File.Delete(filename);
//			}
//			var newFile = new FileInfo(filename);
//			using (ExcelPackage xlPackage = new ExcelPackage(newFile)) {                       
//				// do work here   
//				ExcelWorksheet sht; //= xlPackage.Workbook.Worksheets["output"];
////				if (sht == null)
//				sht = xlPackage.Workbook.Worksheets.Add("comparison result");
//				foreach (worksheetDifference.CellStatus cellstatus in wksd.ResultDataTableCellStatus) {
//					sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Value = cellstatus.UpdatedText;
//					//ExcelComment cmt = sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Comment;
//					//if (cmt != null)
//					//	sht.Comments.Remove(cmt);
//					string author;
//					switch (cellstatus.Status) {
//						case worksheetDifference.DataStatus.New:
//							author = "new";
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Value = cellstatus.UpdatedText;
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Style.Fill.PatternType = ExcelFillStyle.Solid;
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
//							//sht.Cells[cellstatus.RowNumber,cellstatus.ColumnNumber].AddComment(cellstatus.PreviousText + " > " + cellstatus.UpdatedText, author);
//							break;
//						case worksheetDifference.DataStatus.Unchange:
//							author = "unchange";
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Value = cellstatus.UpdatedText;
//							break;
//						case worksheetDifference.DataStatus.Update:
//							author = "update";
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Value = cellstatus.UpdatedText;
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].AddComment("Updated\nOld : " + cellstatus.PreviousText + "\nNew : " + cellstatus.UpdatedText, author);
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Style.Fill.PatternType = ExcelFillStyle.Solid;
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
//							break;
//						case worksheetDifference.DataStatus.Delete:
//							author = "delete";
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Value = cellstatus.PreviousText;
//							//sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].AddComment("Deleted\nOld : " + cellstatus.PreviousText + "\nNew : " + cellstatus.UpdatedText, author);
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Style.Fill.PatternType = ExcelFillStyle.Solid;
//							sht.Cells[cellstatus.RowNumber, cellstatus.ColumnNumber].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
//							break;
//					}
//					
//				}
//				xlPackage.Workbook.Properties.Author = "梁瑞元(Liang)";
//				xlPackage.Workbook.Properties.Title = "xlsxcomp";
//				xlPackage.Workbook.Properties.Subject = "Excel comparison";
//				xlPackage.Save();
//			}
//
//			
//			Console.WriteLine("Updated worksheet key column : " + wksd.UpdatedWorksheet.KeyColumn);
//			Console.WriteLine("Previous worksheet key column : " + wksd.PreviousWorksheet.KeyColumn);
//		}
//		
//		public void LoadWorkbook(string UpdatedFileFullPath,
//			string PreviousFileFullPath)
//		{
//			this.UpdatedFileFullPath = UpdatedFileFullPath;
//			this.PreviousFileFullPath = PreviousFileFullPath;
//			LoadWorkbook();
//		}
//		
//		public void LoadWorkbook()
//		{
//			Console.WriteLine("Start loading filestream: {0}", 
//				DateTime.Now.ToString("hh:mm:ss.fff")); 
//			_updatedFilestream = new FileStream(this.UpdatedFileFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//			_updatedExcelPackage = new ExcelPackage(_updatedFilestream);
//			_previousFilestream = new FileStream(this.PreviousFileFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//			_previousExcelPackage = new ExcelPackage(_previousFilestream);
//			Console.WriteLine("Start initilize excel package: {0}", 
//				DateTime.Now.ToString("hh:mm:ss.fff")); 
//			_updatedWorkSheets = new List<worksheetInfo>();
//			_previousWorkSheets = new List<worksheetInfo>();
//			
//			foreach (ExcelWorksheet wks in _updatedExcelPackage.Workbook.Worksheets) {
//				Console.WriteLine("Initilize worksheetInfo: {0}", 
//					DateTime.Now.ToString("hh:mm:ss.fff")); 
//				worksheetInfo wksInfo = new worksheetInfo(wks);
//				Console.WriteLine("Copy worksheetInfo to worksheets collection: {0}", 
//					DateTime.Now.ToString("hh:mm:ss.fff")); 				
//				_updatedWorkSheets.Add(wksInfo);
//				Console.WriteLine(wks.Name);
//				Console.WriteLine("System End Row:" + wksInfo.SystemEndRow);
//				Console.WriteLine("System End Column:" + wksInfo.SystemEndColumn);
//				Console.WriteLine("True End Row:" + wksInfo.TrueEndRow);
//				Console.WriteLine("True End Column:" + wksInfo.TrueEndColumn);
//				Console.WriteLine("Date and Time with Milliseconds: {0}", 
//					DateTime.Now.ToString("hh:mm:ss.fff")); 
//			}
//			foreach (ExcelWorksheet wks in _previousExcelPackage.Workbook.Worksheets) {
//				Console.WriteLine("Initilize worksheetInfo: {0}", 
//					DateTime.Now.ToString("hh:mm:ss.fff")); 
//				worksheetInfo wksInfo = new worksheetInfo(wks);
//				Console.WriteLine("Copy worksheetInfo to worksheets collection: {0}", 
//					DateTime.Now.ToString("hh:mm:ss.fff")); 				
//				_previousWorkSheets.Add(wksInfo);
//				Console.WriteLine(wks.Name);
//				Console.WriteLine("System End Row:" + wksInfo.SystemEndRow);
//				Console.WriteLine("System End Column:" + wksInfo.SystemEndColumn);
//				Console.WriteLine("True End Row:" + wksInfo.TrueEndRow);
//				Console.WriteLine("True End Column:" + wksInfo.TrueEndColumn);
//				Console.WriteLine("Date and Time with Milliseconds: {0}", 
//					DateTime.Now.ToString("hh:mm:ss.fff")); 
//			}			
//		}
//		
//		public void ReleaseResource()
//		{
//			if (_updatedFilestream != null)
//				_updatedFilestream.Close();
//			if (_previousFilestream != null)
//				_previousFilestream.Close();
//		}
//	}
//	
//	[Serializable()]
//	public class InvalidKeyColumn : System.Exception
//	{
//		public InvalidKeyColumn()
//			: base()
//		{
//		}
//		public InvalidKeyColumn(string message)
//			: base(message)
//		{
//		}
//		public InvalidKeyColumn(string message, System.Exception inner)
//			: base(message, inner)
//		{
//		}
//	
//		// A constructor is needed for serialization when an
//		// exception propagates from a remoting server to the client.
//		protected InvalidKeyColumn(System.Runtime.Serialization.SerializationInfo info,
//			System.Runtime.Serialization.StreamingContext context)
//		{
//		}
//	}
//}
