using Invoiceasy.Helper;
using Invoiceasy.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoiceasy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppContentInitialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LandingForm());
        }

        static void AppContentInitialize()
        {
            string appDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy";

            if (!Directory.Exists(appDocumentPath))
            {
                FileSystemUtility.CreateFolder(appDocumentPath);
                string sourceDirectory = Environment.CurrentDirectory + @"\Libs";
                string targetDirectory = appDocumentPath + @"\Libs";
                FileSystemUtility.CopyFolder(sourceDirectory, targetDirectory);
            }
        }
    }
}
