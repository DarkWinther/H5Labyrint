using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Statistic
    {
        public string Id { get; set; }

        public int[][] LabyrinthGrid { get; set; }
        public int SecondsSpentOnAttempt { get; set; }
    }
}
