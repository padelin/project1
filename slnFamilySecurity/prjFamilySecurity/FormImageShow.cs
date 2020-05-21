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
    public partial class FormImageShow : Form
    {
        string strImgPath = "";

        public FormImageShow(string path)
        {
            InitializeComponent();
            strImgPath = path;
        }

        private void imageShow_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = strImgPath;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void FormImageShow_FormClosed(object sender, FormClosedEventArgs e)
        {
 
        }
    }
}
