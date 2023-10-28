using LightUp_.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LightUp_.GameManager;

namespace LightUp_
{
    internal class MediumLevel : GameManager
    {
        public MediumLevel(MainForm form) : base(form)
        {

            filePath = "data/med.txt";
            solvePath = "data/med-solve.txt";

            gridSize = 10;
        }
        protected override Image GetButtonImage
        {
            get { return Resources.lightbulb_button_med; }
        }
        protected override int GetPanelWidth
        {
            get { return 380; }
        }
        protected override int GetPanelHeight
        {
            get { return 560; }
        }
        protected override Point GetPanelLocation
        {
            get { return new Point(50, 160); }
        }


        protected override int GetButtonWidth
        {
            get { return 30; }
        }
        protected override int GetButtonHeight
        {
            get { return 30; }
        }
    }
}
