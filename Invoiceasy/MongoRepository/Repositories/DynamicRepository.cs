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
    public class DynamicRepository<T> : RepositoryBase where T : IEntity, new()
    {
        private static IMongoCollection<T> Collection { get; set; }
        private MongoDBCore<T> Core;

        static DynamicRepository()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
            {
                BsonClassMap.RegisterClassMap<T>(map =>
                {
                    //map.SetIsRootClass(true);
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    //map.MapIdMember(x => x.Id);
                    //map.MapProperty(x => x.Id).SetElementName("_id");
                    //map.GetMemberMap(x => x.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));

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
                BsonClassMap.RegisterClassMap<T>();
            }

        }

        public DynamicRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
            try
            {
                if (Collection == null)
                {
                    Collection = _database.GetCollection<T>("Dealers");
                }
                Core = new MongoDBCore<T>(Collection);
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

        private FilterDefinition<T> BuildFilter(string _id)
        {
            var filter = Builders<T>.Filter.Empty;

            if (!string.IsNullOrEmpty(_id) && _id.ToLower() != "undefined")
            {
                filter = filter & Builders<T>.Filter.Eq("_id", _id);
            }

            return filter;
        }

        public async Task<T> GetDataById(string _id)
        {
            var filter = BuildFilter(_id);
            return await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);

        }

        public async Task<List<T>> GetDataByField(string fieldName, string fieldValue)
        {
            var filter = Builders<T>.Filter.Eq(fieldName, fieldValue);
            var result = await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
            //var result = await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<List<T>> GetAllData()
        {
            var filter = BuildFilter(null);
            return await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        public string Save(IEntity entity)
        {
            var returnVal = string.Empty;

            try
            {
                MongoDbOperationResult result = new MongoDBHelper<T>(Collection).Save(entity).Result;
                returnVal = result.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnVal;
        }

        public void DropCollection()
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

        public void DropAllData(string _id)
        {
            try
            {
                var collectionDealer = _database.GetCollection<T>("Dealers");
                //var idsFilter = Builders<T>.Filter.Eq(d => d.Id, _id);
                //collectionDealer.DeleteMany(idsFilter);
                //_database.DropCollection("MemberMetaDataHumana");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
