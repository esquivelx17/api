using InventariosCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace InventariosCore.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]
                                            ?? throw new InvalidOperationException("La clave 'ApiBaseUrl' no está configurada en AppSettings.");

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        // Obtener existencia (stock) por clave
        public async Task<int> GetExistenciaAsync(string clave)
        {
            try
            {
                string endpoint = "existenciasapi/existencia";
                string queryString = $"?clave={Uri.EscapeDataString(clave)}";

                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + endpoint + queryString);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(json);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener existencia: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en API (GetExistenciaAsync): {ex.Message}");
                throw;
            }
        }

        // Restar existencia
        public async Task<bool> RestarExistenciaAsync(string clave, int cantidad)
        {
            try
            {
                string endpoint = "existenciasapi/restar_existencia";
                string queryString = $"?clave={Uri.EscapeDataString(clave)}&cantidad={cantidad}";

                // Post sin body, parámetros en query string
                HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl + endpoint + queryString, null);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<bool>(json);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al restar existencia: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en API (RestarExistenciaAsync): {ex.Message}");
                throw;
            }
        }

        // Obtener estatus (int 0/1)
        public async Task<int> GetEstatusAsync(string clave)
        {
            try
            {
                string endpoint = "existenciasapi/estatus";
                string queryString = $"?clave={Uri.EscapeDataString(clave)}";

                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + endpoint + queryString);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(json);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener estatus: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en API (GetEstatusAsync): {ex.Message}");
                throw;
            }
        }
    }
}
