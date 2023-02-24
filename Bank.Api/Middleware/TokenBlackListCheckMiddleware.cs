using Bank.Application.Utils;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;
using System.Net;

namespace Bank.Api.Middleware
{
    public class TokenBlackListCheckMiddleware : IMiddleware
    {
        private readonly GenericRepository<TblInvalidKeys> _invalidKeysRepository;

        public TokenBlackListCheckMiddleware(GenericRepository<TblInvalidKeys> invalidKeysRepository)
        {
            _invalidKeysRepository = invalidKeysRepository;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var tokenFromRequest = context.Request.Headers[Consts.Authorization].ToString();
            var isTokenBlacklisted = _invalidKeysRepository.GetAll().Any(x => tokenFromRequest.Contains(x.Key ?? ""));
            
            if(!isTokenBlacklisted)
            {
                await next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
    }
}
