using System;

namespace ProjectWeightLifting.Api.Models
{
    public class MaxLift
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}