using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.Domain.Interfaces
{
    public interface IFileRepository : IModel<FileStream>
    {
        string AbrirArchivo(string path);
        void GuardarArchivo(string ruta,string mensaje);
    }
}
