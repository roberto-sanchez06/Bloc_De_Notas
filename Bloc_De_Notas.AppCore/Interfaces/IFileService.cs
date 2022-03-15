using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.AppCore.Interfaces
{
    public interface IFileService : IService<FileInfo>
    {
        string AbrirArchivo(string path);
        //este es el de sobreescribir 
        void GuardarArchivo(string ruta, string mensaje);
    }
}
