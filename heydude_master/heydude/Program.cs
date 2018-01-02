/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/30
 * Time: 上午 09:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using ryliang.DataTableComparator;
using ryliang.Excel;
using System.Collections.Generic;
namespace heydude
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			ExcelOperator xlsxop = new ExcelOperator("sample.xlsx");
			DataSet ds = xlsxop.LoadWorkbook();
			
			DataTableComparator dtc = new DataTableComparator(ds.Tables[0], ds.Tables[1]);
			dtc.MasterDataTableInfo.KeyColumnIndex = 0;
			dtc.MasterDataTableInfo.KeyRowIndex = 0;
			dtc.SlaveDataTableInfo.KeyColumnIndex = 0;
			dtc.SlaveDataTableInfo.KeyRowIndex = 0;		
			dtc.MasterDataTableInfo.AutoKeyIndex = false;
			dtc.SlaveDataTableInfo.AutoKeyIndex = false;
			dtc.Compare();
			Console.WriteLine("Master Key Row : " + dtc.MasterDataTableInfo.KeyRowIndex);
			Console.WriteLine("Master Key Column : " + dtc.MasterDataTableInfo.KeyColumnIndex);
			Console.WriteLine("Slave Key Row : " + dtc.SlaveDataTableInfo.KeyRowIndex);
			Console.WriteLine("Slave Key Column : " + dtc.SlaveDataTableInfo.KeyColumnIndex);
			
			DataTable dtResult = new DataTable("output");
			for (int columnIndex = 0; columnIndex < dtc.CellMappingColumnCount; columnIndex++)
				dtResult.Columns.Add(columnIndex.ToString(), typeof(string));
			for (int rowIndex = 0; rowIndex < dtc.CellMappingRowCount; rowIndex++)
				dtResult.Rows.Add(dtResult.NewRow());
			
			
			List<CellPropertyDef> output = new List<CellPropertyDef>();
			//CellPropertyDef cl = new CellPropertyDef(mapItem.TargetRowIndex,mapItem.TargetColumnIndex);
		
				
			foreach (DataTableCellMappingDefinition mapItem in dtc.CellMappingCollection) {
				//if (dtResult.Rows[mapItem.TargetRowIndex].IsNull)
				CellPropertyDef cl = new CellPropertyDef(mapItem.TargetRowIndex, mapItem.TargetColumnIndex);
				if (mapItem.Status == MappingStatusDefinition.Delete) {
//					Console.Write("|T|R" + mapItem.TargetRowIndex);
//					Console.Write("C" + mapItem.TargetColumnIndex);					
//					Console.Write("|S|R" + mapItem.SlaveCell.RowIndex);
//					Console.Write("C" + mapItem.SlaveCell.ColumnIndex);
//					Console.Write("|Index:" + mapItem.SlaveCell.Indexed);
//					Console.Write("|Status:" + mapItem.Status.ToString());
//					Console.Write("|Content:" + mapItem.SlaveCell.DataRow[mapItem.SlaveCell.ColumnIndex]);
//					Console.WriteLine();
					dtResult.Rows[mapItem.TargetRowIndex][mapItem.TargetColumnIndex] = mapItem.SlaveCell.Text;
					cl.BackgroundColor = Color.LightGray;
				} else {
//					Console.Write("|T|R" + mapItem.TargetRowIndex);
//					Console.Write("C" + mapItem.TargetColumnIndex);						
//					Console.Write("|S|R" + mapItem.MasterCell.RowIndex);
//					Console.Write("C" + mapItem.MasterCell.ColumnIndex);
//					Console.Write("|Index:" + mapItem.MasterCell.Indexed);
//					Console.Write("|Status:" + mapItem.Status.ToString());
//					Console.Write("|Content:" + mapItem.MasterCell.DataRow[mapItem.MasterCell.ColumnIndex]);
//					Console.WriteLine();
					dtResult.Rows[mapItem.TargetRowIndex][mapItem.TargetColumnIndex] = mapItem.MasterCell.Text;
					if (mapItem.Status == MappingStatusDefinition.Update) {
						cl.Comment = mapItem.SlaveCell.Text;
						cl.BackgroundColor = Color.Yellow;
					}
					if (mapItem.Status == MappingStatusDefinition.New) {
						cl.BackgroundColor = Color.LightGreen;
					}						
					if (mapItem.Status == MappingStatusDefinition.Unknown) {
						cl.BackgroundColor = Color.LightPink;
					}								
				}
				output.Add(cl);
			}
			xlsxop.SaveWorkbook(dtResult, output, "output.xlsx");
			
//			DataTableInfo dti = new DataTableInfo(ds.Tables[0]);
//			dti.InitializeDataTableInfo();
//			List<CellDefinition> cd = dti.GetCell("b","6");
//			foreach(CellDefinition a in cd) {
//				Console.WriteLine(a.Text + ":" + a.Indexed.ToString());
//			}
//			Console.WriteLine(dti.GetCellIndexStatus(0,0));			
//			Console.WriteLine(dti.GetCellIndexStatus(1,1));
//			Console.WriteLine(dti.GetCellIndexStatus(2,2));
//			Console.WriteLine(dti.GetCellIndexStatus(3,3));
//			Console.WriteLine(dti.GetCellIndexStatus(4,4));
//			Console.WriteLine(dti.GetCellIndexStatus(5,5));			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}