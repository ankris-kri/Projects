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
using System.Configuration;

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
}
