namespace prjFamilySecurity
{
    partial class FormRecord
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecord));
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboDay = new System.Windows.Forms.ComboBox();
            this.cboHour = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.dgv辨識紀錄 = new System.Windows.Forms.DataGridView();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cboResult = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.picUp = new System.Windows.Forms.PictureBox();
            this.picDown = new System.Windows.Forms.PictureBox();
            this.lbl查詢 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSetting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv辨識紀錄)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cboYear
            // 
            this.cboYear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(39, 57);
            this.cboYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(60, 28);
            this.cboYear.TabIndex = 0;
            // 
            // cboMonth
            // 
            this.cboMonth.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(135, 57);
            this.cboMonth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(60, 28);
            this.cboMonth.TabIndex = 1;
            // 
            // cboDay
            // 
            this.cboDay.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboDay.FormattingEnabled = true;
            this.cboDay.Location = new System.Drawing.Point(231, 57);
            this.cboDay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(60, 28);
            this.cboDay.TabIndex = 2;
            // 
            // cboHour
            // 
            this.cboHour.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboHour.FormattingEnabled = true;
            this.cboHour.Location = new System.Drawing.Point(327, 57);
            this.cboHour.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboHour.Name = "cboHour";
            this.cboHour.Size = new System.Drawing.Size(60, 28);
            this.cboHour.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblYear.Location = new System.Drawing.Point(102, 60);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(25, 20);
            this.lblYear.TabIndex = 6;
            this.lblYear.Text = "年";
            // 
            // dgv辨識紀錄
            // 
            this.dgv辨識紀錄.AllowUserToAddRows = false;
            this.dgv辨識紀錄.AllowUserToDeleteRows = false;
            this.dgv辨識紀錄.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv辨識紀錄.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv辨識紀錄.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv辨識紀錄.Location = new System.Drawing.Point(39, 102);
            this.dgv辨識紀錄.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv辨識紀錄.Name = "dgv辨識紀錄";
            this.dgv辨識紀錄.RowTemplate.Height = 31;
            this.dgv辨識紀錄.Size = new System.Drawing.Size(725, 307);
            this.dgv辨識紀錄.TabIndex = 8;
            this.dgv辨識紀錄.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv辨識紀錄_CellClick);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblHour.Location = new System.Drawing.Point(390, 60);
            this.lblHour.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(25, 20);
            this.lblHour.TabIndex = 10;
            this.lblHour.Text = "時";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDay.Location = new System.Drawing.Point(294, 60);
            this.lblDay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(25, 20);
            this.lblDay.TabIndex = 11;
            this.lblDay.Text = "日";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMonth.Location = new System.Drawing.Point(198, 60);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(25, 20);
            this.lblMonth.TabIndex = 12;
            this.lblMonth.Text = "月";
            // 
            // cboResult
            // 
            this.cboResult.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboResult.FormattingEnabled = true;
            this.cboResult.Location = new System.Drawing.Point(467, 57);
            this.cboResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboResult.Name = "cboResult";
            this.cboResult.Size = new System.Drawing.Size(109, 28);
            this.cboResult.TabIndex = 14;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblResult.Location = new System.Drawing.Point(423, 60);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 20);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "結果";
            // 
            // picUp
            // 
            this.picUp.Image = ((System.Drawing.Image)(resources.GetObject("picUp.Image")));
            this.picUp.Location = new System.Drawing.Point(49, 414);
            this.picUp.Name = "picUp";
            this.picUp.Size = new System.Drawing.Size(31, 50);
            this.picUp.TabIndex = 17;
            this.picUp.TabStop = false;
            this.picUp.Visible = false;
            // 
            // picDown
            // 
            this.picDown.Image = ((System.Drawing.Image)(resources.GetObject("picDown.Image")));
            this.picDown.Location = new System.Drawing.Point(12, 414);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(31, 50);
            this.picDown.TabIndex = 16;
            this.picDown.TabStop = false;
            this.picDown.Visible = false;
            // 
            // lbl查詢
            // 
            this.lbl查詢.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl查詢.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl查詢.Image = ((System.Drawing.Image)(resources.GetObject("lbl查詢.Image")));
            this.lbl查詢.Location = new System.Drawing.Point(645, 50);
            this.lbl查詢.Name = "lbl查詢";
            this.lbl查詢.Size = new System.Drawing.Size(64, 39);
            this.lbl查詢.TabIndex = 18;
            this.lbl查詢.Text = "查詢";
            this.lbl查詢.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl查詢.Click += new System.EventHandler(this.btn查詢_Click);
            this.lbl查詢.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseDown);
            this.lbl查詢.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(704, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 39);
            this.label1.TabIndex = 19;
            this.label1.Text = "刪除";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.btn刪除_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseDown);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseUp);
            // 
            // lblSetting
            // 
            this.lblSetting.AutoSize = true;
            this.lblSetting.Font = new System.Drawing.Font("微軟正黑體", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSetting.Location = new System.Drawing.Point(6, 9);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(137, 38);
            this.lblSetting.TabIndex = 20;
            this.lblSetting.Text = "辨識紀錄";
            // 
            // FormRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 442);
            this.Controls.Add(this.lblSetting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl查詢);
            this.Controls.Add(this.picUp);
            this.Controls.Add(this.picDown);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cboResult);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.dgv辨識紀錄);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cboHour);
            this.Controls.Add(this.cboDay);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.cboYear);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormRecord";
            this.Text = "辨識紀錄";
            this.Load += new System.EventHandler(this.FormRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv辨識紀錄)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboDay;
        private System.Windows.Forms.ComboBox cboHour;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.DataGridView dgv辨識紀錄;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cboResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox picUp;
        private System.Windows.Forms.PictureBox picDown;
        private System.Windows.Forms.Label lbl查詢;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSetting;
    }
}

