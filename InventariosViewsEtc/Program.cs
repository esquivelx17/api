using InventariosCore.Business;
using InvSis.Views;

namespace InvSis
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            

            frmLogIn login_form = new frmLogIn();
            if (login_form.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMDI());
            }
        }
    }
}
