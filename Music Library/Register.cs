using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Music_Library
{
    public partial class Form_Register : Form
    {
        string conn_string = "user id=root;persistsecurityinfo=True;server=localhost;database=music_library;password=aamir";

        public Form_Register()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if(txt_password.Text.Equals(txt_confirmpassword.Text))
            {

                MySqlConnection con = new MySqlConnection(conn_string);
                con.Open();
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "INSERT INTO users(username,password) VALUES('" + txt_username.Text + "','" + txt_password.Text + "')";
                comm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User Added Successfully");
            }
            else
            {
                MessageBox.Show("Password and Confirm Password should be equal");
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
