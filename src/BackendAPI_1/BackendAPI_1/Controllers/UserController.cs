using BackendAPI_1.Contacts;
using BackendAPI_1.Contacts.User;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                Id = result.Id,
                Firstname = result.Firstname,
                Lastname = result.Lastname,
                Middlename = result.Middlename,
                Birthdate = result.Birthdate,
                Login = result.Login,
                Email = result.Email,
                Password = result.Password,
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new User()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Middlename = request.Middlename,
                Birthdate = request.Birthdate,
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
            };
            await _userService.Create(userDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }

    }
}