using InventariosCore.Controllers;
using InventariosCore.Model;

public class AuditoriaService
{
    private readonly AuditoriaController _auditoriaController;

    public AuditoriaService()
    {
        _auditoriaController = new AuditoriaController();
    }

    public void RegistrarAccion(string tipoMovimiento, string tablaAfectada)
    {
        int idUsuario = Sesion.IdUsuarioActual;

        if (idUsuario <= 0)
            throw new InvalidOperationException("No hay usuario activo para registrar auditoría.");

        var bitacora = new Bitacora
        {
            IdUsuario = idUsuario,
            IpEquipo = ObtenerIpLocal(),
            NombreEquipo = Environment.MachineName,
            Fecha = DateTime.Now,
            TipoMovimiento = tipoMovimiento,
            TablaAfectada = tablaAfectada
        };

        _auditoriaController.RegistrarAuditoria(bitacora);
    }

    private string ObtenerIpLocal()
    {
        try
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }
        catch
        {
            return "127.0.0.1";
        }
    }
}
