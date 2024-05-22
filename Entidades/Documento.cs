using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// Enumera los diferentes estados por los que puede pasar un documento.
    public enum Paso
    {
        Inicio,
        Distribuido,
        EnEscaner,
        EnRevision,
        Terminado
    }

    /// Representa un documento abstracto con propiedades comunes y métodos para avanzar su estado.
    public abstract class Documento
    {
        private int anio; // Año de publicación del documento.
        private string autor; // Autor del documento.
        private string barcode; // Código de barras del documento.
        private Paso estado; // Estado actual del documento.
        private string numNormalizado; // Número normalizado (ej. ISBN para libros).
        private string titulo; // Título del documento.

        /// Constructor que inicializa un nuevo documento con los detalles especificados.
        /// <param name="titulo">Título del documento.</param>
        /// <param name="autor">Autor del documento.</param>
        /// <param name="anio">Año de publicación del documento.</param>
        /// <param name="numNormalizado">Número normalizado del documento.</param>
        /// <param name="barcode">Código de barras del documento.</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        /// Obtiene el año de publicación del documento.
        public int Anio { get { return anio; } }

        /// Obtiene el autor del documento.
        public string Autor { get { return autor; } }

        /// Obtiene el código de barras del documento.
        public string Barcode { get { return barcode; } }

        /// Obtiene el estado actual del documento.
        public Paso Estado { get { return estado; } }

        /// Obtiene el número normalizado del documento.
        protected string NumNormalizado { get { return numNormalizado; } }

        /// Obtiene el título del documento.
        public string Titulo { get { return titulo; } }

        /// Devuelve una representación en cadena del documento.
        /// <returns>Una cadena que representa el documento.</returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"Titulo: {titulo}");
            mensaje.AppendLine($"Autor: {autor}");
            mensaje.AppendLine($"Año: {anio}");
            if (this is Libro)
            {
                mensaje.AppendLine($"ISBN: {NumNormalizado}");
            }
            mensaje.AppendLine($"Cod. de barras: {barcode}");
            return mensaje.ToString();
        }

        /// Avanza el estado del documento al siguiente paso en el proceso.
        /// <returns>True si el estado fue avanzado, de lo contrario, false.</returns>
        public bool AvanzarEstado()
        {
            switch (estado)
            {
                case Paso.Inicio:
                    estado = Paso.Distribuido;
                    return true;
                case Paso.Distribuido:
                    estado = Paso.EnEscaner;
                    return true;
                case Paso.EnEscaner:
                    estado = Paso.EnRevision;
                    return true;
                case Paso.EnRevision:
                    estado = Paso.Terminado;
                    return true;
                case Paso.Terminado:
                    return false; // Estado final, no se puede avanzar más
                default:
                    return false; // Caso inesperado
            }
        }
    }
}