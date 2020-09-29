using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class UpdateLabyrinthDTO // Work-in-progress
    {
        public string Id { get; set; }
        public LabyrinthSpace[][] LabyrinthSpaces { get; set; }
    }
}
