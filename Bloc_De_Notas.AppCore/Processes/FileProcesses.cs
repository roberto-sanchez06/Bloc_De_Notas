using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.AppCore.Processes
{
    public static class FileProcesses
    {
        public static FileStream Create(string path, string name)
        {
            string rutaCompleta = path + "\\" + name+".txt";
            if (File.Exists(rutaCompleta))
            {
                throw new ArgumentException("El archivo ya existe");
            }
            //Esto escribe o sobreescribe el archivo si ya esta
            return File.Create(rutaCompleta);
        }
        public static void Delete(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("No existe el archivo");
            }
            File.Delete(path);
        }
    }
}
