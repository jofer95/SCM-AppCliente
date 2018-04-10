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
        IRepository repo;

        //int count = 1;
        public string dbPath = System.IO.Path.Combine(
               System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
               "clientes.bd3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SQLRepository repo = new SQLRepository(dbPath);
            repo.inicializar();


            //repo = new ISQLitePedidoRepository (dbPath);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            NombeTxt = FindViewById<EditText>(Resource.Id.editNombre);
            NumeroTxt = FindViewById<EditText>(Resource.Id.editNumero);
            EntrarBt = FindViewById<Button>(Resource.Id.btnEntrar);


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

