using System;
using System.Collections.Generic;
using System.Net;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace SCM.mobile.Droid.Adapters
{
    public class MisPedidosAdapter : BaseAdapter<Pedido>
    {
        private Activity context;
        private List<Pedido> items;
        IProductosRepository repo;

        public MisPedidosAdapter(Activity context, List<Pedido> items)
        {
            this.context = context;
            this.items = items;
            repo = new ApiProductosRepository();
        }

        public override Pedido this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.itemMisPedidos, null);
            view.FindViewById<TextView>(Resource.Id.tvDescripcion).Text = "Descripció: " + item.DescripcionProducto;
            view.FindViewById<TextView>(Resource.Id.tvFechaPedido).Text = "Fecha del pedido: " + item.FechaPedido.ToString();
            view.FindViewById<TextView>(Resource.Id.tvEstatus).Text = "Estatus: " + item.Estado;
            if (item.Estado.Equals("CA"))
            {
                view.FindViewById<Button>(Resource.Id.btnCancelarPedido).Visibility = ViewStates.Gone;
                view.FindViewById<Button>(Resource.Id.btnCompletarPedido).Visibility = ViewStates.Gone;

                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Red);
            }
            else if (item.Estado.Equals("PR"))
            {
                view.FindViewById<Button>(Resource.Id.btnCancelarPedido).Visibility = ViewStates.Gone;
                view.FindViewById<Button>(Resource.Id.btnCompletarPedido).Visibility = ViewStates.Gone;
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Yellow);
            }
            else if (item.Estado.Equals("CO"))
            {
                view.FindViewById<Button>(Resource.Id.btnCancelarPedido).Visibility = ViewStates.Gone;
                view.FindViewById<Button>(Resource.Id.btnCompletarPedido).Visibility = ViewStates.Visible;
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Green);
            }
            else if (item.Estado.Equals("EN"))
            {
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Blue);
                view.FindViewById<Button>(Resource.Id.btnCancelarPedido).Visibility = ViewStates.Gone;
                view.FindViewById<Button>(Resource.Id.btnCompletarPedido).Visibility = ViewStates.Gone;
            }else{
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.White);
                view.FindViewById<Button>(Resource.Id.btnCancelarPedido).Visibility = ViewStates.Visible;
                view.FindViewById<Button>(Resource.Id.btnCompletarPedido).Visibility = ViewStates.Gone;
            }
            Button btnCancelar = view.FindViewById<Button>(Resource.Id.btnCancelarPedido);
            btnCancelar.Click += delegate
            {
                mostrarDialogoCancelar(item);
            };
            Button btnRecivir = view.FindViewById<Button>(Resource.Id.btnCompletarPedido);
            btnRecivir.Click += delegate
            {
                mostrarDialogoRecivir(item);
            };
            return view;
        }

        private void mostrarDialogoCancelar(Pedido item)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(context);
            alert.SetTitle("Confirmar pedido");
            alert.SetMessage("Desea cancelar el pedido seleccionado?");
            alert.SetPositiveButton("Cancelar pedido", (senderAlert, args) =>
            {
                item.Estado = "CA";
                repo.ActualizarEstadoPedido(item);
                Toast.MakeText(context, "Cancelado!", ToastLength.Short).Show();
                context.Finish();
            });

            alert.SetNegativeButton("Continuar pedido", (senderAlert, args) =>
            {
                //Toast.MakeText(context, "", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private void mostrarDialogoRecivir(Pedido item)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(context);
            alert.SetTitle("Confirmar pedido");
            alert.SetMessage("Recivio su pedido?");
            alert.SetPositiveButton("Pedido recivido", (senderAlert, args) =>
            {
                item.Estado = "R";
                repo.RecivirPedido(item);
                Toast.MakeText(context, "Recivido!", ToastLength.Short).Show();
                context.Finish();
            });

            alert.SetNegativeButton("Aun no...", (senderAlert, args) =>
            {
                //Toast.MakeText(context, "", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

    }
}
