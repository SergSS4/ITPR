using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "2";
            textBox2.Text = "Практическая работа №2 Чигаркин С.С.";
            textBox2.Text += Environment.NewLine + "Рассчитать значение выражения y = _вписать сюда свое задание_ ";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);
            textBox2.Text += Environment.NewLine + "При x = " + x.ToString();
            double y = ((Math.Sqrt(1 + Math.Pow(Math.E, Math.Sqrt(x))) + Math.Cos(Math.Pow(x, 2))) / Math.Abs(1 - Math.Pow(Math.Sin(x), 2) * x)) + Math.Log(Math.Abs(2 * x))) ;
            textBox2.Text += Environment.NewLine + "Результат y = " + y.ToString();
        }
    }
}
 