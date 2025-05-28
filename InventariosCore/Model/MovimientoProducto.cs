using System;

namespace InventariosCore.Model
{
    public class MovimientoProducto
    {
        public int IdMovimientoProducto { get; set; }

        public int IdProducto { get; set; }

        public int IdOperador { get; set; }  // Referencia a Usuario que actúa como operador

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        /// <summary>
        /// Estado: 0 = Rechazado, 1 = Aprobado, 2 = Pendiente
        /// </summary>
        public short Estatus { get; set; }

        public Producto Producto { get; set; }

        public Usuario Operador { get; set; }

        public MovimientoProducto()
        {
            Fecha = DateTime.Today;
            Cantidad = 0;
            Estatus = 2; // Pendiente por defecto
            Producto = new Producto();
            Operador = new Usuario();
        }

        public MovimientoProducto(int idProducto, int idOperador, int cantidad, DateTime fecha, short estatus)
        {
            IdProducto = idProducto;
            IdOperador = idOperador;
            Cantidad = cantidad;
            Fecha = fecha.Date; // Solo fecha sin hora
            Estatus = estatus;
            Producto = new Producto();
            Operador = new Usuario();
        }
    }
}
