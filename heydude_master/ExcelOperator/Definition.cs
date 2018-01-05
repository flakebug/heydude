///*
// * Created by SharpDevelop.
// * User: 53785
// * Date: 2018/1/1
// * Time: 上午 08:30
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.IO;
//using OfficeOpenXml;
//
//namespace ryliang.Excel
//{
//	public class Cell
//	{
//		public int RowIndex;
//		public int ColumnIndex;
//		public string Text;
//		public string Comment;
//		public System.Drawing.Color FontColor;
//		public System.Drawing.Color BackgroundColor;
//		public Cell(int RowIndex, int ColumnIndex)
//		{
//			this.RowIndex = RowIndex;
//			this.ColumnIndex = ColumnIndex;
//		}
//	}
//	public class Row
//	{
//		public Dictionary<int, Cell> Columns;
//		public Row()
//		{
//			Columns = new Dictionary<int, Cell>();
//		}
//	}
//	public class Worksheet
//	{
//		public string Name;
//		public Dictionary<int, Row> Rows;
//		public Worksheet(string WorksheetName)
//		{
//			Rows = new Dictionary<int, Row>();
//			Name = WorksheetName;
//		}
//	}
//	public class Workbook
//	{
//		public string Filename;
//		public Dictionary<int, Worksheet> Worksheets;
//		public Workbook()
//		{
//			Worksheets = new Dictionary<int, Worksheet>();
//		}
//		public void SaveWorkbook()
//		{
//			SaveWorkbook(this.Filename);
//		}
//		public void SaveWorkbook(string Filename)
//		{
//			if (File.Exists(Filename))
//				File.Delete(Filename);
//			FileInfo newFile = new FileInfo(Filename);
//			ExcelPackage eppPackage;	
//			eppPackage = new ExcelPackage(newFile);
//			
//			for (int tableIndex = 0;
//			     tableIndex < this.Worksheets.Count;
//			     tableIndex++) {
//				Worksheet worksheet = this.Worksheets[tableIndex];
//				ExcelWorksheet eppWorksheet = eppPackage.Workbook.Worksheets.Add(worksheet.Name);
////				foreach (KeyValuePair<int, Row> rowItem in worksheet.Rows)
////					foreach (KeyValuePair<int, Cell> cl in rowItem.Value.Columns)
////						//Con
////						//eppWorksheet.Cells[cl.Value.RowIndex, cl.Value.ColumnIndex].Value = cl.Value.Text;
//
//			}
//			eppPackage.Save();
//		}
//	}
//}