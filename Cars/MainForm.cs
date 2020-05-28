using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Cars
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(4000);
            InitializeComponent();
            t.Abort();
        }
        private void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public static List<Cars> collection = new List<Cars>();
        public string filename;
        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                filename = openFileDialog1.FileName;
                var studColl = File.ReadLines(filename);
                foreach (var item in studColl)
                {
                    string[] a = item.Split(' ');
                    Cars c = new Cars
                    {
                        brand = a[0],
                        type = a[1],
                        year = int.Parse(a[2]),
                        price = double.Parse(a[3]),
                    };
                    collection.Add(c);
                    dataGridView1.Rows.Add(c.brand, c.type, c.year, c.price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Somth wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridView1.RowCount;
            int columnCount = dataGridView1.ColumnCount;
            string[] line = new string[columnCount];

            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        line[j] = (dataGridView1.Rows[i].Cells[j].Value ?? "").ToString();
                    }
                    writer.WriteLine(string.Join(" ", line));
                }
            }
            MessageBox.Show("Is saved!");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridView1.RowCount;
            int columnCount = dataGridView1.ColumnCount;
            string[] line = new string[columnCount];
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            line[j] = (string)(dataGridView1.Rows[i].Cells[j].Value ?? "").ToString();
                        }
                        writer.WriteLine(string.Join(" ", line));
                    }
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm it = new ItemForm(this, "Add");
            it.Show();
        }

        int selectedRow;
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
        }

        public void update(string b, string t, int y, double p)
        {
            ItemForm it = new ItemForm();
            dataGridView1.CurrentRow.Cells[0].Value = b;
            dataGridView1.CurrentRow.Cells[1].Value = t;
            (dataGridView1.CurrentRow.Cells[2].Value) = y;
            (dataGridView1.CurrentRow.Cells[3].Value) = p;
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[selectedRow];

            ItemForm it = new ItemForm(this, "Edit");
            it.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            it.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            it.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            it.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            it.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                var res = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Somth wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            int n = int.Parse(comboBoxSortBy.Text);
            dataGridView1.Sort(dataGridView1.Columns[n], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //var list = collection.ToList();
                Validation.if_price(textBoxSearch1.Text);
                var search = from a in collection
                             where a.price < double.Parse(textBoxSearch1.Text)
                             select a;
                MainForm m = new MainForm();
                foreach (var i in search)
                {
                    m.dataGridView1.Rows.Add(i.brand, i.type, i.year, i.price);
                }
                m.Show();
            }
            catch
            {
                MessageBox.Show("Can`t search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemForm it = new ItemForm();
            it.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            it.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            it.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            it.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
            it.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxSearch_MouseHover(object sender, EventArgs e)
        {
            textBoxSearch1.Text = "input the highest price";
        }

        private void textBoxSearch_MouseLeave(object sender, EventArgs e)
        {
            textBoxSearch1.Text = "";
        }

        private void textBoxSearch2_MouseHover(object sender, EventArgs e)
        {
            textBoxSearch2.Text = "The cheaper car of brand";
        }

        private void textBoxSearch2_MouseLeave(object sender, EventArgs e)
        {
            textBoxSearch2.Text = "";
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                var search = from a in collection
                             where a.brand == textBoxSearch2.Text && a.price < double.Parse(textBoxSearch1.Text)
                             select a;
                MainForm m = new MainForm();
                foreach (var i in search)
                {
                    m.dataGridView1.Rows.Add(i.brand, i.type, i.year, i.price);
                }
                m.Show();
            }
            catch
            {
                MessageBox.Show("Can`t search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void buttonSetNewPrice_Click(object sender, EventArgs e)
        {
            try
            {
                Validation.if_year(textBoxNewPrice.Text);
                var search = from a in collection
                             where a.year <= int.Parse(textBoxNewPrice.Text)
                             orderby a.price -= 100
                             select a;
                MainForm m = new MainForm();
                foreach (var i in search)
                {
                    m.dataGridView1.Rows.Add(i.brand, i.type, i.year, i.price);
                }
                m.Show();
            }
            catch
            {
                MessageBox.Show("Can`t search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart c = new Chart();
            c.Show();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileWithProgramTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Windows Forms program. You can add, edit, delete cars collection in datagridview. You can sort, search using ling query, read file, save to files, create chart...", "View help");
        }

        private void wikipediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://uk.wikipedia.org/wiki/%D0%9B%D1%8C%D0%B2%D1%96%D0%B2%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D0%BD%D0%B0%D1%86%D1%96%D0%BE%D0%BD%D0%B0%D0%BB%D1%8C%D0%BD%D0%B8%D0%B9_%D1%83%D0%BD%D1%96%D0%B2%D0%B5%D1%80%D1%81%D0%B8%D1%82%D0%B5%D1%82_%D1%96%D0%BC%D0%B5%D0%BD%D1%96_%D0%86%D0%B2%D0%B0%D0%BD%D0%B0_%D0%A4%D1%80%D0%B0%D0%BD%D0%BA%D0%B0");
        }
    }
}
