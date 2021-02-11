using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR05
{
    public partial class Form1 : Form
    {
        int mines = 4;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = Convert.ToString(mines);
            BackColor = Color.GreenYellow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = Convert.ToString(mines);
            BackColor = Color.GreenYellow;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "MINAAA";
            BackColor = Color.Red;
            mines = mines - 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "MINAAA";
            BackColor = Color.Red;
            mines = mines - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = Convert.ToString(mines);
            BackColor = Color.GreenYellow;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = Convert.ToString(mines);
            BackColor = Color.GreenYellow;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = "MINAAA";
            BackColor = Color.Red;
            mines = mines - 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = Convert.ToString(mines);
            BackColor = Color.GreenYellow;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Text = "MINAAA";
            BackColor = Color.Red;
            mines = mines - 1;
        }
    }
}
