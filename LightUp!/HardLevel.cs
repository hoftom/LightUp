using LightUp_.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static LightUp_.GameManager;

namespace LightUp_
{
    internal class HardLevel : GameManager
    {
        public HardLevel(MainForm form) : base(form)
        {

            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);

            filePath = Path.GetFullPath(Path.Combine(dirPath, "data/hard.txt"));
            solvePath = Path.GetFullPath(Path.Combine(dirPath, "data/hard-solve.txt"));

            gridSize = 14;
        }
        protected override Image GetButtonImage
        {
            get { return Resources.lightbulb_button_hard; }
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
