using ModLoader.Core;
using ModLoader.Core.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.IO;
using System.Windows.Forms;

namespace ModLoader
{
    public partial class WaitingForm : Form
    {
        public WaitingForm(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }
    }
}
