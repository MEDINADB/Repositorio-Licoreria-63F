using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqourStore.Entities.IRepositories
{
    public interface IUnityofWork :IDisposable
    {
        IClienteRepository Cliente { get; }
        ICompraRepository Compra { get; } 
        IEmpleadoRepository Empleado { get; }
        IMarcaRepository Marca { get; }
        IProductoRepository Producto { get; }
        IProveedorRepository Proveedor { get; }
        ISucursalRepository Sucursal { get; }
        ITiendaRepository Tienda { get; }
        IVentaRepository Venta { get; }

        int SaveChanges();
        void StateModified(object Entity);
    }
}
