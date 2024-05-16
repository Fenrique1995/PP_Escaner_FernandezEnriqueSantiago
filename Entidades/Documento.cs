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

        protected Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        public int GetAnio () => anio;
        public string GetAutor () => autor;
        public string GetBarcode () => barcode;
        public Paso GetEstado() => estado;
        public string GetNumNormalizado() => numNormalizado;
        public string GetTitulo() => titulo;

        // Método abstracto (sin implementación)
        public abstract void MostrarInformacion();


        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"Titulo: {titulo}");
            mensaje.AppendLine($"Autor: {autor}");
            mensaje.AppendLine($"Año: {anio}");
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
