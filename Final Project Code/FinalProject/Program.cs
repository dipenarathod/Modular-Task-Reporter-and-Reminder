using FinalProject.Common;
using FinalProject.Information_Collector_Plugins;
using FinalProject.Notifier;
using FinalProject.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());


        }
    }
}
