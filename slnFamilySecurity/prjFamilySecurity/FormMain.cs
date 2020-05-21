using prjFamilySecurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFamilySecurity
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void MethNorepeat(Form x) //控制視窗不重複開啟&倒入Mdi容器中
        {
            //檢查父視窗每一個子視窗
            foreach (Form f in this.MdiChildren)
            {
                //如果子視窗已經存在
                if (f.Name == x.Name)
                {
                    //將該子視窗設為焦點
                    f.Focus();
                    return;
                }
            }
            x.MdiParent = this;
            x.Show();
        }

        private void lbl成員資料_Click(object sender, EventArgs e)
        {
            FormMember x = new FormMember();
            MethNorepeat(x);
        }

        private void lbl辨識紀錄_Click(object sender, EventArgs e)
        {
            FormRecord x = new FormRecord();
            MethNorepeat(x);
        }

        private void lbl設定_Click(object sender, EventArgs e)
        {
            FormSetting x = new FormSetting();
            MethNorepeat(x);
        }

        private void lbl登出_Click(object sender, EventArgs e)
        {
            // 確認視窗
            DialogResult msgbox = MessageBox.Show("是否登出?", "即將登出並關閉程式", MessageBoxButtons.OKCancel);
            if (msgbox == DialogResult.OK)
            {
                Application.Exit();
            }
            else if (msgbox == DialogResult.Cancel)
            {
                return;
            }
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //panel1.BackColor = Color.FromArgb(0, 162, 232);
            (new FormLogin()).ShowDialog();
            FormMember x = new FormMember();
            x.MdiParent = this;
            x.Show();
        }

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
