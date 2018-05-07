
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
    [Activity(Label = "CatalogoActivity")]
    public class CatalogoActivity : Activity
    {
        ListView lvCatalogo;
        CatalogoAdapter adapter;
        IProductosRepository repo;
        String numeroTelefono;
        List<Producto> listcatalogoProductos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Catalogo);
            Button btnCerrarSesion = FindViewById<Button>(Resource.Id.btnSalir);
            Button btnMisPedidos = FindViewById<Button>(Resource.Id.btnMisPedidos);
            lvCatalogo = FindViewById<ListView>(Resource.Id.listProductos);
            repo = new ApiProductosRepository();
            numeroTelefono = Intent.GetStringExtra("MyData") ?? "";
            obtenerCatalogoProductos();
            lvCatalogo.ItemClick += onItemClick;
            btnCerrarSesion.Click += cerrarSesionClick;
            btnMisPedidos.Click += misPedidosClick;
        }

        private void misPedidosClick(object sender, EventArgs e)
        {
            var misPedidos = new Intent(this, typeof(MisPedidosActivity));
            misPedidos.PutExtra("MyData", numeroTelefono);
            StartActivity(misPedidos);
        }

        private void cerrarSesionClick(object sender, EventArgs e)
        {
            Finish();
        }

        private void onItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
        }
        public async void obtenerCatalogoProductos(){
            List<Producto> productos = await repo.LeerProductos();
            listcatalogoProductos = productos;
            adapter = new CatalogoAdapter(this, listcatalogoProductos);
            //Asignar a la lista
            lvCatalogo.Adapter = adapter;
        }
    }
}
