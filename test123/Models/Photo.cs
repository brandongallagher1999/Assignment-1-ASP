using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test123.Models
{
    public class Photo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("caption")]
        public string caption { get; set; }

        [BsonElement("tagged_people")]
        public string[] tagged_people { get; set; }

        [BsonElement("location")]
        public string location { get; set; }
    }
}
