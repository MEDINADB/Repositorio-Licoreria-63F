using LiqourStore.Entities;
using LiqourStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Persistence.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(LiqourStoreDbContext context):base(context)
		{
        }

        public void Delete(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
