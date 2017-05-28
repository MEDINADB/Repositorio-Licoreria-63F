using LiqourStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiqourStore.Entities;

namespace LiqourStore.Persistence.Repositories
{
    public class UnityOfWork : IUnityofWork
    {
        private readonly LiqourStoreDbContext _Context;
     

        public  IClienteRepository Cliente { get; private set; }

        public ICompraRepository Compra { get; private set; }

        public  IEmpleadoRepository Empleado { get; private set; }

        public IMarcaRepository Marca { get; private set; }

        public IProductoRepository Producto { get; private set; }

        public IProveedorRepository Proveedor { get; private set; }

        public ISucursalRepository Sucursal { get; private set; }

        public  ITiendaRepository Tienda { get; private set; }

        //public ITipoProductoRepository TipoProducto { get; private set; }

        //public ITipoVentaRepository TipoVenta { get; private set; }

        public  IVentaRepository Venta { get; private set; }

       public static UnityOfWork Instance { get; set; }

        public UnityOfWork()
        {

        }

        public   UnityOfWork( LiqourStoreDbContext context)
        {
            _Context = new LiqourStoreDbContext();
 
            Cliente = new ClienteRepository(_Context);

            Compra = new CompraRepository(_Context);

            Empleado = new EmpleadoRepository(_Context);

            Marca = new MarcaRepository(_Context);

            Producto = new ProductoRepository(_Context);

            Proveedor = new ProveedorRepository(_Context);

            Tienda = new TiendaRepository(_Context);

            Sucursal = new SucursalRepository(_Context);

            //TipoProducto = new TipoProductoRepository(_Context);

            //TipoVenta = new TipoVentaRepository(_Context);

            Venta = new VentaRepository(_Context);       

        }


        public void Dispose()
        {
            _Context.Dispose();
        }

        //metodo que guarda los cambios. lleva los cambios en memoria hacia la base de datos.
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        //metodo que cambia el estado de una entidad en el entityframework para que luego se cambie en la base de datos
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }



        public void StateModified(Producto producto)
        {
            throw new NotImplementedException();
        }

        public void StateModified()
        {
            throw new NotImplementedException();
        }

        public void StateModified(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
