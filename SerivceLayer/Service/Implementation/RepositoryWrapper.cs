using RepositoryLayer.DbContextLayer;
using SerivceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerivceLayer.Service.Implementation
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private ApplicationDbContext _dbContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            this._dbContext = context;
        }

        public IOwnerRepository Owner
        {
            get
            {
                if(_owner == null)
                {
                    _owner = new OwnerRepository(_dbContext);
                }
                return _owner;
            }
        }
        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_dbContext);
                }
                return _account;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
