using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Capture = Emgu.CV.Capture;

namespace prjFamilySecurity
{
    public partial class FormMember : Form
    {
        //  新增成員UI功能:
        //  
        //  1. 結合5連拍, 
        //  2. 照片檔案存C:\Users\Public\Pictures
        //  3. 資料上傳sql to tMember and tPhoto
        //  4. 刪除確認
        //  5. Name格式檢查- 不可有特殊字元
        //  6. Email格式檢查- 不可錯誤格式
        //  7. 人臉辨識到陌生人,可選擇是否寄Email


        DataSet ds = new DataSet();         //new水桶(dataset)
        int MemberID = 0;                   //要查出txtName.Text的MemberID
        bool l_bln_NameValid = true;        //Name格式檢查
        bool l_bln_EmailValid = true;       //Email格式檢查

        private Capture cap = null;     //宣告Webcam
        private string fileName;        //照片儲存的檔名
        private bool bln攝影機運作 = false;

        //照片儲存路徑
        //string phtoDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures)+@"\";
        string phtoDirectory = @"\\pc\專題\Photo\";

        int count = 1;      //取像張數 初始值

        public FormMember()
        {
            InitializeComponent();
        }

        private void Timer畫面運作_Tick(object sender, EventArgs e)
        {
            Image<Bgr, Byte> 框架 = cap.QueryFrame();
            pictureBox1.Image = 框架.ToBitmap();
        }

        private void 開啟攝影機()  // 開啟攝影機方法
        {
            //如果webcam沒啟動
            if (cap == null)
            {
                try
                {
                    //打開預設的webcam
                    cap = new Capture(1);
                    cap.FlipHorizontal = !cap.FlipHorizontal;   //消除鏡像
                }
                catch
                {
                    MessageBox.Show("請連結攝影機");
                    return;
                }
            }
        }

        private void btn開關_Click(object sender, EventArgs e)
        {
            開啟攝影機();
            //webcam啟動
            if (cap != null)
            {
                //frame啟動
                if (bln攝影機運作)
                {
                    //stop the capture
                    bln攝影機運作 = false;
                    btn開關.Text = "開啟攝影機";
                    timer畫面運作.Stop();
                    btnCapture.Visible = false;
                    lblCaptureStar.Visible = false;
                    pictureBox1.Image = null;
                }
                //frame關閉
                else
                {
                    //start the capture
                    MessageBox.Show("建立臉部資料時，請將臉部對準鏡頭");
                    bln攝影機運作 = true;
                    btn開關.Text = "關閉攝影機";
                    btnCapture.Visible = true;
                    lblCaptureStar.Visible = true;
                    timer畫面運作.Start();
                }
            }
        }


        private void executeSql(string sql)     //同下sql語法
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            con.Close();
        }


        private int GetMumberIDsql()        //要查出txtName.Text的MemberID
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            con.Open();

            string searchName = txtName.Text;
            string selectCmd = "SELECT MemberID FROM tMember WHERE MemberName = '" + searchName + "'";

