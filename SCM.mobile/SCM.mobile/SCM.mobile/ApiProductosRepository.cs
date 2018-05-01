using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}
