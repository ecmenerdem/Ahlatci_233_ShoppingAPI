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

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("/Users")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();

            List<UserResponseDTO> userDTOList = new();

            foreach (var user in users)
            {
                userDTOList.Add(_mapper.Map<UserResponseDTO>(user));

            }

            return Ok(Sonuc<List<UserResponseDTO>>.SuccessWithData(userDTOList));
        }

        [HttpGet("/User/{id}")]
        [ProducesResponseType(typeof(Sonuc<UserResponseDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetAsync(q => q.id == id);

            if (user!=null)
            {
                UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);

                return Ok(Sonuc<UserResponseDTO>.SuccessWithData(userDTO));
            }
            return NotFound(Sonuc<UserResponseDTO>.SuccessNoDataFound("Kullanıcı Bulunamadı"));
           
        }

        //Data Transfer Object
        [HttpPost("/AddUser")]
        [ProducesResponseType(typeof(Sonuc<UserResponseDTO>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser(UserRequestDTO userRequestDTO)
        {
            UserRegisterValidation userRegisterValidation = new UserRegisterValidation();

            if (userRegisterValidation.Validate(userRequestDTO).IsValid)
            {
                User user = _mapper.Map<User>(userRequestDTO);
                await _userService.AddAsync(user);
                UserResponseDTO userResponseDTO = _mapper.Map<UserResponseDTO>(user);
                return Ok(Sonuc<UserResponseDTO>.SuccessWithData(userResponseDTO));
            }
            else
            {
                List<string> ValidatonMessages = new List<string>();
                for (int i = 0; i < userRegisterValidation.Validate(userRequestDTO).Errors.Count; i++)
                {
                    ValidatonMessages.Add(userRegisterValidation.Validate(userRequestDTO).Errors[i].ErrorMessage);
                }
                throw new FieldValidationException(ValidatonMessages);
            }

            
        }
    }
}
