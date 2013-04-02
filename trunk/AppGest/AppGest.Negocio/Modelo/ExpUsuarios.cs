using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Util.Encriptacion.Algoritmos;
using AppGest.Util.Encriptacion;


namespace AppGest.Negocio.Modelo
{
    public class ExpUsuarios : ExpertoEntidad<Usuario>
    {

        public override void Guardar(Usuario entidad)
        {
            
            entidad.Clave = this.Encriptar(entidad);
            base.Guardar(entidad);
        }

        private string Encriptar(Usuario entidad)
        {
            IAlgoritmoEncriptador d = Encriptador.Obtener<CTripleDES>();

            return d.Encriptar(entidad.Nombre + entidad.Clave);
        }
        private string Desencriptar(Usuario entidad)
        {
            IAlgoritmoEncriptador d = Encriptador.Obtener<CTripleDES>();
            return d.Desencriptar(entidad.Clave);
        }
        protected override void Inicializar(Usuario entidad)
        {
            entidad.Alta = DateTime.Now;
            entidad.Baja = null;
        }

        internal Usuario ObtenerCuenta(string cuenta)
        {
            return Persistidor.Primero<Usuario>(u => u.Nombre == cuenta);
        }

        internal void Validar(Usuario usuario, string cuenta, string clave)
        {
            if (usuario == null || Desencriptar(usuario) != (cuenta+clave))
                throw new InvalidOperationException("Usuario o clave no válido.");
        }



        internal void Proteger(Usuario usuario)
        {
            usuario.Clave = this.Encriptar(usuario);
        }
    }
}
