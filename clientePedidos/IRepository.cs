using System;
using System.Collections.Generic;

namespace clientePedidos
{
    public interface IRepository
    {
        List<Pedido> LeerPedido();
        Pedido LeerPedidoId(int PedidoId);
        void CrearPedido (Pedido p);
        void CancelarPedido(Pedido p);
        void Ubicacion(Pedido p);
        void Actulizar(Pedido p);
        void inicializar();

        List<Pizza> LeerPizza();
        Pizza LeerPizzaId (int PizzaId);
        void CrearPizza(Pizza p);
        void BorrarPizza(Pizza p);

        List<Cliente> LeerCliente();
        Cliente LeerClienteId(int ClienteId);
        void GuardarCliente(Cliente c);

    }
}
