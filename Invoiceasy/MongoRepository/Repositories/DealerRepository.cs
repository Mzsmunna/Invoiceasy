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
    public class DealerRepository : RepositoryBase
    {
        private static IMongoCollection<DealerEntity> Collection { get; set; }
        private MongoDBCore<DealerEntity> Core;

        static DealerRepository()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(DealerEntity)))
            {
                BsonClassMap.RegisterClassMap<DealerEntity>(map =>
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

        public DealerRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
            try
            {
                if (Collection == null)
                {
                    Collection = _database.GetCollection<DealerEntity>("Dealers");
                }
                Core = new MongoDBCore<DealerEntity>(Collection);
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

        private FilterDefinition<DealerEntity> BuildFilter(string _id)
        {
            var filter = Builders<DealerEntity>.Filter.Empty;

            if (!string.IsNullOrEmpty(_id) && _id.ToLower() != "undefined")
            {
                filter = filter & Builders<DealerEntity>.Filter.Eq("_id", _id);
            }

            return filter;
        }
        public async Task<DealerEntity> GetDealerById(string _id)
        {
            var filter = BuildFilter(_id);
            return await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);

        }

        public async Task<List<DealerEntity>> GetAllDealersByField(string fieldName, string fieldValue)
        {
            var filter = Builders<DealerEntity>.Filter.Eq(fieldName, fieldValue);
            var result = await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
            //var result = await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<List<DealerEntity>> GetAllDealers()
        {
            var filter = BuildFilter(null);
            return await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        public string Save(IEntity entity)
        {
            var returnVal = string.Empty;

            try
            {
                MongoDbOperationResult result = new MongoDBHelper<DealerEntity>(Collection).Save(entity).Result;
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
                _database.DropCollection("Dealers");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DropMemberMetaDataHumanaPayer(string _id)
        {
            try
            {
                var collectionDealer = _database.GetCollection<DealerEntity>("Dealers");
                var idsFilter = Builders<DealerEntity>.Filter.Eq(d => d.Id, _id);
                collectionDealer.DeleteMany(idsFilter);
                //_database.DropCollection("MemberMetaDataHumana");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
