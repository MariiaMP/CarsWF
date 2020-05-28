using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cars
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            //chart1.Series["Price"].Points.AddXY[];

            //Chart chart1 = new Chart();
            MainForm a = new MainForm();
            //chart1.Series["Price"] = new Series();
            //chart1.Series["Price"].XValueMember = m.dataGridView1.Columns[0].DataPropertyName;
            //chart1.Series["Price"].YValueMembers = m.dataGridView1.Columns[3].DataPropertyName;
            //chart1.DataSource = m.dataGridView1.DataSource;
            ////chart1.DataBind();
            //chart1.Series["Price"].ChartType = SeriesChartType.Line;
            //chart1.SaveImage("chart.png", ChartImageFormat.Png);
            try
            {
                chart1.DataSource = m.dataGridView1;
                double x = 0, y = 0;
                //for (int i = 0; i < m.dataGridView1.Rows.Count - 1; i++)
                {
                    //x = double.Parse(m.dataGridView1.Rows[i].Cells[0].Value.ToString());
                    //y = double.Parse(m.dataGridView1.Rows[i].Cells[3].Value.ToString());

                    //this.chart1.Series["Price"].Points.AddXY("a", 15);
                    //this.chart1.Series["Price"].Points.AddXY("b", 25);
                    //this.chart1.Series["Price"].Points.AddXY("c", 5);

                    //chart1.Series["Price"].XValueMember = m.dataGridView1.Columns[0].DataPropertyName;
                    //chart1.Series["Price"].YValueMembers = m.dataGridView1.Columns[3].DataPropertyName;
                    //chart1.Series["Price"].Points.AddXY();

                    //chart1.Series[0].Points.DataBindXY(m.dataGridView1.Rows[0].Cells[0].Value.ToString(), m.dataGridView1.Rows[0].Cells[1].Value.ToString());
                    
                }
            }
            catch
            {
                MessageBox.Show("No chart...");
            }
        }
    }
}
