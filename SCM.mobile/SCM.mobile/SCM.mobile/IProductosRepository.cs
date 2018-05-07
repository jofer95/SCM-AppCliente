using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.mobile
{
    interface IProductosRepository
    {
        Task<List<Producto>> LeerProductos();
        Task<List<Pedido>> LeerTodosPedidosPorTelefono(Pedido pedido);
        Task<bool> ActualizarEstadoPedido(Pedido pedido);
        Task<bool> RegistrarPedido(Pedido pedido);
    }
    public class Pedido
    {
        public string PedidoID { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string Producto { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Precio { get; set; }
        public string DescripcionProducto { get; set; }
        public string Estado { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
    public class Producto
    {
        public string Codigo
        {
            get;
            set;
        }

        public string Descripcion
        {
            get;
            set;
        }
        public decimal Precio
        {
            get;
            set;
        }

        public string Categoria
        {
            get;
            set;
        }
        public string Imagen
        {
            get;
            set;
        }

    }
}
