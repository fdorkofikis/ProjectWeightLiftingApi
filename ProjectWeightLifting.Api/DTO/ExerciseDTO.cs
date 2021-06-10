using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeightLifting.Api.DTO
{
    public class ExerciseDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public IEnumerable<MaxLiftDTO> MaxLifts { get; set; }
    }
}