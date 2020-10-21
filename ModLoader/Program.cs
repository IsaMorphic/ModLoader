using ModLoader.Core;
using System;
using System.Windows.Forms;

namespace ModLoader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Game.DefaultPackImageStream = System.Reflection.Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("ModLoader.Resources.UnderDevPack.png");
            Game.DefaultPackNote = "This is a generated test pack. Once you're ready to ship your mod, go to Build->Pack and follow the steps!";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ManagerForm());
        }
    }
}
