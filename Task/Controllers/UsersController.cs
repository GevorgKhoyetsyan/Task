using AutoMapper;
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
    public class UsersController : ControllerBase
    {
        private readonly IBaseRepository<User> repository;
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public UsersController(IBaseRepository<User> repository, AppDbContext context, IMapper mapper)
        {
            this.repository = repository;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserResponseModel>>> GetUsers() //Get
        {
            var carResponses = await repository.GetAll(); // car repository

            var carsResponseModels = mapper.Map<IEnumerable<GetUserResponseModel>>(carResponses);

            return Ok(carsResponseModels);
        }
        [HttpGet("GetId{id}")]
        public async Task<ActionResult<GetUserResponseModel>> GetUserId(int id)
        {
            var userResponse = await repository.GetId(id); // GetId
            if (userResponse == null)
            {
                return NotFound();
            }
            var userResponseModel = mapper.Map<GetUserResponseModel>(userResponse);

            return Ok(userResponseModel);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<GetUserResponseModel>> CreateUser([FromBody] CreateUserRequestModel requestModel) //Create User
        {
            var request = mapper.Map<User>(requestModel);
            var userResponse = await repository.Add(request);

            var userResponseModel = mapper.Map<GetUserResponseModel>(userResponse);

            return CreatedAtAction(nameof(GetUsers), new { id = userResponseModel.Id }, userResponseModel);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserRequestModel requestModel) //Update Method
        {
            var userToUpdate = await repository.GetId(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            var request = mapper.Map<User>(requestModel);
            await repository.Update(id, request);

            return NoContent();
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteUser(int id) //Delete
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
