using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SCM.mobile
{
    public class UbicacionCambioEventArgs : EventArgs
    {
        public UbicacionCambioEventArgs(double lat, double lon)
        {
            Latitud = lat;
            Longitud = lon;
        }

        public double Latitud { get; }
        public double Longitud { get; }
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
            proxy.On("pedidoIniciado", () => {
                if (OnPedidoIniciado != null)
                {
                    OnPedidoIniciado(this, new EventArgs());
                }
            });
            proxy.On("estoyEsperando", () => {
                if (OnEstoyEsperando != null)
                {
                    OnEstoyEsperando(this, new EventArgs());
                }
            });
            proxy.On("ubicacionCambio", (double lat, double lon) => {
                if (OnUbicacionCambio != null)
                {
                    OnUbicacionCambio(this, new UbicacionCambioEventArgs(lat, lon));
                }
            });
        }
        public Task IniciarRecorrido(string pedidoid)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("IniciarRecorrido", pedidoid);
            }
            return Task.Delay(0);
        }
        public Task EsperarPedido(string pedidoid)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("EsperarPedido", pedidoid);
            }
            return Task.Delay(0);
        }
        public Task NotificarUbicacion(string pedidoId, double lat, double lon)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("NotificarUbicacion", pedidoId, lat, lon);
            }
            return Task.Delay(0);
        }
        public Task DondeEstaMiComida(string pedidoId)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                return proxy.Invoke("DondeEstaMiComida", pedidoId);
            }
            return Task.Delay(0);
        }

    }
}