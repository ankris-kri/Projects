using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneDirectory
{
    public partial class Form1 : Form
    {
        private BusinessLayer businesslayer = new BusinessLayer();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           Result result= businesslayer.Search();
            dataGridView1.DataSource = result.value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            long _number;
            if (!(long.TryParse(textBox2.Text, out _number)))
                MessageBox.Show("invalid number");
            else
            {
                PhoneDirectory phonedirectory = new PhoneDirectory(textBox1.Text, _number);
                Error error = businesslayer.Add(phonedirectory);
                if (error.iserror)
                    MessageBox.Show(error.description);
                else
                {
                    Result result = businesslayer.Search();
                    dataGridView1.DataSource = result.value;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            Result result = businesslayer.Search(textBox3.Text);
            dataGridView1.DataSource = result.value;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            textBox3.Text = "";
        }
    }
    class PhoneDirectory
    {
        public string name;
        public long number;
        public PhoneDirectory(String _LocalName, long _LocalNumber)
        {
            name = _LocalName;
            number = _LocalNumber;
        }
    }
    class Result
    {
        public DataTable value;
    }
    class Error
    {
        public bool iserror;
        public String description;
    }
    class BusinessLayer
    {
        Repository repository = new Repository();
        public Result Search(String _enteredstring="")
        {
            int _number;
            if(_enteredstring=="")
                return repository.SearchAll();
            else if (int.TryParse(_enteredstring, out _number))
            {
                return repository.SearchByNumber(_number);
            }
            else
            {   
                return repository.SearchByName(_enteredstring);
            }
        }
        public Error Add(PhoneDirectory phonedirectory)
        {
           Error error= Validate(phonedirectory.number);
            if (error.iserror==false)
            {
               return repository.Add(phonedirectory);
            }
            return error;
        }
        public Error Validate(long _number)
        {
            Error error = new Error();
            if (_number.ToString().Length != 10)
            {
                error.iserror = true;
                error.description = "number should be of length 10";
            }
            else
                error.iserror = false;
            return error;
        }
    }
    class Repository
    {
        Result result = new Result();
        Error error = new Error();
        public Result SearchAll()
        {
            using (SqlConnection sq = new SqlConnection("Server=localhost;Database=Krishna;Trusted_Connection=true"))
            {
                sq.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("SELECT * FROM PhoneDirectory", sq);
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                result.value = t;
                return result;
            }
        }
        public Result SearchByName(String _name)
        {
            using (SqlConnection sq = new SqlConnection("Server=localhost;Database=Krishna;Trusted_Connection=true"))
            {
                sq.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("select * from PhoneDirectory where Name=@phone", sq);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@phone",_name);
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                result.value = t;
                return result;
            }
        }
        public Result SearchByNumber(int _number)
        {
            using (SqlConnection sq = new SqlConnection("Server=localhost;Database=Krishna;Trusted_Connection=true"))
            {
                sq.Open();
                SqlDataAdapter _dataadapter = new SqlDataAdapter("select * from PhoneDirectory where Number=@phone", sq);
                _dataadapter.SelectCommand.Parameters.AddWithValue("@phone", _number);
                DataTable t = new DataTable();
                _dataadapter.Fill(t);
                result.value = t;
                return result;
            }
        }
        public Error Add(PhoneDirectory phonedirectory)
        {
            try
            {
                using (SqlConnection sq = new SqlConnection("Server=localhost;Database=Krishna;Trusted_Connection=true"))
                {
                    sq.Open();
                    var cmd = new SqlCommand("Insert into PhoneDirectory values(@name,@phone)");
                    cmd.Connection = sq;
                    cmd.Parameters.AddWithValue("@name", phonedirectory.name);
                    cmd.Parameters.AddWithValue("@phone", phonedirectory.number);
                    cmd.ExecuteNonQuery();
                    error.iserror = false;
                    return error;
                }
            }
            catch (Exception e)
            {
                error.iserror = true;
                error.description = e.ToString();
                return error;
            }
        }
    }
}
