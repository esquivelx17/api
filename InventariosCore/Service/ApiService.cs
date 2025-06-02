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

        // Obtiene el resumen de ventas por producto (clave)
        public async Task<ResumenVenta?> GetResumenVentasPorProductoAsync(string codigoArticulo)
        {
            try
            {
                string endpoint = "VentasAPI/resumen";
                string queryString = $"?codigoArticulo={Uri.EscapeDataString(codigoArticulo)}";

                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + endpoint + queryString);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResumenVenta>(json);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener resumen de ventas: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en API (GetResumenVentasPorProductoAsync): {ex.Message}");
                throw;
            }
        }
    }

    // Clases modelo para mapear JSON recibido
    public class ResumenVenta
    {
        public string CodigoArticulo { get; set; } = string.Empty;
        public int TotalVentas { get; set; }
        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }

    public class Venta
    {
        public string CodigoArticulo { get; set; } = string.Empty;
        public int IdCompra { get; set; }
        public string CodigoCompra { get; set; } = string.Empty;
        public DateTime FechaCompra { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public string Estatus { get; set; } = string.Empty;
    }
}
