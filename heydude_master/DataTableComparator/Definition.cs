/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/31
 * Time: 下午 01:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Data;

public struct DataTableCellDefinition
{
	public int RowIndex;
	public int ColumnIndex;
	public bool Indexed;
	public DataRow DataRow;
}

public struct DataTableCellMappingDefinition
{
	public int TargetRowIndex;
	public int TargetColumnIndex;
	public DataTableCellDefinition MasterCell;
	public DataTableCellDefinition SlaveCell;
	public MappingStatusDefinition Status;
}

public enum MappingStatusDefinition
{
	New,
	Unchange,
	Update,
	Delete,
	Unknown
}

public enum ComparisonMethodDefinition
{
	List,
	Form
}