using DomainLayer.Models;
using RepositoryLayer.DbContextLayer;
using SerivceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerivceLayer.Service.Implementation
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
