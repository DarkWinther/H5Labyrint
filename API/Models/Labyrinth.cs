using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class Labyrinth
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string LabyrinthName { get; set; }
        public string Category { get; set; }
        public LabyrinthSpace[][] labyrinthSpaces { get; set; }
    }
    public enum LabyrinthSpace
    {
        Empty,
        Wall,
        Start,
        Goal
    }
}
