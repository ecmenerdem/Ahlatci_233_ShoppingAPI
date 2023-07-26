using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Api.Validation.FluentValidation;
using ShoppingAPI.Business.Abstract;
using ShoppingAPI.Entity.DTO.Category;
using ShoppingAPI.Entity.DTO.User;
using ShoppingAPI.Entity.Poco;
using ShoppingAPI.Entity.Result;
using ShoppingAPI.Helper.CustomException;
using System.Net;

namespace ShoppingAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("/Users")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
        }

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetAsync(q => q.id == id);
        }
            return NotFound(Sonuc<UserResponseDTO>.SuccessNoDataFound("Kullanıcı Bulunamadı"));
           
        }

        //Data Transfer Object
        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser(UserRequestDTO userRequestDTO)
        {
            {
            await _userService.AddAsync(user);
            {


            return Ok(userResponseDTO);
        }
    }
}
