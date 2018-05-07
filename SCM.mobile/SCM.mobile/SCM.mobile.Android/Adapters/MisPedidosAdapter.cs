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

        public MisPedidosAdapter(Activity context, List<Pedido> items)
        {
            this.context = context;
            this.items = items;
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
                view = context.LayoutInflater.Inflate(Resource.Layout.itemProducto, null);
            view.FindViewById<TextView>(Resource.Id.tvDescripcion).Text = "Descripció: " + item.Descripcion;
            view.FindViewById<TextView>(Resource.Id.tvCategoria).Text = "Categoria: " + item.Categoria;
            view.FindViewById<TextView>(Resource.Id.tvPrecio).Text = "Precio: $" + item.Precio.ToString();
            if (item.Imagen != null)
            {
                var imageBitmap = GetImageBitmapFromUrl(item.Imagen);
                view.FindViewById<ImageView>(Resource.Id.imgImagen).SetImageBitmap(imageBitmap);
            }
            return view;
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
