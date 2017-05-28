using LiqourStore.Entities;
using LiqourStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.Repositories
{
    public class TiendaRepository : Repository<Tienda>, ITiendaRepository
    {
        public TiendaRepository(LiqourStoreDbContext context):base(context)
		{
        }

    }
}
