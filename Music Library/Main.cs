using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Library
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:/Users/nawab/OneDrive/Desktop/image1.jpg");
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();

           
        }

        private void Register_Click(object sender, EventArgs e)
        {
           Form_Register f = new Form_Register();
            f.Show();

        }
    }
}
