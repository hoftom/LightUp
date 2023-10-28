using LightUp_.Properties;
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
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LightUp_.GameManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace LightUp_
{
    public class GameManager
    {
        public class FileData
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }
        }

        #region Set the 'problemFlowLayoutPanel' Size and Location
        protected virtual int GetPanelWidth { get; }
        protected virtual int GetPanelHeight { get; }
        protected virtual Point GetPanelLocation
        {
            get { return new Point(0, 0); }
        }
        #endregion

        #region Set the puzzle gridButtons's Size and Image
        protected virtual int GetButtonWidth { get; }
        protected virtual int GetButtonHeight { get; }
        protected virtual Image GetButtonImage { get; }
        #endregion

        #region Set the puzzle's Path
        public string solvePath;
        public string filePath;
        #endregion

        #region Initialize the gameboard's components
        public int gridSize;
        private Button[,] gridButtons;
        private int[,] gameboard;
        private bool[,] buttonState;
        #endregion

        #region Initialize the Timer
        private Timer timer;
        private Label timerLabel;
        private DateTime startTime;
        #endregion

        //Set the value of a lamp on the board
        private int light_value = -50;


        private int stepsCounter;
        private Label stepLabel;
        private MainForm form;
        private List<FileData> SolveDataList;


        public GameManager(MainForm form)
        {
            this.form = form;
        }

        public void InitializeGame()
        {
            gridButtons = new Button[gridSize, gridSize];
            gameboard = new int[gridSize, gridSize];
            buttonState = new bool[gridSize, gridSize];

            FlowLayoutPanel puzzleFlowLayoutPanel = new FlowLayoutPanel
            {
                Width = GetPanelWidth,
                Height = GetPanelHeight,
                Location = GetPanelLocation,

                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
            };

            //Fill the gameboard with the selected puzzle level
            SetupGameboardLogic(puzzleFlowLayoutPanel);

            //Load in the selected puzzle's solution
            SolveDataList = LoadSolutionData(solvePath);

            //Show the Puzzle Onscreen
            form.Controls.Add(puzzleFlowLayoutPanel);

            #region Create the statisticsPanel and show ON-Screen
            Panel statisticsPanel = new Panel
            {
                BackColor = Color.Transparent,
                Size = new Size(200, 200),
                Location = new Point(450, 250),
            };
            #region Add timer to the statisticsPanel
            timer = new Timer();
            timer.Tick += Timer_Tick;
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
            #endregion

            #region Create the StepCounter Label
            stepLabel = new Label
            {
                Text = $"Lépések: {stepsCounter}",
                Font = new Font("Kristen ITC", 14),
                ForeColor = Color.Black,
                Size = new Size(200, 50),
                Location = new Point(5, 50)
            };
            statisticsPanel.Controls.Add(stepLabel);
            #endregion


            form.Controls.Add(statisticsPanel);
            #endregion

        }

        public void CellButtonClick(object sender, EventArgs e)
        {
            //Determining the index of a selected button
            Button clickedButton = (Button)sender;
            Tuple<int, int> cellCoordinates = (Tuple<int, int>)clickedButton.Tag;
            int row = cellCoordinates.Item1;
            int col = cellCoordinates.Item2;

            CheckAdjacentCells(row, col);
            CheckGoodResult(SolveDataList);

            //Update the stepLabel
            stepLabel.Text = $"Lépések: {stepsCounter}";

        }

        protected virtual void SetupGameboardLogic(FlowLayoutPanel flowLayoutPanel)
        {
            #region Fill the flowLayoutPanel with the game buttons and Set up the actual playable gameboard
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
                #endregion
            }
        }

        private void IlluminateAdjacentCells(int row, int col)
        {
            //Illuminate Upside
            for (int r = row - 1; r >= 0; r--)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] -= 1;
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else gridButtons[r, col].BackColor = Color.Yellow;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
            }

            //Illuminate Downside
            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] -= 1;
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else gridButtons[r, col].BackColor = Color.Yellow;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
            }

            //Illuminate Leftside
            for (int c = col - 1; c >= 0; c--)
            {
                if (gameboard[row, c] > -1) break;
                gameboard[row, c] -= 1;
                if (gameboard[row, c] < -51) gridButtons[row, c].BackColor = Color.Red;
                else gridButtons[row, c].BackColor = Color.Yellow;
                //gridButtons[row, c].Text = gameboard[row, c].ToString();
            }

            //Illuminate Rightside
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
            //Unilluminate Upside
            for (int r = row - 1; r >= 0; r--)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] += 1;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else if (gameboard[r, col] < -1) gridButtons[r, col].BackColor = Color.Yellow;
                else gridButtons[r, col].BackColor = Color.White;
            }

            //Unilluminate Downside
            for (int r = row + 1; r < gridSize; r++)
            {
                if (gameboard[r, col] > -1) break;
                gameboard[r, col] += 1;
                //gridButtons[r, col].Text = gameboard[r, col].ToString();
                if (gameboard[r, col] < -51) gridButtons[r, col].BackColor = Color.Red;
                else if (gameboard[r, col] < -1 ) gridButtons[r, col].BackColor = Color.Yellow;
                else gridButtons[r, col].BackColor = Color.White;
            }

            //Unilluminate Leftside
            for (int c = col - 1; c >= 0; c--)
            {
                if (gameboard[row, c] > -1) break;
                gameboard[row, c] += 1;
                //gridButtons[row, c].Text = gameboard[row, c].ToString();
                if (gameboard[row, c] < -51) gridButtons[row, c].BackColor = Color.Red;
                else if (gameboard[row, c] < -1) gridButtons[row, c].BackColor = Color.Yellow;
                else gridButtons[row, c].BackColor = Color.White;
            }

            //Unilluminate Rightside
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
            /*Check that the light on the selected button is turned on as a background
             * if not adjust the lamp
             * else cleare the button's background
             */
            if (gridButtons[row, col].BackgroundImage == null && stepsCounter > 0)
            {
                gridButtons[row, col].BackgroundImageLayout = ImageLayout.Center;
                gridButtons[row, col].BackgroundImage = GetButtonImage;
            }
            else
            {
                gridButtons[row, col].BackgroundImage = null;
            }

            /*Check the value of the selected button
             * from -1 to -49 -> no lamp on the button
             * under -50 means there is a lamp
            */
            if (gameboard[row, col] <= -1 && gameboard[row, col] > light_value)
            {
                if (stepsCounter > 0)
                {
                    IlluminateAdjacentCells(row, col);
                    gameboard[row, col] += light_value; //Incrase the button's value and put down a lamp

                    //gridButtons[row, col].Text = gameboard[row, col].ToString();

                    //Red means invalid move, so there is an another lamp in the row/column
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
            /* After each click, to check whether the player gave a good solution
             * If yes -> create the SolvedPanel panel
             */
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
                //Create Panel
                Panel SolvedPanel = new Panel
                {
                    Location = new Point(240, 200),
                    BackColor = Color.Gray,
                    Size = new Size(209,133)
                };
                //Create Label and add to Panel
                Label SolvedLabel = new Label
                {
                    Text = "Helyes megoldás!",
                    Location = new Point(22, 34),
                    Size = new Size(167, 27),
                    Font = new Font("Kristen ITC", 14),
                };
                SolvedPanel.Controls.Add(SolvedLabel);
                //Create Label and add to Panel
                PictureBox picture = new PictureBox
                {
                    Image = Resources.lightbulb_button_easy,
                    Location = new Point(92,3),
                    Size = new Size(24,42)
                };
                SolvedPanel.Controls.Add(picture);
                //Create Button and add to Panel
                Button NewgameButton = new Button
                {
                    Text = "Új játék",
                    Location = new Point(55, 74),
                    Size = new Size(100, 43)
                };
                SolvedPanel.Controls.Add(NewgameButton);


                //Show the SolvedPanel On-screen
                form.Controls.Add(SolvedPanel);
                SolvedPanel.BringToFront();

                //After Selected navigate to MainMenu
                NewgameButton.Click += NewgameButton_Click;
                
            }
        }
        private void NewgameButton_Click(object sender, EventArgs e)
        {
            //restart application
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
                            /*file format:
                             * row,column,value
                               1;0;1
                               0;5;3
                               2;2;1
                               2;4;1
                             */
                            string[] parts = line.Split(';');


                            // x -> row index; y-> column index; value -> value on the button
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
                            //increasing the value, as many steps are possible as the given file consists of lines
                            stepsCounter++;

                            /*file format:
                             * row,column
                               1;0
                               0;5
                               2;2
                               2;4
                             */
                            string[] parts = line.Split(';');

                            // x -> row index; y-> column index;
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
