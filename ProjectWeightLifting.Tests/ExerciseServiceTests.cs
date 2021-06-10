using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using ProjectWeightLifting.Api.Models;
using ProjectWeightLifting.Api.Repositories.Interfaces;
using ProjectWeightLifting.Api.Services.Implementations;
using Xunit;

namespace ProjectWeightLifting.Tests
{
    public class ExerciseServiceTests
    {
        private Exercise _exercise1;
        private Exercise _exercise2;
        private IEnumerable<Exercise> _exerciseList;

        public ExerciseServiceTests()
        {
            _exercise1 = new Exercise()
            {
                Id = 1,
                Name = "Snatch"
            };
            _exercise2 = new Exercise()
            {
                Id = 2,
                Name = "Clean"
            };
            _exerciseList = new[] {_exercise1, _exercise2};
        }

        [Fact]
        public async void GetAll_NotEmpty()
        {
            var unitOfWork =  new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Exercises.GetAllAsync()).Returns(Task.FromResult(_exerciseList));
            var service = new ExerciseService(unitOfWork.Object);
            var actual = await service.GetAll();
            Assert.NotEmpty(actual);
        }
        
        [Fact]
        public async void GetAll_ReturnEmpty()
        {
            _exerciseList = new Exercise[] {};
            var unitOfWork =  new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Exercises.GetAllAsync()).Returns(Task.FromResult(_exerciseList));
            var service = new ExerciseService(unitOfWork.Object);
            var actual = await service.GetAll();
            Assert.Empty(actual);
        }
        
        [Fact]
        public async void GetById_NotNull()
        {
            var unitOfWork =  new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Exercises.GetByIdAsync(1)).Returns(new ValueTask<Exercise>(Task.FromResult(_exercise1)));
            var service = new ExerciseService(unitOfWork.Object);
            var actual = await service.GetById(1);
            Assert.NotNull(actual);
            Assert.Equal(1, actual.Id);
        }
        
        [Fact]
        public async void GetById_Null()
        {
            var unitOfWork =  new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Exercises.GetByIdAsync(It.IsAny<int>())).Returns(null);
            var service = new ExerciseService(unitOfWork.Object);
            var actual = await service.GetById(1);
            Assert.Null(actual);
        }
    }
}