﻿
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
        Button btnIniciar;
        Button btnEsperar;
        EditText editLat;
        EditText editLon;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RepartidorSingalR);
            btnIniciar = FindViewById<Button>(Resource.Id.ed);
            btnEsperar = FindViewById<Button>(Resource.Id.listPedidos);

            editLat = FindViewById<EditText>(Resource.Id.ed);
            editLon = FindViewById<EditText>(Resource.Id.listPedidos);
            pedidos = new PedidosClient();

            pedidos.OnEstoyEsperando += Pedidos_OnEstoyEsperando;
            // Create your application here
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await pedidos.Connect();
        }

        async void IniciarBtn_Click(Object sender, System.EventArgs e){
            var pedido = tvPrueba1.Text;
            await pedidos.IniciarRecorrido(pedido);
        }

        async void SpLat_ProgressChanged(Object sender, System.EventArgs e){
            //var lat = SpLat_Progress;
            //var lon = SpLat_Progress;
            await pedidos.NotificarUbicacion(tvPrueba1.Text, 123, 2315);
        }

        void Pedidos_OnEstoyEsperando(object sender,System.EventArgs e){
            //Toast;
        }
	}
}
