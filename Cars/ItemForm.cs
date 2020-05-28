using System;
using System.Windows.Forms;

namespace Cars
{
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();
        }

        MainForm m;
        string choise;
        public ItemForm(MainForm m, string c)
        {
            InitializeComponent();
            this.m = m;
            this.choise = c;
        }
        private string b, t; private int y; private double p;
        public ItemForm(string b, string t, int y, double p)
        {
            this.b = b;
            this.t = t;
            this.y = y;
            this.p = p;
            //this.choise = c;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            labelPlease.Text = labelPlease.Text + choise;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var b = Validation.if_word(textBox1.Text);
                var t = Validation.if_word(textBox2.Text);
                var y = Validation.if_year(textBox3.Text);
                var p = Validation.if_price(textBox4.Text);
                var res = MessageBox.Show("Adding", "Accept", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (res == DialogResult.OK)
                {
                    m.dataGridView1.Rows.Add(b, t, y, p);
                }
                else new ItemForm();
            }
            catch
            {
                MessageBox.Show("Can`t Add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string b = Validation.if_word(textBox1.Text);
                string t = Validation.if_word(textBox2.Text);
                int y = Validation.if_year(textBox3.Text);
                double p = Validation.if_price(textBox4.Text);
                var res = MessageBox.Show("Editing", "Accept", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (res == DialogResult.OK)
                {
                    m.update(b, t, y, p);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Can`t update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
