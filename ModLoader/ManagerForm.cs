using ModLoader.Core;
using System.Linq;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class ManagerForm : Form
    {
        public GameManager GameManager { get; }

        public ManagerForm()
        {
            InitializeComponent();
            GameManager = new GameManager();
        }

        private async void ManagerForm_Load(object sender, System.EventArgs e)
        {
            await GameManager.InitializeAsync();
            GameList.Items.AddRange(GameManager.Games.ToArray());
        }

        private void LoadGameButton_Click(object sender, System.EventArgs e)
        {
            if (GameList.SelectedItem as Game != null)
            {
                Hide();
                new MainForm(GameList.SelectedItem as Game).ShowDialog();
                Show();
            }
        }

        private async void AddGameButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new GameForm();
            dialog.ShowDialog();

            if (dialog.GameName != null && dialog.GamePath != null)
            {
                Hide();
                var waiter = new WaitingForm("Initializing Game\nThis may take a while...");
                waiter.Show();
                await GameManager.AddGameAsync(dialog.GameName, dialog.GamePath);
                GameList.Items.Clear();
                GameList.Items.AddRange(GameManager.Games.ToArray());
                waiter.Close();
                Show();
                MessageBox.Show("Game initialized!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
