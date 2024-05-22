using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// Representa un libro, que es un tipo específico de documento.
    public class Libro : Documento
    {
        private int numPaginas; // Número de páginas del libro.

        /// Constructor que inicializa un nuevo libro con los detalles especificados.
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="anio">Año de publicación del libro.</param>
        /// <param name="numNormalizado">Número normalizado (ISBN) del libro.</param>
        /// <param name="codebar">Código de barras del libro.</param>
        /// <param name="numPaginas">Número de páginas del libro.</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }

        /// Obtiene el ISBN del libro.
        public string ISBN { get { return NumNormalizado; } }

        /// Obtiene el número de páginas del libro.
        public int NumPaginas { get { return numPaginas; } }

        /// Devuelve una representación en cadena del libro.
        /// <returns>Una cadena que representa el libro.</returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append(base.ToString());
            mensaje.AppendLine($"Número de Páginas: {numPaginas}");
            return mensaje.ToString();
        }

        /// Sobrecarga del operador == para comparar dos libros.
        /// <param name="l1">Primer libro.</param>
        /// <param name="l2">Segundo libro.</param>
        /// <returns>True si los libros son iguales, de lo contrario, false.</returns>
        public static bool operator ==(Libro? l1, Libro? l2)
        {
            if (l1 is null || l2 is null) return false;
            return l1.Barcode == l2.Barcode ||
                   l1.ISBN == l2.ISBN ||
                   (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }

        /// Sobrecarga del operador != para comparar dos libros.
        /// <param name="l1">Primer libro.</param>
        /// <param name="l2">Segundo libro.</param>
        /// <returns>True si los libros no son iguales, de lo contrario, false.</returns>
        public static bool operator !=(Libro? l1, Libro? l2)
        {
            return !(l1 == l2);
        }
    }
}