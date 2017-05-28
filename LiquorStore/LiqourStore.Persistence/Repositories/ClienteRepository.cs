using LiqourStore.Entities;
using LiqourStore.Entities.IRepositories;
using LiqourStore.Entities.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LiqourStore.Persistence.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(LiqourStoreDbContext context) : base(context)
        {
        }
    }
       
}
