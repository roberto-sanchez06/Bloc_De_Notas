using System;
using System.Collections.Generic;
using System.Text;

namespace Bloc_De_Notas.AppCore.Interfaces
{
    public interface IService<T>
    {
        T Create(string ruta, string nombre);
        void Delete(string ruta);
    }
}
