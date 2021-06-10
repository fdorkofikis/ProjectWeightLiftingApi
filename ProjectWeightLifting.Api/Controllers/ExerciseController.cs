using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectWeightLifting.Api.DTO;
using ProjectWeightLifting.Api.Extensions;
using ProjectWeightLifting.Api.Models;
using ProjectWeightLifting.Api.Services.Interfaces;

namespace ProjectWeightLifting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _service;
        private readonly IMapper _mapper;
        
        public ExerciseController(IExerciseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDTO>>> GetAll()
        {
            var exercises = await _service.GetAll();
            var exerciseDTOs = _mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseDTO>>(exercises);
            return Ok(exerciseDTOs);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDTO>> GetById(int id)
        {
            try
            {
                var exercise = await _service.GetById(id);
                var exerciseDTO = _mapper.Map<Exercise, ExerciseDTO>(exercise);
                return Ok(exerciseDTO);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ExerciseDTO>> CreateNew([FromBody] ExerciseDTO saveExercise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var exerciseToCreate = _mapper.Map<ExerciseDTO, Exercise>(saveExercise);
            var newExercise = await _service.CreateNew(exerciseToCreate);
            var exerciseDTO = _mapper.Map<Exercise, ExerciseDTO>(newExercise);
            return Ok(exerciseDTO);
        }
        
        [HttpPut]
        public async Task<ActionResult<ExerciseDTO>> Update([FromBody] ExerciseDTO saveExercise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
    
            var exerciseToUpdate = await _service.GetById(saveExercise.Id);

            if (exerciseToUpdate == null)
                return NotFound();

            var exercise = _mapper.Map<ExerciseDTO, Exercise>(saveExercise);

            await _service.Update(exerciseToUpdate, exercise);

            var updatedExercise = await _service.GetById(exercise.Id);
            var updatedExerciseDTO = _mapper.Map<Exercise, ExerciseDTO>(updatedExercise);

            return Ok(updatedExerciseDTO);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
    
            var bodyWeight = await _service.GetById(id);

            if (bodyWeight == null)
                return NotFound();

            await _service.Delete(bodyWeight);

            return Ok();
        }
    }
}