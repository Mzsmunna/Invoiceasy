using Invoiceasy.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.MongoRepository.Repositories
{
    public class RepositoryBase
    {
        protected IMongoDatabase _database;

        public RepositoryBase(IDatabaseContext dbContext)
        {
            IDatabaseContextContainer<IMongoDatabase> dbContextContainer = (IDatabaseContextContainer<IMongoDatabase>)dbContext;
            _database = dbContextContainer.GetInstance();
        }
    }
}
