﻿namespace LightUp_
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label_main = new System.Windows.Forms.Label();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.btn_rules = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.panel_Level = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_easy = new System.Windows.Forms.Label();
            this.label_adv = new System.Windows.Forms.Label();
            this.label_exp = new System.Windows.Forms.Label();
            this.btn_easy = new System.Windows.Forms.Button();
            this.btn_adv = new System.Windows.Forms.Button();
            this.btn_exp = new System.Windows.Forms.Button();
            this.label_chooseLevel = new System.Windows.Forms.Label();
            this.panel_rules = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.panel_Menu.SuspendLayout();
            this.panel_Level.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel_rules.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_main
            // 
            this.label_main.AutoSize = true;
            this.label_main.BackColor = System.Drawing.Color.Transparent;
            this.label_main.Font = new System.Drawing.Font("Showcard Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_main.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label_main.Location = new System.Drawing.Point(141, 11);
            this.label_main.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_main.Name = "label_main";
            this.label_main.Size = new System.Drawing.Size(645, 149);
            this.label_main.TabIndex = 3;
            this.label_main.Text = "LightUp!";
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.Transparent;
            this.panel_Menu.Controls.Add(this.btn_rules);
            this.panel_Menu.Controls.Add(this.btn_Exit);
            this.panel_Menu.Controls.Add(this.btn_Start);
            this.panel_Menu.Location = new System.Drawing.Point(168, 161);
            this.panel_Menu.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(599, 479);
            this.panel_Menu.TabIndex = 8;
            // 
            // btn_rules
            // 
            this.btn_rules.BackColor = System.Drawing.Color.Transparent;
            this.btn_rules.BackgroundImage = global::LightUp_.Properties.Resources.button_bg;
            this.btn_rules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_rules.FlatAppearance.BorderSize = 0;
            this.btn_rules.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_rules.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_rules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rules.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rules.ForeColor = System.Drawing.Color.White;
            this.btn_rules.Image = ((System.Drawing.Image)(resources.GetObject("btn_rules.Image")));
            this.btn_rules.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_rules.Location = new System.Drawing.Point(83, 208);
            this.btn_rules.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rules.Name = "btn_rules";
            this.btn_rules.Size = new System.Drawing.Size(433, 105);
            this.btn_rules.TabIndex = 11;
            this.btn_rules.Text = "Szabályzat";
            this.btn_rules.UseVisualStyleBackColor = false;
            this.btn_rules.Click += new System.EventHandler(this.btn_rules_Click);
            this.btn_rules.MouseEnter += new System.EventHandler(this.btn_rules_MouseEnter);
            this.btn_rules.MouseLeave += new System.EventHandler(this.btn_rules_MouseLeave);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BackgroundImage = global::LightUp_.Properties.Resources.button_bg;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_Exit.Location = new System.Drawing.Point(127, 354);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(356, 86);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.Text = "Kilépés";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            this.btn_Exit.MouseEnter += new System.EventHandler(this.btn_Exit_MouseEnter);
            this.btn_Exit.MouseLeave += new System.EventHandler(this.btn_Exit_MouseLeave);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.BackgroundImage = global::LightUp_.Properties.Resources.button_bg;
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Start.FlatAppearance.BorderSize = 0;
            this.btn_Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.ForeColor = System.Drawing.Color.White;
            this.btn_Start.Image = ((System.Drawing.Image)(resources.GetObject("btn_Start.Image")));
            this.btn_Start.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_Start.Location = new System.Drawing.Point(83, 66);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(433, 105);
            this.btn_Start.TabIndex = 9;
            this.btn_Start.Text = "Játék";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            this.btn_Start.MouseEnter += new System.EventHandler(this.btn_Start_MouseEnter);
            this.btn_Start.MouseLeave += new System.EventHandler(this.btn_Start_MouseLeave);
            // 
            // panel_Level
            // 
            this.panel_Level.BackColor = System.Drawing.Color.Transparent;
            this.panel_Level.Controls.Add(this.flowLayoutPanel1);
            this.panel_Level.Controls.Add(this.label_chooseLevel);
            this.panel_Level.Location = new System.Drawing.Point(0, 180);
            this.panel_Level.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Level.Name = "panel_Level";
            this.panel_Level.Size = new System.Drawing.Size(928, 396);
            this.panel_Level.TabIndex = 9;
            this.panel_Level.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.btn_easy);
            this.flowLayoutPanel1.Controls.Add(this.btn_adv);
            this.flowLayoutPanel1.Controls.Add(this.btn_exp);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 79);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(924, 298);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label_easy);
            this.flowLayoutPanel2.Controls.Add(this.label_adv);
            this.flowLayoutPanel2.Controls.Add(this.label_exp);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(907, 32);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // label_easy
            // 
            this.label_easy.AutoSize = true;
            this.label_easy.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_easy.Location = new System.Drawing.Point(4, 0);
            this.label_easy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_easy.Name = "label_easy";
            this.label_easy.Size = new System.Drawing.Size(272, 33);
            this.label_easy.TabIndex = 0;
            this.label_easy.Text = "           Kezdő               ";
            // 
            // label_adv
            // 
            this.label_adv.AutoSize = true;
            this.label_adv.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_adv.Location = new System.Drawing.Point(284, 0);
            this.label_adv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_adv.Name = "label_adv";
            this.label_adv.Size = new System.Drawing.Size(259, 33);
            this.label_adv.TabIndex = 1;
            this.label_adv.Text = "            Haladó           ";
            // 
            // label_exp
            // 
            this.label_exp.AutoSize = true;
            this.label_exp.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exp.Location = new System.Drawing.Point(551, 0);
            this.label_exp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_exp.Name = "label_exp";
            this.label_exp.Size = new System.Drawing.Size(175, 33);
            this.label_exp.TabIndex = 2;
            this.label_exp.Text = "              Profi";
            this.label_exp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_easy
            // 
            this.btn_easy.FlatAppearance.BorderSize = 0;
            this.btn_easy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_easy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_easy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_easy.Image = ((System.Drawing.Image)(resources.GetObject("btn_easy.Image")));
            this.btn_easy.Location = new System.Drawing.Point(4, 44);
            this.btn_easy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_easy.Name = "btn_easy";
            this.btn_easy.Size = new System.Drawing.Size(299, 238);
            this.btn_easy.TabIndex = 2;
            this.btn_easy.UseVisualStyleBackColor = true;
            this.btn_easy.Click += new System.EventHandler(this.btn_easy_Click);
            this.btn_easy.MouseEnter += new System.EventHandler(this.btn_easy_MouseEnter);
            this.btn_easy.MouseLeave += new System.EventHandler(this.btn_easy_MouseLeave);
            // 
            // btn_adv
            // 
            this.btn_adv.FlatAppearance.BorderSize = 0;
            this.btn_adv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_adv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_adv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adv.Image = ((System.Drawing.Image)(resources.GetObject("btn_adv.Image")));
            this.btn_adv.Location = new System.Drawing.Point(311, 44);
            this.btn_adv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_adv.Name = "btn_adv";
            this.btn_adv.Size = new System.Drawing.Size(299, 238);
            this.btn_adv.TabIndex = 3;
            this.btn_adv.UseVisualStyleBackColor = true;
            this.btn_adv.Click += new System.EventHandler(this.btn_adv_Click);
            this.btn_adv.MouseEnter += new System.EventHandler(this.btn_adv_MouseEnter);
            this.btn_adv.MouseLeave += new System.EventHandler(this.btn_adv_MouseLeave);
            // 
            // btn_exp
            // 
            this.btn_exp.FlatAppearance.BorderSize = 0;
            this.btn_exp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exp.Image = ((System.Drawing.Image)(resources.GetObject("btn_exp.Image")));
            this.btn_exp.Location = new System.Drawing.Point(618, 44);
            this.btn_exp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exp.Name = "btn_exp";
            this.btn_exp.Size = new System.Drawing.Size(299, 238);
            this.btn_exp.TabIndex = 4;
            this.btn_exp.UseVisualStyleBackColor = true;
            this.btn_exp.Click += new System.EventHandler(this.btn_exp_Click);
            this.btn_exp.MouseEnter += new System.EventHandler(this.btn_exp_MouseEnter);
            this.btn_exp.MouseLeave += new System.EventHandler(this.btn_exp_MouseLeave);
            // 
            // label_chooseLevel
            // 
            this.label_chooseLevel.AutoSize = true;
            this.label_chooseLevel.Font = new System.Drawing.Font("Kristen ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_chooseLevel.Location = new System.Drawing.Point(243, 0);
            this.label_chooseLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_chooseLevel.Name = "label_chooseLevel";
            this.label_chooseLevel.Size = new System.Drawing.Size(441, 45);
            this.label_chooseLevel.TabIndex = 0;
            this.label_chooseLevel.Text = "Válassz nehézségi szintet:";
            // 
            // panel_rules
            // 
            this.panel_rules.BackColor = System.Drawing.Color.Transparent;
            this.panel_rules.Controls.Add(this.label2);
            this.panel_rules.Controls.Add(this.label1);
            this.panel_rules.Location = new System.Drawing.Point(19, 161);
            this.panel_rules.Margin = new System.Windows.Forms.Padding(4);
            this.panel_rules.Name = "panel_rules";
            this.panel_rules.Size = new System.Drawing.Size(896, 428);
            this.panel_rules.TabIndex = 10;
            this.panel_rules.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kristen ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Szabályzat:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(57, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(770, 297);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.Color.Transparent;
            this.button_back.FlatAppearance.BorderSize = 0;
            this.button_back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.Location = new System.Drawing.Point(828, 580);
            this.button_back.Margin = new System.Windows.Forms.Padding(4);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(100, 76);
            this.button_back.TabIndex = 14;
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Visible = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            this.button_back.MouseEnter += new System.EventHandler(this.button_back_MouseEnter);
            this.button_back.MouseLeave += new System.EventHandler(this.button_back_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::LightUp_.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 655);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label_main);
            this.Controls.Add(this.panel_Level);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.panel_rules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "LightUp!";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel_Menu.ResumeLayout(false);
            this.panel_Level.ResumeLayout(false);
            this.panel_Level.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel_rules.ResumeLayout(false);
            this.panel_rules.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_main;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Panel panel_Level;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label_easy;
        private System.Windows.Forms.Label label_adv;
        private System.Windows.Forms.Label label_exp;
        private System.Windows.Forms.Button btn_easy;
        private System.Windows.Forms.Button btn_adv;
        private System.Windows.Forms.Button btn_exp;
        private System.Windows.Forms.Label label_chooseLevel;
        private System.Windows.Forms.Button btn_rules;
        private System.Windows.Forms.Panel panel_rules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_back;
    }
}

