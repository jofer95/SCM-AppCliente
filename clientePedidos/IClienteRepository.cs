using System;
using System.Collections.Generic;

namespace clientePedidos
{
    public interface IClienteRepository

    {
        List<Cliente> LeerCliente();
        Cliente LeerPorId(int ClienteId);
        void GuardarCliente(Cliente c);

    }
}
