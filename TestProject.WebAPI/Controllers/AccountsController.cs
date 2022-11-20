using AutoMapper;
using Contracts;
using Domain;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AccountsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogManager _logger;
        private readonly IMapper _mapper;

        public AccountsController(IRepositoryManager repository, ILogManager logManager, IMapper mapper)
        {
            _repository = repository;
            _logger = logManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Accounts()
        {
            var accountsList = await _repository.Account.GetAllAccountsAsync(false);

            // Not a good idea to expose domain entity
            
            var accountsDto = _mapper.Map<IEnumerable<AccountsDto>>(accountsList);

            return Ok(accountsDto);
        }

        [HttpPost]
        
        public async Task<IActionResult> Accounts([FromBody] CreateAccountDto accountDto)
        {
            if (accountDto == null)
            {
                _logger.Info($"Invalid Account details");

                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.Info($"Invalid Model state. UserId: {accountDto.UserId} must be greater then 0. Not valid");

                return UnprocessableEntity(ModelState);
            }

            var user = await _repository.User.GetUserAsync(accountDto.UserId, false);

            if (user == null)
            {
                _logger.Info($"UserId: {accountDto.UserId} must be greater then 0. Not valid");

                return NotFound();
            }

            var account = _mapper.Map<Account>(accountDto);

            await _repository.Account.CreateAccountAsync(account);

            return Ok();
        }
    }
}
