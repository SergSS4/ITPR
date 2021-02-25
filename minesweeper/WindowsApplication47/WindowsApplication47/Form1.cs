using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        private int
          MR = 10,
          MC = 10,
          NM = 10, 
          W = 40,  
          H = 40;  
        private int[,] Field; 
        private int status;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
            Minesweeper();
        }
        private void Minesweeper()
        {
            Field = new int[MR + 2, MC + 2];

            for (int row = 0; row <= MR + 1; row++)
            {
                Field[row, 0] = -3;
                Field[row, MC + 1] = -3;
            }

            for (int col = 0; col <= MC + 1; col++)
            {
                Field[0, col] = -3;
                Field[MR + 1, col] = -3;
            }
            this.ClientSize = new Size(W * MC + 1, H * MR + 1);
            Game();

            g = panel1.CreateGraphics();
        }

        private void Game()
        {
            int row, col;    
            int n = 0;      
            int k;           

            Random rnd = new Random();

            do
            {
                row = rnd.Next(MR) + 1;
                col = rnd.Next(MC) + 1;

                if (Field[row, col] != 9)
                {
                    Field[row, col] = 9;
                    n++;
                }
            }
            while (n != NM);

            for (row = 1; row <= MR; row++)
                for (col = 1; col <= MC; col++)
                    if (Field[row, col] != 9)
                    {
                        k = 0;

                        if (Field[row - 1, col - 1] == 9) k++;
                        if (Field[row - 1, col] == 9) k++;
                        if (Field[row - 1, col + 1] == 9) k++;
                        if (Field[row, col - 1] == 9) k++;
                        if (Field[row, col + 1] == 9) k++;
                        if (Field[row + 1, col - 1] == 9) k++;
                        if (Field[row + 1, col] == 9) k++;
                        if (Field[row + 1, col + 1] == 9) k++;

                        Field[row, col] = k;
                    }

            status = 0;    

        }


        private void ShowField(Graphics g, int status)
        {
            for (int row = 1; row <= MR; row++)
                for (int col = 1; col <= MC; col++)
                    this.kletka(g, row, col, status);
        }

        private void kletka(Graphics g, int row, int col, int status)
        {

            int x, y;

            x = (col - 1) * W + 1;
            y = (row - 1) * H + 1;

            if (Field[row, col] < 100)
                g.FillRectangle(SystemBrushes.ControlLight, x - 1, y - 1, W, H);

            if (Field[row, col] >= 100)
            {

                if (Field[row, col] != 109)
                    g.FillRectangle(Brushes.Green, x - 1, y - 1, W, H);
                else

                    g.FillRectangle(Brushes.Red, x - 1, y - 1, W, H);


                if ((Field[row, col] >= 101) && (Field[row, col] <= 108))
                    g.DrawString((Field[row, col] - 100).ToString(), new Font("Tahoma", 10, System.Drawing.FontStyle.Regular), Brushes.Blue, x + 3, y + 2);
            }

            g.DrawRectangle(Pens.Black, x - 1, y - 1, W, H);

            if ((status == 2) && ((Field[row, col] % 10) == 9))
                this.mina(g, x, y);
        }


        private void open(int row, int col)
        {
            int x = (col - 1) * W + 1, y = (row - 1) * H + 1;

            if (Field[row, col] == 0)
            {
                Field[row, col] = 100;

                this.kletka(g, row, col, status);

            }
            else
                if ((Field[row, col] < 100) &&
                     (Field[row, col] != -3))
            {
                Field[row, col] += 100;


                this.kletka(g, row, col, status);
            }
        }

        private void mina(Graphics g, int x, int y)
        {

            g.FillRectangle(Brushes.Green,
                x + 16, y + 26, 8, 4);
            g.FillRectangle(Brushes.Green,
                x + 8, y + 30, 24, 4);
            g.DrawPie(Pens.Black,
                x + 6, y + 28, 28, 16, 0, -180);
            g.FillPie(Brushes.Green,
                x + 6, y + 28, 28, 16, 0, -180);

            g.DrawLine(Pens.Black,
                x + 12, y + 32, x + 28, y + 32);

            g.DrawLine(Pens.Black,
                x + 20, y + 22, x + 20, y + 26);

            g.DrawLine(Pens.Black,
                x + 8, y + 30, x + 6, y + 28);
            g.DrawLine(Pens.Black,
                x + 32, y + 30, x + 34, y + 28);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (status == 2) return;

            if (status == 0) status = 1;
          
            int row = (int)(e.Y / H) + 1,
                col = (int)(e.X / W) + 1;

            int x = (col - 1) * W + 1,
                y = (row - 1) * H + 1;

            if (e.Button == MouseButtons.Left)
            {                   
                if (Field[row, col] == 9)
                {
                    Field[row, col] += 100;

                    status = 2;

                    this.panel1.Invalidate();
                }
                else
                    if (Field[row, col] < 9)
                    this.open(row, col);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ShowField(g, status);
        }

    }



    
}
