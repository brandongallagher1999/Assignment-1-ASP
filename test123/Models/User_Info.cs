using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace test123.Models
{
    public class User_Info
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string username { get; set; }

        [BsonElement("posts")]
        public int posts { get; set; }

        [BsonElement("followers")]
        public int followers { get; set; }

        [BsonElement("following")]
        public int following { get; set; }

        [BsonElement("biography")]
        public string biography { get; set; }

        [BsonElement("profile_picture")]
        public string profile_picture { get; set; }

    }
}
