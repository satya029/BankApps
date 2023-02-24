using Bank.Application.AccountDomain.Commands;
using Bank.Application.CQRS.Interface;
using Bank.Application.Models;
using Bank.Application.UsersAccount.Queries;
using Bank.Application.Utils;
using Bank.Core.Entities;
using Bank.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("customer/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly ICommandsBus _commandBus;
        private readonly IQueryBus _queryBus;
     
        public BankAccountController(ICommandsBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost("GetAccountsForUser/{userId}")]
        [Authorize(Roles = Consts.UserRole)]
        public IActionResult GetAccountsForUser(int userId)
        {
            var accounts = _queryBus.Send<GetAccountForUserIdQuery, IEnumerable<BankAccountModel>>(
                new GetAccountForUserIdQuery
                {
                    UserId = userId
                });

            return Ok(accounts);
        }

        [HttpPost("TransferMoney")]
        public IActionResult TransferMoney(MoneyTransferCommand moneyTransfer)
        {
            _commandBus.Send(moneyTransfer);
            return Ok();
        }
    }
}