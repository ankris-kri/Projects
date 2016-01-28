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
                    }
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

        }

        private void Name_Textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