            SqlCommand cmd = new SqlCommand(selectCmd, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return System.Convert.ToInt32(dr["MemberID"]);
            }
            else
            {
                MessageBox.Show("查無MemberID");
                return 999;     //Error code 999:查無MemberID
            }
        }

        private string getInsertSql()       //下sql語法,上傳Insert to tMember
        {
            string sql = "INSERT INTO tMember (";
            sql += " MemberName,";
            sql += " FamilyID,";
            sql += " Email,";
            sql += " SendEmail ";
            sql += " )VALUES(";
            sql += " '" + txtName.Text + "',";
            sql += " '" + CGlobal.FamilyID + "',";
            sql += " '" + txtEmail.Text + "',";
            sql += " '" + checkBox1.Tag + "')";
            return sql;
        }

        private string getUpdateSql()       //下sql語法,上傳Update to tMember
        {
            MemberID = GetMumberIDsql();
            string sql = "Update tMember SET";
            sql += " FamilyID = ";
            sql += " '" + CGlobal.FamilyID + "',";
            sql += " Email = ";
            sql += " '" + txtEmail.Text + "',";
            sql += " SendEmail = ";
            sql += " '" + checkBox1.Tag + "'";
            sql += " WHERE MemberID= ";
            sql += MemberID;
            return sql;
        }

        private string getDeleteSql()       //下sql語法,刪除
        {
            MemberID = GetMumberIDsql();
            string sql = "Delete from tPhoto where MemberID ="; //刪除tPhoto的MemberID
            sql += MemberID;
            executeSql(sql);
            sql = "Delete from tMember where MemberID =";       //刪除tMember的MemberID
            sql += MemberID;
            return sql;
        }

        private string getInsertPhoto(string imageName)     //下sql語法,上傳到tPhoto
        {
            //string path2;
            //path2 = phtoDirectory.Replace(@"\",@"//");

            string sql = "INSERT INTO tPhoto (";
            sql += " PhotoName,";
            sql += " MemberID,";
            sql += " PhotoFile ";
            sql += " )VALUES(";
            sql += " '" + imageName + "',";
            sql += " '" + MemberID + "',";
            sql += " '" + phtoDirectory + "')";
            return sql;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            dataGridView1.Visible = false;
            GrideViewLoadDataFromSql();
        }

        private void GrideViewLoadDataFromSql()         //倒資料到dataGridView1
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            con.Open();

            SqlDataAdapter ada = new SqlDataAdapter(
                " select row_number() over(order by MemberID desc) 成員編號," +
                " MemberName as 姓名," +
                " Email," +
                " SendEmail as Email通知" +
                " from tMember where FamilyID = " + CGlobal.FamilyID, con);

            ada.Fill(ds);          // 倒水到水桶
            con.Close();

            dataGridView1.DataSource = ds.Tables[0];

            resetGridStyle();

        }

        private void resetGridStyle()           //建立dataGridView1的顯示格式
        {
            //dataGridView1.Columns[0].Width = 90;
            //dataGridView1.Columns[1].Width = 100;
            //dataGridView1.Columns[2].Width = 200;
            //dataGridView1.Columns[3].Width = 100;

            bool isChaned = false;
            foreach (DataGridViewRow r1 in dataGridView1.Rows)
            {
                //r1.DefaultCellStyle.Font = new Font("微軟正黑體", 9);
                //r1.DefaultCellStyle.BackColor = Color.LightBlue;
                if (isChaned)
                    r1.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                isChaned = !isChaned;
                if (r1.Cells[0].Value == null)
                    continue;
                if (r1.Cells[1].Value.ToString() == txtName.Text)
                {
                    r1.Cells[0].Style.BackColor = Color.Yellow;
                    r1.Cells[1].Style.BackColor = Color.Yellow;
                    r1.Cells[2].Style.BackColor = Color.Yellow;
                    r1.Cells[3].Style.BackColor = Color.Yellow;
                }
            }

        }


        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void loadCheckBox()     //人臉辨識到陌生人,可選擇是否寄Email
        {
            if (checkBox1.Checked && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                checkBox1.Tag = true;      //寄Email
            }
            else
            {
                checkBox1.Tag = false;      //沒勾checkBox1 or 沒輸入Email都是不寄Email
                checkBox1.Checked = false;
            }
        }

        private void VerifyText_for_txtName_txtEmail()      //方法, 驗證Name和Email格式
        {
            Regex word = new Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]");   //姓名的錯誤字元集               

            if (String.IsNullOrEmpty(txtName.Text))     //姓名空值
            {
                txtName.Text = "請輸入姓名";
                l_bln_NameValid = false;
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "請輸入姓名" + "\r\n";
                lblResult.Visible = true;
                l_bln_NameValid = false;
            }
            else if (word.IsMatch(txtName.Text))         //姓名有特殊符號
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "姓名 格式錯誤: 不可有特殊符號 " + "\r\n";
                lblResult.Visible = true;
                l_bln_NameValid = false;
            }
            else
            {
                lblResult.Text = "";
                l_bln_NameValid = true;
            }


            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "";                          //允許不輸入Email
                l_bln_EmailValid = true;
            }
            else if (!IsValidEmail(txtEmail.Text))           //Email格式錯誤
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text += "Email格式錯誤: " + txtEmail.Text;
                lblResult.Visible = true;
                l_bln_EmailValid = false;
            }
            else l_bln_EmailValid = true;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            count = 1;  
            bool l_bln_新成員 = true;
            VerifyText_for_txtName_txtEmail();

            if (l_bln_NameValid && l_bln_EmailValid)    //姓名 and Email格式皆正確
            {
                loadCheckBox();
                foreach (DataGridViewRow r in dataGridView1.Rows) //判斷該成員Name,已存在嗎?
                {
                    if (r.Cells[1].Value == null || !l_bln_新成員)     //結束迴圈
                    {
                        break;
                    }

                    else if (r.Cells[1].Value.ToString() == txtName.Text)   //已存在該成員Name
                    {
                        executeSql(getUpdateSql());
                        timer畫面運作.Start();
                        timer照相.Interval = 1000;        //執行重新拍5連拍
                        timer照相.Enabled = true;
                        timer照相.Start();
                        l_bln_新成員 = false;
                        lblResult.Visible = false;
                        lblResult.Text = "修改成功";
                        break;
                    }
                    else continue;
                }

                if (l_bln_新成員)             //true為新成員Name,Insert Name and Email資料到tMember
                {
                    executeSql(getInsertSql());
                    timer畫面運作.Start();
                    timer照相.Interval = 1000;    //單位每秒
                    timer照相.Enabled = true;
                    timer照相.Start();
                    lblResult.Visible = false;

                }
                else return;
            }
            else return;


        }

        private void timer照相_Tick(object sender, EventArgs e)
        {
            開啟攝影機();
            try
            {
                // Query 攝影機的畫面
                Image<Bgr, Byte> phtoFrame = cap.QueryFrame();
                picLoading.Visible = true;
                btnCapture.Visible = false;
                lblCaptureStar.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnReflash.Enabled = false;
                btnClearAll.Enabled = false;
                btn開關.Enabled = false ;
                txtName.Enabled = false;
                txtEmail.Enabled = false;
                checkBox1.Enabled = false;
                btnPreviousPic.Enabled = false;
                btnNextPic.Enabled = false;
                lblResult.ForeColor = Color.Black;
                dataGridView1.Visible = false;


                if (count <= 5) //動作計次
                {
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = "建立臉部資料中 ... 請將臉部對準鏡頭";
                    lblResult.Visible = true;
                    //儲存照片檔名
                    fileName = string.Format("{0}{1}{2}{3}", phtoDirectory, txtName.Text, count, ".JPG");

                    //儲存影像
                    phtoFrame.Save(fileName);
                    picLoading.Image = new Bitmap(Environment.CurrentDirectory + @"\pic\loading.gif");

                    //上傳照片位置資料到sql.tPhoto
                    MemberID = GetMumberIDsql();
                    fileName = string.Format("{0}{1}{2}", txtName.Text, count, ".JPG");
                    executeSql(getInsertPhoto(fileName));

                    //改回正確fileName
                    fileName = string.Format("{0}{1}{2}{3}", phtoDirectory, txtName.Text, count, ".JPG");
                    count++;
                }
                else
                {
                    timer照相.Stop();
                    timer照相.Enabled = false;  //計時器關閉
                    picLoading.Visible = false;
                    lblResult.Visible = false;
                    MessageBox.Show("已建立臉部資料庫").ToString();
                    //關閉Webcam, show最後一張照片
                    timer畫面運作.Stop();

                    btnCapture.Visible = true;
                    lblCaptureStar.Visible = true;
                    btnUpdate.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnReflash.Enabled = true;
                    btnClearAll.Enabled = true;
                    btn開關.Enabled = true;
                    txtName.Enabled = true;
                    txtEmail.Enabled = true;
                    checkBox1.Enabled = true;
                    btnPreviousPic.Enabled = true;
                    btnNextPic.Enabled = true;
                    pictureBox1.ImageLocation = fileName;

                    lblResult.Text = "成員新增成功";
                    lblResult.ForeColor = Color.Green;
                    lblResult.Visible = true;

                    ds.Clear();
                    GrideViewLoadDataFromSql();
                    dataGridView1.Visible = true;

                    count = 1;
                }
            }
            catch
            {
                return;
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_CursorChanged(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)    //GridView看所有成員
        {

            int index = e.RowIndex;
            if (index == -1)            //預防選到title row造成當機
                return;
            else
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                if (selectedRow.Cells[1].Value.ToString() == "")        //預防空白row造成當機
                    return;
                else
                {
                    txtName.Text = selectedRow.Cells[1].Value.ToString();
                    txtEmail.Text = selectedRow.Cells[2].Value.ToString();
                    checkBox1.Checked = Convert.ToBoolean(selectedRow.Cells[3].Value);
                    //GridView顯示成員照片
                    fileName = string.Format("{0}{1}{2}{3}", phtoDirectory, txtName.Text, count, ".JPG");
                    pictureBox1.ImageLocation = fileName;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)   //顯示上一張照片
        {
            count--;
            if (count < 1)
            {
                count = 5;
                return;
            }
            else
            {
                fileName = string.Format("{0}{1}{2}{3}", phtoDirectory, txtName.Text, count, ".JPG");
                //pictureBox1.Image = Image.FromFile(fileName);  //這樣寫不好,刪除時占住記憶體空間,造成刪除失敗
                pictureBox1.ImageLocation = fileName;
            }
        }

        private void btnNextPic_Click(object sender, EventArgs e)   //顯示下一張照片
        {
            count++;
            if (count > 5)
            {
                count = 1;
                return;
            }
            else
            {
                fileName = string.Format("{0}{1}{2}{3}", phtoDirectory, txtName.Text, count, ".JPG");
                pictureBox1.ImageLocation = fileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnReflash_Click(object sender, EventArgs e)
        {
            ds.Clear();
            GrideViewLoadDataFromSql();
            dataGridView1.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            lblResult.Text = "全部家庭成員如下:";
            lblResult.ForeColor = Color.Green;
            lblResult.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            VerifyText_for_txtName_txtEmail();
            if (l_bln_NameValid && l_bln_EmailValid)    //姓名 and Email格式皆正確
            {
                loadCheckBox();
                executeSql(getUpdateSql());
                if (MemberID == 999)
                {
                    lblResult.Text = "修改失敗,無此成員" + txtName.Text + "。" + "\r\n" +
                        "如要新增成員,請按新增成員";
                    lblResult.ForeColor = Color.Red;
                    lblResult.Visible = true;
                }
                else
                {
                    ds.Clear();
                    GrideViewLoadDataFromSql();
                    lblResult.Text = "修改成功";
                    lblResult.ForeColor = Color.Green;
                    lblResult.Visible = true;
                }
            }
            else return;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult myResult;
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Visible = true;
                lblResult.Text = "請選擇要刪除的成員";
            }
            else
            {
                myResult = MessageBox.Show("確認刪除: " + txtName.Text + "的所有資料嗎?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (myResult == DialogResult.OK)
                {
                    pictureBox1.Image.Dispose();         //Dispose pictureBox1與照片的記憶體配置 

                    for (int countDelete = 1; countDelete < 6; countDelete++)  //刪除照片檔案實體, countDelete刪5張照片
                    {
                        fileName = string.Format("{0}{1}{2}{3}", phtoDirectory, txtName.Text, countDelete, ".JPG");
                        File.Delete(fileName);
                    }
                    executeSql(getDeleteSql());
                    lblResult.Text = "刪除" + txtName.Text + "成功";
                    ClearAll();
                    lblResult.ForeColor = Color.Red;
                    lblResult.Visible = true;
                    ds.Clear();
                    GrideViewLoadDataFromSql();
                    dataGridView1.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                }
                else
                {
                    //No delete
                    return;
                }
            }
                
        }

        private void btnClearAll_Click(object sender, EventArgs e)      //刪除成員
        {
            ClearAll();
        }

        private void ClearAll()                 //清除所有欄位
        {
            txtName.Text = "";
            txtEmail.Text = "";
            checkBox1.Checked = true;
            pictureBox1.Image = null;
            dataGridView1.Visible = false;
            lblResult.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            bln攝影機運作 = false;
            btn開關.Text = "開啟攝影機";
            timer畫面運作.Stop();
            btnCapture.Visible = false;
            lblCaptureStar.Visible = false;
            pictureBox1.Image = null;

        }

        private bool IsValidEmail(string email)     //Mail格式檢查
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                txtEmail.Text = "";
                return true;        //允許不輸入Email
            }

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
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
