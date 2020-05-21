using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFamilySecurity
{
    public partial class FormRecord : Form
    {
        DataSet ds = new DataSet();
        List<string> listDateYear = new List<string>();
        List<string> listRecordID = new List<string>();
        List<string> listResultPhoto = new List<string>();
        CheckBox cb全選 = new CheckBox();

        public FormRecord()
        {
            InitializeComponent();
        }

        private void FormRecord_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            載入comboBox選項();

        }

        private void btn查詢_Click(object sender, EventArgs e)
        {
            string getSelectSql = 查詢字串();

            產生DataGridView(getSelectSql);

        }

        private void btn刪除_Click(object sender, EventArgs e)
        {
            // 刪除鍵

            List<int> listResultPhotoIndex = new List<int>();
            int index = 0;
            bool blnIsChecked = false;
            // 讓刪除語法 == false
            string getDeleteSql = "DELETE FROM tRecord WHERE FamilyID = " + CGlobal.FamilyID;
            getDeleteSql += " AND (1=2";

            // 確認有打勾的欄位
            foreach (DataGridViewRow r in dgv辨識紀錄.Rows)
            {
                if (r.Cells[0].Value is true)
                {
                    getDeleteSql += " OR RecordID = " + listRecordID[index];
                    listResultPhotoIndex.Add(index);
                    blnIsChecked = true;
                }

                index++;
            }

            getDeleteSql += ")";

            if (blnIsChecked == false)
            {
                MessageBox.Show("請選取想要刪除的紀錄");
                return;
            }

            // 確認視窗
            DialogResult msgbox = MessageBox.Show("確認刪除?", "紀錄即將刪除", MessageBoxButtons.OKCancel);
            if (msgbox == DialogResult.OK)
            {
                // 刪除本機圖片
                foreach (int i in listResultPhotoIndex)
                {
                    System.IO.File.Delete(listResultPhoto[i]);
                }

                // 執行刪除
                executeSql(getDeleteSql);

                string getSelectSql = 查詢字串();

                產生DataGridView(getSelectSql);

                載入comboBox選項();
            }

            else if (msgbox == DialogResult.Cancel)
                return;

        }

        private void 載入comboBox選項()
        {
            // 載入comboBox選項
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT DISTINCT DATEPART(YEAR, Date) FROM tRecord WHERE FamilyID = " + CGlobal.FamilyID;

            SqlDataReader dr = cmd.ExecuteReader();

            cboYear.Items.Clear();
            cboMonth.Items.Clear();
            cboDay.Items.Clear();
            cboHour.Items.Clear();
            cboResult.Items.Clear();

            // 年
            cboYear.Items.Add("任何");
            while (dr.Read())
                cboYear.Items.Add(dr[0]);
            // 月
            cboMonth.Items.Add("任何");
            for (int i = 1; i < 13; i++)
                cboMonth.Items.Add(i);
            // 日
            cboDay.Items.Add("任何");
            for (int i = 1; i < 32; i++)
                cboDay.Items.Add(i);
            // 時
            cboHour.Items.Add("任何");
            for (int i = 1; i < 25; i++)
                cboHour.Items.Add(i);
            // 結果
            cboResult.Items.Add("任何");
            cboResult.Items.Add("辨識成功");
            cboResult.Items.Add("辨識失敗");
            cboResult.Items.Add("無辨識人像");

            // 預設選擇項目
            cboYear.SelectedIndex = 0;
            cboMonth.SelectedIndex = 0;
            cboDay.SelectedIndex = 0;
            cboHour.SelectedIndex = 0;
            cboResult.SelectedIndex = 0;

            dr.Close();

            conn.Close();
        }

        private static void executeSql(string strSql)
        {
            // 執行SQL語法
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSql;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private string 查詢字串()
        {
            // 日期查詢
            string sqlString = "SELECT RecordID, Date, Result, ResultMemberName, ResultPhoto FROM tRecord WHERE FamilyID = " + CGlobal.FamilyID;

            sqlString = 日期查詢(sqlString, "YEAR", cboYear.SelectedItem.ToString());
            sqlString = 日期查詢(sqlString, "MONTH", cboMonth.SelectedItem.ToString());
            sqlString = 日期查詢(sqlString, "DAY", cboDay.SelectedItem.ToString());
            sqlString = 日期查詢(sqlString, "HOUR", cboHour.SelectedItem.ToString());

            // 結果查詢
            switch (cboResult.SelectedItem.ToString())
            {
                case "任何":
                    break;
                case "辨識成功":
                    sqlString += " AND Result = 1 ";
                    break;
                case "辨識失敗":
                    sqlString += " AND Result = 0 ";
                    break;
                case "無辨識人像":
                    sqlString += " AND Result is null ";
                    break;
            }

            return sqlString;
        }

        private string 日期查詢(string sqlString, string datepart, string selectedItem)
        {
            // ComboBox當前選項判別
            switch (selectedItem)
            {
                case "任何":
                    break;
                default:
                    string sqlDatepart = " AND DATEPART(" + datepart + ", Date) = ";
                    sqlString += sqlDatepart + selectedItem;
                    break;
            }

            return sqlString;
        }

        private void 產生DataGridView(string sqlString)
        {
            // 清空dgv辨識紀錄
            ds.Clear();
            dgv辨識紀錄.DataSource = ds;
            dgv辨識紀錄.Columns.Clear();

            // 從SQL載入資料
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlString, conn);
            da.Fill(ds);
            conn.Close();

            dgv辨識紀錄.DataSource = ds.Tables[0];

            //---------------------------------------------------------

            // 將 RecordID 存在 list 作為刪除索引
            // 將 RecordPhoto 存在 list 作為彈出照片索引
            listRecordID.Clear();
            listResultPhoto.Clear();
            foreach (DataGridViewRow r in dgv辨識紀錄.Rows)
            {
                listRecordID.Add(r.Cells["RecordID"].Value.ToString());
                listResultPhoto.Add(r.Cells["ResultPhoto"].Value.ToString());
            }

            // 刪除 RecordID + ResultPhoto 欄位
            dgv辨識紀錄.Columns.Remove("RecordID");
            dgv辨識紀錄.Columns.Remove("ResultPhoto");

            resetGridStyle();

        }

        private void resetGridStyle()
        {
            //---------------------------------------------------------

            // DataGridView Result欄位 Bool => string

            // 新增string欄位
            DataGridViewColumn Result = new DataGridViewColumn();
            Result.HeaderText = "辨識結果";

            // 必要 將欄位轉為string 原本型別為null
            Result.CellTemplate = new DataGridViewTextBoxCell();

            dgv辨識紀錄.Columns.Insert(1, Result);

            foreach (DataGridViewRow r in dgv辨識紀錄.Rows)
            {
                if (r.Cells["Result"].Value is true)
                {
                    r.Cells[1].Value = "辨識成功";
                    r.Cells[1].Style.ForeColor = Color.DarkGreen;
                }
                else if (r.Cells[2].Value is false)
                {
                    r.Cells[1].Value = "辨識失敗";
                    r.Cells[1].Style.ForeColor = Color.Red;
                }
                else if (r.Cells[2].Value.ToString() == "")
                {
                    r.Cells[1].Value = "無辨識人像";
                    r.Cells[1].Style.ForeColor = Color.Gray;
                }
            }

            // 刪除 Result欄位
            dgv辨識紀錄.Columns.Remove("Result");

            //---------------------------------------------------------

            // DataGridView 增加 ResultPhoto欄位

            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.HeaderText = "圖片";
            imageCol.FillWeight = 40;
            imageCol.Image = new Bitmap(Environment.CurrentDirectory + @"\image\click.jpg");
            imageCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

            imageCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv辨識紀錄.Columns.Insert(3, imageCol);


            //---------------------------------------------------------

            // DataGridView 增加 CheckBox欄位
            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
            checkBox.Width = 60;
            checkBox.HeaderText = "         　　" + "全選";
            checkBox.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv辨識紀錄.Columns.Insert(0, checkBox);

            // 建立矩形，計算 CheckBox 嵌入 GridView 的位置
            Rectangle rect = dgv辨識紀錄.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + rect.Width / 4 - 20;
            rect.Y = rect.Location.Y + (rect.Height / 2 - 9);

            //CheckBox cbHeader = new CheckBox();
            cb全選.Name = "checkboxHeader";
            cb全選.Size = new Size(18, 18);
            cb全選.Location = rect.Location;
            cb全選.Checked = false;


            // 全選框框 加入事件
            cb全選.CheckedChanged += new EventHandler(cbHeader_CheckedChanged);

            // 將 全選CheckBox方塊 加入到 dataGridView
            dgv辨識紀錄.Controls.Add(cb全選);

            //---------------------------------------------------------


            dgv辨識紀錄.Columns[0].FillWeight = 60; // "全選"
            dgv辨識紀錄.Columns[1].FillWeight = 180; // Date
            dgv辨識紀錄.Columns[2].FillWeight = 80; // "辨識結果"
            dgv辨識紀錄.Columns[3].FillWeight = 80; // ResultMemberName

            dgv辨識紀錄.Columns[1].HeaderText = "日期";
            dgv辨識紀錄.Columns[3].HeaderText = "符合成員";

            dgv辨識紀錄.Columns[1].ReadOnly = true;
            dgv辨識紀錄.Columns[2].ReadOnly = true;
            dgv辨識紀錄.Columns[3].ReadOnly = true;

            dgv辨識紀錄.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv辨識紀錄.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv辨識紀錄.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv辨識紀錄.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv辨識紀錄.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;


            bool isChaned = false;
            foreach (DataGridViewRow r in dgv辨識紀錄.Rows)
            {
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
                r.DefaultCellStyle.BackColor = Color.LightBlue;
                if (isChaned)
                    r.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                isChaned = !isChaned;


            }

        }

        private void cbHeader_CheckedChanged(object sender, EventArgs e)
        {
            // 全選事件
            foreach (DataGridViewRow dr in dgv辨識紀錄.Rows)
                dr.Cells[0].Value = ((CheckBox)dgv辨識紀錄.Controls.Find("checkboxHeader", true)[0]).Checked;

            dgv辨識紀錄.EndEdit();
        }

        private void dgv辨識紀錄_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 判斷點擊位置是否為圖片欄位
            if (e.ColumnIndex == dgv辨識紀錄.Columns[4].Index && e.RowIndex >= 0)
            {
                // 獲取 當前列索引
                int indexPath = e.RowIndex;
                string path = listResultPhoto[indexPath];

                // 彈出圖片視窗
                FormImageShow imgShow = new FormImageShow(path);
                imgShow.ShowDialog();
                return;

            }

            if (e.ColumnIndex == dgv辨識紀錄.Columns[0].Index)
            {
                int indexPath = e.RowIndex;

                if (indexPath == -1)
                {
                    return;
                }
                if (dgv辨識紀錄.Rows[indexPath].Cells[0].Value is true)
                {
                    dgv辨識紀錄.Rows[indexPath].Cells[0].Value = false;
                }
                else
                {
                    dgv辨識紀錄.Rows[indexPath].Cells[0].Value = true;
                }

                dgv辨識紀錄.EndEdit();

            }
        }

        //UI按鈕設計
        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Image = picDown.Image;
        }

        private void lbl_MouseUp(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Image = picUp.Image;
        }
    }
}
