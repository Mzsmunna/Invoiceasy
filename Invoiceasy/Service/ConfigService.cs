using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Invoiceasy.Interface;
using Invoiceasy.MongoRepository.Core;
using Invoiceasy.Helper;

namespace Invoiceasy.Service
{
    public class ConfigService
    {
        public static string DatabaseConnectionString
        {
            get
            {
                string valString = null;
                var valSettings = AppConfigure.ConnectionString;
                if (valSettings != null)
                {
                    valString = valSettings;
                }
                return valString;
            }
        }

        public static string DatabaseName
        {
            get
            {
                string valString = null;
                var valSettings = AppConfigure.DatabaseName;
                if (valSettings != null)
                {
                    valString = valSettings;
                }
                return valString;
            }
        }

        public IDatabaseContext DatabaseContext
        {
            get
            {
                return new MongoDbContext();
            }
        }
    }
}
