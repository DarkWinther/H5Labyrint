using API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class LabyrinthService
    {
        private readonly IMongoCollection<Labyrinth> _labyrinths;

        public LabyrinthService(ILabyrinthDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _labyrinths = database.GetCollection<Labyrinth>(settings.LabyrinthsCollectionName);
        }

        public List<Labyrinth> Get() =>
            _labyrinths.Find(labyrinth => true).ToList();

        public Labyrinth Get(string id) =>
            _labyrinths.Find<Labyrinth>(labyrinth => labyrinth.Id == id).FirstOrDefault();

        public Labyrinth Create(Labyrinth labyrinth)
        {
            _labyrinths.InsertOne(labyrinth);
            return labyrinth;
        }

        public void Update(string id, Labyrinth labyrinthIn) =>
            _labyrinths.ReplaceOne(labyrinth => labyrinth.Id == id, labyrinthIn);

        public void Remove(Labyrinth labyrinthIn) =>
            _labyrinths.DeleteOne(labyrinth => labyrinth.Id == labyrinthIn.Id);

        public void Remove(string id) =>
            _labyrinths.DeleteOne(labyrinth => labyrinth.Id == id);
    }
}
