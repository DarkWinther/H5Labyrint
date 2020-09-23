using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Statistic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string LabyrinthId { get; set; }

        public int[][] LabyrinthGrid { get; set; }
        public int SecondsSpentOnAttempt { get; set; }
    }
}
