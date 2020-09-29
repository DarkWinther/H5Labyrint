using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Statistic  // I denne class bruges MongoDB.Bson driver'en.
    {
        [BsonId]    // Her fortæller vi API'en at denne string er objektets Id.
        [BsonRepresentation(BsonType.ObjectId)] // Her fortæller vi API'en at Id representere et objekts ID.
        public string Id { get; set; }

        [BsonRequired]  // Her fortæller vi API'en at dette felt ikke må være tomt.
        [BsonRepresentation(BsonType.ObjectId)]
        public string Labyrinths_id { get; set; }   // Dette er ID'en for den labyrint statistikkerne tilhøre.

        [BsonRequired]
        public int[][] Traversal { get; set; }  // Traversal indeholder et grid over hvor mange gange hvert felt er blevet passeret.
        [BsonRequired]
        public int MillisecondsSpent { get; set; }  // Hvor langtid det tog at gennemføre labyrinten.
    }
}
