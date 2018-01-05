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
		private System.Windows.Forms.OpenFileDialog ofdMain;
		private System.Windows.Forms.ComboBox cboPrevIndexColumn;
		private System.Windows.Forms.DataGridView dgPreviousWorksheet;
		private System.Windows.Forms.ComboBox cboPrevHeaderRow;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPreviousFilename;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button1;
		
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
			this.tabpgResult = new System.Windows.Forms.TabPage();
			this.ofdMain = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tabMain.SuspendLayout();
			this.tabpgPreviousExcel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPreviousWorksheet)).BeginInit();
			this.tabpgUpdatedExcel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabpgPreviousExcel);
			this.tabMain.Controls.Add(this.tabpgUpdatedExcel);
			this.tabMain.Controls.Add(this.tabpgResult);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(1461, 956);
			this.tabMain.TabIndex = 0;
			// 
			// tabpgPreviousExcel
			// 
			this.tabpgPreviousExcel.Controls.Add(this.groupBox1);
			this.tabpgPreviousExcel.Controls.Add(this.dgPreviousWorksheet);
			this.tabpgPreviousExcel.Controls.Add(this.btnLoadPreviousExcel);
			this.tabpgPreviousExcel.Location = new System.Drawing.Point(10, 58);
			this.tabpgPreviousExcel.Name = "tabpgPreviousExcel";
			this.tabpgPreviousExcel.Padding = new System.Windows.Forms.Padding(3);
			this.tabpgPreviousExcel.Size = new System.Drawing.Size(1441, 888);
			this.tabpgPreviousExcel.TabIndex = 0;
			this.tabpgPreviousExcel.Text = "Previous Excel";
			this.tabpgPreviousExcel.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cboPrevIndexColumn);
			this.groupBox1.Controls.Add(this.cboPrevHeaderRow);
			this.groupBox1.Controls.Add(this.cboPreviousWorksheets);
			this.groupBox1.Controls.Add(this.txtPreviousFilename);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(309, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1126, 400);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Previous Excel Information";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(38, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(203, 50);
			this.label4.TabIndex = 11;
			this.label4.Text = "Filename";
			// 
			// label2
			// 
			this.label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.label2.Location = new System.Drawing.Point(38, 305);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(203, 46);
			this.label2.TabIndex = 6;
			this.label2.Text = "Index Column";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(38, 226);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(185, 46);
			this.label1.TabIndex = 5;
			this.label1.Text = "Header Row";
			// 
			// cboPrevIndexColumn
			// 
			this.cboPrevIndexColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPrevIndexColumn.FormattingEnabled = true;
			this.cboPrevIndexColumn.Location = new System.Drawing.Point(298, 305);
			this.cboPrevIndexColumn.Name = "cboPrevIndexColumn";
			this.cboPrevIndexColumn.Size = new System.Drawing.Size(417, 48);
			this.cboPrevIndexColumn.TabIndex = 3;
			this.cboPrevIndexColumn.SelectedIndexChanged += new System.EventHandler(this.CboPrevIndexColumnSelectedIndexChanged);
			// 
			// cboPrevHeaderRow
			// 
			this.cboPrevHeaderRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPrevHeaderRow.FormattingEnabled = true;
			this.cboPrevHeaderRow.Location = new System.Drawing.Point(298, 226);
			this.cboPrevHeaderRow.Name = "cboPrevHeaderRow";
			this.cboPrevHeaderRow.Size = new System.Drawing.Size(417, 48);
			this.cboPrevHeaderRow.TabIndex = 7;
			this.cboPrevHeaderRow.SelectedIndexChanged += new System.EventHandler(this.CboPrevHeaderRowSelectedIndexChanged);
			// 
			// cboPreviousWorksheets
			// 
			this.cboPreviousWorksheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPreviousWorksheets.FormattingEnabled = true;
			this.cboPreviousWorksheets.Location = new System.Drawing.Point(298, 143);
			this.cboPreviousWorksheets.Name = "cboPreviousWorksheets";
			this.cboPreviousWorksheets.Size = new System.Drawing.Size(417, 48);
			this.cboPreviousWorksheets.TabIndex = 1;
			this.cboPreviousWorksheets.SelectedIndexChanged += new System.EventHandler(this.CboPreviousWorksheetsSelectedIndexChanged);
			// 
			// txtPreviousFilename
			// 
			this.txtPreviousFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPreviousFilename.Location = new System.Drawing.Point(298, 64);
			this.txtPreviousFilename.Name = "txtPreviousFilename";
			this.txtPreviousFilename.Size = new System.Drawing.Size(786, 55);
			this.txtPreviousFilename.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(38, 143);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(203, 50);
			this.label3.TabIndex = 10;
			this.label3.Text = "Worksheet";
			this.label3.Click += new System.EventHandler(this.Label3Click);
			// 
			// dgPreviousWorksheet
			// 
			this.dgPreviousWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgPreviousWorksheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPreviousWorksheet.Location = new System.Drawing.Point(6, 431);
			this.dgPreviousWorksheet.Name = "dgPreviousWorksheet";
			this.dgPreviousWorksheet.RowTemplate.Height = 45;
			this.dgPreviousWorksheet.Size = new System.Drawing.Size(1429, 451);
			this.dgPreviousWorksheet.TabIndex = 4;
			// 
			// btnLoadPreviousExcel
			// 
			this.btnLoadPreviousExcel.Location = new System.Drawing.Point(6, 25);
			this.btnLoadPreviousExcel.Name = "btnLoadPreviousExcel";
			this.btnLoadPreviousExcel.Size = new System.Drawing.Size(278, 400);
			this.btnLoadPreviousExcel.TabIndex = 0;
			this.btnLoadPreviousExcel.Text = "Load Excel";
			this.btnLoadPreviousExcel.UseVisualStyleBackColor = true;
			this.btnLoadPreviousExcel.Click += new System.EventHandler(this.BtnLoadPreviousExcelClick);
			// 
			// tabpgUpdatedExcel
			// 
			this.tabpgUpdatedExcel.Controls.Add(this.dataGridView1);
			this.tabpgUpdatedExcel.Controls.Add(this.groupBox2);
			this.tabpgUpdatedExcel.Controls.Add(this.button1);
			this.tabpgUpdatedExcel.Location = new System.Drawing.Point(10, 58);
			this.tabpgUpdatedExcel.Name = "tabpgUpdatedExcel";
			this.tabpgUpdatedExcel.Padding = new System.Windows.Forms.Padding(3);
			this.tabpgUpdatedExcel.Size = new System.Drawing.Size(1441, 888);
			this.tabpgUpdatedExcel.TabIndex = 1;
			this.tabpgUpdatedExcel.Text = "Updated Excel";
			this.tabpgUpdatedExcel.UseVisualStyleBackColor = true;
			this.tabpgUpdatedExcel.Click += new System.EventHandler(this.TabpgUpdatedExcelClick);
			// 
			// tabpgResult
			// 
			this.tabpgResult.Location = new System.Drawing.Point(10, 58);
			this.tabpgResult.Name = "tabpgResult";
			this.tabpgResult.Padding = new System.Windows.Forms.Padding(3);
			this.tabpgResult.Size = new System.Drawing.Size(1441, 888);
			this.tabpgResult.TabIndex = 2;
			this.tabpgResult.Text = "Result";
			this.tabpgResult.UseVisualStyleBackColor = true;
			// 
			// ofdMain
			// 
			this.ofdMain.FileName = "openFileDialog1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 25);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(278, 400);
			this.button1.TabIndex = 1;
			this.button1.Text = "Load Excel";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Controls.Add(this.comboBox2);
			this.groupBox2.Controls.Add(this.comboBox3);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(315, 25);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1126, 400);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Previous Excel Information";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(38, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(203, 50);
			this.label5.TabIndex = 11;
			this.label5.Text = "Filename";
			// 
			// label6
			// 
			this.label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.label6.Location = new System.Drawing.Point(38, 305);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(203, 46);
			this.label6.TabIndex = 6;
			this.label6.Text = "Index Column";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(38, 226);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(185, 46);
			this.label7.TabIndex = 5;
			this.label7.Text = "Header Row";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(298, 305);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(417, 48);
			this.comboBox1.TabIndex = 3;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(298, 226);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(417, 48);
			this.comboBox2.TabIndex = 7;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(298, 143);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(417, 48);
			this.comboBox3.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(298, 64);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(786, 55);
			this.textBox1.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(38, 143);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(203, 50);
			this.label8.TabIndex = 10;
			this.label8.Text = "Worksheet";
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(9, 431);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 45;
			this.dataGridView1.Size = new System.Drawing.Size(1429, 451);
			this.dataGridView1.TabIndex = 15;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1461, 956);
			this.Controls.Add(this.tabMain);
			this.Name = "MainForm";
			this.Text = "heydude.gui";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tabMain.ResumeLayout(false);
			this.tabpgPreviousExcel.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPreviousWorksheet)).EndInit();
			this.tabpgUpdatedExcel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
