using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LightUp_.GameManager;

namespace LightUp_
{
    public class GameManager
    {
        private Timer timer = new Timer();
        private int gridSize = 7;
        private Button[,] gridButtons;
        private int[,] gameBoard;
        private bool[,] buttonState;

        private int elapsedTime = 0;
        private int stepsCounter = 8;
        private int light_value = -50;
        private bool good = false;


        private MainForm form;
        public class FileData
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }
        }

        public GameManager(MainForm form)
        {
            this.form = form;
        }

        public void InitializeGame()
        {
            int elapsedTime = 0;
            int stepsCounter = 8;
            int light_value = -50;

            string filePath = "C:/Users//hoffm/OneDrive/Asztali gép/projects/C#/LightUp!/Data/easy.txt";
            


            gridButtons = new Button[gridSize, gridSize];
            gameBoard = new int[gridSize, gridSize];
            buttonState = new bool[gridSize, gridSize];

            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel
            {
                Width = 300,
                Height = 560,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new Point(126, 170),
                BackColor = Color.Transparent,
            };
            form.Controls.Add(flowLayoutPanel1);

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    gameBoard[row, col] = -1;

                    gridButtons[row, col] = new Button
                    {
                        Width = 35,
                        Height = 35,
                        Tag = new Tuple<int, int>(row, col),
                        Text = gameBoard[row, col].ToString(),
                    };
                    gridButtons[row, col].Click += CellButtonClick;

                    flowLayoutPanel1.Controls.Add(gridButtons[row, col]);


                    List<FileData> data = ReadData(filePath);

                    foreach (var item in data)
                    {
                        gameBoard[item.X, item.Y] = item.Value;
                    }

                    if (gameBoard[row, col] == 100)
                    {
                        gridButtons[row, col].BackColor = Color.Black;
                        gridButtons[row, col].Enabled = false;
                    }

                    if (gameBoard[row, col] >= 0)
                    {
                        gridButtons[row, col].BackColor = Color.Black;
                        gridButtons[row, col].ForeColor = Color.White;
                        gridButtons[row, col].Text = gameBoard[row, col].ToString();
                    }


                    gameBoard[row, col] = -1;
                    buttonState[row, col] = false;
                }
            }
        }

        public void CellButtonClick(object sender, EventArgs e)
        {;

            Button clickedButton = (Button)sender;
            Tuple<int, int> cellCoordinates = (Tuple<int, int>)clickedButton.Tag;
            int row = cellCoordinates.Item1;
            int col = cellCoordinates.Item2;
            if (gameBoard[row, col] <= -1 && gameBoard[row, col] > light_value)
            {
                if (stepsCounter > 0)
                {
                    IlluminateAdjacentCells(row, col);
                    gameBoard[row, col] += light_value;
                    gridButtons[row, col].Text = gameBoard[row, col].ToString();
                    gridButtons[row, col].BackColor = Color.Yellow;

                    stepsCounter--;

                }
            }
            else if (gameBoard[row, col] <= light_value)
            {
                UnIlluminateAdjacentCells(row, col);
                gameBoard[row, col] -= light_value;
                gridButtons[row, col].Text = gameBoard[row, col].ToString();
                if (gameBoard[row, col] == -1) gridButtons[row, col].BackColor = Color.White;

                stepsCounter++;


            }


            string solvePath = "C:/Users/hoffm/OneDrive/Asztali gép/projects/C#/LightUp!/Data/easy-solve.txt";
            List<FileData> solveData = SolveData(solvePath);
            foreach (var item in solveData)
            {
                if (gameBoard[item.X, item.Y] <= light_value)
                {
                    good = true;
                    MessageBox.Show("Nyertél");
                }
                else
                {
                    good = false;
                    break;
                }

            }
            if (good)
            {
                timer.Stop();
                MessageBox.Show("Nyertél");
            }
        }
        private void IlluminateAdjacentCells(int row, int col)
        {

            for (int r = row - 1; r >= 0; r--)
            {
                if (gameBoard[r, col] > -1) break;
                gameBoard[r, col] -= 1;
                gridButtons[r, col].BackColor = Color.Yellow;
                gridButtons[r, col].Text = gameBoard[r, col].ToString();
            }


            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameBoard[r, col] > -1) break;
                gameBoard[r, col] -= 1;
                gridButtons[r, col].BackColor = Color.Yellow;
                gridButtons[r, col].Text = gameBoard[r, col].ToString();
            }

            for (int c = col - 1; c >= 0; c--)
            {
                if (gameBoard[row, c] > -1) break;
                gameBoard[row, c] -= 1;
                gridButtons[row, c].BackColor = Color.Yellow;
                gridButtons[row, c].Text = gameBoard[row, c].ToString();
            }


            for (int c = col + 1; c < gridSize; c++)
            {
                if (gameBoard[row, c] > -1) break;
                gameBoard[row, c] -= 1;
                gridButtons[row, c].BackColor = Color.Yellow;
                gridButtons[row, c].Text = gameBoard[row, c].ToString();
            }

        }
        private void UnIlluminateAdjacentCells(int row, int col)
        {
            for (int r = row - 1; r >= 0; r--)
            {
                if (gameBoard[r, col] > -1) break;
                gameBoard[r, col] += 1;
                gridButtons[r, col].Text = gameBoard[r, col].ToString();
                if (gameBoard[r, col] == -1) gridButtons[r, col].BackColor = Color.White;
            }


            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameBoard[r, col] > -1) break;
                gameBoard[r, col] += 1;
                gridButtons[r, col].Text = gameBoard[r, col].ToString();
                if (gameBoard[r, col] == -1) gridButtons[r, col].BackColor = Color.White;
            }


            for (int c = col - 1; c >= 0; c--)
            {
                if (gameBoard[row, c] > -1) break;
                gameBoard[row, c] += 1;
                gridButtons[row, c].Text = gameBoard[row, c].ToString();
                if (gameBoard[row, c] == -1) gridButtons[row, c].BackColor = Color.White;
            }


            for (int c = col + 1; c < gridSize; c++)
            {
                if (gameBoard[row, c] > -1) break;
                gameBoard[row, c] += 1;
                gridButtons[row, c].Text = gameBoard[row, c].ToString();
                if (gameBoard[row, c] == -1) gridButtons[row, c].BackColor = Color.White;
            }

        }

        private List<FileData> ReadData(string filePath)
        {

            List<FileData> fileDataList = new List<FileData>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(';');
                            if (parts.Length == 3 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y) && int.TryParse(parts[2], out int value))
                            {
                                FileData data = new FileData { X = x, Y = y, Value = value };
                                fileDataList.Add(data);
                            }
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
            return fileDataList;
        }

        private List<FileData> SolveData(string solvePath)
        {

            List<FileData> SolveDataList = new List<FileData>();

            if (File.Exists(solvePath))
            {
                using (StreamReader reader = new StreamReader(solvePath))
                {
                    string line;
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(';');
                            if (parts.Length == 3 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y) && int.TryParse(parts[2], out int value))
                            {
                                FileData data = new FileData { X = x, Y = y, Value = value };
                                SolveDataList.Add(data);
                            }
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
            return SolveDataList;
        }
    }
}
