using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFamilySecurity
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            ControlBox = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Account,Password,Phone,Address FROM tFamily WHERE FamilyID=" + CGlobal.FamilyID;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbl帳號.Text = reader["Account"].ToString();
                txt密碼.Text = reader["Password"].ToString();
                lbl電話.Text = reader["Phone"].ToString();
                lbl地址.Text = reader["Address"].ToString();
            }
        }

        private void lbl密碼變更_Click(object sender, EventArgs e)
        {
            lbl密碼.Visible = false;
            txt密碼.Visible = true;
            lbl密碼確認.Visible = true;
            lbl密碼取消.Visible = true;
            lbl密碼變更.Visible = false;
        }

        private void lbl電話變更_Click(object sender, EventArgs e)
        {
            lbl電話.Visible = false;
            txt電話.Visible = true;
            lbl電話確認.Visible = true;
            lbl電話取消.Visible = true;
            lbl電話變更.Visible = false;
        }

        private void lbl地址變更_Click(object sender, EventArgs e)
        {
            lbl地址.Visible = false;
            txt地址.Visible = true;
            lbl地址確認.Visible = true;
            lbl地址取消.Visible = true;
            lbl地址變更.Visible = false;
        }

        private void lbl密碼取消_Click(object sender, EventArgs e)
        {
            lbl密碼.Visible = true;
            txt密碼.Visible = false;
            lbl密碼確認.Visible = false;
            lbl密碼取消.Visible = false;
            lbl密碼變更.Visible = true;
        }

        private void lbl電話取消_Click(object sender, EventArgs e)
        {
            lbl電話.Visible = true;
            txt電話.Visible = false;
            lbl電話確認.Visible = false;
            lbl電話取消.Visible = false;
            lbl電話變更.Visible = true;
        }

        private void lbl地址取消_Click(object sender, EventArgs e)
        {
            lbl地址.Visible = true;
            txt地址.Visible = false;
            lbl地址確認.Visible = false;
            lbl地址取消.Visible = false;
            lbl地址變更.Visible = true;
        }

        private void lbl密碼確認_Click(object sender, EventArgs e)
        {
            // 確認視窗
            DialogResult msgbox = MessageBox.Show("確認更改密碼?", "密碼即將變更", MessageBoxButtons.OKCancel);
            if (msgbox == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tFamily SET Password = '" + txt密碼.Text + "'  WHERE FamilyID=" + CGlobal.FamilyID;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT Password FROM tFamily WHERE FamilyID=" + CGlobal.FamilyID;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //lbl密碼.Text = reader["Password"].ToString();
                }
                con.Close();
            }
            else if (msgbox == DialogResult.Cancel)
            {
                lbl密碼.Visible = true;
                txt密碼.Visible = false;
                lbl密碼確認.Visible = false;
                lbl密碼取消.Visible = false;
                lbl密碼變更.Visible = true;
            }

            lbl密碼.Visible = true;
            txt密碼.Visible = false;
            lbl密碼確認.Visible = false;
            lbl密碼取消.Visible = false;
            lbl密碼變更.Visible = true;
        }

        private void lbl電話確認_Click(object sender, EventArgs e)
        {
            // 確認視窗
            DialogResult msgbox = MessageBox.Show("確認更改密碼?", "密碼即將變更", MessageBoxButtons.OKCancel);
            if (msgbox == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tFamily SET Phone = '" + txt電話.Text + "'  WHERE FamilyID=" + CGlobal.FamilyID;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT Phone FROM tFamily WHERE FamilyID=" + CGlobal.FamilyID;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lbl電話.Text = reader["Phone"].ToString();
                }
                con.Close();
            }
            else if (msgbox == DialogResult.Cancel)
            {
                lbl電話.Visible = true;
                txt電話.Visible = false;
                lbl電話確認.Visible = false;
                lbl電話取消.Visible = false;
                lbl電話變更.Visible = true;
            }

            lbl電話.Visible = true;
            txt電話.Visible = false;
            lbl電話確認.Visible = false;
            lbl電話取消.Visible = false;
            lbl電話變更.Visible = true;
        }

        private void lbl地址確認_Click(object sender, EventArgs e)
        {
            // 確認視窗
            DialogResult msgbox = MessageBox.Show("確認更改密碼?", "密碼即將變更", MessageBoxButtons.OKCancel);
            if (msgbox == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tFamily SET Address = '" + txt地址.Text + "'  WHERE FamilyID=" + CGlobal.FamilyID;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT Address FROM tFamily WHERE FamilyID=" + CGlobal.FamilyID;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lbl地址.Text = reader["Address"].ToString();
                }
                con.Close();
            }
            else if (msgbox == DialogResult.Cancel)
            {
                lbl地址.Visible = true;
                txt地址.Visible = false;
                lbl地址確認.Visible = false;
                lbl地址取消.Visible = false;
                lbl地址變更.Visible = true;
            }

            lbl地址.Visible = true;
            txt地址.Visible = false;
            lbl地址確認.Visible = false;
            lbl地址取消.Visible = false;
            lbl地址變更.Visible = true;
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
