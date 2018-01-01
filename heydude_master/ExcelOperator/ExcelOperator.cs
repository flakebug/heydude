/*
 * Created by SharpDevelop.
 * User: 53785
 * Date: 2017/12/30
 * Time: 上午 11:0
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ryliang.Excel
{
	/// <summary>
	/// Handling the excel object
	/// </summary>
	public class ExcelOperator
	{
		private string _excelFilename;
		private DataSet _excelDataSet;

		public ExcelOperator(string Filename)
		{
			_excelFilename = Filename;
		}
		public DataSet LoadWorkbook()
		{
			DataSet ds = LoadWorkbook(_excelFilename);
			return ds;
		}
		public DataSet LoadWorkbook(string Filename)
		{
			DataSet ds = new DataSet();
			FileStream _excelFileStream;
			ExcelPackage _excelPackage;			
			_excelFileStream = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			_excelPackage = new ExcelPackage(_excelFileStream);
			for (int worksheetIndex = 1; 
			    	worksheetIndex <= _excelPackage.Workbook.Worksheets.Count; 
			    	worksheetIndex++) {
				ExcelWorksheet worksheet = _excelPackage.Workbook.Worksheets[worksheetIndex];
				int rowLimit = worksheet.Dimension.End.Row;
				int columnLimit = worksheet.Dimension.End.Column;

				DataTable dt = new DataTable();
				dt.TableName = worksheet.Name;
				
				//Initialize columns
				for (int colIndex = 0; colIndex < columnLimit; colIndex++) {
					dt.Columns.Add(colIndex.ToString(), typeof(string));
				}
				//Initialize rows
				Parallel.For(0, rowLimit, (int rowIndex) => {
					DataRow dr = dt.NewRow();
					lock (dt) {
						dt.Rows.Add(dr);
					}
				});
				//Copy data from excel to datatable / dataset
				Parallel.For(0, rowLimit, (int rowIndex) => {
					DataRow dr = dt.Rows[rowIndex];
					for (int colIndex = 0; colIndex < columnLimit; colIndex++) {
						lock (dt) {
							dr[colIndex] = worksheet.Cells[rowIndex + 1, colIndex + 1].Text;
						}
					}	
				});
				ds.Tables.Add(dt);
			}
			_excelDataSet = ds;
			return ds;
		}
		

	}
}