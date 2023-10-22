using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightUp_
{
    public partial class MainForm : Form
    {
        private Timer timer = new Timer();
        private int gridSize = 7; 
        private Button[,] gridButtons;
        private int[,] gameBoard;
        private bool[,] buttonState;

       private int elapsedTime = 0;
       private int stepsCounter = 8;
       private int light_value = -50;

        private GameManager gameManager;

       /* Label helloLabel = new Label
        {
            Text = $"Indításhoz lépj egyet!",
            Font = new Font("Kristen ITC", 14.25f),
            ForeColor = Color.Black,
            AutoSize = true,
        };

        Panel panel_Statistics = new Panel
        {
            Width = 300,
            Height = 200,
            BackColor = Color.Transparent,
            Location = new Point(450, 215),
            Visible = false,

        };*/



        public MainForm()
        {
            InitializeComponent();

            gameManager = new GameManager(this);
            gameManager.InitializeGame();

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
            //panel_Statistics.Visible = true;
            //timer.Start();
            flowLayoutPanel1.Visible = true;
            
        }

        private void btn_adv_Click(object sender, EventArgs e)
        {
            panel_Level.Visible = false;
            //panel_Statistics.Visible = true;
        }
    }
}
