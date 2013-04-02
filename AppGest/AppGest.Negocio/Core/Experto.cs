using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using AppGest.Datos;
using System.Data.Objects.DataClasses;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Modelo;

namespace AppGest.Negocio.Core
{
    public abstract class Experto: IDisposable
    {
        internal Guid IdSesion { get; set; }
        protected bool _commit = true;
        internal PersistidorPredet Persistidor
        {
            get 
            {
                if (_persistidor == null)
                {
                    var persistidor = IoC.Singleton.Obtener<PersistidorPredet>();
                    persistidor.Inicializar();
                
                    _persistidor = persistidor;
                }
                
                return _persistidor; 
            }
            set
            {
                _persistidor = value;
                _commit = false;
            }
        }   PersistidorPredet _persistidor;
        public void Dispose()
        {
            _persistidor = null;
        }


    }
}
