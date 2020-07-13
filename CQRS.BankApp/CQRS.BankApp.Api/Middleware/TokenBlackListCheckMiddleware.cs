using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CQRS.BankApp.Api.Middleware
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
            //TODO: check token
            //if (_invalidKeysRepository.GetAll().FirstOrDefault(x => x.Key == context.Request.Headers["token"].ToString()) != null)
            //{
                await next(context);
            //}
            //else
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //}
        }
    }
}
