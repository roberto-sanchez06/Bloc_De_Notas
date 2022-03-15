using Autofac;
using Bloc_De_Notas.AppCore.Interfaces;
using Bloc_De_Notas.AppCore.Service;
using Bloc_De_Notas.Domain.Interfaces;
using Bloc_De_Notas.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloc_De_Notas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DirectoryRepository>().As<IDirectoryRepository>();
            builder.RegisterType<DirectoryService>().As<IDirectoryService>();

            builder.RegisterType<FIleRepository>().As<IFileRepository>();
            builder.RegisterType<FileService>().As<IFileService>();

            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Notepad(container.Resolve<IDirectoryService>(), container.Resolve<IFileService>()));
        }
    }
}
