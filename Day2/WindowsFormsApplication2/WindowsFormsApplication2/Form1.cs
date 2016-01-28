using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
      

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String _name = Name_Textbox.Text;
                int _number;
                if (!(int.TryParse(Number_Textbox.Text, out _number)))
                {
                    MessageBox.Show("Invalid Number");
                    Number_Textbox.Clear();
                }
                else
                {

                    using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
                    {
                        sq.Open();
                       
                        var cmd = new SqlCommand("Insert into phone_dir values(@name,@phone)");
                        cmd.Connection = sq;
                        cmd.Parameters.AddWithValue("@name", _name);
                        cmd.Parameters.AddWithValue("@phone", _number);
                        cmd.ExecuteNonQuery();

                        SqlCommand command = new SqlCommand("select * from phone_dir",sq);
                        var result = command.ExecuteNonQuery();
                        

                    }

                    string connectionString = "Server=localhost;Database=phone_directory;Trusted_Connection=true";
                    string sql = "SELECT * FROM phone_dir";
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    connection.Open();
                    dataadapter.Fill(ds, "dataGridView1");
                    connection.Close();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "dataGridView1";

                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

         
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox3.Text,out _number)
            {

            }
        }

        private void Name_Textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
