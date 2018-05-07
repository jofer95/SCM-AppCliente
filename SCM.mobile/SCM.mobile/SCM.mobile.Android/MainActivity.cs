using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace SCM.mobile.Droid
{
    [Activity(Label = "PizzasMoya!", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText tvNumeroTelefono;
        IProductosRepository repo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button btnIniciarSesion = FindViewById<Button>(Resource.Id.btnIniciarSesion);
            tvNumeroTelefono = FindViewById<EditText>(Resource.Id.editTelefonoLogin);
            repo = new ApiProductosRepository();
            btnIniciarSesion.Click += IniciarSesionClick;
        }

        public void IniciarSesionClick(object sender, System.EventArgs e)
        {
            string numero = tvNumeroTelefono.Text;
            if(!string.IsNullOrWhiteSpace(numero)){
                var iniciarSesion = new Intent(this, typeof(CatalogoActivity));
                iniciarSesion.PutExtra("MyData", numero);
                StartActivity(iniciarSesion);
            }else{
                Toast.MakeText(this, "Ingrese un numero de telefono", ToastLength.Short).Show();
            }
        }
    }
}

