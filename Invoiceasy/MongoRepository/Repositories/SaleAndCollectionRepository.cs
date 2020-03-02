using Invoiceasy.Entity;
using Invoiceasy.Interface;
using Invoiceasy.MongoRepository.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.MongoRepository.Repositories
{
    public class SaleAndCollectionRepository : RepositoryBase
    {
        private static IMongoCollection<SaleAndCollectionEntity> Collection { get; set; }
        private MongoDBCore<SaleAndCollectionEntity> Core;

        static SaleAndCollectionRepository()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(SaleAndCollectionEntity)))
            {
                BsonClassMap.RegisterClassMap<SaleAndCollectionEntity>(map =>
                {
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    map.MapProperty(x => x.Id).SetElementName("_id");
                    map.GetMemberMap(x => x.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));

                    //if (!BsonClassMap.IsClassMapRegistered(typeof(Response)))
                    //{
                    //    BsonClassMap.RegisterClassMap<Response>(child =>
                    //    {
                    //        child.AutoMap();
                    //        child.SetIgnoreExtraElements(true);

                    //        if (!BsonClassMap.IsClassMapRegistered(typeof(ReportingProperties)))
                    //        {
                    //            BsonClassMap.RegisterClassMap<ReportingProperties>(child2 =>
                    //            {
                    //                child2.AutoMap();
                    //                child2.SetIgnoreExtraElements(true);
                    //            });
                    //        }
                    //    });
                    //}
                });
            }

        }

        public SaleAndCollectionRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
            try
            {
                if (Collection == null)
                {
                    Collection = _database.GetCollection<SaleAndCollectionEntity>("SalesAndCollections");
                }
                Core = new MongoDBCore<SaleAndCollectionEntity>(Collection);
            }
            catch (Exception ex)
            {
                //new ExceptionWrapper(ex).Handle();
            }
            finally
            {
                //Do Nothing
            }
        }

        private FilterDefinition<SaleAndCollectionEntity> BuildFilter(string _id)
        {
            var filter = Builders<SaleAndCollectionEntity>.Filter.Empty;

            if (!string.IsNullOrEmpty(_id) && _id.ToLower() != "undefined")
            {
                filter = filter & Builders<SaleAndCollectionEntity>.Filter.Eq("_id", _id);
            }

            return filter;
        }
        public async Task<SaleAndCollectionEntity> GetSaleAndCollectionById(string _id)
        {
            var filter = BuildFilter(_id);
            return await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);

        }

        public async Task<List<SaleAndCollectionEntity>> GetAllSales()
        {
            var filter = BuildFilter(null);
            filter = filter & Builders<SaleAndCollectionEntity>.Filter.Where(x => x.SyncType.ToLower().Equals("sales"));
            return await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<SaleAndCollectionEntity>> GetAllCollections()
        {
            var filter = BuildFilter(null);
            filter = filter & Builders<SaleAndCollectionEntity>.Filter.Where(x => x.SyncType.ToLower().Equals("collections"));
            return await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<SaleAndCollectionEntity>> GetAllSalesAndCollectionsByField(string fieldName, string fieldValue)
        {
            var filter = Builders<SaleAndCollectionEntity>.Filter.Eq(fieldName, fieldValue);
            var result = await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
            //var result = await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<List<SaleAndCollectionEntity>> GetAllSalesByField(string fieldName, string fieldValue)
        {
            var filter = Builders<SaleAndCollectionEntity>.Filter.Eq(fieldName, fieldValue);
            filter = filter & Builders<SaleAndCollectionEntity>.Filter.Where(x => x.SyncType.ToLower().Equals("sales"));
            var result = await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<List<SaleAndCollectionEntity>> GetAllCollectionsByField(string fieldName, string fieldValue)
        {
            var filter = Builders<SaleAndCollectionEntity>.Filter.Eq(fieldName, fieldValue);
            filter = filter & Builders<SaleAndCollectionEntity>.Filter.Where(x => x.SyncType.ToLower().Equals("collections"));
            var result = await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<List<SaleAndCollectionEntity>> GetAllSalesAndCollections()
        {
            var filter = BuildFilter(null);
            return await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        public string Save(IEntity entity)
        {
            var returnVal = string.Empty;

            try
            {
                MongoDbOperationResult result = new MongoDBHelper<SaleAndCollectionEntity>(Collection).Save(entity).Result;
                returnVal = result.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnVal;
        }

        public void DropDealer()
        {
            try
            {
                _database.DropCollection("SalesAndCollections");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DropAllSalesAndCollectionsData(string _id)
        {
            try
            {
                var collectionDealer = _database.GetCollection<SaleAndCollectionEntity>("SalesAndCollections");
                //var idsFilter = Builders<SaleAndCollectionEntity>.Filter.Eq(d => d.Id, _id);
                //collectionDealer.DeleteMany(idsFilter);

                var filter = Builders<SaleAndCollectionEntity>.Filter.Empty;
                collectionDealer.DeleteMany(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
