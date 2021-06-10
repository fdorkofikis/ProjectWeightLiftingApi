using AutoMapper;
using ProjectWeightLifting.Api.Models;

namespace ProjectWeightLifting.Api.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exercise, ExerciseDTO>().ReverseMap();
            CreateMap<MaxLift, MaxLiftDTO>().ReverseMap();
        }
    }
}