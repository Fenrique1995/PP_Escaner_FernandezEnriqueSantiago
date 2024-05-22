using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// Representa un mapa, que es un tipo específico de documento.
    public class Mapa : Documento
    {
        private int alto; // Altura del mapa.
        private int ancho; // Anchura del mapa.

        /// Constructor que inicializa un nuevo mapa con los detalles especificados.
        /// <param name="titulo">Título del mapa.</param>
        /// <param name="autor">Autor del mapa.</param>
        /// <param name="anio">Año de publicación del mapa.</param>
        /// <param name="numNormalizado">Número normalizado del mapa.</param>
        /// <param name="codebar">Código de barras del mapa.</param>
        /// <param name="ancho">Anchura del mapa.</param>
        /// <param name="alto">Altura del mapa.</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        /// Obtiene la altura del mapa.
        public int Alto { get { return alto; } }

        /// Obtiene la anchura del mapa.
        public int Ancho { get { return ancho; } }

        /// Obtiene la superficie del mapa en cm².
        public int Superficie { get { return Ancho * Alto; } }

        /// Devuelve una representación en cadena del mapa.
        /// <returns>Una cadena que representa el mapa.</returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append(base.ToString());
            mensaje.AppendLine($"Superficie: {Ancho} * {Alto}: {Superficie} cm².");
            return mensaje.ToString();
        }

        /// Sobrecarga del operador == para comparar dos mapas.
        /// <param name="M1">Primer mapa.</param>
        /// <param name="M2">Segundo mapa.</param>
        /// <returns>True si los mapas son iguales, de lo contrario, false.</returns>
        public static bool operator ==(Mapa? M1, Mapa? M2)
        {
            if (M1 is null || M2 is null) return false;
            return M1.Barcode == M2.Barcode ||
                   (M1.Titulo == M2.Titulo && M1.Autor == M2.Autor && M1.Superficie == M2.Superficie);
        }

        /// Sobrecarga del operador != para comparar dos mapas.
        /// <param name="M1">Primer mapa.</param>
        /// <param name="M2">Segundo mapa.</param>
        /// <returns>True si los mapas no son iguales, de lo contrario, false.</returns>
        public static bool operator !=(Mapa? M1, Mapa? M2)
        {
            return !(M1 == M2);
        }
    }
}