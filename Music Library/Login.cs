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
    public partial class Login : Form
    {
        string conn_string = "user id=root;persistsecurityinfo=True;server=localhost;database=music_library;password=aamir";
        public Login()
        {
            
            InitializeComponent();
        }
        public void calladmin()
        {

            MessageBox.Show("Welcome Admin");
            Form_Manage f = new Form_Manage();
            f.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
           
           
            string sql = " SELECT * FROM users  ";
            MySqlConnection con = new MySqlConnection(conn_string);
            MySqlCommand cmd = new MySqlCommand(sql, con);

            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
              
               if(txt_username.Text.Equals(reader.GetString("username")) &&
                    txt_username.Text.Equals(reader.GetString("password")))
                {
                    if (reader.GetString("username").Equals("admin"))
                    {
                        calladmin();
                    }
                    else
                    {
                        MessageBox.Show("Welcome" + " " + reader.GetString("username"));
                        ViewTrack f = new ViewTrack();
                        f.Show();
                    }
                }
                
            }


        }


    }
}
