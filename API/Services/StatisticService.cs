using API.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class StatisticService
    {
        private readonly IMongoCollection<Statistic> _statistics;   // Her opretter vi en variabel for statistikkerne i databasen

        public StatisticService(ILabyrinthDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);    // Her opretter vi en variabel for forbindelse til vores MongoDB vha. "ConnectionString" i appsettings.json
            var database = client.GetDatabase(settings.DatabaseName);   // Her opretter vi en variabel for databasen vha. "DatabaseName" i appsettings.json

            _statistics = database.GetCollection<Statistic>(settings.StatisticsCollectionName); // Her henter vi samlingen af statistikker fra databasen og putter dem i _statistics variablen. 
                                                                                                // Dette gør vi vha. "StatisticsCollectionName" i appsettings.json
        }

        public List<Statistic> Get() =>
            _statistics.Find(statistic => true).ToList();   // Hent alle statistikker fra databasen og put dem i en list

        public Statistic Get(string id) =>
            _statistics.Find(statistic => statistic.Labyrinths_id == id).FirstOrDefault();  // Hent en specifik statistik vha. statistikkens id

        public List<Statistic> GetAllForId(string id) =>
            _statistics.Find(statistic => statistic.Labyrinths_id == id).ToList();  // Hent alle statistikker for en labyrint vha. labyrintens id

        public Statistic Create(Statistic statistic)
        {
            _statistics.InsertOne(statistic);   // Indsæt "labyrinth" i databasen
            return statistic;   // Retuner objektet der blev sat ind i databasen
        }

        public void Update(string id, Statistic statisticIn) =>
            _statistics.ReplaceOne(statistic => statistic.Id == id, statisticIn);   // Opdater labyrinten i databasen

        public void Remove(string id) =>
            _statistics.DeleteOne(statistic => statistic.Id == id);     // Slet labyrint fra databasen
    }
}
