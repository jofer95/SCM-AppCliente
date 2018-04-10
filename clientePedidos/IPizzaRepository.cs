using System;
using System.Collections.Generic;

namespace clientePedidos
{
    public interface IPizzaRepository
    {
        List<Pizza> LeerPizza();
        Pizza LeerPorId(int PizzaId);
        void CrearPizza(Pizza p);
        void BorrarPizza (Pizza p);

    }
}
