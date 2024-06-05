using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoIncorrectoException : Exception
    {
        private string nombreClase;
        private string nombreMetodo;
        public string NombreClase { get { return nombreClase;} }
        public string NombreMetodo { get { return nombreMetodo; } }
        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo) 
            : base(mensaje)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }
        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }
        public override string ToString()
        {
            string detallesInnerException = InnerException != null ? InnerException.Message : "No hay detalles adicionales.";
            return $"Excepción en el método {NombreMetodo} de la clase {NombreClase}.\n" +
                   "Algo salió mal, revisa los detalles.\n" +
                   $"Detalles: {detallesInnerException}";
        }

    }
}
