using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoiceasy.Entity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Invoiceasy.MongoRepository.Core
{
    internal class MongoDbOperationResult
    {
        internal string Id { get; set; }
        internal bool IsCompleted { get; set; }
    }
    internal class MongoDBHelper<T> where T : class
    {
        private IMongoCollection<T> collection { get; set; }
        public MongoDBHelper(IMongoCollection<T> collection)
        {
            this.collection = collection;
        }
        internal async Task<MongoDbOperationResult> Save(IEntity entity)
        {
            var _entity = entity as T;
            var _id = _entity.GetType().GetProperty("Id").GetValue(_entity, null);

            if (_id != null && !string.IsNullOrEmpty(_id.ToString()))
            {
                //upadte
                BsonDocument query = new BsonDocument {
                    { "_id" , ObjectId.Parse(_id.ToString()) }
                };

                if (_entity.GetType().GetProperty("ModifiedOn") != null)
                    _entity.GetType().GetProperty("ModifiedOn").SetValue(_entity, DateTime.Now);

                var result = await collection.ReplaceOneAsync(query, _entity).ConfigureAwait(false);
                return new MongoDbOperationResult() { Id = _id.ToString(), IsCompleted = result.IsAcknowledged };

            }
            else
            {
                //create
                var _generatedId = ObjectId.GenerateNewId().ToString();
                //_entity.GetType().GetProperty("CreatedOn").SetValue(_entity, DateTime.Now);

                if (_entity.GetType().GetProperty("ModifiedOn") != null)
                    _entity.GetType().GetProperty("ModifiedOn").SetValue(_entity, DateTime.Now);

                _entity.GetType().GetProperty("Id").SetValue(_entity, _generatedId);
                await collection.InsertOneAsync(_entity).ConfigureAwait(false);

                // have to return tru for the moment, due to lack of return type support.
                return new MongoDbOperationResult() { Id = _generatedId, IsCompleted = true };
            }
        }
        internal async Task<MongoDbOperationResult> Delete(IEntity entity)
        {
            var _entity = entity as T;
            var _id = _entity.GetType().GetProperty("Id").GetValue(_entity, null);

            BsonDocument query = new BsonDocument {
                    { "_id" , ObjectId.Parse(_id.ToString()) }
                };

            var result = await collection.DeleteOneAsync(query).ConfigureAwait(false);
            return new MongoDbOperationResult() { Id = _id.ToString(), IsCompleted = result.IsAcknowledged };

        }
    }
}
