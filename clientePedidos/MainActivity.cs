using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace clientePedidos
{
    [Activity(Label = "clientePedidos", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Button EntrarBt;
        EditText NombeTxt;
        EditText NumeroTxt;
        IPedidoRepository repo;

        //int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            repo = PedidosApp.Repositorio;
            repo.inicializar();

            string dbPath = System.IO.Path.Combine(
               System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
               "clientes.bd3");
            //repo = new ISQLitePedidoRepository (dbPath);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EntrarBt = FindViewById<Button>(Resource.Id.btnEntrar);
            NombeTxt = FindViewById<EditText>(Resource.Id.editNombre);
            NumeroTxt = FindViewById<EditText>(Resource.Id.editNumero);


            // Get our button from the layout resource,
            // and attach an event to it
            EntrarBt.Click += EntrarBt_Click;
            //button.Click += delegate { button.Text = $"{count++} clicks!";};

        }

        private void EntrarBt_Click(object sender, EventArgs e)
        {
            var EntrarIntent = new Intent(this, typeof(CatalogoActivity));
            StartActivity(EntrarIntent);
        }
    }
}

