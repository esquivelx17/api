using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace InventariosCore.Business
{
    public class ProductosNegocio
    {
        
        public static int ObtenerExistenciaMinima()
        {
            string? val = ConfigurationManager.AppSettings["ExistenciaMinimaAlerta"];
            if (int.TryParse(val, out int existenciaMin))
                return existenciaMin;
            return 5; // default si no está configurado
        }

    }
}
