using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SCM.mobile
{
    public class UbicacionCambioEventArgs: EventArgs{
        public UbicacionCambioEventArgs(long lat, long lon){
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
            hubConnection = new HubConnection(@"");
            proxy = hubConnection.CreateHubProxy("Pedidos");
        }

        public async Task Connect(){
            await hubConnection.Start();
            proxy.On("pedidoIniciado,", () =>
            {
                if (OnPedidoIniciado != null)
                {
                    OnPedidoIniciado(this, new EventArgs());
                }
            });
            proxy.On("estoyEsperando,", () => {
                if (OnEstoyEsperando != null)
                {
                    OnEstoyEsperando(this, new EventArgs());
                }
            });
            proxy.On("ubicacionCambio,", (long lat, long lon) => {
                if (OnUbicacionCambio != null)
                {
                    OnUbicacionCambio(this, new UbicacionCambioEventArgs(lat,lon));
                }
            });
        }

        public Task IniciarRecorrido(string pedidoID){
            return proxy.Invoke("IniciarRecorrido",pedidoID);
        }
        public Task EsperarPedido(string pedidoID)
        {
            return proxy.Invoke("EsperarPedido",pedidoID);
        }
        public Task NotificarUbicacion(string pedidoID, long lat, long lon)
        {
            return proxy.Invoke("NotificarUbicacion",pedidoID,lat,lon);
        }
        public Task DondeEstaMiComida(string pedidoID)
        {
            return proxy.Invoke("DondeEstaMiComida",pedidoID);
        }
    }
}
