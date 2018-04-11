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
            lock (l)
            {
                db.Delete<Pedido>(p.Id);
            }
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
            lock (l)
            {
                db.Insert(p);
            } 
        }

        public void GuardarCliente(Cliente c)
        {
            lock (l)
            {
                db.Insert(c);
            }        
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
            lock (l)
            {

                return db.Find<Cliente>(ClienteId);


            }        
        }

        public List<Pedido> LeerPedido()
        {
            lock (l)
            {
                return db.Table<Pedido>().ToList();
            }        
        }

        public Pedido LeerPedidoId(int PedidoId)
        {
            lock (l)
            {

                return db.Find<Pedido>(PedidoId);


            }        }

        public List<Pizza> LeerPizza()
        {
            lock (l)
            {
                return db.Table<Pizza>().ToList();
            }        }

        public Pizza LeerPizzaId(int PizzaId)
        {
            lock (l)
            {

                return db.Find<Pizza>(PizzaId);


            }        
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
            }      
        }
    }
}
