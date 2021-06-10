using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeightLifting.Api.DTO
{
    public class MaxLiftDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ExerciseDTO Exercise { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}