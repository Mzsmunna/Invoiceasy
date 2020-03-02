using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Entity
{
    //[BsonDiscriminator(RootClass = true)]
    //[BsonKnownTypes(typeof(DealerEntity)/*, typeof(OtherEntity)*/)]
    public abstract class IEntity
    {
        //[BsonIgnore]
        //[BsonId]
        //public string Id { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public DateTime ModifiedOn { get; set; }
    }
}
