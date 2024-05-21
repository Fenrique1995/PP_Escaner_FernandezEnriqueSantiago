using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Paso
    {
        Inicio,
        Distribuido,
        EnEscaner,
        EnRevision,
        Terminado
    }
    public abstract class Documento
    {
        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        public int Anio { get { return anio;} } 
        public string Autor { get { return autor;} }
        
        public string Barcode { get { return barcode;} }
        
        public Paso Estado { get { return estado;} }
        
        protected string NumNormalizado { get { return numNormalizado; } }
        public string Titulo { get { return titulo;} }
        

         


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

        public bool AvanzarEstado()
        {
            switch (estado)//En este switch el estado que pongas pasara al siguiente
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
