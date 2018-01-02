/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/31
 * Time: 下午 01:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ryliang.Excel;

namespace ryliang.DataTableComparator
{
	/// <summary>
	/// Description of DataTableComparator.
	/// </summary>
	public class DataTableComparator
	{
		private DataTableInfo _masterDataTableInfo;
		private DataTableInfo _slaveDataTableInfo;
		private List<DataTableCellMappingDefinition> _cellMappingCollection;
		private ComparisonMethodDefinition _comparisonMethod;
		private int _cellMappingRowCount;
		private int _cellMappingColumnCount;
		
		public DataTableInfo MasterDataTableInfo {
			get { return _masterDataTableInfo; }
			set { _masterDataTableInfo = value; }
		}
		public DataTableInfo SlaveDataTableInfo {
			get { return _slaveDataTableInfo; }
			set { _slaveDataTableInfo = value; }
		}
		public List<DataTableCellMappingDefinition> CellMappingCollection {
			get { return _cellMappingCollection; }
		}
		public ComparisonMethodDefinition ComparisonMethod {
			get { return _comparisonMethod; }
			set { _comparisonMethod = value; }
		}
		public int CellMappingRowCount 
		{
			get {return _cellMappingRowCount; }
		}
		public int CellMappingColumnCount 
		{
			get {return _cellMappingColumnCount; }
		}		
		
		public DataTableComparator(DataTable MasterDataTable, DataTable SlaveDataTable)
		{
			_masterDataTableInfo = new DataTableInfo(MasterDataTable);
			_slaveDataTableInfo = new DataTableInfo(SlaveDataTable);
		}
		
