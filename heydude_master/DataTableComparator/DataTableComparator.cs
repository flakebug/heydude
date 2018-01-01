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
			_cellMappingCollection = CalculateTargetRowAndColumn(_cellMappingCollection);
		}
		public List<DataTableCellMappingDefinition> CalculateTargetRowAndColumn(List<DataTableCellMappingDefinition> CellMapping)
		{
			List<DataTableCellMappingDefinition> resultCellMapping = new List<DataTableCellMappingDefinition>();
			HashSet<int> deletedColumnIndexList = new HashSet<int>();
			HashSet<int> deletedRowIndexList = new HashSet<int>();
			foreach (DataTableCellMappingDefinition mapItem in CellMapping) {
				if (mapItem.Status == MappingStatusDefinition.Delete) {
					if (mapItem.SlaveCell.ColumnIndex == _slaveDataTableInfo.KeyColumnIndex)
						deletedColumnIndexList.Add(mapItem.SlaveCell.ColumnIndex);
					if (mapItem.SlaveCell.RowIndex == _slaveDataTableInfo.KeyRowIndex)					
						deletedRowIndexList.Add(mapItem.SlaveCell.RowIndex);
				}
			}
			return resultCellMapping;
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
						DataTableCellMappingDefinition cellMap;
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
								slaveCell = getNullCellDef();
								cellMap.Status = MappingStatusDefinition.New;
							}
						} else {
							//master cell is not indexed
							slaveCell = getNullCellDef();
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
						DataTableCellMappingDefinition cellMap;
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
								masterCell = getNullCellDef();
								cellMap.Status = MappingStatusDefinition.Delete;
							}
						} else {
							//slave cell indexed
							masterCell = getNullCellDef();
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
			
			
			return resultCellMapping;
		}
		
		private DataTableCellDefinition getNullCellDef()
		{
			DataTableCellDefinition cell;
			cell.RowIndex = -1;
			cell.ColumnIndex = -1;
			cell.Indexed = false;
			cell.DataRow = null;
			return cell;
		}
		
		
	}
}
