using LiqourStore.Entities;
using LiqourStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LiqourStore.Persistence.Repositories
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        public CompraRepository(LiqourStoreDbContext context):base(context)
		{
        }
        
    }
}
