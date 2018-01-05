/*
 * Created by SharpDevelop.
 * User: liang
 * Date: 2018/1/5
 * Time: 下午 04:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ryliang.Excel;
using System.Drawing;
using System.Data;

namespace heydude.gui
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private ExcelOperator _previousExcel;
		private ExcelOperator _updatedExcel;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnLoadPreviousExcelClick(object sender, EventArgs e)
		{

			_previousExcel = ExcelGUIInitiator(cboPreviousWorksheets, dgPreviousWorksheet);

			
		}
		ExcelOperator ExcelGUIInitiator(ComboBox WorksheetsCombobox, DataGridView WorksheetDataGrid)
		{
			ExcelOperator xlsx = new ExcelOperator();
			DialogResult dlg = ofdMain.ShowDialog();
			if (dlg == DialogResult.OK) {
				try {
					xlsx = new ExcelOperator(ofdMain.FileName);
				}
				catch {
					MessageBox.Show("Not a valid excel file","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return xlsx;
				}
			}
			else {
				return xlsx;
			}
			txtPreviousFilename.Text = ofdMain.FileName;
			WorksheetDataGrid.DataSource = null;
			WorksheetsCombobox.Items.Clear();
			foreach (string sheetname in xlsx.WorksheetNames) {
				WorksheetsCombobox.Items.Add(sheetname);
			}
			return xlsx;
		}

		void worksheetChangeGUI(DataTable SourceDataTable, DataGridView ExcelGrid, ComboBox RowBox, ComboBox ColumnBox)
		{
			ExcelGrid.DataSource = SourceDataTable;
			foreach (DataGridViewColumn column in ExcelGrid.Columns) {
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			ColumnBox.Items.Clear();
			for (int i = 1; i <= SourceDataTable.Columns.Count; i++) {
				ColumnBox.Items.Add(i.ToString());
			}
			RowBox.Items.Clear();
			for (int i = 1; i <= SourceDataTable.Rows.Count; i++) {
				RowBox.Items.Add(i.ToString());
			}			
		}
		void CboPreviousWorksheetsSelectedIndexChanged(object sender, EventArgs e)
		{
			DataTable dt = _previousExcel.ExcelDataSet.Tables[cboPreviousWorksheets.SelectedItem.ToString()];
			worksheetChangeGUI(dt, dgPreviousWorksheet, cboPrevHeaderRow, cboPrevIndexColumn);
		}
		void CboPrevIndexColumnSelectedIndexChanged(object sender, EventArgs e)
		{
			setGridHighlight(dgPreviousWorksheet, cboPrevHeaderRow, cboPrevIndexColumn);
		}

		void setGridHighlight(DataGridView Grid, ComboBox RowBox, ComboBox ColumnBox)
		{
			int colindex;
			if (ColumnBox.SelectedItem == null)
				return;
			else
				colindex = Convert.ToInt32(ColumnBox.SelectedItem) - 1;
			int rowindex;
			if (RowBox.SelectedItem == null)
				return;
			else
				rowindex = Convert.ToInt32(RowBox.SelectedItem) - 1;
			int maxrow;
			if (Grid.Rows.Count > 100)
				maxrow = Grid.Rows.Count / 5;
			else
				maxrow = Grid.Rows.Count;
			
			for (int row = 0; row < maxrow; row++) {
				for (int col = 0; col < Grid.Columns.Count; col++) {
					Grid.Rows[row].Cells[col].Style.BackColor = Color.White;	
				}
			}
			for (int row = 0; row < maxrow; row++) {
				Grid.Rows[row].Cells[colindex].Style.BackColor = Color.Yellow;	
			}		
			for (int col = 0; col < Grid.Columns.Count; col++) {
				Grid.Rows[rowindex].Cells[col].Style.BackColor = Color.Yellow;	
			}					
		}
		void CboPrevHeaderRowSelectedIndexChanged(object sender, EventArgs e)
		{
			setGridHighlight(dgPreviousWorksheet, cboPrevHeaderRow, cboPrevIndexColumn);

		}
		void Label3Click(object sender, EventArgs e)
		{
	
		}
		void TabpgUpdatedExcelClick(object sender, EventArgs e)
		{
	
		}
	}
}
