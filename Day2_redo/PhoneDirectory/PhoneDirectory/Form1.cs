using System;
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
                MessageBox.Show("invalid number");
            else
            {
                PhoneEntry phonedirectory = new PhoneEntry(textBox1.Text, _number);
                ErrorDto error = businesslayer.Add(phonedirectory);
                if (error.isError)
                    MessageBox.Show(error.description);
                else
                {
                    grid_view(null);
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            grid_view(textBox3.Text);
        }
        private void grid_view(String inputArg)
        {
            dataGridView1.Rows.Clear();
            var result = businesslayer.Search(inputArg);
            foreach (PhoneEntry phoneEntry in result)
            {
                dataGridView1.Rows.Add(phoneEntry.name, phoneEntry.number);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            textBox3.Text = "";
        }
    }
}
