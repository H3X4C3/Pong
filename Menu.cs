using System.Drawing.Text;
using System.Media;

namespace Pong
{
    public partial class Menu : Form
    {
        // MUSIC
        SoundPlayer soundPlayer = new SoundPlayer(@"..\..\..\resources\audio\Menu Theme.wav");
        // CUSTOM FONT
        PrivateFontCollection fontCollection = new PrivateFontCollection();

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            fontCollection.AddFontFile(Application.StartupPath + @"..\..\..\resources\fonts\ThaleahFat.ttf");
            foreach(Control c in this.Controls)
            {
                c.Font = new Font(fontCollection.Families[0], c.Font.Size, c.Font.Style);
            }

            soundPlayer.PlayLooping();
        }

        private void goToGameScreen(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen();

            soundPlayer.Stop(); // stop playing music

            // switch to game screen when button is clicked
            try
            {
                this.Hide();
                gameScreen.ShowDialog();
                gameScreen.BringToFront();
                this.Show();

                soundPlayer.PlayLooping(); // replay after going back to menu
            } catch(Exception exception)
            {
                string error = exception.ToString();
            }
        }

        private void goToHelp(object sender, EventArgs e)
        {
            HelpScreen helpScreen = new HelpScreen();

            // switch to help screen when button is clicked
            this.Hide();
            helpScreen.ShowDialog();
            helpScreen.BringToFront();
            this.Show();
        }

        private void exitGame(object sender, EventArgs e)
        {
            // Exit game when clicked
            this.Close();
        }
    }
}