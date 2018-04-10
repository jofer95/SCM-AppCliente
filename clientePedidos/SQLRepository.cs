using System;
using System.Collections.Generic;

namespace clientePedidos
{
    public class SQLRepository : IRepository
    {
        SQLiteConnection db;
        private static object l = new object();
        public SQLRepository(string path)
        {
            db = new SQLiteConnection(path);

        }

        public void BorrarPizza(Pizza p)
        {
            lock (l)
            {
              db.Delete<Pizza>(p.Id);
            }
         }

        public void CancelarPedido(Pedido p)
        {
            throw new NotImplementedException();
        }

        public void CrearPedido(Pedido p)
        {
            lock (l)
            {
                db.Insert(p);
            }       
        }

        public void CrearPizza(Pizza p)
        {
            throw new NotImplementedException();
        }

        public void EditarPedido(Pedido p)
        {
            throw new NotImplementedException();
        }

        public void GuardarCliente(Cliente c)
        {
            throw new NotImplementedException();
        }

        public void inicializar()
        {
            db.CreateTable<Cliente>();
        }

        public List<Cliente> LeerCliente()
        {
            lock (l)
            {
                return db.Table<Cliente>().ToList();
            }        }

        public Cliente LeerClienteId(int ClienteId)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> LeerPedido()
        {
            throw new NotImplementedException();
        }

        public Pedido LeerPedidoId(int PedidoId)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> LeerPizza()
        {
            lock (l)
            {
                return db.Table<Pizza>().ToList();
            }        }

        public Pizza LeerPizzaId(int PizzaId)
        {
            throw new NotImplementedException();
        }

        public void Ubicacion(Pedido p)
        {
            throw new NotImplementedException();
        }

        public void Actulizar(Pedido p)
        {
            lock (l)
            {
                var toUpdate = db.Find<Pedido>(p.Id);
                if (toUpdate != null)
                {
                    p.NombreCliente = p.NombreCliente;
                    p.Descripcion = p.Descripcion;
                    p.Longitud = p.Longitud;
                    p.Altitud = p.Altitud;
                    p.Estado = p.Estado;
                    db.Update(p);
                }
            }        }
    }
}
