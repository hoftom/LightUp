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

namespace LightUp_
{
    internal class EasyLevel : GameManager
    {
        public EasyLevel(MainForm form) : base(form)
        {

            //Sets the access path
            filePath = "data/easy.txt";
            solvePath = "data/easy-solve.txt";

            //Sets the number of columns and rows
            gridSize = 7;
        }

        #region Adjusts the width/height and position of the game board
        //Sets the pixel value of the button light
        protected override Image GetButtonImage
        {
            get { return Resources.lightbulb_button_easy; }
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
        #endregion

        #region Adjusts the size of the buttons on the game board
        protected override int GetButtonWidth
        {
            get { return 35; }
        }
        protected override int GetButtonHeight
        {
            get { return 35; }
        }
        #endregion

    }
}
