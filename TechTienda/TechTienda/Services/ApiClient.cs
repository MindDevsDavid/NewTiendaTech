using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        public async Task<List<Celular>> GetCelularesAsync() => await HandleRequest<List<Celular>>($"/celulares");
        public async Task<Celular> GetCelularByIdAsync(int id) => await HandleRequest<Celular>($"/celulares/{id}");
        public async Task<Celular> CreateCelularAsync(Celular celular) => await HandlePostRequest<Celular>("/celulares", celular);
        public async Task UpdateCelularAsync(Celular celular) => await HandlePutRequest($"/celulares/{celular.Id}", celular);
        public async Task DeleteCelularAsync(int id) => await _client.DeleteAsync($"{_baseUrl}/celulares/{id}");

        // Operaciones para Cargador (similar a Celular)
        // ... Implementar mismos métodos para Cargador

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
    }
}
