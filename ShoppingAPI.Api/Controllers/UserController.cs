using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Business.Abstract;
using ShoppingAPI.Entity.DTO.User;
using ShoppingAPI.Entity.Poco;
using System.Net;

namespace ShoppingAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/Users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("/Users/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetAsync(q => q.id == id);
            return Ok(user);
        }
        //Data Transfer Object
        [HttpPost("/AddUser")]
        [ProducesResponseType(typeof(UserResponseDTO),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser(UserRequestDTO userRequestDTO)
        {
            User user = new()
            {
                FirstName = userRequestDTO.Adi,
                LastName = userRequestDTO.Soyadi,
                UserName = userRequestDTO.KullaniciAdi,
                Password = userRequestDTO.Sifre,
                Email = userRequestDTO.EPosta,
                Phone = userRequestDTO.Tel,
                Adress = userRequestDTO.Adres,             
            };



            await _userService.AddAsync(user);

            UserResponseDTO userResponseDTO = new()
            {
                Guid = user.Guid,
                Adi = user.FirstName,
                Soyadi = user.LastName,
                KullaniciAdi = user.UserName,
                Sifre = user.Password,
                EPosta = user.Email,
                Tel = user.Phone,
                Adres = user.Adress,
            };


            return Ok(userResponseDTO);
        }
    }
}
