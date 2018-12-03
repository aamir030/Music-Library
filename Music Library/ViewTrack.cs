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
    public partial class ViewTrack : Form
    {
        string conn_string = "user id=root;persistsecurityinfo=True;server=localhost;database=music_library;password=aamir";

        public ViewTrack()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "select * from tracks";
            MySqlConnection con = new MySqlConnection(conn_string);
            con.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            MyDA.SelectCommand = new MySqlCommand(sql, con);
            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;
            dataGridView1.AutoResizeColumns();
            con.Close();
        }

        private void ViewTrack_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string u = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

         
            try
            {

                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = u;
                wplayer.controls.play();
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}


