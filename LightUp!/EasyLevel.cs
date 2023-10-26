﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightUp_
{
    internal class EasyLevel : GameManager
    {
        public EasyLevel(MainForm form) : base(form)
        {
            solvePath = "C:/Users/hoffm/OneDrive/Asztali gép/projects/C#/LightUp!/Data/easy-solve.txt";
            filePath = "C:/Users//hoffm/OneDrive/Asztali gép/projects/C#/LightUp!/Data/easy.txt";

            gridSize = 7;
        }

        protected override int GetPanelWidth
        {
            get { return 300; }
        }
        protected override int GetPanelHeight
        {
            get { return 560; }
        }
        protected override Point GetPanelLocation
        {
            get { return new Point(126, 170); }
        }


        protected override int GetButtonWidth
        {
            get { return 35; }
        }
        protected override int GetButtonHeight
        {
            get { return 35; }
        }

    }
}