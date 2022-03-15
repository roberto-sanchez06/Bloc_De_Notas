using System;
using System.Collections.Generic;
using System.Text;

namespace Bloc_De_Notas.Domain.Interfaces
{
    public interface IModel<T>
    {
        T Create(string ruta, string nombre);
        void Delete(string ruta);
    }
}
