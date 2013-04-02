//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Objects.DataClasses;


namespace AppGest.Datos.Persistencia
{
    
    public partial class Reg_Det : EntityObject
    {
    
        #region Composiciones
    

        #endregion
    
        #region Agregaciones
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'Reg_encab' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'Reg_encab') o por referencia (propiedad 'Reg_encabReference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetReg_encab(Reg_encab nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("Reg_encab", "Reg_encabReference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'Concepto' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'Concepto') o por referencia (propiedad 'ConceptoReference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetConcepto(Concepto nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("Concepto", "ConceptoReference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'ValLista1' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'ValLista1') o por referencia (propiedad 'ValLista1Reference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetValLista1(EB nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("ValLista1", "ValLista1Reference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'ValLista2' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'ValLista2') o por referencia (propiedad 'ValLista2Reference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetValLista2(EB nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("ValLista2", "ValLista2Reference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'ValLista3' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'ValLista3') o por referencia (propiedad 'ValLista3Reference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetValLista3(EB nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("ValLista3", "ValLista3Reference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'ValLista4' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'ValLista4') o por referencia (propiedad 'ValLista4Reference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetValLista4(EB nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("ValLista4", "ValLista4Reference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'UM' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'UM') o por referencia (propiedad 'UMReference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetUM(EB nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("UM", "UMReference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'EntidadAfectada2' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'EntidadAfectada2') o por referencia (propiedad 'EntidadAfectada2Reference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetEntidadAfectada2(Persona nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("EntidadAfectada2", "EntidadAfectada2Reference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'EntidadAfectada1' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'EntidadAfectada1') o por referencia (propiedad 'EntidadAfectada1Reference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetEntidadAfectada1(Persona nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("EntidadAfectada1", "EntidadAfectada1Reference", nuevo, forzarPorInstancia);
        }
    
        /// <summary>
        /// Establece el objeto asociado a la propiedad 'EntidadAfectada3' de esta instancia, teniendo en cuena
        /// si se se debe hacer por instancia (propiedad 'EntidadAfectada3') o por referencia (propiedad 'EntidadAfectada3Reference').
        /// </summary>
        /// <param name="nuevo">Entidad a asociar</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        public virtual void SetEntidadAfectada3(Persona nuevo, bool forzarPorInstancia = false)
        {
            this.SetRelacion("EntidadAfectada3", "EntidadAfectada3Reference", nuevo, forzarPorInstancia);
        }
    

        #endregion
    
    }
}