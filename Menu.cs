using System.Drawing.Text;
using System.Media;

namespace Pong
{
    public partial class Menu : Form
    {
        //GameScreen gameScreen = new GameScreen();
        //HelpScreen helpScreen = new HelpScreen();
        SoundPlayer soundPlayer = new SoundPlayer(@"..\..\..\resources\audio\Menu Theme.wav");

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
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
            this.Hide();
            gameScreen.ShowDialog();
            this.Show();

            soundPlayer.PlayLooping(); // replay after going back to menu
        }

        private void goToHelp(object sender, EventArgs e)
        {
            HelpScreen helpScreen = new HelpScreen();

            // switch to help screen when button is clicked
            this.Hide();
            helpScreen.ShowDialog();
            this.Show();
        }

        private void exitGame(object sender, EventArgs e)
        {


            // Exit game when clicked
            this.Close();
        }
    }
}