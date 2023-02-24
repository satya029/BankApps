using Bank.Application.CQRS.Interface;
using Bank.Application.Models;
using Bank.Application.Users.Queries;
using Bank.Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = Consts.UserRole)]
    public class UserController : ControllerBase
    {
        private readonly IQueryBus _queryBus;

        public UserController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        [HttpPost("details")]
        public IActionResult GetUserDetails(GetUserDetailsQuery user)
        {
            var userDetailsQuery = _queryBus.Send<GetUserDetailsQuery, UserDetailsModel>(user);
            return Ok(userDetailsQuery);
        }
    }
}