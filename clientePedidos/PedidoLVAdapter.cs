using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace clientePedidos
{
    public class PedidoLVAdapter :BaseAdapter<Pedido>
    {
        private MainActivity mainActivity;
        private List<Pedido> pedidos;
        private Activity context;
        public PedidoLVAdapter(Activity context, List<Pedido> pedidos)
        {
            this.context = context;
            this.pedidos = pedidos;
        }
        public override Pedido this[int position]
        {
            get
            {
                return pedidos[position];
            }
        }

        public override int Count => pedidos.Count;


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = pedidos[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.PedidoLVItem, null);
            view.FindViewById<TextView>(Resource.Id.TextNombre).Text = item.NombreCliente;
            view.FindViewById<TextView>(Resource.Id.TextDescripcion).Text = item.Descripcion.ToString();
           // view.FindViewById<TextView>(Resource.Id.TextUbicacion).Text = item.Ubicacion;
            view.FindViewById<TextView>(Resource.Id.TextEstado).Text = item.Estado;
            return view;

        }

    }
}
