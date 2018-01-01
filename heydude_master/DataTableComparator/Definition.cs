/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/31
 * Time: 下午 01:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

public struct CellDefinition
{
	public int RowIndex;
	public int ColumnIndex;
	public bool Indexed;
	public string Text;
}

public struct CellMappingDefinition
{
	public CellDefinition MasterCell;
	public CellDefinition SlaveCell;
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

