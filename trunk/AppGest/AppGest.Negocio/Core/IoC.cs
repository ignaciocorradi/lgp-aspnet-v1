using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;


namespace AppGest.Negocio.Core
{
    /// <summary>
    /// Implementación del patrón de Inyección de Dependencia (Inversión de Control).
    /// </summary>
    public class IoC: IIoC
    {
        /// <summary>
        /// Única instancia de acceso a la funcionalidad de Inyección de Dependencia.
        /// </summary>
        public readonly static IIoC Singleton;
        IUnityContainer _contenedor;
    
        static IoC()
        {
            Singleton = new IoC();
        }


        IoC()
        {
            _contenedor = new UnityContainer();

            UnityConfigurationSection section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            UnityConfigurationSection.CurrentSection.Configure(_contenedor, "predet");
           
        }

        

        

        #region IIoC Members

        T IIoC.Obtener<T>(Type type)
        {
            var obj =_contenedor.Resolve(type);
            return (T) obj;
        }

        T IIoC.Obtener<T>()
        {
            if (_contenedor.IsRegistered<T>())
            {
                T obj = _contenedor.Resolve<T>();
                return obj;
            }
            else
            {
                T obj = new T();
                return obj;
            }
        }

        T IIoC.Experto<T>(Guid idSesion)
        {
            T experto = ((IIoC)this).Obtener<T>();
           experto.IdSesion = idSesion;

           return experto;
        }
        #endregion
    }
}