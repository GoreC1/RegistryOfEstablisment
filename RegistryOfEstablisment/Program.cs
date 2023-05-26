using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model;
using RegistryOfEstablisment.View;
using RegistryOfEstablisment.Unit;

namespace RegistryOfEstablisment
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataContext dataContext = new DataContext();
            UnitOfWork unit = new UnitOfWork(dataContext);
            Application.Run(new AuthorisationForm(unit));
        }

    }


}
