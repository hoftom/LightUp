using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LightUp_.GameManager;

namespace LightUp_
{
    internal class HardLevel : GameManager
    {
        public HardLevel(MainForm form) : base(form)
        {

            filePath = "C:/Users/Tamá$/Documents/GitHub/LightUp/LightUp!/Data/hard.txt";
            solvePath = "C:/Users/Tamá$/Documents/GitHub/LightUp/LightUp!/Data/hard-solve.txt";

            gridSize = 14;
        }

        protected override int GetPanelWidth
        {
            get { return 400; }
        }
        protected override int GetPanelHeight
        {
            get { return 560; }
        }
        protected override Point GetPanelLocation
        {
            get { return new Point(30, 130); }
        }


        protected override int GetButtonWidth
        {
            get { return 22; }
        }
        protected override int GetButtonHeight
        {
            get { return 22; }
        }
    }
}
