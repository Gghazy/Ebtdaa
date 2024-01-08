﻿using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualProductionAndCapacitiesController : ControllerBase
    {
        private readonly IActualProductionService _actualProductionService;

        public ActualProductionAndCapacitiesController(IActualProductionService actualProductionService)
        {
            _actualProductionService = actualProductionService;
        }
      
        // GET api/<ActualProductionAndCapacitiesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok( await _actualProductionService.GetOne(id));
        }

        // POST api/<ActualProductionAndCapacitiesController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ActualProductionRequestDto req)
        {
            return Ok(await _actualProductionService.AddAsync(req));
        }

        // PUT api/<ActualProductionAndCapacitiesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] ActualProductionRequestDto req)
        {
            return Ok(await _actualProductionService.UpdateAsync(req));
        }

        // DELETE api/<ActualProductionAndCapacitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
