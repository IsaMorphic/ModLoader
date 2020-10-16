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
                var form = new MainForm(GameList.SelectedItem as Game);
                form.FormClosed += (s, ev) => Show();
                form.Show();
            }
        }

        private async void AddGameButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new GameForm();
            dialog.ShowDialog();

            if (dialog.GameName != null && dialog.GamePath != null)
            {
                Hide();
                var waiter = new WaitingForm("Initializing game.\nThis may take a while...");
                waiter.Show();
                await GameManager.AddGameAsync(dialog.GameName, dialog.GamePath);
                GameList.Items.Clear();
                GameList.Items.AddRange(GameManager.Games.ToArray());
                waiter.Close();
                Show();
                MessageBox.Show("Game initialized!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GameList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool enabled = GameList.SelectedItem != null;
            LoadGameButton.Enabled = enabled;
            RemoveGameButton.Enabled = enabled;
        }

        private async void RemoveGameButton_Click(object sender, System.EventArgs e)
        {
            var game = GameList.SelectedItem as Game;

            if (game == null) return;

            var shouldContinue = MessageBox.Show(
                "NOTE: This is very dangerous.\n" +
                "If you plan to move forward with this, make sure you have all of your mods unloaded and that the game still functions!\n" +
                "This will not delete the actual game, just the ModLoader related aspects of it.\n" +
                $"Are you sure you want to delete all of {game}'s mods, configuration data and scripts?",
                "WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );

            if (shouldContinue == DialogResult.Yes)
            {
                Hide();

                var waiter = new WaitingForm($"Deleting all of {game}'s mods, configuration data and scripts.\nThis may take a while...");
                waiter.Show();

                await GameManager.RemoveGameAsync(game);

                GameList.Items.Clear();
                GameList.Items.AddRange(GameManager.Games.ToArray());

                waiter.Hide();

                Show();

                MessageBox.Show(
                    $"{game.Name} was deleted successfully.\n" +
                    "Just a friendly reminder: The developer of ModLoader is not in any way responsible for any consequences that result from this action.\n" +
                    "If you fricked something up, you're on your own!\n" +
                    "~Yodadude2003",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
            }
        }
    }
}
