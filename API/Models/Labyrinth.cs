﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Labyrinth
    {
        public string Id { get; set; }
        public LabyrinthSpace[][] labyrinthSpaces { get; set; }
    }
    public enum LabyrinthSpace
    {
        Empty,
        Wall,
        Start,
        End
    }
}
