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

namespace ryliang.DataTableComparator
{
	/// <summary>
	/// Description of DataTableComparator.
	/// </summary>
	public class DataTableComparator
	{
		private DataTableInfo _masterDataTableInfo;
		private DataTableInfo _slaveDataTableInfo;
		private List<CellMappingDefinition> _cellMapping;
		
		public DataTableInfo MasterDataTableInfo {
			get { return _masterDataTableInfo; }
			set { _masterDataTableInfo = value; }
		}
		public DataTableInfo SlaveDataTableInfo {
			get { return _slaveDataTableInfo; }
			set { _slaveDataTableInfo = value; }
		}
		
		public DataTableComparator(DataTable MasterDataTable, DataTable SlaveDataTable)
		{
			_masterDataTableInfo = new DataTableInfo(MasterDataTable);
			_masterDataTableInfo.InitializeDataTableInfo();
			_slaveDataTableInfo = new DataTableInfo(SlaveDataTable);
			_slaveDataTableInfo.InitializeDataTableInfo();
			CreateCellMapping(_masterDataTableInfo, _slaveDataTableInfo);
		}
		
		public List<CellMappingDefinition> CreateCellMapping(DataTableInfo MasterDataTableInfo, DataTableInfo SlaveDataTableInfo)
		{
			List<CellMappingDefinition> resultCellMapping = new List<CellMappingDefinition>();
			Parallel.For(0, 
				MasterDataTableInfo.PayloadDataTable.Rows.Count, 
				(int rowIndex) => {
					for (int columnIndex = 0;
			             columnIndex < MasterDataTableInfo.PayloadDataTable.Columns.Count;
			             columnIndex++) {
						CellMappingDefinition cellMap;
						CellDefinition masterCell;
						masterCell = MasterDataTableInfo.GetCell(rowIndex, columnIndex);
						CellDefinition slaveCell;
						if (masterCell.Indexed) {
							//master cell indexed
							string masterRowName = MasterDataTableInfo.IndexedRowSetByNumber[rowIndex];
							string masterColumnName = MasterDataTableInfo.IndexedColumnSetByNumber[columnIndex];
							if (SlaveDataTableInfo.IndexedRowSetByName.ContainsKey(masterRowName) &&
							    SlaveDataTableInfo.IndexedColumnSetByName.ContainsKey(masterColumnName)) {
								int slaveRowIndex = SlaveDataTableInfo.IndexedRowSetByName[masterRowName];
								int slaveColumnIndex = SlaveDataTableInfo.IndexedColumnSetByName[masterColumnName];	
								slaveCell = SlaveDataTableInfo.GetCell(slaveRowIndex, slaveColumnIndex);
							} else {
								slaveCell = getNullCellDef();
							}

							//cellMap.Status = 

							//slaveCell = SlaveDataTableInfo.GetCell(
						} else {
							//master cell is not indexed
							slaveCell = getNullCellDef();
							
						}
						cellMap.MasterCell = masterCell;
						cellMap.SlaveCell = slaveCell;
						cellMap.Status
					}
				});
			return resultCellMapping;
		}
		
		private CellDefinition getNullCellDef()
		{
			CellDefinition cell;
			cell.RowIndex = -1;
			cell.ColumnIndex = -1;
			cell.Indexed = false;
			cell.Text = null;
			return cell;
		}
	}
}
