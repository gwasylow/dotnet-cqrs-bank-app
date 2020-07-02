using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Models;
using CQRS.BankApp.Core.Services;
using CQRS.BankApp.Persistance.Entities;
using System.Linq;
using CQRS.BankApp.Persistance.Repositories;
using CQRS.BankApp.Core.Domains.UserDomain.Queries;

namespace CQRS.BankApp.Core.Domains.UserDomain.QueryHandlers
{
    public class GetTokenForUserQueryHanlder : IHandleQuery<LoginQuery, JWTModel>
    {
        private readonly JWTTokenService _tokenService;
        private readonly GenericRepository<TblLogins> _loginsRepository;

        public GetTokenForUserQueryHanlder(JWTTokenService tokenService, GenericRepository<TblLogins> loginsRepository)
        {
            _tokenService = tokenService;
            _loginsRepository = loginsRepository;
        }
        public JWTModel Handle(LoginQuery query)
        {
            var userAuthDetails = _loginsRepository.GetAll().FirstOrDefault(x => x.Login == query.Login && x.Password == query.Password);

            if (userAuthDetails != null)
            {
                return new JWTModel
                {
                    Token = _tokenService.GenerateJWT(query),
                    UserId = userAuthDetails.Id
                };
            }

            return new JWTModel { Token = string.Empty, UserId = -1 };
        }
    }
}
