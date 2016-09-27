using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ifc4;
using Workspace = CafmConnect.Workspace;
using System.IO;
using System.Windows.Forms;

namespace CafmConnect.Samples
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainDLG());
        }
    }
}
