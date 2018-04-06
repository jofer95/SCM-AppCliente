using System;
using Android.App;

namespace clientePedidos
{
    [Application]
    public class PedidosApp :Application
    {
        private static IPedidoRepository _repositorio;

        public static IPedidoRepository Repositorio
        {
            get
            {
                return _repositorio;
            }
        }
        public override void OnCreate()
        {
            base.OnCreate();
            string dbPath = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "clientes.bd3");
            //_repositorio = new ISQLitePedidoRepository(dbPath);
        }
    }
}
