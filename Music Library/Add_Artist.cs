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
    public partial class Form_Add : Form
    {
        string conn_string = "user id=root;persistsecurityinfo=True;server=localhost;database=music_library;password=aamir";

        public Form_Add()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conn_string);
            con.Open();
            MySqlCommand comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO artists(name) VALUES('" + textBox1.Text + "')";
            comm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Artist Added Successfully");
        }
    }
}
