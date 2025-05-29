using System;
using System.Collections.Generic;
using System.Linq;
using InventariosCore.Data;
using InventariosCore.Model;
using InventariosCore.Business;
using System.Configuration;

namespace InventariosCore.Controllers
{
    public class ProductosController
    {
        private readonly ProductosDataAccess _productosDA;
        private readonly AuditoriaService _auditoriaService;

        public ProductosController()
        {
            _productosDA = new ProductosDataAccess();
            _auditoriaService = new AuditoriaService();
        }

        public List<Producto> ObtenerProductosConStockBajo()
        {
            int existenciaMinima = ProductosNegocio.ObtenerExistenciaMinima();
            var productos = _productosDA.ObtenerTodosLosProductos();
            return productos.FindAll(p => p.Stock.HasValue && p.Stock.Value < existenciaMinima);
        }

        public List<API> ObtenerProductosParaAPI(string? clave = null)
        {
            List<Producto> productos;

            if (string.IsNullOrEmpty(clave))
                productos = _productosDA.ObtenerTodosLosProductos();
            else
            {
                var producto = _productosDA.ObtenerProductoPorClave(clave);
                productos = producto != null ? new List<Producto> { producto } : new List<Producto>();
            }

            var productosDto = new List<API>();

            foreach (var p in productos)
            {
                productosDto.Add(new API
                {
                    Clave = p.Clave,
                    Nombre = p.Nombre,
                    CostoUnitario = p.Costo,
                    Stock = p.Stock ?? 0,
                    Impuesto = p.AplicaImpuesto && p.Impuesto != null ? p.Impuesto.CantidadImpuesto.ToString("0.##") : "N/A",
                    Estatus = p.Estatus
                });
            }

            return productosDto;
        }

        public List<Producto> ObtenerProductos(string? categoria = null, int? estatus = null)
        {
            var productos = _productosDA.ObtenerTodosLosProductos();

            if (!string.IsNullOrEmpty(categoria) && categoria != "Todo")
                productos = productos.FindAll(p => p.Categoria == categoria);

            if (estatus.HasValue)
                productos = productos.FindAll(p => p.Estatus == estatus.Value);

            return productos;
        }

        public int InsertarProducto(Producto producto)
        {
            ValidarProducto(producto);
            int id = _productosDA.InsertarProducto(producto);

            if (id > 0)
            {
                _auditoriaService.RegistrarAccion("Inserción", "Productos");
            }

            return id;
        }

        public bool ActualizarProducto(Producto producto)
        {
            if (producto.IdProducto <= 0)
                throw new ArgumentException("El Id del producto es inválido.");

            ValidarProducto(producto);
            bool resultado = _productosDA.ActualizarProducto(producto);

            if (resultado)
            {
                _auditoriaService.RegistrarAccion("Actualización", "Productos");
            }

            return resultado;
        }

        public Producto? ObtenerProductoPorClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede estar vacía.");

            return _productosDA.ObtenerProductoPorClave(clave);
        }

        public Producto? ObtenerProductoPorNombre(string nombre)
        {
            var productos = ObtenerProductosActivos();
            return productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public bool ModificarStockPorClave(string clave, int cantidadARestar)
        {
            // Obtener el producto por clave
            var producto = _productosDA.ObtenerProductoPorClave(clave);
            if (producto == null)
                throw new Exception("Producto no encontrado");

            // Calcular nuevo stock restando la cantidad indicada
            int stockActual = producto.Stock ?? 0;
            int nuevoStock = stockActual - cantidadARestar;

            if (nuevoStock < 0)
                nuevoStock = 0; // O lanzar excepción si no quieres stock negativo

            // Actualizar el stock en la base de datos
            return _productosDA.ActualizarStock(producto.IdProducto, nuevoStock);
        }


        private void ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Clave))
                throw new ArgumentException("La clave no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (producto.Costo < 0)
                throw new ArgumentException("El costo no puede ser negativo.");

            if (producto.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            if (producto.AplicaImpuesto && !producto.IdImpuesto.HasValue)
                throw new ArgumentException("Debe especificar un impuesto si AplicaImpuesto es verdadero.");
        }

        public List<Producto> ObtenerProductosActivos()
        {
            return _productosDA.ObtenerProductos(true);
        }
    }
}
