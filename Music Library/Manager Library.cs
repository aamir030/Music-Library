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
    public partial class Form_Manage : Form
    {
        
        string conn_string = "user id=root;persistsecurityinfo=True;server=localhost;database=music_library;password=aamir";


        public Form_Manage()
        {
            InitializeComponent();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            string sql;
            string s = lst_table.GetItemText(lst_table.SelectedItem);
            sql = "select * from " + s;
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            string s = lst_table.GetItemText(lst_table.SelectedItem);
            if(s.Equals("Artists"))
            {
                Form_Add f = new Form_Add();
                f.Show();
            }
            if (s.Equals("Albums"))
            {
                Add_Album f = new Add_Album();
                f.Show();

            }
            if (s.Equals("Users"))
            {
                Add_User f = new Add_User();
                f.Show();
            }
            if (s.Equals("Tracks"))
            {
                Add_Track f = new Add_Track();
                f.Show();
            }
            if (s.Equals("Genres"))
            {
                Add_Genre f = new Add_Genre();
                f.Show();
            }
        }

        private void Form_Manage_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 250;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 45;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lst_table.GetItemText(lst_table.SelectedItem).Equals("Users"))
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    using (MySqlConnection con = new MySqlConnection(conn_string))
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        string u = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        
                        cmd.CommandText = "Delete from users where Id='" + u + "'";

                        dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted");
                    }

                }
            }


            if (lst_table.GetItemText(lst_table.SelectedItem).Equals("Artists"))
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    using (MySqlConnection con = new MySqlConnection(conn_string))
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        string u = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        MessageBox.Show(u);
                        cmd.CommandText = "Delete from artists where name='" + u + "'";

                        dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted");
                    }

                }
            }


            if (lst_table.GetItemText(lst_table.SelectedItem).Equals("Albums"))
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    using (MySqlConnection con = new MySqlConnection(conn_string))
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        string u = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        MessageBox.Show(u);
                        cmd.CommandText = "Delete from albums where name='" + u + "'";

                        dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted");
                    }

                }
            }

            if (lst_table.GetItemText(lst_table.SelectedItem).Equals("Tracks"))
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    using (MySqlConnection con = new MySqlConnection(conn_string))
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        string u = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        MessageBox.Show(u);
                        cmd.CommandText = "Delete from tracks where name='" + u + "'";

                        dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted");
                    }

                }
            }

            if (lst_table.GetItemText(lst_table.SelectedItem).Equals("Genres"))
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    using (MySqlConnection con = new MySqlConnection(conn_string))
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        string u = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        MessageBox.Show(u);
                        cmd.CommandText = "Delete from genres where name='" + u + "'";

                        dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted");
                    }

                }
            }










        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string s = lst_table.GetItemText(lst_table.SelectedItem);

            DataRowView drv = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            DataRow[] rowsToUpdate = new DataRow[] { drv.Row };
            MySqlConnection con = new MySqlConnection(conn_string);
            con.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from " + s ,con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            adapter.Update(rowsToUpdate);
            con.Close();
            MessageBox.Show("Record Updated");
            
        }
    }
}
