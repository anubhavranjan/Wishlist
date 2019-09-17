using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wishlist.Models
{
    public class Wish
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("updatedOn")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedOn { get; set; }

    }
}
