using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.AppCore.Processes
{
    public static class DirectoryProcesses
    {
        public static DirectoryInfo Create(string path, string name)
        {
            string rutaCompleta = path + "\\" + name;
            if (Directory.Exists(rutaCompleta))
            {
                throw new ArgumentException("La carpeta ya existe");
            }
            return Directory.CreateDirectory(rutaCompleta);
        }
        public static void Delete(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("No existe la carpeta");
            }
            Directory.Delete(path, true);
        }
    }
}
