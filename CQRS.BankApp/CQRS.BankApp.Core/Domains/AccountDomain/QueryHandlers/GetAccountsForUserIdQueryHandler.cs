using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.AccountDomain.Queries;
using CQRS.BankApp.Core.Models;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.BankApp.Core.Domains.AccountDomain.QueryHandlers
{
    public class GetAccountsForUserIdQueryHandler : IHandleQuery<GetAccountForUserIdQuery, IEnumerable<BankAccountModel>>
    {
        private readonly GenericRepository<TblBankAccounts> _bankAccountRepository;

        public GetAccountsForUserIdQueryHandler(GenericRepository<TblBankAccounts> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public IEnumerable<BankAccountModel> Handle(GetAccountForUserIdQuery query)
        {
            return _bankAccountRepository.GetAll()
                .Where(x => x.Login.Id == query.UserId)
                .Select(x => new BankAccountModel
                {
                    AccountNo = x.AccountNo,
                    Balance = x.Balance,
                    Id = x.Id
                });
        }
    }
}
