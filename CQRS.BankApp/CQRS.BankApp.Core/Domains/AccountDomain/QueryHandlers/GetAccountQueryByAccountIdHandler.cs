using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.AccountDomain.Queries;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;

namespace CQRS.BankApp.Core.Domains.AccountDomain.QueryHandlers
{
    public class GetAccountQueryByAccountIdHandler : IHandleQuery<GetAccountQueryById, TblBankAccounts>
    {
        private GenericRepository<TblBankAccounts> _accounts;

        public GetAccountQueryByAccountIdHandler(GenericRepository<TblBankAccounts> accounts)
        {
            _accounts = accounts;
        }
        public TblBankAccounts Handle(GetAccountQueryById query)
        {
            return _accounts.GetById(query.Id);
        }
    }
}
