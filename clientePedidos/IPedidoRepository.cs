using System;
using System.Collections.Generic;

namespace clientePedidos
{
    public interface IPedidoRepository

    {
        List<Pedido> LeerPedido();
        Pedido LeerPorId(int PedidoId);
        void Ordenar(Pedido p);
        void CancelarPedido(Pedido p);
        void EditarPedido(Pedido p);
        void Ubicacion(Pedido p);
        void inicializar();

    }
}
