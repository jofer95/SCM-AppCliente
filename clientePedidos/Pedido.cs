using System;
namespace clientePedidos
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public int Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }
        public int Total { get; set; }

        
    }
}
