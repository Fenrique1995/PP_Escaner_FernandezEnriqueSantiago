using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    

    /// Representa un escáner que puede manejar diferentes tipos de documentos y está ubicado en diferentes departamentos.
    public class Escaner
    {
        private List<Documento> listaDocumentos; // Lista de documentos escaneados.
        private Departamento locacion; // Departamento donde está ubicado el escáner.
        private string marca; // Marca del escáner.
        private TipoDoc tipo; // Tipo de documento que el escáner maneja.

        /// Enumera los diferentes departamentos donde puede estar ubicado el escáner.
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        /// Enumera los diferentes tipos de documentos que puede manejar el escáner.
        public enum TipoDoc
        {
            libro,
            mapa
        }

        /// Constructor que inicializa un nuevo escáner con la marca y el tipo de documento especificados.
        /// <param name="marca">Marca del escáner.</param>
        /// <param name="tipo">Tipo de documento que el escáner maneja.</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            // Establece la ubicación del escáner según el tipo de documento.
            if (this.tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
            else if (this.tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.nulo;
            }
        }

        /// Obtiene la lista de documentos escaneados.
        public List<Documento> ListaDocumentos { get { return listaDocumentos; } }

        /// Obtiene la ubicación del escáner.
        public Departamento Locacion { get { return locacion; } }

        /// Obtiene la marca del escáner.
        public string Marca { get { return marca; } }

        /// Obtiene el tipo de documento que el escáner maneja.
        public TipoDoc Tipo { get { return tipo; } }

        /// Cambia el estado del documento si es un libro o un mapa.
        /// <param name="d">Documento a cambiar de estado.</param>
        /// <returns>True si el estado fue cambiado, de lo contrario, false.</returns>
        public static bool CambiarEstadoDocumento(Documento? d)
        {
            if (d == null)
            {
                return false;
            }

            if ((d is Libro) || (d is Mapa))
            {
                return d.AvanzarEstado();
            }
            return false;
        }

        /// Sobrecarga del operador == para comparar un escáner con un documento.
        /// <param name="e">Escáner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento está en la lista del escáner, de lo contrario, false.</returns>
        public static bool operator ==(Escaner e, Documento? d)
        {
            if (d == null || e == null) return false;

            foreach (var item in e.listaDocumentos)
            {
                if (item == d)
                {
                    return true;
                }
            }

            return false;
        }

        /// Sobrecarga del operador != para comparar un escáner con un documento.
        /// <param name="e">Escáner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento no está en la lista del escáner, de lo contrario, false.</returns>
        public static bool operator !=(Escaner e, Documento? d)
        {
            return !(e == d);
        }

        /// Sobrecarga del operador + para agregar un documento a la lista del escáner si está en el estado de inicio.
        /// <param name="e">Escáner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento fue agregado, de lo contrario, false.</returns>
        public static bool operator +(Escaner e, Documento? d)
        {
            if (d.Estado != Paso.Inicio)
            {
                return false;
            }

            if ((e.Tipo == TipoDoc.libro && d is Mapa) || (e.Tipo == TipoDoc.mapa && d is Libro))
            {
                return false;
            }

            foreach (Documento doc in e.listaDocumentos)
            {
                if ((doc is Libro libroDoc && d is Libro libro) && (libroDoc == libro))
                {
                    return false;
                }
                else if ((doc is Mapa mapaDoc && d is Mapa mapa) && (mapaDoc == mapa))
                {
                    return false;
                }
            }

            d.AvanzarEstado();
            e.ListaDocumentos.Add(d);
            return true;
        }
    }
}