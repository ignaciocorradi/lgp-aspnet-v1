using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Reflection;
using AppGest.Util.Atributos;
using System.Data.Objects;

namespace AppGest.Datos.Persistencia
{
    interface IObjectContext
    {
        object ContextoId { get; set; }
    }

    public partial class Contendor_LGP
    {
        
        public void Aux()
        {
            ObjectStateManager.ObjectStateManagerChanged += new System.ComponentModel.CollectionChangeEventHandler(ObjectStateManager_ObjectStateManagerChanged);
        }

        void ObjectStateManager_ObjectStateManagerChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            var entidad = e.Element as IObjectContext;
            if (entidad != null)
            {
                if (e.Action == System.ComponentModel.CollectionChangeAction.Remove)
                    entidad.ContextoId = null;
                else
                    entidad.ContextoId = (sender as ObjectStateManager).GetHashCode();
            }
        }

    }

    public partial class EB: EntityObject, IObjectContext
    {
        protected override void OnPropertyChanged(string property)
        {
            base.OnPropertyChanged(property);
        }
        public IKey Key
        {
            get
            {
                _key = _key ?? CrearKey();
                return _key;
            }

        }   IKey _key;

        protected virtual IKey CrearKey()
        {
            return new KeyTipo(this);
        }

        public object ContextoId { get; set; }


        public override string ToString()
        {
            return (Nombre ?? "") + " (Id= " + Id.ToString() + ") - " + (ContextoId ?? "null").ToString();
        }
    }

    public partial class Reg_encab: IObjectContext
    {
        public object ContextoId { get; set; }
        public override string ToString()
        {
            return "(Id= " + Id.ToString() + ") - " + (ContextoId ?? "null").ToString();
        }

    }

    public partial class Reg_Det : IObjectContext
    {
        public object ContextoId { get; set; }
        public override string ToString()
        {
            return "(Id= " + Id.ToString() + ") - " + (ContextoId ?? "null").ToString();
        }
    }

    public interface IKey
    {
    }

    public class KeyTipo : IKey
    {
        EB _inst;

        internal KeyTipo(EB inst)
        {
            _inst = inst;
        }

        public override int GetHashCode()
        {
            if (_inst.Id != 0)
                return (_inst.GetType().ToString() + "|" + _inst.Id.ToString()).GetHashCode();
            else
                return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;

            var key = obj as KeyTipo;
            if ((object) key == null)
                return false;

            return GetHashCode() == key.GetHashCode();

        }

        public static bool operator ==(KeyTipo key1, KeyTipo key2)
        {
            if ((object)key1 != (object)null)
                return key1.Equals(key2);
            else if ((object)key2 != (object)null)
                return key1.Equals(key1);
            else
                return true;
        }

        public static bool operator !=(KeyTipo key1, KeyTipo key2)
        {
            return !(key1 == key2);
        }

    }
    public class KeyConcepto: IKey
    {
        Concepto _inst;

        internal KeyConcepto(Concepto inst)
        {
            _inst = inst;
        }

        public override int GetHashCode()
        {
            if (ValorEnumDeUsuarioAttribute.EsDeSistema(_inst.ValorEnum))
                return (_inst.Clase.ToString() + "|" + _inst.Valor.ToString()).GetHashCode();
            else
                return (_inst.Clase.ToString() + "|" + _inst.Valor.ToString() + "|" + _inst.Nombre).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;

            var key = obj as KeyConcepto;
            if ((object)key == null)
                return false;

            return GetHashCode() == key.GetHashCode();

        }

        public static bool operator ==(KeyConcepto key1, KeyConcepto key2)
        {
            if ((object)key1 != (object) null)
                return key1.Equals(key2);
            else if ((object)key2 != (object) null)
                return key1.Equals(key1);
            else
                return true;
        }

        public static bool operator !=(KeyConcepto key1, KeyConcepto key2)
        {
            return !(key1 == key2);
        }
    }

    public partial class Concepto : EB
    {
        protected override IKey CrearKey()
        {
            return new KeyConcepto(this);
        }

        /// <summary>
        /// Obtiene el tipo Enum correspondiente al tipo de concepto especificado
        /// </summary>
        /// <param name="tipo">Tipo de concepto consultado</param>
        /// <returns></returns>
        public static Type TipoEnumeracion(TipoConcepto tipo)
        {
            TipoConcepto tipoConcepto = (TipoConcepto) tipo;
            Type t = typeof(TipoConcepto).Assembly.GetType(typeof(TipoConcepto).Namespace + "." + tipoConcepto.ToString());
            return t;
        }

        /// <summary>
        /// Obtiene el tipo de concepto para el valor enumerado proporcionado
        /// </summary>
        /// <param name="valor">Valor enumerado consultado</param>
        /// <returns></returns>
        public static TipoConcepto ClaseEnumeracion(Enum valor)
        {
            TipoConcepto tipoConcepto = (TipoConcepto) Enum.Parse(typeof(TipoConcepto), valor.GetType().Name);
            return tipoConcepto;
        }

        /// <summary>
        /// Obtiene el tipo de concepto para el valor enumerado proporcionado por su valor int.
        /// </summary>
        /// <param name="valor">Valor int del valor enumerado consultado</param>
        /// <returns></returns>
        public static TipoConcepto ClaseEnumeracion(int valor)
        {
            TipoConcepto tipoConcepto = (TipoConcepto)Enum.ToObject(typeof(TipoConcepto), valor);
            return tipoConcepto;
        }


        /// <summary>
        /// Carga en el concepto la clase y valor de la enumeracion que se pasa como parámetro
        /// </summary>
        /// <param name="concepto">Concepto al que se le cargará clase y valor de la enumeración</param>
        /// <param name="valorEnumeracion">Valor de la enumeración a cargar</param>
        public static void ObtenerClaseYValor(Enum valorEnumeracion, out int clase, out int valor)
        {
            TipoConcepto tipoConcepto = ClaseEnumeracion(valorEnumeracion);

            clase = tipoConcepto.GetHashCode();
            valor = valorEnumeracion.GetHashCode();
        }


        public TipoConcepto ClaseEnum
        {
            get
            {
                return ClaseEnumeracion(Clase);
            }
        }


        public Enum ValorEnum
        {
            get
            {
                return (Enum) Enum.ToObject(TipoEnumeracion(ClaseEnum), Valor);
            }
            set
            {
                int clase, valor;
                ObtenerClaseYValor(value, out clase, out valor);

                Clase = clase;
                Valor = valor;
            }
        }    
    }

    public partial class Entidad: EB
    {
        public string KeyValores()
        {
            var propiedadesStr = ObtenerPropiedadesEntidad();
            return KeyValores(propiedadesStr);

        }

        private string KeyValores(IList<string> propiedadesStr)
        {
            var tipo = this.GetType();
            var propiedades = from prop in tipo.GetProperties()
                              where propiedadesStr.Contains(prop.Name)
                              select prop;

            StringBuilder sb = new StringBuilder();
            foreach (var prop in propiedades)
            {
                var value = prop.GetValue(this, null);

                var valueStr = "";

                if (value == null || DBNull.Value.Equals(value))
                    valueStr = "<null>";
                else
                    valueStr = value.ToString();

                sb.Append(prop.Name + "=" + valueStr);
            }

            return sb.ToString();
        }

    }
    public partial class Persona: Entidad
    {
        public const string PROP_NOMBRECOMPLETO = "NombreCompleto";
        public const string PROP_DOMICILIOCOMPLETO = "DomicilioCompleto";
        public const string PROP_TELEFONO = "Telefono";
        public const string PROP_CELULAR = "Celular";
        public const string PROP_ACTIVO = "Activo";

        public string TelefonoTrabajo
        {
            get 
            {
                return Contacto.TelefonoTrabajo;
            }
        }
        public string Celular
        {
            get
            {
                return Contacto.Movil;
            }
        }
        public string Telefono
        {
            get
            {
                return Contacto.Telefono;
            }
        }
        public string Email
        {
            get
            {
                return Contacto.Email;
            }
        }
        public string DomicilioCompleto
        {
            get 
            {
                return Contacto.Domicilio;
            }
        }
        public string NombreCompleto
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Apellido) && String.IsNullOrWhiteSpace(Nombre) && String.IsNullOrWhiteSpace(Nombre2))
                {
                    return string.Empty;
                }

                return (Apellido + ", " + Nombre + " " + Nombre2).Trim();
            }
        }
        public bool Activo 
        {
            get { return !this.Baja.HasValue; }
        }

    }
}
