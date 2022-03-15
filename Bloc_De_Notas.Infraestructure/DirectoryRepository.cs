using Bloc_De_Notas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.Infraestructure
{
    public class DirectoryRepository : IDirectoryRepository
    {
        public DirectoryInfo Create(string ruta, string nombre)
        {
            string rutaCompleta = ruta + "\\" + nombre;
            if (Directory.Exists(rutaCompleta))
            {
                throw new ArgumentException("La carpeta ya existe");
            }
            return Directory.CreateDirectory(rutaCompleta);
        }

        public void Delete(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("No existe la carpeta");
            }
            Directory.Delete(path, true);
        }
    }
}
