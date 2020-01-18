using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoiceasy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //System.Diagnostics.Process.Start(@"cmd.exe", @"/k c:\path\my.exe");

            if (AllocConsole())
            {
                TestEnvironment.Program();

                FreeConsole();
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();
    }
}
