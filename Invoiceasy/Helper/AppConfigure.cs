using Invoiceasy.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoiceasy.Helper
{
    public static class AppConfigure
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }

        public static string DatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseName"];
            }
        }

        public static string MediaLocation
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MediaLocation"]))
                {
                    return ConfigurationManager.AppSettings["MediaLocation"];
                }
                return null;
            }
        }

        public static string InvoiceChallanNo
        {
            get
            {
                return ConfigurationManager.AppSettings["InvoiceChallanNo"];
            }
            set
            {
                ConfigurationManager.AppSettings["InvoiceChallanNo"] = value;
            }
        }

        public static List<string> InvoiceChallanCode
        {
            get
            {
                var codes = ConfigurationManager.AppSettings["InvoiceChallanCode"];
                var listOfCode = codes.Split(',').ToList();
                return listOfCode;
            }
            set
            {
                var listOfCode = value;
                string codes = string.Join(",", listOfCode);
                ConfigurationManager.AppSettings["InvoiceChallanCode"] = codes;
            }
        }

        public static string GetInvoiceChallanCode(InvoiceChallanCode icNo)
        {
            int index = icNo.ToString().LastIndexOf(@"_");
            string subString = string.Empty;

            if (index != -1)
            {
                subString = icNo.ToString().Substring(index + 1);
            }

            return subString;
        }

        public static bool ExecuteOnce
        {
            get
            {
                string key = "ExecuteOnce";
                if (ConfigurationManager.AppSettings[key] != null && !string.IsNullOrEmpty(ConfigurationManager.AppSettings[key] as string))
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings[key] as string);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                string key = "ExecuteOnce";
                bool setValue = value;
                var setValueAsString = setValue.ToString().ToLower();

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings[key].Value = setValueAsString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
        }
    }
}
