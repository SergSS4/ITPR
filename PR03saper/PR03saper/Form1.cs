using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR03saper
{
    public partial class Form1 : Form
    {
        List<Button> buttons;
        Random randmina;
        public Form1()
        {

            InitializeComponent();
           randmina = new Random();  
            buttons = new List<Button>();
            buttons.AddRange(new Button[25] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25});
            button1.Click += button1_Click;
            button2.Click += button1_Click;
            button3.Click += button1_Click;
            button4.Click += button1_Click;
            button5.Click += button1_Click;
            button6.Click += button1_Click;
            button7.Click += button1_Click;
            button8.Click += button1_Click;
            button9.Click += button1_Click;
            button10.Click += button1_Click;
            button11.Click += button1_Click;
            button12.Click += button1_Click;
            button13.Click += button1_Click;
            button14.Click += button1_Click;
            button15.Click += button1_Click;
            button16.Click += button1_Click;
            button17.Click += button1_Click;
            button18.Click += button1_Click;
            button19.Click += button1_Click;
            button20.Click += button1_Click;
            button21.Click += button1_Click;
            button22.Click += button1_Click;
            button23.Click += button1_Click;
            button24.Click += button1_Click;
            button25.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Button knopka = (Button)sender;
            if (randmina.Next(2) == 0) 
            {
               knopka.Text = "МИНААААА";
                knopka.BackColor = Color.Red;
                BackColor = Color.OrangeRed;
            }
            else
            {
                knopka.Text = randmina.Next(25).ToString();
               knopka.BackColor = Color.Blue;
                BackColor = Color.Green;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