		public void Compare()
		{
			_masterDataTableInfo.InitializeDataTableInfo();
			_slaveDataTableInfo.InitializeDataTableInfo();
			_cellMappingCollection = CreateCellMapping(_masterDataTableInfo, _slaveDataTableInfo);
		}
		private List<DataTableCellMappingDefinition> calculateTargetRowAndColumn(List<DataTableCellMappingDefinition> CellMapping)
		{
			//List<DataTableCellMappingDefinition> resultCellMapping;
			
			//Find all the row and column index in both master and slave(deleted) table 
			HashSet<int> deletedColumnIndexList = new HashSet<int>();
			HashSet<int> deletedRowIndexList = new HashSet<int>();
			HashSet<int> masterColumnIndexList = new HashSet<int>();
			HashSet<int> masterRowIndexList = new HashSet<int>();			
			foreach (DataTableCellMappingDefinition mapItem in CellMapping) {
				if (mapItem.Status == MappingStatusDefinition.Delete) {
					if (mapItem.SlaveCell.ColumnIndex == _slaveDataTableInfo.KeyColumnIndex)
						deletedRowIndexList.Add(mapItem.SlaveCell.RowIndex);
					if (mapItem.SlaveCell.RowIndex == _slaveDataTableInfo.KeyRowIndex)
						deletedColumnIndexList.Add(mapItem.SlaveCell.ColumnIndex);
				} else {
					if (mapItem.MasterCell.ColumnIndex == _masterDataTableInfo.KeyColumnIndex)
						masterRowIndexList.Add(mapItem.MasterCell.RowIndex);
					if (mapItem.MasterCell.RowIndex == _masterDataTableInfo.KeyRowIndex)
						masterColumnIndexList.Add(mapItem.MasterCell.ColumnIndex);					
				}
			}
			int[] deletedRowIndexListArray = deletedRowIndexList.ToArray();
			Array.Sort(deletedRowIndexListArray);
			int[] deletedColumnIndexListArray = deletedColumnIndexList.ToArray();
			Array.Sort(deletedColumnIndexListArray);			
			int[] masterRowIndexListArray = masterRowIndexList.ToArray();
			Array.Sort(masterRowIndexListArray);
			int[] masterColumnIndexListArray = masterColumnIndexList.ToArray();
			Array.Sort(masterColumnIndexListArray);			
			Dictionary<int, int> deletedTargetRowMapping = new Dictionary<int, int>();
			Dictionary<int, int> deletedTargetColumnMapping = new Dictionary<int, int>();
			Dictionary<int, int> masterTargetRowMapping = new Dictionary<int, int>();
			Dictionary<int, int> masterTargetColumnMapping = new Dictionary<int, int>();
			
			for (int index = 0;
			     index < deletedRowIndexListArray.Count();
			     index++) {
				deletedTargetRowMapping.Add(deletedRowIndexListArray[index], index);
			}
			for (int index = 0;
			     index < masterRowIndexListArray.Count();
			     index++) {
				masterTargetRowMapping.Add(masterRowIndexListArray[index], index + deletedTargetRowMapping.Count());
			}			
			for (int index = 0;
			     index < deletedColumnIndexListArray.Count();
			     index++) {
				deletedTargetColumnMapping.Add(deletedColumnIndexListArray[index], index);
			}
			for (int index = 0;
			     index < masterColumnIndexListArray.Count();
			     index++) {
				masterTargetColumnMapping.Add(masterColumnIndexListArray[index], index + deletedTargetColumnMapping.Count());
			}					
			_cellMappingRowCount = deletedTargetRowMapping.Count() + masterTargetRowMapping.Count();
			_cellMappingColumnCount = deletedTargetColumnMapping.Count() + masterTargetColumnMapping.Count();
//
//			foreach (DataTableCellMappingDefinition item in CellMapping) {
//				if (item.Status == MappingStatusDefinition.Delete){
//				Console.Write("|T|R" + item.TargetRowIndex);
//				Console.Write("C" + item.TargetColumnIndex);					
//				Console.Write("|S|R" + item.SlaveCell.RowIndex);
//				Console.Write("C" + item.SlaveCell.ColumnIndex);
//				Console.Write("|Index:" + item.SlaveCell.Indexed);
//				Console.Write("|Status:" + item.Status.ToString());
//				Console.Write("|Content:" + item.SlaveCell.DataRow[item.SlaveCell.ColumnIndex]);
//				Console.WriteLine();	
//				}
//			}
			
			for (int index = 0;
			     index < CellMapping.Count;
			     index++) {
				DataTableCellMappingDefinition item = CellMapping[index];
				if (item.Status == MappingStatusDefinition.Delete) {
					if (deletedTargetRowMapping.ContainsKey(item.SlaveCell.RowIndex))
						item.TargetRowIndex = deletedTargetRowMapping[item.SlaveCell.RowIndex];
					else
						item.TargetRowIndex = item.SlaveCell.RowIndex + deletedTargetRowMapping.Count();
					if (deletedTargetColumnMapping.ContainsKey(item.SlaveCell.ColumnIndex))
						item.TargetColumnIndex = deletedTargetColumnMapping[item.SlaveCell.ColumnIndex];
					else
						item.TargetColumnIndex = item.SlaveCell.ColumnIndex + deletedTargetColumnMapping.Count();
				} else {
					item.TargetRowIndex = masterTargetRowMapping[item.MasterCell.RowIndex];
					item.TargetColumnIndex = masterTargetColumnMapping[item.MasterCell.ColumnIndex];

				}
			}


			//resultCellMapping = CellMapping;
			return CellMapping;
		}
		
