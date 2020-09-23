using API.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class StatisticService
    {
        private readonly IMongoCollection<Statistic> _statistics;

        public StatisticService(ILabyrinthDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _statistics = database.GetCollection<Statistic>(settings.StatisticsCollectionName);
        }

        public List<Statistic> Get() =>
            _statistics.Find(statistic => true).ToList();

        public Statistic Get(string id) =>
            _statistics.Find(statistic => statistic.Id == id).FirstOrDefault();

        public Statistic GetRandom() =>
            _statistics.AsQueryable().Sample(1).FirstOrDefault();

        public Statistic Create(Statistic statistic)
        {
            _statistics.InsertOne(statistic);
            return statistic;
        }

        public void Update(string id, Statistic statisticIn) =>
            _statistics.ReplaceOne(statistic => statistic.Id == id, statisticIn);

        public void Remove(Statistic statisticIn) =>
            _statistics.DeleteOne(statistic => statistic.Id == statisticIn.Id);

        public void Remove(string id) =>
            _statistics.DeleteOne(statistic => statistic.Id == id);
    }
}
