using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Pong
{
    public partial class HelpScreen : Form
    {
        public HelpScreen()
        {
            InitializeComponent();
        }

        PrivateFontCollection fontCollection = new PrivateFontCollection(); // CUSTOM FONT
        private void HelpScreen_Load(object sender, EventArgs e)
        {
            fontCollection.AddFontFile(Application.StartupPath + @"..\..\..\resources\fonts\ThaleahFat.ttf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(fontCollection.Families[0], c.Font.Size, c.Font.Style);
            }

            lblHelp1.Text = "Use W/Up Arrow to move up\nUse S/Down Arrow to move down\n\nGet the ball past the opponent to get a point\nFirst one to 10 points wins";
        }

        private void goBack(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
