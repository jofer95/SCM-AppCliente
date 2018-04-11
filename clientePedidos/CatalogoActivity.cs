
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

namespace clientePedidos
{
    [Activity(Label = "CatalogoActivity")]
    public class CatalogoActivity : Activity
    {
        ListView lv;
        Button PedidoBt;
        IRepository repo;
        PizzaLVAdapter adapter;

        public string dbPath = System.IO.Path.Combine(
                         System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
               "clientes.bd3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SQLRepository repo = new SQLRepository(dbPath);
            repo.inicializar();
            // Create your application here

            SetContentView(Resource.Layout.Catalogo);

            lv = FindViewById<ListView>(Resource.Id.listView1);
            var pizza = repo.LeerPizza();
            adapter = new PizzaLVAdapter(this, pizza);

            lv.ItemClick += Lv_ItemClick;
            PedidoBt.Click += PedidoBt_Click;


        }


        protected override void OnResume()
        {
            base.OnResume();
            if (lv != null)
            {
                var pizza = repo.LeerPizza();

                adapter = new PizzaLVAdapter(this, pizza);
                lv.Adapter = adapter;

            }
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var CatalogoIntent = new Intent(this, typeof(CatalogoActivity));
            CatalogoIntent.PutExtra("PizzaId", adapter[e.Position].Id);
            StartActivity(CatalogoIntent);
        }
        private void PedidoBt_Click(object sender, EventArgs e)
        {
            var PedidoIntent = new Intent(this, typeof(PedidosActivity));
            StartActivity(PedidoIntent);
        }

    }
}
