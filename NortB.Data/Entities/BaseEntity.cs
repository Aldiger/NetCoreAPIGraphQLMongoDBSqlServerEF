using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace NortB.Data.Entities
{
    public class BaseEntity
    {
        //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public int Id { get; set; }
    }
}