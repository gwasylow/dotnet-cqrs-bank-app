using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.UserDomain.Queries;
using CQRS.BankApp.Core.Models;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;

namespace CQRS.BankApp.Core.Domains.UserDomain.QueryHandlers
{
    public class GetUserDetailsQueryHandler : IHandleQuery<GetUserDetailsQuery, UserDetailsModel>
    {
        private readonly GenericRepository<TblLogins> _loginsRepository;

        public GetUserDetailsQueryHandler(GenericRepository<TblLogins> loginsRepository)
        {
            _loginsRepository = loginsRepository;
        }
        public UserDetailsModel Handle(GetUserDetailsQuery query)
        {
            var user = _loginsRepository.GetById(query.UserId);
            return new UserDetailsModel { Login = user.Login };
        }
    }
}
