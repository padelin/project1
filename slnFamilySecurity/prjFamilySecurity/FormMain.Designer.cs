namespace prjFamilySecurity
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picUp = new System.Windows.Forms.PictureBox();
            this.picDown = new System.Windows.Forms.PictureBox();
            this.lbl登出 = new System.Windows.Forms.Label();
            this.lbl設定 = new System.Windows.Forms.Label();
            this.lbl辨識紀錄 = new System.Windows.Forms.Label();
            this.lbl成員資料 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.picUp);
            this.panel1.Controls.Add(this.picDown);
            this.panel1.Controls.Add(this.lbl登出);
            this.panel1.Controls.Add(this.lbl設定);
            this.panel1.Controls.Add(this.lbl辨識紀錄);
            this.panel1.Controls.Add(this.lbl成員資料);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 681);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 295);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // picUp
            // 
            this.picUp.Image = ((System.Drawing.Image)(resources.GetObject("picUp.Image")));
            this.picUp.Location = new System.Drawing.Point(44, 593);
            this.picUp.Name = "picUp";
            this.picUp.Size = new System.Drawing.Size(31, 50);
            this.picUp.TabIndex = 8;
            this.picUp.TabStop = false;
            this.picUp.Visible = false;
            // 
            // picDown
            // 
            this.picDown.Image = ((System.Drawing.Image)(resources.GetObject("picDown.Image")));
            this.picDown.Location = new System.Drawing.Point(3, 593);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(31, 50);
            this.picDown.TabIndex = 7;
            this.picDown.TabStop = false;
            this.picDown.Visible = false;
            // 
            // lbl登出
            // 
            this.lbl登出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl登出.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl登出.ForeColor = System.Drawing.Color.White;
            this.lbl登出.Image = ((System.Drawing.Image)(resources.GetObject("lbl登出.Image")));
            this.lbl登出.Location = new System.Drawing.Point(6, 545);
            this.lbl登出.Name = "lbl登出";
            this.lbl登出.Size = new System.Drawing.Size(150, 60);
            this.lbl登出.TabIndex = 6;
            this.lbl登出.Text = "登出";
            this.lbl登出.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl登出.Click += new System.EventHandler(this.lbl登出_Click);
            this.lbl登出.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseDown);
            this.lbl登出.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseUp);
            // 
            // lbl設定
            // 
            this.lbl設定.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl設定.ForeColor = System.Drawing.Color.White;
            this.lbl設定.Image = ((System.Drawing.Image)(resources.GetObject("lbl設定.Image")));
            this.lbl設定.Location = new System.Drawing.Point(6, 200);
            this.lbl設定.Name = "lbl設定";
            this.lbl設定.Size = new System.Drawing.Size(150, 60);
            this.lbl設定.TabIndex = 5;
            this.lbl設定.Text = "設定";
            this.lbl設定.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl設定.Click += new System.EventHandler(this.lbl設定_Click);
            this.lbl設定.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseDown);
            this.lbl設定.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseUp);
            // 
            // lbl辨識紀錄
            // 
            this.lbl辨識紀錄.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl辨識紀錄.ForeColor = System.Drawing.Color.White;
            this.lbl辨識紀錄.Image = ((System.Drawing.Image)(resources.GetObject("lbl辨識紀錄.Image")));
            this.lbl辨識紀錄.Location = new System.Drawing.Point(6, 117);
            this.lbl辨識紀錄.Name = "lbl辨識紀錄";
            this.lbl辨識紀錄.Size = new System.Drawing.Size(150, 60);
            this.lbl辨識紀錄.TabIndex = 4;
            this.lbl辨識紀錄.Text = "辨識紀錄";
            this.lbl辨識紀錄.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl辨識紀錄.Click += new System.EventHandler(this.lbl辨識紀錄_Click);
            this.lbl辨識紀錄.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseDown);
            this.lbl辨識紀錄.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseUp);
            // 
            // lbl成員資料
            // 
            this.lbl成員資料.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl成員資料.ForeColor = System.Drawing.Color.White;
            this.lbl成員資料.Image = ((System.Drawing.Image)(resources.GetObject("lbl成員資料.Image")));
            this.lbl成員資料.Location = new System.Drawing.Point(6, 34);
            this.lbl成員資料.Name = "lbl成員資料";
            this.lbl成員資料.Size = new System.Drawing.Size(150, 60);
            this.lbl成員資料.TabIndex = 3;
            this.lbl成員資料.Text = "成員資料";
            this.lbl成員資料.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl成員資料.Click += new System.EventHandler(this.lbl成員資料_Click);
            this.lbl成員資料.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseDown);
            this.lbl成員資料.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "家庭AI保全管理系統";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl登出;
        private System.Windows.Forms.Label lbl設定;
        private System.Windows.Forms.Label lbl辨識紀錄;
        private System.Windows.Forms.Label lbl成員資料;
        private System.Windows.Forms.PictureBox picDown;
        private System.Windows.Forms.PictureBox picUp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

