
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
    [Activity(Label = "Lista de mis pedidos")]
    public class MisPedidosActivity : Activity
    {
        ListView lvMisPedidos;
        MisPedidosAdapter adapter;
        IProductosRepository repo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MisPedidos);
            lvCatalogo = FindViewById<ListView>(Resource.Id.listProductos);
        }
    }
}
