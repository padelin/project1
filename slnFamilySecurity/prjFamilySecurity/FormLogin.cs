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
    public partial class FormLogin : Form
    {
        bool isAllClose = true;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void lbl登入_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=FamilySecurity;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tFamily WHERE Account='"
                + txtId.Text.Trim() + "' AND Password='" + txtPassword.Text.Trim() + "'";

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                isAllClose = false;
                lblMessage.Visible = false;
                CGlobal.FamilyID = (int)reader[0];
                con.Close();
                Close();
            }
            else
            {
                lblMessage.Visible = true;
            }
            con.Close();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAllClose == true)
            {
                Application.Exit();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(0, 162, 232);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Label).Image = picDown.Image;
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Label).Image = picUp.Image;
        }
    }
}
