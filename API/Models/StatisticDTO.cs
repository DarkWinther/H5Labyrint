﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class StatisticDTO
    {
        public int[][] LabyrinthPathGrid { get; set; }
        public int SecondsSpentOnAttempt { get; set; }
    }
}
