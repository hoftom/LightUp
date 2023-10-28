﻿using LightUp_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LightUp_.GameManager;

namespace LightUp_
{
    public class GameManager
    {
        protected virtual int GetPanelWidth { get; }
        protected virtual int GetPanelHeight { get; }
        protected virtual Point GetPanelLocation
        {
            get { return new Point(0, 0); }
        }


        protected virtual int GetButtonWidth { get; }
        protected virtual int GetButtonHeight { get; }

        protected virtual Image GetButtonImage { get; }


        public string solvePath;
        public string filePath;

        public int gridSize;
        private Button[,] gridButtons;
        private int[,] gameboard;
        private bool[,] buttonState;

        private int stepsCounter;
        private int light_value = -50;

        private Timer timer;
        private Label timerLabel;
        private DateTime startTime;

        private Label stepLabel;
        


        private MainForm form;
        private List<FileData> SolveDataList;


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
            gridButtons = new Button[gridSize, gridSize];
            gameboard = new int[gridSize, gridSize];
            buttonState = new bool[gridSize, gridSize];

            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel
            {
                Width = GetPanelWidth,
                Height = GetPanelHeight,
                Location = GetPanelLocation,

                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
            };
            SetupGameboardLogic(flowLayoutPanel1);

            SolveDataList = LoadSolutionData(solvePath);

            form.Controls.Add(flowLayoutPanel1);

            timer = new Timer();
            timer.Tick += Timer_Tick;
            

            Panel statisticsPanel = new Panel
            {
                BackColor = Color.Transparent,
                Size = new Size(200, 200),
                Location = new Point(450, 250),
            };
            timerLabel = new Label
            {
                Text = $"Eltelt idő: 00:00",
                Font = new Font("Kristen ITC", 14),
                ForeColor = Color.Black,
                Size = new Size(200, 25),
                Location = new Point(5,0),
            };
            statisticsPanel.Controls.Add(timerLabel);
            startTime = DateTime.Now;

            timer.Start();

            stepLabel = new Label
            {
                Text = $"Lépések: {stepsCounter}",
                Font = new Font("Kristen ITC", 14),
                ForeColor = Color.Black,
                Size = new Size(200, 50),
                Location = new Point(5, 50)
            };
            statisticsPanel.Controls.Add(stepLabel);

            form.Controls.Add(statisticsPanel);

        }

        public void CellButtonClick(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            Tuple<int, int> cellCoordinates = (Tuple<int, int>)clickedButton.Tag;
            int row = cellCoordinates.Item1;
            int col = cellCoordinates.Item2;

            CheckAdjacentCells(row, col);
            CheckGoodResult(SolveDataList);

            stepLabel.Text = $"Lépések: {stepsCounter}";

        }

        protected virtual void SetupGameboardLogic(FlowLayoutPanel flowLayoutPanel)
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    gameboard[row, col] = -1;

                    gridButtons[row, col] = new Button
                    {
                        Width = GetButtonWidth,
                        Height = GetButtonHeight,
                        Tag = new Tuple<int, int>(row, col),
                        //Text = gameboard[row, col].ToString(),
                    };
                    gridButtons[row, col].Click += CellButtonClick;

                    flowLayoutPanel.Controls.Add(gridButtons[row, col]);


                    List<FileData> data = LoadProblemData(filePath);

                    foreach (var item in data)
                    {
                        gameboard[item.X, item.Y] = item.Value;
                    }

                    if (gameboard[row, col] == 100)
                    {
                        gridButtons[row, col].BackColor = Color.Black;
                        gridButtons[row, col].Enabled = false;
                    }

                    if (gameboard[row, col] >= 0)
                    {
                        gridButtons[row, col].BackColor = Color.Black;
                        gridButtons[row, col].ForeColor = Color.White;
                        gridButtons[row, col].Text = gameboard[row, col].ToString();
                    }


