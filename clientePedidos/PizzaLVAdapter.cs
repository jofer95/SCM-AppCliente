using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace clientePedidos
{
    public class PizzaLVAdapter :BaseAdapter<Pizza>
    {
        private MainActivity mainActivity;
        private List<Pizza> pizzas;
        private Activity context;
        public PizzaLVAdapter(Activity context, List<Pizza> pizzas)
        {
            this.context = context;
            this.pizzas = pizzas;
        }
        public override Pizza this[int position]
        {
            get
            {
                return pizzas[position];
            }
        }

        public override int Count => pizzas.Count;


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = pizzas[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.PizzaLVItem, null);
            view.FindViewById<TextView>(Resource.Id.TextNombre).Text = item.Nombre;
            view.FindViewById<TextView>(Resource.Id.TextIngredientes).Text = item.Ingredientes.ToString();
            view.FindViewById<TextView>(Resource.Id.TextRebanadas).Text = item.Rebanadas.ToString();
            view.FindViewById<TextView>(Resource.Id.TextPrecio).Text = item.Precio.ToString();
            return view;

        }
    }
}
