using Bloc_De_Notas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.Infraestructure
{
    public class FIleRepository : IFileRepository
    {
        StreamReader reader;
        StreamWriter writer;
        public string AbrirArchivo(string path)
        {
            //StreamReader streamReader = new StreamReader(path);
            //string mensaje = streamReader.ReadToEnd();
            //streamReader.Close();
            //return mensaje;
            string mensaje = string.Empty;
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    reader = new StreamReader(fileStream);
                    mensaje = reader.ReadToEnd();
                    reader.Close();
                }
                return mensaje;
            }
            catch (IOException)
            {
                throw;
            }
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
            //File.WriteAllText(ruta, mensaje);
            try
            {
                using (FileStream fileStream = new FileStream(ruta, FileMode.Truncate, FileAccess.Write))
                {
                    writer = new StreamWriter(fileStream);
                    writer.Write(mensaje);
                    writer.Close();
                }

            }
            catch (IOException)
            {
                return;
            }
        }
    }
}
