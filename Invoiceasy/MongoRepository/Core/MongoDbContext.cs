using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Invoiceasy.Interface;
using Invoiceasy.Service;
using MongoDB.Driver;

namespace Invoiceasy.MongoRepository.Core
{
    public class MongoDbContext : IDatabaseContextContainer<IMongoDatabase>, IDatabaseContext
    {
        private static IMongoDatabase database;
        private static int retryCount = 3;


        private static bool IsTransient(Exception ex)
        {
            var webException = ex as WebException;
            if (webException != null)
            {
                return new[] {WebExceptionStatus.ConnectionClosed,
                  WebExceptionStatus.Timeout,
                  WebExceptionStatus.RequestCanceled }.
                        Contains(webException.Status);
            }

            return false;
        }

        private static IMongoDatabase Database
        {
            get
            {
                int currentRetry = 0;

                if (database == null)
                {
                    var client = new MongoClient(ConfigService.DatabaseConnectionString);
                    database = client.GetDatabase(ConfigService.DatabaseName);

                }
                return database;
            }
        }

        public IMongoDatabase GetInstance()
        {
            return Database;
        }
    }
}
