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
                    PhoneDirectory phone = new PhoneDirectory(_name, _number);
                    BusinessLayer phoneDetail = new BusinessLayer();
                    bool result=phoneDetail.ValidateAndAdd(phone);
                    if (result == true)
                    {    
                         
                        dataGridView1.DataSource = phoneDetail.ViewPhone(phone);
                        Number_Textbox.Clear();
                        Name_Textbox.Clear();
                    }
                        
                    else
                    {
                        MessageBox.Show("cannot be Added");

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
             BusinessLayer phoneDetail = new BusinessLayer();
             dataGridView1.DataSource = phoneDetail.Search(textBox3.Text);

             //int _number;
             //String _name;

             //if (int.TryParse(textBox3.Text, out _number))
             //{
             //    DataTable t = phoneDetail.Search("select * from Phone_dir where Phone=@phone", _number);
             //}
             //else
             //{
             //    _name = textBox3.Text;
             //    DataTable t = phoneDetail.Search("select * from Phone_dir where Name=@phone", _name);
             //}
             //SqlDataAdapter _dataadapter;

             //using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
             //{
             //    sq.Open();
             //    if (int.TryParse(textBox3.Text, out _number))
             //    {

             //        _dataadapter = new SqlDataAdapter("select * from Phone_dir where Phone=@phone", sq);
             //        _dataadapter.SelectCommand.Parameters.AddWithValue("@phone", _number);

             //    }
             //    else
             //    {
             //        _name = textBox3.Text;
             //        _dataadapter = new SqlDataAdapter("select * from Phone_dir where Name=@name", sq);
             //        _dataadapter.SelectCommand.Parameters.AddWithValue("@name", _name);
             //    }

             //    DataTable t = new DataTable();
             //    _dataadapter.Fill(t);
             //    dataGridView1.DataSource = t;
             //}
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
    class PhoneDirectory
    {
        public string name;
        public int number;
        public PhoneDirectory(String _LocalName,int _LocalNumber)
        {
            name = _LocalName;
            number = _LocalNumber;
        }

    }
    class BusinessLayer
    {
  
        public PhoneDirectoryRepository repository=new PhoneDirectoryRepository();

       
        public bool ValidateAndAdd(PhoneDirectory phoneDetails)
        {
            bool _validateResult=ValidatePhone();
            if (_validateResult==true)
            {
                return repository.Add(phoneDetails);
                   
            }
            else
                return false;
           
        }
        private bool ValidatePhone()
        {
            return true;
        }
        public DataTable ViewPhone(PhoneDirectory phoneDetails)
        {
            return repository.viewAll();
        }
        public DataTable Search(String s)
        {

        }


    }
    class PhoneDirectoryRepository
    {
      //  private PhoneDirectory _directory;
        public string Name { get; private set; }
        public PhoneDirectoryRepository()
        {
           // _directory=_localDirectory;
        }
        public bool Add(PhoneDirectory directory)
        {
            try
            {
                using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
                {
                    sq.Open();
                    var cmd = new SqlCommand("Insert into phone_dir values(@name,@phone)");
                    cmd.Connection = sq;
                    cmd.Parameters.AddWithValue("@name",directory.name);
                    cmd.Parameters.AddWithValue("@phone",directory.number);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception)
            {
                return false;
            }

        }
        public DataTable viewAll()
        {
            using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
            {
                sq.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("SELECT * FROM phone_dir", sq);
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                return t;
               
            }
        }
        public DataTable Search(string sql,string value)
        {
            using (SqlConnection sq = new SqlConnection("Server=localhost;Database=phone_directory;Trusted_Connection=true"))
            {
                sq.Open();
                if(int.TryParse(textBox3.Text,out _number))
                SqlDataAdapter _dataadapter = new SqlDataAdapter(sql, value);

            }
        }
      
       
        
    }
}
