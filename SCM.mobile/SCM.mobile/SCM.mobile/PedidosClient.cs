using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SCM.mobile
{
    public class UbicacionCambioEventArgs : EventArgs
    {
        public UbicacionCambioEventArgs(long lat, long lon)
        {
            Latitud = lat;
            Longitud = lon;
        }

        public long Latitud { get; }
        public long Longitud { get; }
    }
    public class PedidosClient
    {
        private readonly HubConnection hubConnection;
        private readonly IHubProxy proxy;


        public event EventHandler OnPedidoIniciado;
        public event EventHandler OnEstoyEsperando;
        public event EventHandler<UbicacionCambioEventArgs> OnUbicacionCambio;

        public PedidosClient()
        {
            hubConnection = new HubConnection(@"https://signalrpruebaspizzas.azurewebsites.net");
            proxy = hubConnection.CreateHubProxy("PedidosHub");
        }

        public async Task Connect()
        {
            await hubConnection.Start();
            proxy.On("pedidoIniciado,", () =>
            {
                if (OnPedidoIniciado != null)
                {
                    OnPedidoIniciado(this, new EventArgs());
                }
            });
            proxy.On("estoyEsperando,", () =>
            {
                if (OnEstoyEsperando != null)
                {
                    OnEstoyEsperando(this, new EventArgs());
                }
            });
            proxy.On("ubicacionCambio,", (long lat, long lon) =>
            {
                if (OnUbicacionCambio != null)
                {
                    OnUbicacionCambio(this, new UbicacionCambioEventArgs(lat, lon));
                }
            });
        }

        public Task IniciarRecorrido(string pedidoID)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("IniciarRecorrido", pedidoID);
            }
            return Task.CompletedTask;
        }

        public Task EsperarPedido(string pedidoID)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("EsperarPedido", pedidoID);
            }
            return Task.CompletedTask;
        }


        public Task NotificarUbicacion(string pedidoID, long lat, long lon)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("NotificarUbicacion", pedidoID);
            }
            return Task.CompletedTask;
        }


        public Task DondeEstaMiComida(string pedidoID)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("DondeEstaMiComida", pedidoID);
            }
            return Task.CompletedTask;
        }
    }
}