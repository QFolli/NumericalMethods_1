using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabWork1
{
    public partial class Form1 : Form
    {
        const int left = -10;
        const int right= 10;
        int count = 0;

        public Form1()
        {
            this.MaximizeBox = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButtonBis.Checked=true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h = Convert.ToDouble(textBox1.Text);
            List<Data> list = new List<Data>();

            if (radioButtonBis.Checked)
            {
                list = Equation.Bissection(left,right,h,count);
            }
            else if (radioButtonNew.Checked)
            {
                list = Equation.Newton(left, right, h, count);
            }
            else if (radioButtonHord.Checked)
            {
                list = Equation.Chord(left, right, h, count);
            }

            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item.RefinedRoot, item.UptoDate, item.FuncUptoDate, item.Count);
            }

            chart1.Series[0].Points.Clear();

            for (double i = left; i <= right; i += 0.1)
            {
                double y = Math.Tan(i) - i;
                chart1.Series[0].Points.AddXY(i, y);
            }
        }
    }
}
