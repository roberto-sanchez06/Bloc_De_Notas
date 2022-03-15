using Bloc_De_Notas.AppCore.Interfaces;
using Bloc_De_Notas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloc_De_Notas.AppCore.Service
{
    public abstract class BaseService<T> : IService<T>
    {
        protected IModel<T> model;

        protected BaseService(IModel<T> model)
        {
            this.model = model;
        }

        public T Create(string ruta, string nombre)
        {
            return model.Create(ruta, nombre);
        }

        public void Delete(string ruta)
        {
            model.Delete(ruta);
        }
    }
}
