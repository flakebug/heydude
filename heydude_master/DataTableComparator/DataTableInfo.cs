/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/30
 * Time: 上午 09:17
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
	/// The meta information of the DataTable
	/// </summary>
	public class DataTableInfo
	{
		private DataTable _payloadTable;
		private int _keyRowIndex;
		private int _keyColumnIndex;
		private Dictionary<string, List<int>> _keyRowIndexList;
		private Dictionary<string, List<int>> _keyColumnIndexList;
		private Dictionary<int, string> _indexedRowSetByNumber;
		private Dictionary<int, string> _indexedColumnSetByNumber;
		private Dictionary<string, int> _indexedRowSetByName;
		private Dictionary<string, int> _indexedColumnSetByName;
		private bool _autoKeyIndex;
		
		public int KeyRowIndex {
			get { return _keyRowIndex; }
			set { _keyRowIndex = value; }
		}

		public int KeyColumnIndex {
			get { return _keyColumnIndex; }
			set { _keyColumnIndex = value; }
		}
		
		public DataTable PayloadDataTable {
			get { return _payloadTable; }
			set { _payloadTable = value; }
		}
		public bool AutoKeyIndex
		{
			get { return _autoKeyIndex; }
			set { _autoKeyIndex = value; }
		}

		public Dictionary<int, string> IndexedRowSetByNumber
		{
			get { return _indexedRowSetByNumber; }
		}
		
		public Dictionary<int, string> IndexedColumnSetByNumber
		{
			get { return _indexedColumnSetByNumber; }
		}
		public Dictionary<string, int> IndexedRowSetByName
		{
			get { return _indexedRowSetByName; }
		}
		
		public Dictionary<string, int> IndexedColumnSetByName
		{
			get { return _indexedColumnSetByName; }
		}		
		public DataTableInfo(DataTable PayloadDataTable)
		{
			_payloadTable = PayloadDataTable;
		}
		
		public void InitializeDataTableInfo()
		{
			if(_autoKeyIndex) {
				_keyRowIndex = findKeyRowIndex();
				_keyColumnIndex = findKeyColumnIndex();
			}
			_keyRowIndexList = getKeyRowIndexList();
			_keyColumnIndexList = getKeyColumnIndexList();
			_indexedColumnSetByNumber = getIndexedColumnSetByNumber();
			_indexedRowSetByNumber = getIndexedRowSetByNumber();
			_indexedColumnSetByName = getIndexedColumnSetByName();
			_indexedRowSetByName = getIndexedRowSetByName();
		}
		
		public List<DataTableCellDefinition> GetCell(string KeyRowName, string KeyColumnName)
		{
			List<DataTableCellDefinition> result = new List<DataTableCellDefinition>();
			foreach (int columnIndex in _keyRowIndexList[KeyRowName]) {	//columnIndex in keyRow(or header)
				foreach (int rowIndex in _keyColumnIndexList[KeyColumnName]) {	//rowIndex in keyColum(the index key)
					DataTableCellDefinition cell;
					cell.RowIndex = rowIndex;
					cell.ColumnIndex = columnIndex;
					cell.Indexed = getCellIndexStatus(rowIndex, columnIndex);
					cell.DataRow = _payloadTable.Rows[rowIndex];
					result.Add(cell);
				}
			}
			return result;
		}
		
		public DataTableCellDefinition GetCell(int RowIndex, int ColumnIndex)
		{
			DataTableCellDefinition cell;
			cell.RowIndex = RowIndex;
			cell.ColumnIndex = ColumnIndex;
			cell.Indexed = getCellIndexStatus(RowIndex, ColumnIndex);
			cell.DataRow = _payloadTable.Rows[RowIndex];			
			return cell;
		}
		
		private bool getCellIndexStatus(int RowIndex, int ColumnIndex)
		{
			if (_indexedColumnSetByNumber.ContainsKey(ColumnIndex))
			if (_indexedRowSetByNumber.ContainsKey(RowIndex))
				return true;
			return false;
		}
		
		private int findKeyRowIndex()
		{
			Dictionary<int, HashSet<string>> rowInfo = new Dictionary<int, HashSet<string>>();
			Parallel.For(0, _payloadTable.Rows.Count, (int rowIndex) => {
				HashSet<string> colSet = new HashSet<string>();
				for (int colIndex = 0;
				     colIndex < _payloadTable.Columns.Count;
				     colIndex++) {
					colSet.Add(_payloadTable.Rows[rowIndex][colIndex].ToString().Trim());
				}
				lock (rowInfo) {
					rowInfo.Add(rowIndex, colSet);
				}
			});
			
			int maxColCount = 0;
			int maxIndex = 0;
			for (int rowIndex = 0;
			     rowIndex < _payloadTable.Rows.Count;
			     rowIndex++) {
				if (maxColCount < rowInfo[rowIndex].Count) {
					maxColCount = rowInfo[rowIndex].Count;
					maxIndex = rowIndex;
				}				
			}
			return maxIndex;
		}
		
		private int findKeyColumnIndex()
		{
			Dictionary<int, HashSet<string>> columnInfo = new Dictionary<int, HashSet<string>>();
			Parallel.For(0, _payloadTable.Columns.Count, (int columnIndex) => {
				HashSet<string> rowSet = new HashSet<string>();
				for (int rowIndex = 0;
				     rowIndex < _payloadTable.Rows.Count;
				     rowIndex++) {
					rowSet.Add(_payloadTable.Rows[rowIndex][columnIndex].ToString().Trim());
				}
				lock (columnInfo) {
					columnInfo.Add(columnIndex, rowSet);
				}
			});
			
			int maxRowCount = 0;
			int maxIndex = 0;
			for (int columnIndex = 0;
			     columnIndex < _payloadTable.Columns.Count;
			     columnIndex++) {
				if (maxRowCount < columnInfo[columnIndex].Count) {
					maxRowCount = columnInfo[columnIndex].Count;
					maxIndex = columnIndex;
				}				
			}
			return maxIndex;
		}
		
		private Dictionary<string, List<int>> getKeyRowIndexList()
		{
			Dictionary<string, List<int>> rowList = new Dictionary<string, List<int>>();
			for (int columnIndex = 0;
			     columnIndex < _payloadTable.Columns.Count;
			     columnIndex++) {
				string content = _payloadTable.Rows[_keyRowIndex][columnIndex].ToString();
				if (!rowList.ContainsKey(content)) {
					rowList.Add(content, new List<int>());
				}
				rowList[content].Add(columnIndex);
			}
			return rowList;
		}

		private Dictionary<string, List<int>> getKeyColumnIndexList()
		{
			Dictionary<string, List<int>> columnList = new Dictionary<string, List<int>>();
			for (int rowIndex = 0;
			     rowIndex < _payloadTable.Rows.Count;
			     rowIndex++) {
				string content = _payloadTable.Rows[rowIndex][_keyColumnIndex].ToString();
				if (!columnList.ContainsKey(content)) {
					columnList.Add(content, new List<int>());
				}
				columnList[content].Add(rowIndex);
			}
			return columnList;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns>Return the indexed column number of the header row</returns>
		private Dictionary<int, string> getIndexedColumnSetByNumber()
		{
			Dictionary<int, string> result = new Dictionary<int, string>();
			foreach (KeyValuePair<string, List<int>> item in _keyRowIndexList) {
				if (item.Value.Count == 1)
					result.Add(item.Value[0], item.Key);
			}
			return result;		
		}
		private Dictionary<string, int> getIndexedColumnSetByName()
		{
			Dictionary<string, int> result = new Dictionary<string, int>();
			foreach (KeyValuePair<string, List<int>> item in _keyRowIndexList) {
				if (item.Value.Count == 1)
					result.Add(item.Key, item.Value[0]);
			}
			return result;		
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns>Return the indexed row number of the index column</returns>
		private Dictionary<int, string> getIndexedRowSetByNumber()
		{
			Dictionary<int, string> result = new Dictionary<int, string>();
			foreach (KeyValuePair<string, List<int>> item in _keyColumnIndexList) {
				if (item.Value.Count == 1)
					result.Add(item.Value[0], item.Key);
			}
			return result;		
		}
		private Dictionary<string, int> getIndexedRowSetByName()
		{
			Dictionary<string, int> result = new Dictionary<string, int>();
			foreach (KeyValuePair<string, List<int>> item in _keyColumnIndexList) {
				if (item.Value.Count == 1)
					result.Add(item.Key, item.Value[0]);
			}
			return result;		
		}		
	}
}