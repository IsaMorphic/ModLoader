using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class GameManager
    {
        public string BasePath { get; }

        public HashSet<Game> Games { get; }

        public GameManager()
        {
            var dir = Environment.GetEnvironmentVariable("MODLOADER_PATH") ?? 
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ModLoader");
            BasePath = Path.Combine(dir, "Games");
            Games = new HashSet<Game>();
        }

        public Task InitializeAsync()
        {
            return Task.Run(() =>
            {
                Directory.CreateDirectory(BasePath);
                foreach (var dir in Directory.EnumerateDirectories(BasePath))
                {
                    var name = Path.GetFileName(dir);
                    Games.Add(new Game(this, name));
                }
            });
        }

        public async Task AddGameAsync(string name, string gamePath)
        {
            var game = new Game(this, name);
            await game.InitializeAsync(gamePath);
            Games.Add(game);
        }
    }
}
