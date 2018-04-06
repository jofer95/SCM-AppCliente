using System;
using System.Collections.Generic;

namespace clientePedidos
{
    public interface IPedidoRepository

    {
        List<Pizza> LeerPizza();
        Pizza LeerPorId(int PizzaId);
        void Ordenar(Pizza p);
        void CancelarPedido(Pizza p);
        void EditarPedido(Pizza p);
        void Ubicacion(Pizza p);
        void inicializar();

    }
}
