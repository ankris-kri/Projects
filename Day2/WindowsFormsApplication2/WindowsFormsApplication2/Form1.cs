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
using System.Threading;

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
                   // MessageBox.Show("Invalid Number");             
                      label4.Visible = true;
                     
                }
                else
                {
                    
                    Business_layer phone_detail = new Business_layer(_name, _number);
                    String result=phone_detail.ValidateAndAdd();
                    if (result =="success")
                        using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
                        {
                            sq.Open();
                            SqlDataAdapter _dataadapter = new SqlDataAdapter("SELECT * FROM phone_dir", sq);
                            DataTable t = new DataTable();
                            _dataadapter.Fill(t);
                            dataGridView1.DataSource = t;
                            Number_Textbox.Clear();
                            Name_Textbox.Clear();
                        }
                    else
                    {
                        MessageBox.Show(result);

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
            int _number;
            String _name;
            SqlDataAdapter _dataadapter;
                
            using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
            {
                sq.Open();
                if(int.TryParse(textBox3.Text,out _number))
                {
                    
                    _dataadapter = new SqlDataAdapter("select * from Phone_dir where Phone=@phone", sq);
                    _dataadapter.SelectCommand.Parameters.AddWithValue("@phone",_number);

                }
                else
                {
                    _name=textBox3.Text;
                    _dataadapter = new SqlDataAdapter("select * from Phone_dir where Name=@name", sq);
                    _dataadapter.SelectCommand.Parameters.AddWithValue("@name",_name);
                }

                 DataTable t = new DataTable();
                _dataadapter.Fill(t);
                dataGridView1.DataSource = t;
            }
            textBox3.Clear();
                       
        }

        private void Name_Textbox_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
            {
                sq.Open();

                SqlDataAdapter _dataadapter = new SqlDataAdapter("SELECT * FROM phone_dir", sq);
             
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                dataGridView1.DataSource = t;



            
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
      
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_2(object sender, EventArgs e)
        {

        }

        private void Number_Textbox_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }
    }
    class Phone_directory
    {
        public string name;
        public int number;

        public Phone_directory(String _LocalName,int _LocalNumber)
        {
            name = _LocalName;
            number = _LocalNumber;
        }

    }
    class Business_layer
    {
        private Phone_directory _directory;

        public Business_layer(String _LocalName, int _LocalNumber)
        {
            _directory = new Phone_directory(_LocalName, _LocalNumber);
        }
        public string ValidateAndAdd()
        {
            String _validateResult=ValidatePhone();
            if (_validateResult=="successfully validated")
            {
                PhoneDirectoryRepository repository = new PhoneDirectoryRepository(_directory);
                return repository.Add();
                   
            }
            else
                return _validateResult;
           
        }
        private string ValidatePhone()
        {
            return "successfully validated";
        }

    }
    class PhoneDirectoryRepository
    {
        private Phone_directory _directory;

        public PhoneDirectoryRepository(Phone_directory _localDirectory)
        {
            _directory=_localDirectory;
        }
        public string Add()
        {
            try
            {
                using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
                {
                    sq.Open();
                    var cmd = new SqlCommand("Insert into phone_dir values(@name,@phone)");
                    cmd.Connection = sq;
                    cmd.Parameters.AddWithValue("@name",_directory.name);
                    cmd.Parameters.AddWithValue("@phone",_directory.number);
                    cmd.ExecuteNonQuery();
                    return "success";
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }

        }

       
        
    }
}
