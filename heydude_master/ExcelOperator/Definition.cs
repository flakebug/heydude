/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2018/1/1
 * Time: 上午 08:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace ryliang.Excel
{
	public class Cell
	{
		public string Text;
		public string Comment;
		public System.Drawing.Color FontColor;
		public System.Drawing.Color BackgroundColor;
	}
	public class Row
	{
		public Dictionary<int, Cell> Columns;
		public Row()
		{
			Columns = new Dictionary<int, Cell>();
		}
	}
	public class Worksheet
	{
		public string Name;
		public Dictionary<int, Row> Rows;
		public Worksheet()
		{
			Rows = new Dictionary<int, Row>();
		}
	}
	public class Workbook
	{
		public string Filename;
		public Dictionary<int, Worksheet> Worksheets;
		public Workbook()
		{
			Worksheets = new Dictionary<int, Worksheet>();
		}
		public void SaveWorkbook()
		{
			SaveWorkbook(this.Filename);
		}
		public void SaveWorkbook(string Filename)
		{
			if (File.Exists(Filename))
				File.Delete(Filename);
			FileInfo newFile = new FileInfo(Filename);
			ExcelPackage eppPackage;	
			eppPackage = new ExcelPackage(newFile);
			
			for (int tableIndex = 0;
			     tableIndex < this.Worksheets.Count;
			     tableIndex++) {
				Worksheet worksheet = this.Worksheets[tableIndex];
				ExcelWorksheet eppWorksheet = eppPackage.Workbook.Worksheets.Add(worksheet.Name);
				Parallel.For(0, worksheet.Rows.Count, (int rowIndex) => {
					for (int columnIndex = 0;
				         columnIndex < worksheet.Rows[rowIndex].Columns.Count;
				         columnIndex++) {
						lock (eppWorksheet) {
							eppWorksheet.Cells[rowIndex + 1, columnIndex + 1].Value = worksheet.Rows[rowIndex].Columns[columnIndex].Text;
						}
					}
				});
			}
			eppPackage.Save();
		}		
	}
}