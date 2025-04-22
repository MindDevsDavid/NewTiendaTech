using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration; // <-- Agrega esto

namespace TechTienda.Services
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public ApiClient()
        {
            _baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _client = new HttpClient();
        }

        // Operaciones para Celular
        public async Task<List<TechTienda.Models.Celular>> GetCelularesAsync() => await HandleRequest<List<TechTienda.Models.Celular>>($"/celulares");
        public async Task<TechTienda.Models.Celular> GetCelularByIdAsync(int id) => await HandleRequest<TechTienda.Models.Celular>($"/celulares/{id}");
        public async Task<TechTienda.Models.Celular> CreateCelularAsync(TechTienda.Models.Celular celular) => await HandlePostRequest<TechTienda.Models.Celular>("/celulares", celular);
        public async Task UpdateCelularAsync(TechTienda.Models.Celular celular) => await HandlePutRequest($"/celulares/{celular.Id}", celular);
        public async Task DeleteCelularAsync(int id) => await _client.DeleteAsync($"{_baseUrl}/celulares/{id}");

        

        private async Task<T> HandleRequest<T>(string endpoint)
        {
            var response = await _client.GetAsync($"{_baseUrl}{endpoint}");
            return await ProcessResponse<T>(response);
        }

        private async Task<T> HandlePostRequest<T>(string endpoint, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_baseUrl}{endpoint}", content);
            return await ProcessResponse<T>(response);
        }

        private async Task HandlePutRequest(string endpoint, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            await _client.PutAsync($"{_baseUrl}{endpoint}", content);
        }

        private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}");

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        // Operaciones para Cargador
        public async Task<List<Cargador>> GetCargadoresAsync() => await HandleRequest<List<Cargador>>("/cargadores");
        public async Task<Cargador> GetCargadorByIdAsync(int id) => await HandleRequest<Cargador>($"/cargadores/{id}");
        public async Task<Cargador> CreateCargadorAsync(Cargador cargador) => await HandlePostRequest<Cargador>("/cargadores", cargador);
        public async Task UpdateCargadorAsync(Cargador cargador) => await HandlePutRequest($"/cargadores/{cargador.Id}", cargador);
        public async Task DeleteCargadorAsync(int id) => await _client.DeleteAsync($"{_baseUrl}/cargadores/{id}");
        public async Task<List<Cargador>> SearchCargadoresAsync(Dictionary<string, object> criteria) => await HandlePostRequest<List<Cargador>>("/cargadores/search", criteria);
    }
}
