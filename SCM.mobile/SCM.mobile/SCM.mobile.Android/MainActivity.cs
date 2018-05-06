using Android.App;
using Android.Widget;
using Android.OS;

namespace SCM.mobile.Droid
{
    [Activity(Label = "SCM.mobile", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        IProductosRepository repo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            repo = new ApiProductosRepository();
            button.Click += Button_Click;
        }

        async void Button_Click(object sender, System.EventArgs e)
        {
            var productos = await repo.LeerProductos();
        }
    }
}

