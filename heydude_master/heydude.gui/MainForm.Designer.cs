/*
 * Created by SharpDevelop.
 * User: liang
 * Date: 2018/1/5
 * Time: 下午 04:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace heydude.gui
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabpgPreviousExcel;
		private System.Windows.Forms.TabPage tabpgUpdatedExcel;
		private System.Windows.Forms.TabPage tabpgResult;
		private System.Windows.Forms.Button btnLoadPreviousExcel;
		private System.Windows.Forms.ComboBox cboPreviousWorksheets;
		private System.Windows.Forms.ComboBox cboPrevIndexColumn;
		private System.Windows.Forms.DataGridView dgPreviousWorksheet;
		private System.Windows.Forms.ComboBox cboPrevHeaderRow;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPreviousFilename;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dgCurrentWorksheet;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cboCurrentIndexColumn;
		private System.Windows.Forms.ComboBox cboCurrentHeaderRow;
		private System.Windows.Forms.ComboBox cboCurrentWorksheets;
		private System.Windows.Forms.TextBox txtCurrentFilename;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnLoadCurrentExcel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnProceed;
		private System.Windows.Forms.Button btnAssignOutputFile;
		private System.Windows.Forms.TextBox txtOutputFilename;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabpgPreviousExcel = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cboPrevIndexColumn = new System.Windows.Forms.ComboBox();
			this.cboPrevHeaderRow = new System.Windows.Forms.ComboBox();
			this.cboPreviousWorksheets = new System.Windows.Forms.ComboBox();
			this.txtPreviousFilename = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dgPreviousWorksheet = new System.Windows.Forms.DataGridView();
			this.btnLoadPreviousExcel = new System.Windows.Forms.Button();
			this.tabpgUpdatedExcel = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.cboCurrentIndexColumn = new System.Windows.Forms.ComboBox();
			this.cboCurrentHeaderRow = new System.Windows.Forms.ComboBox();
			this.cboCurrentWorksheets = new System.Windows.Forms.ComboBox();
			this.txtCurrentFilename = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.dgCurrentWorksheet = new System.Windows.Forms.DataGridView();
			this.btnLoadCurrentExcel = new System.Windows.Forms.Button();
			this.tabpgResult = new System.Windows.Forms.TabPage();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnProceed = new System.Windows.Forms.Button();
			this.btnAssignOutputFile = new System.Windows.Forms.Button();
			this.txtOutputFilename = new System.Windows.Forms.TextBox();
			this.tabMain.SuspendLayout();
			this.tabpgPreviousExcel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPreviousWorksheet)).BeginInit();
			this.tabpgUpdatedExcel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCurrentWorksheet)).BeginInit();
			this.tabpgResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabpgPreviousExcel);
			this.tabMain.Controls.Add(this.tabpgUpdatedExcel);
			this.tabMain.Controls.Add(this.tabpgResult);
			this.tabMain.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.tabMain.Location = new System.Drawing.Point(11, 11);
			this.tabMain.Margin = new System.Windows.Forms.Padding(2);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(765, 488);
			this.tabMain.TabIndex = 0;
			// 
			// tabpgPreviousExcel
			// 
			this.tabpgPreviousExcel.Controls.Add(this.groupBox1);
			this.tabpgPreviousExcel.Controls.Add(this.dgPreviousWorksheet);
			this.tabpgPreviousExcel.Controls.Add(this.btnLoadPreviousExcel);
			this.tabpgPreviousExcel.Location = new System.Drawing.Point(4, 30);
			this.tabpgPreviousExcel.Margin = new System.Windows.Forms.Padding(2);
			this.tabpgPreviousExcel.Name = "tabpgPreviousExcel";
			this.tabpgPreviousExcel.Padding = new System.Windows.Forms.Padding(2);
			this.tabpgPreviousExcel.Size = new System.Drawing.Size(757, 454);
			this.tabpgPreviousExcel.TabIndex = 0;
			this.tabpgPreviousExcel.Text = "Previous Excel";
			this.tabpgPreviousExcel.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cboPrevIndexColumn);
			this.groupBox1.Controls.Add(this.cboPrevHeaderRow);
			this.groupBox1.Controls.Add(this.cboPreviousWorksheets);
			this.groupBox1.Controls.Add(this.txtPreviousFilename);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(155, 4);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(604, 213);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Previous Excel Information";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(364, 163);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(221, 28);
			this.label10.TabIndex = 14;
			this.label10.Text = "Content must be identical";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(364, 124);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(221, 28);
			this.label9.TabIndex = 13;
			this.label9.Text = "Content must be identical";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(19, 34);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 27);
			this.label4.TabIndex = 11;
			this.label4.Text = "Filename";
			// 
			// label2
			// 
			this.label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.label2.Location = new System.Drawing.Point(19, 163);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 25);
			this.label2.TabIndex = 6;
			this.label2.Text = "Index Column";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(19, 121);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 25);
			this.label1.TabIndex = 5;
			this.label1.Text = "Header Row";
			// 
			// cboPrevIndexColumn
			// 
			this.cboPrevIndexColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPrevIndexColumn.FormattingEnabled = true;
			this.cboPrevIndexColumn.Location = new System.Drawing.Point(149, 163);
			this.cboPrevIndexColumn.Margin = new System.Windows.Forms.Padding(2);
			this.cboPrevIndexColumn.Name = "cboPrevIndexColumn";
			this.cboPrevIndexColumn.Size = new System.Drawing.Size(210, 28);
			this.cboPrevIndexColumn.TabIndex = 3;
			this.cboPrevIndexColumn.SelectedIndexChanged += new System.EventHandler(this.CboPrevIndexColumnSelectedIndexChanged);
			// 
			// cboPrevHeaderRow
			// 
			this.cboPrevHeaderRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPrevHeaderRow.FormattingEnabled = true;
			this.cboPrevHeaderRow.Location = new System.Drawing.Point(149, 121);
			this.cboPrevHeaderRow.Margin = new System.Windows.Forms.Padding(2);
			this.cboPrevHeaderRow.Name = "cboPrevHeaderRow";
			this.cboPrevHeaderRow.Size = new System.Drawing.Size(210, 28);
			this.cboPrevHeaderRow.TabIndex = 7;
			this.cboPrevHeaderRow.SelectedIndexChanged += new System.EventHandler(this.CboPrevHeaderRowSelectedIndexChanged);
			// 
			// cboPreviousWorksheets
			// 
			this.cboPreviousWorksheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPreviousWorksheets.FormattingEnabled = true;
			this.cboPreviousWorksheets.Location = new System.Drawing.Point(149, 76);
			this.cboPreviousWorksheets.Margin = new System.Windows.Forms.Padding(2);
			this.cboPreviousWorksheets.Name = "cboPreviousWorksheets";
			this.cboPreviousWorksheets.Size = new System.Drawing.Size(210, 28);
			this.cboPreviousWorksheets.TabIndex = 1;
			this.cboPreviousWorksheets.SelectedIndexChanged += new System.EventHandler(this.CboPreviousWorksheetsSelectedIndexChanged);
			// 
			// txtPreviousFilename
			// 
			this.txtPreviousFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPreviousFilename.Location = new System.Drawing.Point(149, 34);
			this.txtPreviousFilename.Margin = new System.Windows.Forms.Padding(2);
			this.txtPreviousFilename.Name = "txtPreviousFilename";
			this.txtPreviousFilename.ReadOnly = true;
			this.txtPreviousFilename.Size = new System.Drawing.Size(436, 31);
			this.txtPreviousFilename.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 76);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 27);
			this.label3.TabIndex = 10;
			this.label3.Text = "Worksheet";
			// 
			// dgPreviousWorksheet
			// 
			this.dgPreviousWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgPreviousWorksheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPreviousWorksheet.Location = new System.Drawing.Point(4, 221);
			this.dgPreviousWorksheet.Margin = new System.Windows.Forms.Padding(2);
			this.dgPreviousWorksheet.Name = "dgPreviousWorksheet";
			this.dgPreviousWorksheet.RowTemplate.Height = 45;
			this.dgPreviousWorksheet.Size = new System.Drawing.Size(755, 229);
			this.dgPreviousWorksheet.TabIndex = 4;
			// 
			// btnLoadPreviousExcel
			// 
			this.btnLoadPreviousExcel.Location = new System.Drawing.Point(4, 4);
			this.btnLoadPreviousExcel.Margin = new System.Windows.Forms.Padding(2);
			this.btnLoadPreviousExcel.Name = "btnLoadPreviousExcel";
			this.btnLoadPreviousExcel.Size = new System.Drawing.Size(139, 213);
			this.btnLoadPreviousExcel.TabIndex = 0;
			this.btnLoadPreviousExcel.Text = "Load Excel";
			this.btnLoadPreviousExcel.UseVisualStyleBackColor = true;
			this.btnLoadPreviousExcel.Click += new System.EventHandler(this.BtnLoadPreviousExcelClick);
			// 
			// tabpgUpdatedExcel
			// 
			this.tabpgUpdatedExcel.Controls.Add(this.groupBox2);
			this.tabpgUpdatedExcel.Controls.Add(this.dgCurrentWorksheet);
			this.tabpgUpdatedExcel.Controls.Add(this.btnLoadCurrentExcel);
			this.tabpgUpdatedExcel.Location = new System.Drawing.Point(4, 30);
			this.tabpgUpdatedExcel.Margin = new System.Windows.Forms.Padding(2);
			this.tabpgUpdatedExcel.Name = "tabpgUpdatedExcel";
			this.tabpgUpdatedExcel.Padding = new System.Windows.Forms.Padding(2);
			this.tabpgUpdatedExcel.Size = new System.Drawing.Size(757, 454);
			this.tabpgUpdatedExcel.TabIndex = 1;
			this.tabpgUpdatedExcel.Text = "Updated Excel";
			this.tabpgUpdatedExcel.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.cboCurrentIndexColumn);
			this.groupBox2.Controls.Add(this.cboCurrentHeaderRow);
			this.groupBox2.Controls.Add(this.cboCurrentWorksheets);
			this.groupBox2.Controls.Add(this.txtCurrentFilename);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Location = new System.Drawing.Point(155, 4);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(604, 213);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Updated Excel Information";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(364, 163);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(221, 28);
			this.label5.TabIndex = 14;
			this.label5.Text = "Content must be identical";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(364, 124);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(221, 28);
			this.label6.TabIndex = 13;
			this.label6.Text = "Content must be identical";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(19, 34);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(126, 27);
			this.label7.TabIndex = 11;
			this.label7.Text = "Filename";
			// 
			// label8
			// 
			this.label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.label8.Location = new System.Drawing.Point(19, 163);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(126, 25);
			this.label8.TabIndex = 6;
			this.label8.Text = "Index Column";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(19, 121);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(126, 25);
			this.label11.TabIndex = 5;
			this.label11.Text = "Header Row";
			// 
			// cboCurrentIndexColumn
			// 
			this.cboCurrentIndexColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCurrentIndexColumn.FormattingEnabled = true;
			this.cboCurrentIndexColumn.Location = new System.Drawing.Point(149, 163);
			this.cboCurrentIndexColumn.Margin = new System.Windows.Forms.Padding(2);
			this.cboCurrentIndexColumn.Name = "cboCurrentIndexColumn";
			this.cboCurrentIndexColumn.Size = new System.Drawing.Size(210, 28);
			this.cboCurrentIndexColumn.TabIndex = 3;
			this.cboCurrentIndexColumn.SelectedIndexChanged += new System.EventHandler(this.CboCurrentIndexColumnSelectedIndexChanged);
			// 
			// cboCurrentHeaderRow
			// 
			this.cboCurrentHeaderRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCurrentHeaderRow.FormattingEnabled = true;
			this.cboCurrentHeaderRow.Location = new System.Drawing.Point(149, 121);
			this.cboCurrentHeaderRow.Margin = new System.Windows.Forms.Padding(2);
			this.cboCurrentHeaderRow.Name = "cboCurrentHeaderRow";
			this.cboCurrentHeaderRow.Size = new System.Drawing.Size(210, 28);
			this.cboCurrentHeaderRow.TabIndex = 7;
			this.cboCurrentHeaderRow.SelectedIndexChanged += new System.EventHandler(this.CboCurrentHeaderRowSelectedIndexChanged);
			// 
			// cboCurrentWorksheets
			// 
			this.cboCurrentWorksheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCurrentWorksheets.FormattingEnabled = true;
			this.cboCurrentWorksheets.Location = new System.Drawing.Point(149, 76);
			this.cboCurrentWorksheets.Margin = new System.Windows.Forms.Padding(2);
			this.cboCurrentWorksheets.Name = "cboCurrentWorksheets";
			this.cboCurrentWorksheets.Size = new System.Drawing.Size(210, 28);
			this.cboCurrentWorksheets.TabIndex = 1;
			this.cboCurrentWorksheets.SelectedIndexChanged += new System.EventHandler(this.CboCurrentWorksheetsSelectedIndexChanged);
			// 
			// txtCurrentFilename
			// 
			this.txtCurrentFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCurrentFilename.Location = new System.Drawing.Point(149, 34);
			this.txtCurrentFilename.Margin = new System.Windows.Forms.Padding(2);
			this.txtCurrentFilename.Name = "txtCurrentFilename";
			this.txtCurrentFilename.ReadOnly = true;
			this.txtCurrentFilename.Size = new System.Drawing.Size(436, 31);
			this.txtCurrentFilename.TabIndex = 12;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(19, 76);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(126, 27);
			this.label12.TabIndex = 10;
			this.label12.Text = "Worksheet";
			// 
			// dgCurrentWorksheet
			// 
			this.dgCurrentWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgCurrentWorksheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgCurrentWorksheet.Location = new System.Drawing.Point(4, 221);
			this.dgCurrentWorksheet.Margin = new System.Windows.Forms.Padding(2);
			this.dgCurrentWorksheet.Name = "dgCurrentWorksheet";
			this.dgCurrentWorksheet.RowTemplate.Height = 45;
			this.dgCurrentWorksheet.Size = new System.Drawing.Size(755, 229);
			this.dgCurrentWorksheet.TabIndex = 15;
			// 
			// btnLoadCurrentExcel
			// 
			this.btnLoadCurrentExcel.Location = new System.Drawing.Point(4, 4);
			this.btnLoadCurrentExcel.Margin = new System.Windows.Forms.Padding(2);
			this.btnLoadCurrentExcel.Name = "btnLoadCurrentExcel";
			this.btnLoadCurrentExcel.Size = new System.Drawing.Size(139, 213);
			this.btnLoadCurrentExcel.TabIndex = 14;
			this.btnLoadCurrentExcel.Text = "Load Excel";
			this.btnLoadCurrentExcel.UseVisualStyleBackColor = true;
			this.btnLoadCurrentExcel.Click += new System.EventHandler(this.BtnLoadCurrentExcelClick);
			// 
			// tabpgResult
			// 
			this.tabpgResult.Controls.Add(this.textBox2);
			this.tabpgResult.Controls.Add(this.btnProceed);
			this.tabpgResult.Controls.Add(this.btnAssignOutputFile);
			this.tabpgResult.Controls.Add(this.txtOutputFilename);
			this.tabpgResult.Location = new System.Drawing.Point(4, 30);
			this.tabpgResult.Margin = new System.Windows.Forms.Padding(2);
			this.tabpgResult.Name = "tabpgResult";
			this.tabpgResult.Padding = new System.Windows.Forms.Padding(2);
			this.tabpgResult.Size = new System.Drawing.Size(757, 454);
			this.tabpgResult.TabIndex = 2;
			this.tabpgResult.Text = "Result";
			this.tabpgResult.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(6, 174);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(745, 276);
			this.textBox2.TabIndex = 17;
			this.textBox2.Text = "== HeyDude ==\r\nAuthor : Liang\r\nDescription : Compare the difference of excel\r\n\r\nV" +
	"ersion : 0.1\r\nReleaser : Liang\r\nDate : 2018/1/12\r\nNote :\r\nInitial release, funct" +
	"ional preview\r\nbugs everywhere";
			// 
			// btnProceed
			// 
			this.btnProceed.Location = new System.Drawing.Point(20, 100);
			this.btnProceed.Name = "btnProceed";
			this.btnProceed.Size = new System.Drawing.Size(184, 68);
			this.btnProceed.TabIndex = 16;
			this.btnProceed.Text = "Proceed";
			this.btnProceed.UseVisualStyleBackColor = true;
			this.btnProceed.Click += new System.EventHandler(this.BtnProceedClick);
			// 
			// btnAssignOutputFile
			// 
			this.btnAssignOutputFile.Location = new System.Drawing.Point(20, 26);
			this.btnAssignOutputFile.Name = "btnAssignOutputFile";
			this.btnAssignOutputFile.Size = new System.Drawing.Size(184, 68);
			this.btnAssignOutputFile.TabIndex = 15;
			this.btnAssignOutputFile.Text = "Assign Output File";
			this.btnAssignOutputFile.UseVisualStyleBackColor = true;
			this.btnAssignOutputFile.Click += new System.EventHandler(this.BtnAssignOutputFileClick);
			// 
			// txtOutputFilename
			// 
			this.txtOutputFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutputFilename.Location = new System.Drawing.Point(209, 47);
			this.txtOutputFilename.Margin = new System.Windows.Forms.Padding(2);
			this.txtOutputFilename.Name = "txtOutputFilename";
			this.txtOutputFilename.ReadOnly = true;
			this.txtOutputFilename.Size = new System.Drawing.Size(546, 31);
			this.txtOutputFilename.TabIndex = 14;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(787, 510);
			this.Controls.Add(this.tabMain);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "heydude.gui";
			this.tabMain.ResumeLayout(false);
			this.tabpgPreviousExcel.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPreviousWorksheet)).EndInit();
			this.tabpgUpdatedExcel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCurrentWorksheet)).EndInit();
			this.tabpgResult.ResumeLayout(false);
			this.tabpgResult.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
