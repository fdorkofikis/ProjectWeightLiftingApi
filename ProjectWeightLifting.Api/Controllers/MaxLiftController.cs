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
    public class MaxLiftController : ControllerBase
    {
        private readonly IMaxService _maxService;
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;
        
        public MaxLiftController(IMaxService maxService, IExerciseService exerciseService, IMapper mapper)
        {
            _maxService = maxService;
            _exerciseService = exerciseService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaxLiftDTO>>> GetAll()
        {
            var maxes = await _maxService.GetAll();
            var maxDTOs = _mapper.Map<IEnumerable<MaxLift>, IEnumerable<MaxLiftDTO>>(maxes);
            return Ok(maxDTOs);
        }
        
        [HttpGet("forExerciseId")]
        public async Task<ActionResult<IEnumerable<MaxLiftDTO>>> GetAllForExercise(int id)
        {
            var exercise = await _exerciseService.GetById(id);
            var maxes = await _maxService.GetAllForExercise(exercise);
            var maxDTO = _mapper.Map<IEnumerable<MaxLift>, IEnumerable<MaxLiftDTO>>(maxes);
            return Ok(maxDTO);
        }
        
        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<MaxLiftDTO>>> GetAllLatest()
        {
            var maxes = await _maxService.GetAllLatest();
            var maxDTO = _mapper.Map<IEnumerable<MaxLift>, IEnumerable<MaxLiftDTO>>(maxes);
            return Ok(maxDTO);
        }
        
        [HttpGet("best")]
        public async Task<ActionResult<IEnumerable<MaxLiftDTO>>> GetAllBest()
        {
            var maxes = await _maxService.GetAllBest();
            var maxDTO = _mapper.Map<IEnumerable<MaxLift>, IEnumerable<MaxLiftDTO>>(maxes);
            return Ok(maxDTO);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MaxLiftDTO>> GetById(int id)
        {
            var max = await _maxService.GetById(id);
            var maxDTO = _mapper.Map<MaxLift, MaxLiftDTO>(max);

            return Ok(maxDTO);
        }
        
        [HttpPost]
        public async Task<ActionResult<MaxLiftDTO>> CreateNew([FromBody] MaxLiftDTO saveMaxLift)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
    
            var maxToCreate = _mapper.Map<MaxLiftDTO, MaxLift>(saveMaxLift);

            var newMax = await _maxService.CreateNew(maxToCreate);

            var max = await _maxService.GetById(newMax.Id);

            var maxDTO = _mapper.Map<MaxLift, MaxLiftDTO>(max);

            return Ok(maxDTO);
        }
        
        [HttpPut]
        public async Task<ActionResult<MaxLiftDTO>> Update([FromBody] MaxLiftDTO saveMaxLift)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
    
            var maxToUpdate = await _maxService.GetById(saveMaxLift.Id);

            if (maxToUpdate == null)
                return NotFound();

            var max = _mapper.Map<MaxLiftDTO, MaxLift>(saveMaxLift);

            await _maxService.Update(maxToUpdate, max);

            var updatedMax = await _maxService.GetById(max.Id);
            var updatedMaxDTO = _mapper.Map<MaxLift, MaxLiftDTO>(updatedMax);

            return Ok(updatedMaxDTO);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
    
            var bodyWeight = await _maxService.GetById(id);

            if (bodyWeight == null)
                return NotFound();

            await _maxService.Delete(bodyWeight);

            return Ok();
        }
    }
}