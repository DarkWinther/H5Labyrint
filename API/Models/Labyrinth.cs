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
        [BsonRepresentation(BsonType.ObjectId)] // Fortæller koden at Id representere et ObjectId.
        public string Id { get; set; }

        [BsonElement("Name")]   // Fortæller API'en at LabyrinthName hedder Name på serveren.
        public string LabyrinthName { get; set; }   // Både Name og Category må gerne være null.
        public string Category { get; set; }
        public LabyrinthSpace[][] LabyrinthSpaces { get; set; } // I dette array er labyrintens felter gemt.
    }
    public enum LabyrinthSpace
    {
        Empty,  // 0 er et frit felt
        Wall,   // 1 er en væg
        Start,  // 2 er start feltet
        Goal    // 3 er målet
    }
}
