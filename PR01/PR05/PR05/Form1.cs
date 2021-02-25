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

       // начальные данные, поле 3х3, размер клетки 100, кол-во мин 3
        private const int _fieldWidth = 3;
        private const int _fieldHeight = 3;
        private const int _cellSize = 100;
        private const int _minesAmount = 3;


        private int[,] _fieldInfo;
        private Button[,] _fieldButtons;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Минер";

            initGame();

        }
        private void initGame()
        {
            // отчищаем данные, если они были
            clearField();

            // устанавливаем размер окна в зависисмости от размера клетки
            this.ClientSize = new Size(_cellSize * _fieldWidth, _cellSize * _fieldHeight);

            // создаём массивы с информацией о поле (где мина, где пустое место)
            _fieldInfo = new int[_fieldHeight, _fieldWidth];

            // создаём массив для кнопок на поле
            _fieldButtons = new Button[_fieldHeight, _fieldWidth];


            // создаём кнопки по полю и размещаем их.
            for (int i = 0; i < _fieldHeight; i++)
            {
                for (int j = 0; j < _fieldWidth; j++)
                {
                    Button b = new Button();
                    b.Width = _cellSize;
                    b.Height = _cellSize;
                    b.Location = new Point(j * _cellSize, i * _cellSize);

                    // каждую кнопку подписываем на событие клика
                    int iTemp = i;
                    int jTemp = j;
                    b.Click += (sen, evArg) =>
                    {
                        B_Click(iTemp, jTemp);
                    };


                    // добавляем кнопку в отображение и в массив кнопок
                    Controls.Add(b);
                    _fieldButtons[i, j] = b;
                }
            }
            Random random = new Random();
            int mines = _minesAmount;

            while (mines > 0)
            {
                int randX = random.Next(0, _fieldWidth);
                int randY = random.Next(0, _fieldHeight);

                if (_fieldInfo[randY, randX] == 0)
                {
                    _fieldInfo[randY, randX] = 666;
                    //_fieldButtons[randY, randX].Text = _fieldInfo[randY, randX].ToString();
                    mines--;
                }
            }
        }
        private void clearField()
        {
            if (_fieldButtons != null)
            {
                foreach (Button button in _fieldButtons)
                {
                    Controls.Remove(button);
                }
            }
        }

        // при клике по кнопке
        private void B_Click(int i, int j)
        {
            // если под кнопкой мина - то конец игры.
            Button b = _fieldButtons[i, j];
            if (_fieldInfo[i, j] == 666)
            {
                b.BackColor = Color.Red;
                b.Text = "МИ-НА!!!";

                MessageBox.Show("Вы проиграли!");
                initGame();
                return;
            }


            // если под кнопкой мины нет, то считаем сколько мин вокруг этой кнопки,
            // и отображаем кол-во мин.

            // счётчик найденых мин вокруг кнопки
            int minesAroundCount = 0;

            for (int y = i - 1; y <= i + 1; y++)
            {
                for (int x = j - 1; x <= j + 1; x++)
                {
                    // кнопка не должна проверять сама себя
                    if (y == i && x == j) continue;

                    // проверка за выходы поля
                    if (!(y >= 0 && y < _fieldHeight) || !(x >= 0 && x < _fieldWidth)) continue;

                    // если это мина, то добавляем её в счётчик
                    if (_fieldInfo[y, x] == 666)
                    {
                        minesAroundCount++;
                    }

                }
            }
        }
    }
}
