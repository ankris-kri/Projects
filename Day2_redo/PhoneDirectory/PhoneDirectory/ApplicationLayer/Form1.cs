using System;
using System.Windows.Forms;

namespace PhoneDirectory
{
    public partial class Form1 : Form
    {
        public string searchBy { get; set; }
        private BusinessLayer businessLayer = new BusinessLayer();
        private ErrorDto error { get; set; }

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
            grid_view(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long _number;
            if (!(long.TryParse(textBox2.Text, out _number)))
            {
                MessageBox.Show("Invalid Number");
            }
            else
            {
                var phonedirectory = new PhoneEntry(textBox1.Text, _number);
                if (phonedirectory.IsValidNumber())
                {
                    error = businessLayer.Add(phonedirectory);
                    if (error.isError)
                    {
                        MessageBox.Show(error.description);
                        error.isError = false;
                    }
                    else
                    {
                        grid_view(null);
                        textBox1.Clear();
                        textBox2.Clear();
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
                MessageBox.Show("Invalid Number");
                textBox3.Clear();
            }
            else
                grid_view(textBox3.Text);
        }

        private void grid_view(String inputArg)
        {
            dataGridView1.Rows.Clear();
            var result = businessLayer.Search(searchBy,inputArg);
            foreach (PhoneEntry phoneEntry in result)
            {
                dataGridView1.Rows.Add(phoneEntry.name, phoneEntry.number);
            }
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            searchBy = comboBox1.SelectedItem.ToString();
        }
    }
}
