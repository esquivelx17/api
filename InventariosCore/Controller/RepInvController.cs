using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InventariosCore.Business;
using InventariosCore.Data;
using InventariosCore.Model;

namespace InventariosCore.Controllers
{
    public class RepInvController
    {
        private readonly ProductosDataAccess _productosDA;

        public RepInvController()
        {
            _productosDA = new ProductosDataAccess();
        }

        /// <summary>
        /// Obtiene productos filtrados por categoría, estatus y ubicación.
        /// </summary>
        public List<ProductoConCostoTexto> ObtenerProductos(string? categoria = null, int? estatus = null, string? ubicacion = null)
        {
            var productos = _productosDA.ObtenerTodosLosProductos();

            if (!string.IsNullOrEmpty(categoria) && categoria != "Todo")
                productos = productos.FindAll(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));

            if (estatus.HasValue)
                productos = productos.FindAll(p => p.Estatus == estatus.Value);

            if (!string.IsNullOrEmpty(ubicacion) && ubicacion != "Todo")
                productos = productos.FindAll(p => p.Ubicacion.Equals(ubicacion, StringComparison.OrdinalIgnoreCase));

            // Si quieres manejar la lógica de stock bajo aquí, puedes usar esta lista:
            int existenciaMinima = ProductosNegocio.ObtenerExistenciaMinima();
            var productosStockBajo = productos.FindAll(p => p.Stock.HasValue && p.Stock.Value < existenciaMinima);

            // Puedes usar productosStockBajo para alertas o lógica visual si quieres,
            // pero para devolver la lista completa de productos transformada:

            var productosConTexto = productos.Select(p => new ProductoConCostoTexto
            {
                IdProducto = p.IdProducto,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                Costo = p.Costo,
                CostoEnTexto = ConvertirNumeroATexto(p.Costo),
                Stock = p.Stock,
                Ubicacion = p.Ubicacion,
                Clave = p.Clave,
                Estatus = p.Estatus,
                AplicaImpuesto = p.AplicaImpuesto,
                IdImpuesto = p.IdImpuesto,
                Impuesto = p.Impuesto
            }).ToList();

            return productosConTexto;
        }

        /// <summary>
        /// Método para obtener solo productos con stock bajo.
        /// </summary>
        public List<Producto> ObtenerProductosConStockBajo()
        {
            int existenciaMinima = ProductosNegocio.ObtenerExistenciaMinima();
            var productos = _productosDA.ObtenerTodosLosProductos();
            return productos.FindAll(p => p.Stock.HasValue && p.Stock.Value < existenciaMinima);
        }

        /// <summary>
        /// Convierte un decimal a su representación en texto en pesos mexicanos.
        /// Ejemplo: 1324.00 => "Mil trescientos veinticuatro pesos 00/100 MN"
        /// </summary>
        public string ConvertirNumeroATexto(decimal monto)
        {
            if (monto < 0 || monto >= 1000000000000)
                throw new ArgumentOutOfRangeException(nameof(monto), "Monto fuera de rango válido.");

            long parteEntera = (long)Math.Floor(monto);
            int parteDecimal = (int)((monto - parteEntera) * 100);

            string textoEntero = NumeroALetras(parteEntera);
            string textoDecimal = parteDecimal.ToString("D2");

            return $"{textoEntero} pesos {textoDecimal}/100 MN";
        }

        // Método privado para convertir número entero a letras (hasta billones).
        // Adaptado para español México.
        private string NumeroALetras(long numero)
        {
            if (numero == 0)
                return "cero";

            if (numero < 0)
                return "menos " + NumeroALetras(Math.Abs(numero));

            string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez",
                                "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };

            string[] decenas = { "", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

            string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos",
                                "setecientos", "ochocientos", "novecientos" };

            string resultado = "";

            if (numero == 100)
                return "cien";

            if (numero >= 1000000000000)
                throw new ArgumentOutOfRangeException(nameof(numero), "Número fuera de rango.");

            if (numero >= 1000000000)
            {
                long milesDeMillones = numero / 1000000000;
                resultado += NumeroALetras(milesDeMillones) + " mil ";
                numero %= 1000000000;
            }

            if (numero >= 1000000)
            {
                long millones = numero / 1000000;
                if (millones == 1)
                    resultado += "un millón ";
                else
                    resultado += NumeroALetras(millones) + " millones ";
                numero %= 1000000;
            }

            if (numero >= 1000)
            {
                long miles = numero / 1000;
                if (miles == 1)
                    resultado += "mil ";
                else
                    resultado += NumeroALetras(miles) + " mil ";
                numero %= 1000;
            }

            if (numero >= 100)
            {
                int centenasIndex = (int)(numero / 100);
                resultado += centenas[centenasIndex] + " ";
                numero %= 100;
            }

            if (numero > 0)
            {
                if (numero < 20)
                    resultado += unidades[numero] + " ";
                else
                {
                    int decenaIndex = (int)(numero / 10);
                    int unidadIndex = (int)(numero % 10);

                    if (decenaIndex == 2 && unidadIndex > 0)
                        resultado += "veinti" + unidades[unidadIndex] + " ";
                    else
                    {
                        resultado += decenas[decenaIndex];
                        if (unidadIndex > 0)
                            resultado += " y " + unidades[unidadIndex];
                        resultado += " ";
                    }
                }
            }

            return resultado.Trim();
        }
    }

    /// <summary>
    /// Extiende Producto para agregar propiedad con costo en texto
    /// </summary>
    public class ProductoConCostoTexto : Producto
    {
        public string CostoEnTexto { get; set; } = "";
    }
}
