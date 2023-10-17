using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightUp_
{
    public partial class MainForm : Form
    {
        private int gridSize = 7; 
        private Button[,] gridButtons;
        private int[,] gameBoard;
        private FlowLayoutPanel flowLayoutPanel;
        private bool[,] buttonState;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();

        }
        private void InitializeGame()
        {
            
            gridButtons = new Button[gridSize, gridSize];
            gameBoard = new int[gridSize, gridSize];
            buttonState = new bool[gridSize, gridSize];
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Width = 300,
                Height = 500,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new Point(126, 170),
                BackColor = Color.Transparent,
            };

            Controls.Add(flowLayoutPanel1);


            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    gridButtons[row, col] = new Button
                    {
                        Width = 35,
                        Height = 35,
                        Tag = new Tuple<int, int>(row, col),
                    };
                    gridButtons[row, col].Click += CellButtonClick;
          
                    flowLayoutPanel1.Controls.Add(gridButtons[row, col]);

                    if (gameBoard[row, col] == -1)
                    {
                        gridButtons[row, col].BackColor = Color.Black;
                        gridButtons[row, col].ForeColor = Color.White;
                        gridButtons[row, col].Text = "2";          
                        gridButtons[row, col].Enabled = true;
                    }

                    gameBoard[row, col] = 0;
                    buttonState[row, col] = false;

                    gameBoard[1, 2] = -1;
                    gameBoard[2, 1] = -1;
                    gameBoard[2, 4] = -1;
                    gameBoard[3, 0] = -1;
                    gameBoard[3, 1] = -1;
                    gameBoard[4, 2] = -1;
                    gameBoard[4, 3] = -1;

                }
            }
        }

        private void CellButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Tuple<int, int> cellCoordinates = (Tuple<int, int>)clickedButton.Tag;
            int row = cellCoordinates.Item1;
            int col = cellCoordinates.Item2;

            if (gameBoard[row, col] == 0)
            {
     
                IlluminateAdjacentCells(row, col);
            }
            else
            {
                UnIlluminateAdjacentCells(row, col);
            }
        }

        private void IlluminateAdjacentCells(int row, int col)
        {
           
            for (int r = row; r >= 0; r--)
            {
                if (gameBoard[r, col] == -1) break;
                gameBoard[r, col] = 1;
                gridButtons[r, col].BackColor = Color.Yellow; 
            }


            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameBoard[r, col] == -1) break;
                gameBoard[r, col] = 1;
                gridButtons[r, col].BackColor = Color.Yellow;
            }

            for (int c = col; c >= 0; c--)
            {
                if (gameBoard[row, c] == -1) break;
                gameBoard[row, c] = 1;
                gridButtons[row, c].BackColor = Color.Yellow;
            }


            for (int c = col + 1; c < gridSize; c++)
            {
                if (gameBoard[row, c] == -1) break;
                gameBoard[row, c] = 1;
                gridButtons[row, c].BackColor = Color.Yellow;
            }

        }
        private void UnIlluminateAdjacentCells(int row, int col)
        {

            for (int r = row; r >= 0; r--)
            {
                if (gameBoard[r, col] == -1) break;
                gameBoard[r, col] = 0;
                gridButtons[r, col].BackColor = Color.White;
            }


            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameBoard[r, col] == -1) break;
                gameBoard[r, col] = 0;
                gridButtons[r, col].BackColor = Color.White;
            }

            for (int c = col; c >= 0; c--)
            {
                if (gameBoard[row, c] == -1) break;
                gameBoard[row, c] = 0;
                gridButtons[row, c].BackColor = Color.White;
            }


            for (int c = col + 1; c < gridSize; c++)
            {
                if (gameBoard[row, c] == -1) break;
                gameBoard[row, c] = 0;
                gridButtons[row, c].BackColor = Color.White;
            }

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            panel_Menu.Visible = false;
            panel_Level.Visible = true;
            button_back.Visible = true;
        }

        private void btn_rules_Click(object sender, EventArgs e)
        {
            panel_Menu.Visible = false;
            panel_rules.Visible = true;
            button_back.Visible = true;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            panel_Menu.Visible = true;
            panel_rules.Visible = false;
            panel_Level.Visible = false;
            button_back.Visible = false;
        }

        private void btn_Start_MouseEnter(object sender, EventArgs e)
        {
            btn_Start.ForeColor = Color.Yellow;
            btn_Start.Image = Properties.Resources.lightbulb_on;
        }

        private void btn_Start_MouseLeave(object sender, EventArgs e)
        {
            btn_Start.ForeColor = Color.White;
            btn_Start.Image = Properties.Resources.lightbulb_off;
        }

        private void btn_rules_MouseEnter(object sender, EventArgs e)
        {
            btn_rules.ForeColor = Color.Yellow;
            btn_rules.Image = Properties.Resources.lightbulb_rules;
        }

        private void btn_rules_MouseLeave(object sender, EventArgs e)
        {
            btn_rules.ForeColor = Color.White;
            btn_rules.Image = Properties.Resources.lightbulb_off;
        }

        private void btn_Exit_MouseEnter(object sender, EventArgs e)
        {
            btn_Exit.ForeColor = Color.Yellow;
            btn_Exit.Image = Properties.Resources.lightbulb_logout;
        }

        private void btn_Exit_MouseLeave(object sender, EventArgs e)
        {
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Image = Properties.Resources.lightbulb_off;
        }

        private void button_back_MouseEnter(object sender, EventArgs e)
        {
            button_back.Image = Properties.Resources.back_icon_selected;
        }

        private void button_back_MouseLeave(object sender, EventArgs e)
        {
            button_back.Image = Properties.Resources.back_icon;
        }

        private void btn_easy_MouseEnter(object sender, EventArgs e)
        {
            btn_easy.Image = Properties.Resources._7x7_selected;
            label_easy.ForeColor = Color.Yellow;
        }

        private void btn_easy_MouseLeave(object sender, EventArgs e)
        {
            btn_easy.Image = Properties.Resources._7x7;
            label_easy.ForeColor = Color.Black;
        }

        private void btn_adv_MouseEnter(object sender, EventArgs e)
        {
            btn_adv.Image = Properties.Resources._10x10_selected;
            label_adv.ForeColor = Color.Yellow;
        }

        private void btn_adv_MouseLeave(object sender, EventArgs e)
        {
            btn_adv.Image = Properties.Resources._10x101;
            label_adv.ForeColor = Color.Black;
        }

        private void btn_exp_MouseEnter(object sender, EventArgs e)
        {
            btn_exp.Image = Properties.Resources._14x14_selected;
            label_exp.ForeColor = Color.Yellow;
        }

        private void btn_exp_MouseLeave(object sender, EventArgs e)
        {
            btn_exp.Image= Properties.Resources._14x14;
            label_exp.ForeColor = Color.Black;
        }

        private void btn_easy_Click(object sender, EventArgs e)
        {
            panel_Level.Visible = false;
            flowLayoutPanel1.Visible = true;
        }
    }
}
