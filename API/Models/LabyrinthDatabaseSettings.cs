using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LabyrinthDatabaseSettings : ILabyrinthDatabaseSettings
    {
        public string LabyrinthsCollectionName { get; set; }
        public string StatisticsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILabyrinthDatabaseSettings
    {
        string LabyrinthsCollectionName { get; set; }
        string StatisticsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
