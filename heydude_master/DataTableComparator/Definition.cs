/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/31
 * Time: 下午 01:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Data;

public class DataTableCellDefinition
{
	public int RowIndex = -1;
	public int ColumnIndex = -1;
	public bool Indexed = false;
	public DataRow DataRow;
	public string Text
	{
		get {
			if (DataRow == null || DataRow[ColumnIndex] == null)
				return "";
			return DataRow[ColumnIndex].ToString(); 
		}
	}
}

public class DataTableCellMappingDefinition
{
	public int TargetRowIndex = -1;
	public int TargetColumnIndex = -1;
	public DataTableCellDefinition MasterCell;
	public DataTableCellDefinition SlaveCell;
	public MappingStatusDefinition Status;
}

public enum MappingStatusDefinition
{
	Unknown,
	New,
	Unchange,
	Update,
	Delete
	
}

public enum ComparisonMethodDefinition
{
	List,
	Form
}