                    gameboard[row, col] = -1;
                    buttonState[row, col] = false;
                }
            }
        }
        private void IlluminateAdjacentCells(int row, int col)
        {

            for (int r = row - 1; r >= 0; r--)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] -= 1;
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else gridButtons[r, col].BackColor = Color.Yellow;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
            }


            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] -= 1;
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else gridButtons[r, col].BackColor = Color.Yellow;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
            }

            for (int c = col - 1; c >= 0; c--)
            {
                if (gameboard[row, c] > -1) break;
                gameboard[row, c] -= 1;
                if (gameboard[row, c] < -51) gridButtons[row, c].BackColor = Color.Red;
                else gridButtons[row, c].BackColor = Color.Yellow;
                //gridButtons[row, c].Text = gameboard[row, c].ToString();
            }


            for (int c = col + 1; c < gridSize; c++)
            {
                if (gameboard[row, c] > -1) break;
                gameboard[row, c] -= 1;
                if (gameboard[row, c] < -51) gridButtons[row, c].BackColor = Color.Red;
                else gridButtons[row, c].BackColor = Color.Yellow;
                //gridButtons[row, c].Text = gameboard[row, c].ToString();
            }

        }
        private void UnIlluminateAdjacentCells(int row, int col)
        {
            for (int r = row - 1; r >= 0; r--)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] += 1;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else if (gameboard[r, col] < -1) gridButtons[r, col].BackColor = Color.Yellow;
                else gridButtons[r, col].BackColor = Color.White;
            }


            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] += 1;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else if (gameboard[r, col] < -1 ) gridButtons[r, col].BackColor = Color.Yellow;
                else gridButtons[r, col].BackColor = Color.White;
            }


            for (int c = col - 1; c >= 0; c--)
            {
                if (gameboard[row, c] > -1) break;
                gameboard[row, c] += 1;
                //gridButtons[row, c].Text = gameboard[row, c].ToString();
                if (gameboard[row, c] < -51) gridButtons[row, c].BackColor = Color.Red;
                else if (gameboard[row, c] < -1) gridButtons[row, c].BackColor = Color.Yellow;
                else gridButtons[row, c].BackColor = Color.White;
            }


            for (int c = col + 1; c < gridSize; c++)
            {
                if (gameboard[row, c] > -1) break;
                gameboard[row, c] += 1;
                //gridButtons[row, c].Text = gameboard[row, c].ToString();
                if (gameboard[row, c] < -51) gridButtons[row, c].BackColor = Color.Red;
                else if (gameboard[row, c] < -1) gridButtons[row, c].BackColor = Color.Yellow;
                else gridButtons[row, c].BackColor = Color.White;
            }

        }

        private void CheckAdjacentCells(int row, int col)
        {
            if (gridButtons[row, col].BackgroundImage == null && stepsCounter > 0)
            {
                gridButtons[row, col].BackgroundImageLayout = ImageLayout.Center;
                gridButtons[row, col].BackgroundImage = GetButtonImage;
            }
            else
            {
                gridButtons[row, col].BackgroundImage = null;
            }

            if (gameboard[row, col] <= -1 && gameboard[row, col] > light_value)
            {
                if (stepsCounter > 0)
                {
                    IlluminateAdjacentCells(row, col);
                    gameboard[row, col] += light_value;
                    //gridButtons[row, col].Text = gameboard[row, col].ToString();
                    if (gameboard[row, col] < -51)
                    {
                        gridButtons[row, col].BackColor = Color.Red;
                    }
                    else gridButtons[row, col].BackColor = Color.Yellow;

                    stepsCounter--;
                }
            }
            else if (gameboard[row, col] <= light_value)
            {
                UnIlluminateAdjacentCells(row, col);
                gameboard[row, col] -= light_value;
                //gridButtons[row, col].Text = gameboard[row, col].ToString();
                if (gameboard[row, col] < -1) gridButtons[row, col].BackColor = Color.Yellow;
                else gridButtons[row, col].BackColor = Color.White;

                stepsCounter++;
            }
        }
        private void CheckGoodResult(List<FileData> SolveDataList)
        {
            bool good = true;
            foreach (var item in SolveDataList)
            {
                if (gameboard[item.X, item.Y] >= light_value)
                {
                    good = false;
                    break;
                }
            }
            if (good)
            {
                timer.Stop();
                for (int row = 0; row < gridSize; row++)
                {
                    for (int col = 0; col < gridSize; col++)
                    {
                        if (gameboard[row, col] < 0) gridButtons[row, col].Enabled = false;
                    }
                }

                Panel SolvedPanel = new Panel
                {
                    Location = new Point(240, 200),
                    BackColor = Color.Gray,
                    Size = new Size(209,133)
                };

                Label SolvedLabel = new Label
                {
                    Text = "Helyes megoldás!",
                    Location = new Point(22, 34),
                    Size = new Size(167, 27),
                    Font = new Font("Kristen ITC", 14),
                };
                SolvedPanel.Controls.Add(SolvedLabel);

                PictureBox picture = new PictureBox
                {
                    Image = Resources.lightbulb_button_easy,
                    Location = new Point(92,3),
                    Size = new Size(24,42)
                };
                SolvedPanel.Controls.Add(picture);

                

                Button NewgameButton = new Button
                {
                    Text = "Új játék",
                    Location = new Point(55, 74),
                    Size = new Size(100, 43)
                };
                SolvedPanel.Controls.Add(NewgameButton);

                form.Controls.Add(SolvedPanel);
                SolvedPanel.BringToFront();

                NewgameButton.Click += NewgameButton_Click;
                
            }
        }
        private void NewgameButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private List<FileData> LoadProblemData(string filePath)
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
                Console.WriteLine("The problem file does not exist.");
            }
            return fileDataList;
        }
        private List<FileData> LoadSolutionData(string solvePath)
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
                            stepsCounter++;
                            string[] parts = line.Split(';');
                            if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                            {
                                FileData data = new FileData { X = x, Y = y };
                                SolveDataList.Add(data);
                            }
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine("The solution file does not exist.");
            }

            return SolveDataList;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            timerLabel.Text = $"Eltelt idő: {elapsedTime.ToString(@"mm\:ss")}";
        }
    }
}
