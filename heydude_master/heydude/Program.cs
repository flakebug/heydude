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
			
			foreach (DataTableCellMappingDefinition mapItem in dtc.CellMappingCollection) {
				if (mapItem.Status == MappingStatusDefinition.Delete) {
					Console.Write("R" + mapItem.SlaveCell.RowIndex);
					Console.Write("C" + mapItem.SlaveCell.ColumnIndex);
					Console.Write("|Index:" + mapItem.SlaveCell.Indexed);
					Console.Write("|Status:" + mapItem.Status.ToString());
					Console.Write("|Content:" + mapItem.SlaveCell.DataRow[mapItem.SlaveCell.ColumnIndex]);
					Console.WriteLine();
				}
				if (mapItem.Status == MappingStatusDefinition.New) {
					Console.Write("R" + mapItem.MasterCell.RowIndex);
					Console.Write("C" + mapItem.MasterCell.ColumnIndex);
					Console.Write("|Index:" + mapItem.MasterCell.Indexed);
					Console.Write("|Status:" + mapItem.Status.ToString());
					Console.Write("|Content:" + mapItem.MasterCell.DataRow[mapItem.MasterCell.ColumnIndex]);
					Console.WriteLine();
				}
			}
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