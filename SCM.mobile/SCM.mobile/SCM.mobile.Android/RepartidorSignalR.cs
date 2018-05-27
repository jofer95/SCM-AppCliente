
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

namespace SCM.mobile.Droid
{
    [Activity(Label = "RepartidorSignalR")]
    public class RepartidorSignalR : Activity
    {
        PedidosClient pedidos;
        EditText editPedido;
        EditText editCoordenadas;
        string pedidoId;
        string estatusPedido;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RepartidorSingalR);
            pedidoId = Intent.GetStringExtra("MyData") ?? "";
            estatusPedido = Intent.GetStringExtra("estado") ?? "";
            //btnIniciar = FindViewById<Button>(Resource.Id.btnIniciar);
            //btnEsperar = FindViewById<Button>(Resource.Id.btnEsperando);

            editPedido = FindViewById<EditText>(Resource.Id.editPedido);
            editCoordenadas = FindViewById<EditText>(Resource.Id.editCoordenadas);
            editPedido.Text = pedidoId;
            pedidos = new PedidosClient();

            /*pedidos.OnPedidoIniciado += Pedidos_OnPedidoIniciado;
            pedidos.OnUbicacionCambio += Pedidos_OnUbicacionCambio;
            pedidos.OnEstoyEsperando += Pedidos_OnEstoyEsperando;*/

            pedidos = new PedidosClient();
            pedidos.OnPedidoIniciado += Pedidos_OnPedidoIniciado;
            pedidos.OnUbicacionCambio += Pedidos_OnUbicacionCambio;        }

		protected override async void OnResume()
		{
            base.OnResume();
            if(estatusPedido.Equals("EN")){
                await pedidos.Connect();
                await pedidos.EsperarPedido(pedidoId);
            }
		}

		void Pedidos_OnPedidoIniciado(object sender, EventArgs e)
        {
            //txtEstado.Text = "Pedido iniciado en " + DateTime.Now.ToShortTimeString();
        }
        void Pedidos_OnUbicacionCambio(object sender, UbicacionCambioEventArgs e)
        {
            RunOnUiThread(() => editCoordenadas.Text = e.Latitud.ToString() + "," + e.Longitud.ToString());
        }

	}
}
