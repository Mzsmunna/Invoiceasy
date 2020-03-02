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
    public class ProductRepository : RepositoryBase
    {
        private static IMongoCollection<ProductEntity> Collection { get; set; }
        private MongoDBCore<ProductEntity> Core;

        static ProductRepository()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ProductEntity)))
            {
                BsonClassMap.RegisterClassMap<ProductEntity>(map =>
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

        public ProductRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
            try
            {
                if (Collection == null)
                {
                    Collection = _database.GetCollection<ProductEntity>("Products");
                }
                Core = new MongoDBCore<ProductEntity>(Collection);
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

        private FilterDefinition<ProductEntity> BuildFilter(string _id)
        {
            var filter = Builders<ProductEntity>.Filter.Empty;

            if (!string.IsNullOrEmpty(_id) && _id.ToLower() != "undefined")
            {
                filter = filter & Builders<ProductEntity>.Filter.Eq("_id", _id);
            }

            return filter;
        }
        public async Task<ProductEntity> GetProductById(string _id)
        {
            var filter = BuildFilter(_id);
            return await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);

        }

        public async Task<List<ProductEntity>> GetAllProductsByField(string fieldName, string fieldValue)
        {
            var filter = Builders<ProductEntity>.Filter.Eq(fieldName, fieldValue);
            var result = await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
            //var result = await Collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<List<ProductEntity>> GetAllProducts()
        {
            var filter = BuildFilter(null);
            return await Collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        public string Save(IEntity entity)
        {
            var returnVal = string.Empty;

            try
            {
                MongoDbOperationResult result = new MongoDBHelper<ProductEntity>(Collection).Save(entity).Result;
                returnVal = result.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnVal;
        }

        public void DropProduct()
        {
            try
            {
                _database.DropCollection("Products");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DropAllProductData(string _id)
        {
            try
            {
                var collectionProduct = _database.GetCollection<ProductEntity>("Products");
                //var idsFilter = Builders<ProductEntity>.Filter.Eq(d => d.Id, _id);
                //collectionProduct.DeleteMany(idsFilter);

                var filter = Builders<ProductEntity>.Filter.Empty;
                collectionProduct.DeleteMany(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
