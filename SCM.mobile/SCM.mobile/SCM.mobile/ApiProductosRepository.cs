using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace SCM.mobile
{
    public class ApiProductosRepository : IProductosRepository
    {

        HttpClient client;
        private readonly string ApiLocation = @"https://scm-pizzas.azurewebsites.net/api/productos";
        public ApiProductosRepository()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }
        public async Task<List<Producto>> LeerProductos()
        {
            var uri = new Uri(string.Format(ApiLocation, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<Producto>>(content);

                return lista;
            }
            return null;
        }

        public async Task<List<Pedido>> LeerTodosPedidosPorTelefono(string telefono)
        {
            var uri = new Uri(string.Format(ApiLocation, string.Empty));
            var response = await client.PostAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<Pedido>>(content);

                return lista;
            }
            return null;
        }
    }
}
