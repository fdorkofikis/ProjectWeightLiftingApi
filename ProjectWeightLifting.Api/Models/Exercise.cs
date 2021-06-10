﻿using System.Collections.Generic;

namespace ProjectWeightLifting.Api.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MaxLift> MaxLifts { get; set; }
    }
}