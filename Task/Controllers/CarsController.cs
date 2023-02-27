using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.DALL.Data.Context;
using Task.DALL.Models;
using Task.DALL.Repository.Interface;
using Task.Models.Car;
using Task.Models.User;
namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IBaseRepository<Car> repository;
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public CarsController(IBaseRepository<Car> repository, AppDbContext context, IMapper mapper)
        {
            this.repository = repository;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarResponseModel>>> GetCars()
        {
            var carResponses = await repository.GetAll();

            var carsResponseModels = mapper.Map<IEnumerable<CarResponseModel>>(carResponses);

            return Ok(carsResponseModels);
        }
        [HttpPost]
        public async Task<ActionResult<CarResponseModel>> CreateCar([FromBody] CreateCarRequestModel requestModel) //Post to Car(userId property can not be null)
        {
            var request = mapper.Map<Car>(requestModel);
            var carResponse = await repository.Add(request);

            var carResponseModel = mapper.Map<CarResponseModel>(carResponse);

            return CreatedAtAction(nameof(GetCars), new { id = carResponseModel.Id }, carResponseModel);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CarResponseModel>> GetCarId(int id) //Id of Car
        {
            var carResponse = await repository.GetId(id);
            if (carResponse == null)
            {
                return NotFound();
            }
            var todoItemResponseModel = mapper.Map<CarResponseModel>(carResponse);

            return Ok(todoItemResponseModel);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCarRequestModel requestModel) //Update Method
        {
            var carToUpdate = await repository.GetId(id);
            if (carToUpdate == null)
            {
                return NotFound();
            }
            var request = mapper.Map<Car>(requestModel);
            await repository.Update(id, request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) // Delete
        {
            var user = await repository.GetId(id);
            if (user == null)
            {
                return NotFound();
            }
            await repository.Delete(id);

            return NoContent();
        }
    }
}
