/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/30
 * Time: 上午 11:0
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace ryliang.Excel
{
	
	public class CellPropertyDef
	{
		public int RowIndex;
		public int ColumnIndex;
		public string Comment;
		public System.Drawing.Color FontColor;
		public System.Drawing.Color BackgroundColor;
		public CellPropertyDef(int RowIndex, int ColumnIndex)
		{
			this.RowIndex = RowIndex;
			this.ColumnIndex = ColumnIndex;
		}
	}
	public class DataTablePropertyDef
	{
		public DataTable DataTable;
		public CellPropertyDef CellProperty;
		public DataTablePropertyDef(DataTable DataTable, CellPropertyDef CellProperty)
		{
			this.DataTable = DataTable;
			this.CellProperty = CellProperty;
		}
	}

	/// <summary>
	/// Handling the excel object
	/// </summary>
	public class ExcelOperator
	{
		private string _excelFilename;
		private DataSet _excelDataSet;
		private List<string> _worksheetNames;
		public List<DataTablePropertyDef> DataTablePropertyCollection;
		public List<string> WorksheetNames {
			get { return _worksheetNames; }
		}
		public DataSet ExcelDataSet
		{
			get { return _excelDataSet; }
		}
		public ExcelOperator()
		{
			
		}
		public ExcelOperator(string Filename)
		{
			_excelFilename = Filename;
			LoadWorkbook();
		}
		public DataSet LoadWorkbook()
		{
			DataSet ds = LoadWorkbook(_excelFilename);
			return ds;
		}
		public DataSet LoadWorkbook(string Filename)
		{
			_excelFilename = Filename;
			_worksheetNames = new List<string>();
			DataSet ds = new DataSet();
			FileStream _excelFileStream;
			ExcelPackage _excelPackage;			
			_excelFileStream = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			_excelPackage = new ExcelPackage(_excelFileStream);
			for (int worksheetIndex = 1; 
			    	worksheetIndex <= _excelPackage.Workbook.Worksheets.Count; 
			    	worksheetIndex++) {
				ExcelWorksheet worksheet = _excelPackage.Workbook.Worksheets[worksheetIndex];
				_worksheetNames.Add(worksheet.Name);
				int rowLimit;
				int columnLimit;
				if (worksheet.Dimension == null) {
					rowLimit = 0;
					columnLimit = 0;
				} else {
					rowLimit = worksheet.Dimension.End.Row;
					columnLimit = worksheet.Dimension.End.Column;
				}

				DataTable dt = new DataTable();
				dt.TableName = worksheet.Name;
				
				//Initialize columns
				for (int colIndex = 0; colIndex < columnLimit; colIndex++) {
					dt.Columns.Add((colIndex + 1).ToString(), typeof(string));
				}
				//Initialize rows
				Parallel.For(0, rowLimit, (int rowIndex) => {
					DataRow dr = dt.NewRow();
					lock (dt) {
						dt.Rows.Add(dr);
					}
				});
				//Copy data from excel to datatable / dataset
				Parallel.For(0, rowLimit, (int rowIndex) => {
					DataRow dr = dt.Rows[rowIndex];
					for (int colIndex = 0; colIndex < columnLimit; colIndex++) {
						lock (dt) {
							dr[colIndex] = worksheet.Cells[rowIndex + 1, colIndex + 1].Text;
						}
					}	
				});
				ds.Tables.Add(dt);
			}
			_excelDataSet = ds;
			return ds;
		}
		public void SaveWorkbook(DataSet ExcelDataSet, string Filename)
		{
			if (File.Exists(Filename))
				File.Delete(Filename);
			FileInfo newFile = new FileInfo(Filename);
			ExcelPackage _excelPackage;	
			_excelPackage = new ExcelPackage(newFile);
			
			for (int tableIndex = 0;
			     tableIndex < ExcelDataSet.Tables.Count;
			     tableIndex++) {
				DataTable dt = ExcelDataSet.Tables[tableIndex];
				ExcelWorksheet worksheet = _excelPackage.Workbook.Worksheets.Add(ExcelDataSet.Tables[tableIndex].TableName);
				Parallel.For(0, dt.Rows.Count, (int rowIndex) => {
					for (int columnIndex = 0;
				         columnIndex < dt.Columns.Count;
				         columnIndex++) {
						lock (worksheet) {
							worksheet.Cells[rowIndex + 1, columnIndex + 1].Value = dt.Rows[rowIndex][columnIndex];
						}
					}
				});
			}
			_excelPackage.Save();
		}
		public void SaveWorkbook(DataTable DataTable, List<CellPropertyDef> CellPropertyCollection, string Filename)
		{
			if (File.Exists(Filename))
				File.Delete(Filename);
			FileInfo newFile = new FileInfo(Filename);
			ExcelPackage _excelPackage;	
			_excelPackage = new ExcelPackage(newFile);
			
//			for (int tableIndex = 0;
//			     tableIndex < DataTablePropertyCollection.Count;
//			     tableIndex++) {
			ExcelWorksheet worksheet = _excelPackage.Workbook.Worksheets.Add(DataTable.TableName);

			Object thisLock = new Object();
			Parallel.ForEach(CellPropertyCollection, (CellPropertyDef propItem) => {
				lock (thisLock) {
					worksheet.Cells[propItem.RowIndex + 1, propItem.ColumnIndex + 1].Value = DataTable.Rows[propItem.RowIndex][propItem.ColumnIndex];
				}
				if (!propItem.BackgroundColor.IsEmpty) {
					lock (thisLock) {
						worksheet.Cells[propItem.RowIndex + 1, propItem.ColumnIndex + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
						worksheet.Cells[propItem.RowIndex + 1, propItem.ColumnIndex + 1].Style.Fill.BackgroundColor.SetColor(propItem.BackgroundColor);
					}
				}
				if (propItem.Comment != null) {
					lock (thisLock) {
//						ExcelComment cmt = worksheet.Cells[propItem.RowIndex + 1, propItem.ColumnIndex + 1].Comment;
//						if (cmt != null)
//							worksheet.Comments.Remove(cmt);			                 			
						worksheet.Cells[propItem.RowIndex + 1, propItem.ColumnIndex + 1].AddComment(propItem.Comment, "ryliang");
					}
				}
			});
//			}

			_excelPackage.Save();
		}
		//		public void SaveWorkbook(Workbook ExcelInterfaceObject, string Filename)
		//		{
		//			if (File.Exists(Filename))
		//				File.Delete(Filename);
		//			FileInfo newFile = new FileInfo(Filename);
		//			ExcelPackage eppPackage;
		//			eppPackage = new ExcelPackage(newFile);
		//
		//			for (int tableIndex = 0;
		//			     tableIndex < ExcelInterfaceObject.Worksheets.Count;
		//			     tableIndex++) {
		//				Worksheet worksheet = ExcelInterfaceObject.Worksheets[tableIndex];
		//				ExcelWorksheet eppWorksheet = eppPackage.Workbook.Worksheets.Add(worksheet.Name);
		//				Parallel.For(0, worksheet.Rows.Count, (int rowIndex) => {
		//					for (int columnIndex = 0;
		//				         columnIndex < worksheet.Rows[rowIndex].Columns.Count;
		//				         columnIndex++) {
		//						lock (eppWorksheet) {
		//							eppWorksheet.Cells[rowIndex + 1, columnIndex + 1].Value = worksheet.Rows[rowIndex].Columns[columnIndex].Text;
		//						}
		//					}
		//				});
		//			}
		//			eppPackage.Save();
		//		}
	}
}