		public List<DataTableCellMappingDefinition> CreateCellMapping(DataTableInfo MasterDataTableInfo, DataTableInfo SlaveDataTableInfo)
		{
			List<DataTableCellMappingDefinition> resultCellMapping = new List<DataTableCellMappingDefinition>();
			
			//Handling for MasterDataTableInfo
			Parallel.For(0, 
				MasterDataTableInfo.PayloadDataTable.Rows.Count, 
				(int rowIndex) => {
					for (int columnIndex = 0;
			             columnIndex < MasterDataTableInfo.PayloadDataTable.Columns.Count;
			             columnIndex++) {
						DataTableCellMappingDefinition cellMap = new DataTableCellMappingDefinition();
						DataTableCellDefinition masterCell;
						masterCell = MasterDataTableInfo.GetCell(rowIndex, columnIndex);
						DataTableCellDefinition slaveCell;
						if (masterCell.Indexed) {
							//master cell indexed
							string masterRowName = MasterDataTableInfo.IndexedRowSetByNumber[rowIndex];
							string masterColumnName = MasterDataTableInfo.IndexedColumnSetByNumber[columnIndex];
							if (SlaveDataTableInfo.IndexedRowSetByName.ContainsKey(masterRowName) &&
							    SlaveDataTableInfo.IndexedColumnSetByName.ContainsKey(masterColumnName)) {
								int slaveRowIndex = SlaveDataTableInfo.IndexedRowSetByName[masterRowName];
								int slaveColumnIndex = SlaveDataTableInfo.IndexedColumnSetByName[masterColumnName];	
								slaveCell = SlaveDataTableInfo.GetCell(slaveRowIndex, slaveColumnIndex);
								if (masterCell.DataRow[columnIndex].ToString() == slaveCell.DataRow[slaveColumnIndex].ToString()) {
									cellMap.Status = MappingStatusDefinition.Unchange;
								} else {
									cellMap.Status = MappingStatusDefinition.Update;
								}
							} else {
								slaveCell = null;
								cellMap.Status = MappingStatusDefinition.New;
							}
						} else {
							//master cell is not indexed
							slaveCell = null;
							cellMap.Status = MappingStatusDefinition.Unknown;
						}
						cellMap.TargetRowIndex = -1;
						cellMap.TargetColumnIndex = -1;
						cellMap.MasterCell = masterCell;
						cellMap.SlaveCell = slaveCell;

						lock (resultCellMapping) {
							resultCellMapping.Add(cellMap);
						}
					}
				});
			
			//Handling for SlaveDataTableInfo
			Parallel.For(0, 
				SlaveDataTableInfo.PayloadDataTable.Rows.Count, 
				(int rowIndex) => {
					for (int columnIndex = 0;
			             columnIndex < SlaveDataTableInfo.PayloadDataTable.Columns.Count;
			             columnIndex++) {
						DataTableCellMappingDefinition cellMap = new DataTableCellMappingDefinition();
						DataTableCellDefinition slaveCell;
						slaveCell = SlaveDataTableInfo.GetCell(rowIndex, columnIndex);
						DataTableCellDefinition masterCell;
						if (slaveCell.Indexed) {
							//slave cell indexed
							string slaveRowName = SlaveDataTableInfo.IndexedRowSetByNumber[rowIndex];
							string slaveColumnName = SlaveDataTableInfo.IndexedColumnSetByNumber[columnIndex];
							if (MasterDataTableInfo.IndexedRowSetByName.ContainsKey(slaveRowName) &&
							    MasterDataTableInfo.IndexedColumnSetByName.ContainsKey(slaveColumnName)) {
								int masterRowIndex = MasterDataTableInfo.IndexedRowSetByName[slaveRowName];
								int masterColumnIndex = MasterDataTableInfo.IndexedColumnSetByName[slaveColumnName];	
								masterCell = MasterDataTableInfo.GetCell(masterRowIndex, masterColumnIndex);
								if (slaveCell.DataRow[columnIndex].ToString() == masterCell.DataRow[masterColumnIndex].ToString()) {
									cellMap.Status = MappingStatusDefinition.Unchange;
								} else {
									cellMap.Status = MappingStatusDefinition.Update;
								}
							} else {
								masterCell = null;
								cellMap.Status = MappingStatusDefinition.Delete;
							}
						} else {
							//slave cell indexed
							masterCell = null;
							cellMap.Status = MappingStatusDefinition.Unknown;
						}
						cellMap.TargetRowIndex = -1;
						cellMap.TargetColumnIndex = -1;
						cellMap.MasterCell = masterCell;
						cellMap.SlaveCell = slaveCell;

						lock (resultCellMapping) {
							if (cellMap.Status == MappingStatusDefinition.Delete)
								resultCellMapping.Add(cellMap);
						}
					}
				});
			
			resultCellMapping = calculateTargetRowAndColumn(resultCellMapping);
			return resultCellMapping;
		}
		
		//		private DataTableCellDefinition getNullCellDef()
		//		{
		//			DataTableCellDefinition cell = new DataTableCellDefinition();
		//			cell.RowIndex = -1;
		//			cell.ColumnIndex = -1;
		//			cell.Indexed = false;
		//			cell.DataRow = null;
		//			return cell;
		//		}
		
		
	}
}
