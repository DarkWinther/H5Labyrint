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
    public class LabyrinthService
    {
        private readonly IMongoCollection<Labyrinth> _labyrinths;   // Her opretter vi en variabel for labyrinterene i databasen

        public LabyrinthService(ILabyrinthDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);    // Her opretter vi en variabel med forbindelsen til vores MongoDB vha. "ConnectionString" i appsettings.json
            var database = client.GetDatabase(settings.DatabaseName);   // Her henter vi den database vi bruger vha. "DatabaseName" i appsettings.json

            _labyrinths = database.GetCollection<Labyrinth>(settings.LabyrinthsCollectionName); // Her henter vi samlingen af labyrinter fra databasen og putter dem i _labyrinths variablen. 
                                                                                                // Dette gør vi vha. "LabyrinthsCollectionName" i appsettings.json
        }

        public List<Labyrinth> Get() =>
            _labyrinths.Find(labyrinth => true).ToList();   // Hent alle labyrinter fra databasen og put dem i en list

        public Labyrinth Get(string id) =>
            _labyrinths.Find(labyrinth => labyrinth.Id == id).FirstOrDefault();  // Hent en specifik labyrint vha. labyrintens id

        public Labyrinth GetRandom() => 
            _labyrinths.AsQueryable().Sample(1).FirstOrDefault();   // Hent en tilfældig labyrint fra databasen

        public Labyrinth Create(Labyrinth labyrinth)
        {
            _labyrinths.InsertOne(labyrinth);   // Indsæt "labyrinth" i databasen
            return labyrinth;   // Retuner objektet der blev sat ind i databasen
        }

        public void Update(string id, Labyrinth labyrinthIn) =>
            _labyrinths.ReplaceOne(labyrinth => labyrinth.Id == id, labyrinthIn);   // Opdater labyrinten i databasen

        public void Remove(string id) =>
            _labyrinths.DeleteOne(labyrinth => labyrinth.Id == id);     // Slet labyrint fra databasen
    }
}
