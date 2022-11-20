using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Domain;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogManager _logger;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryManager repository, ILogManager logManager, IMapper mapper)
        {
            _repository = repository;
            _logger = logManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var usersList = await _repository.User.GetAllUsersAsync(false);

            // Not a good idea to expose domain entity
            var usersDtos = _mapper.Map<IEnumerable<UsersDto>>(usersList);

            return Ok(usersDtos);
        }

        /// <summary>
        /// Get user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId:int}")]
        public async Task<IActionResult> Users(int userId)
         {
            if (userId <= 0)
            {
                _logger.Info($"Invalid User Id: {userId} ");

                return BadRequest("Invalid User Id");
            }

            var user = await _repository.User.GetUserAsync(userId, false);

            if (user == null)
            {
                _logger.Info($"User Id: {userId} doesn't exist in the database.");

                return NotFound("Couldn't find the userId");
            }

            var userDto = _mapper.Map<UsersDto>(user);

            return Ok(userDto);

        }


        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Users([FromBody] UsersDto userDto)
        {
            if (userDto == null)
            {
                _logger.Error("Invalid userDto object");

                return BadRequest("userDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.Error("Invalid model state for userDto object");

                // returns http 422 error
                return UnprocessableEntity(ModelState);
            }

            // Business rule, that user email address must be unique

            var existingUser = _repository.User.FindUserByEmail(userDto.Email);

            if (existingUser != null)
            {
                _logger.Error($"User with Email: {userDto.Email} exist.");

                return BadRequest($"User with Email: {userDto.Email} exist.");
            }

            var user = _mapper.Map<User>(userDto);

            await _repository.User.CreateUserAsync(user);

            await _repository.SaveAsync();

            return Ok();
        }
    }
}
