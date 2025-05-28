using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;

public static class SeguridadUI
{
    public static void BloquearBotonesSiEsLector(params Control[] controles)
    {
        if (Sesion.RolActual != null && Sesion.RolActual.NombreRol.Equals("Lector", StringComparison.OrdinalIgnoreCase))
        {
            foreach (var control in controles)
            {
                if (control is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }
    }
}