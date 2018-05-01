using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.mobile
{
    interface IProductosRepository
    {
        Task<List<Producto>> LeerProductos();
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
