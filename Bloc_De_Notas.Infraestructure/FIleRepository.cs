﻿using Bloc_De_Notas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.Infraestructure
{
    public class FIleRepository : IFileRepository
    {
        public string AbrirArchivo(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string mensaje = streamReader.ReadToEnd();
            streamReader.Close();
            return mensaje;
        }

        public FileStream Create(string path, string name)
        {
            string rutaCompleta = path + "\\" + name + ".txt";
            if (File.Exists(rutaCompleta))
            {
                throw new ArgumentException("El archivo ya existe");
            }
            return File.Create(rutaCompleta);
        }

        public void Delete(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("No existe el archivo");
            }
            File.Delete(path);
        }

        public void GuardarArchivo(string ruta, string mensaje)
        {
            File.WriteAllText(ruta, mensaje);
        }
    }
}
