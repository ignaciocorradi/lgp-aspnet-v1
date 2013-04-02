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
    
    public partial class Cliente
    {
    
    
        #region Métodos de Copia
    
        public override void CopiarDesde(EntityObject origen)
        {
            base.CopiarDesde(origen);
    
            var entidad = (Cliente) origen;
            
    		NroCliente = entidad.NroCliente;
    		CUIT = entidad.CUIT;
    		DomicilioFiscal = entidad.DomicilioFiscal;
    		RazonSocial = entidad.RazonSocial;
        }
    
        public override void CopiarA(EntityObject destino)
        {
            base.CopiarA(destino);
    
            var entidad = (Cliente) destino;
            
    		 entidad.NroCliente = NroCliente;
    		 entidad.CUIT = CUIT;
    		 entidad.DomicilioFiscal = DomicilioFiscal;
    		 entidad.RazonSocial = RazonSocial;
        }

        #endregion
    
    }
}