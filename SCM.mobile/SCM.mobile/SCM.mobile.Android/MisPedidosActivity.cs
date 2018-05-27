
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SCM.mobile.Droid.Adapters;

namespace SCM.mobile.Droid
{
    [Activity(Label = "Lista de mis pedidos")]
    public class MisPedidosActivity : Activity
    {
        ListView lvMisPedidos;
        MisPedidosAdapter adapter;
        IProductosRepository repo;
        string numeroTelefono;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MisPedidos);
            lvMisPedidos = FindViewById<ListView>(Resource.Id.listPedidos);
            repo = new ApiProductosRepository();
            numeroTelefono = Intent.GetStringExtra("MyData") ?? "";
            //obtenerCatalogoProductos();
            lvMisPedidos.ItemClick += onItemClick;
        }

		protected override void OnResume()
		{
            base.OnResume();
            obtenerCatalogoProductos();
		}

		private void onItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var detalle = new Intent(this, typeof(RepartidorSignalR));
            detalle.PutExtra("MyData", adapter[e.Position].PedidoID);
            detalle.PutExtra("estado", adapter[e.Position].Estado);
            StartActivity(detalle);
        }
        public async void obtenerCatalogoProductos()
        {
            Pedido pedido = new Pedido();
            pedido.Telefono = numeroTelefono;
            List<Pedido> pedidos = await repo.LeerTodosPedidosPorTelefono(pedido);
            //listcatalogoProductos = productos;
            if(pedidos != null){
                adapter = new MisPedidosAdapter(this, pedidos);
                //Asignar a la lista
                lvMisPedidos.Adapter = adapter;   
            }else{
                Toast.MakeText(this, "Error al obtener los pedidos", ToastLength.Short).Show();
            }
        }
    }
}
