using System;
using System.Windows.Forms;

namespace PhoneDirectory
{
    public partial class Form1 : Form
    {
        public string searchBy { get; set; }
        private BusinessLayer businessLayer = new BusinessLayer();
        private ErrorValidation validation { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Name";
            searchBy = "Name";
            
            dataGridView1.ReadOnly = true;           
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Number";
            gridDisplay(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long _number;
            if ((!(long.TryParse(textBox2.Text, out _number))) | _number==0)
            {
                MessageBox.Show("Invalid Number");
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text) | textBox1.Text.StartsWith(" "))
            {
                MessageBox.Show("Invalid Name");
            }
            else
            {
                var _phoneEntry = new PhoneEntry(textBox1.Text, _number);
                if (_phoneEntry.IsValidNumber())
                {
                    validation = businessLayer.AddToDictionary(_phoneEntry);
                    if (validation.isError)
                    {
                        MessageBox.Show(validation.description);
                        validation.isError = false;
                    }
                    else
                    {
                        gridDisplay(null);
                        button2_Click(sender,e);
                    }
                }
                else
                    MessageBox.Show("Number should be of length 10");
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            long dummyNumber;
            if (searchBy=="Number" && (!(long.TryParse(textBox3.Text, out dummyNumber))))
            {
                if(!(textBox3.Text==""))
                MessageBox.Show("Invalid Number");
            }
            else
                gridDisplay(textBox3.Text);
        }

        private void gridDisplay(String inputArg)
        {
            dataGridView1.Rows.Clear();
            var result = businessLayer.SearchDictionary(searchBy,inputArg);
            foreach (PhoneEntry phoneEntry in result)
            {
                dataGridView1.Rows.Add(phoneEntry.name, phoneEntry.number);
            }
            dataGridView1.ClearSelection();
        }

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            searchBy = comboBox1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            string beforeLoad= searchBy;
            Form1_Load(sender, e);
            comboBox1.SelectedItem = beforeLoad;
            searchBy = beforeLoad;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
