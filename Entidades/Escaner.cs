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
            try
            {
                foreach (var item in e.ListaDocumentos)
                {
                    if (item == d)
                    {
                        return true;
                    }
                }
                throw new TipoIncorrectoException("Este escáner no acepta este tipo de documento", nameof(Escaner), "==");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
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
            // Verifica si el documento es nulo o no está en el estado de inicio
            if (d == null || d.Estado != Paso.Inicio)
            {
                return false;
            }

            // Verifica si el tipo del documento coincide con el tipo del escáner
            if((e.Tipo == TipoDoc.libro && !(d is Libro)) || (e.Tipo == TipoDoc.mapa && !(d is Mapa)))
            {
                throw new TipoIncorrectoException("El tipo de documento no coincide con el tipo de escáner.", nameof(Escaner), "+");
            }
            // Verifica si el documento ya está en la lista del escáner
            if (e.ListaDocumentos.Contains(d))
            {
                return false;
            }

            // Agrega el documento a la lista del escáner y cambia su estado
            e.ListaDocumentos.Add(d);
            CambiarEstadoDocumento(d);
            return true;
        }

        /// Implementa el método Equals para comparar escáneres.
        /// <param name="obj">El objeto a comparar con el escáner actual.</param>
        /// <returns>True si los objetos son iguales, de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Escaner escaner)
            {
                return marca == escaner.marca && tipo == escaner.tipo && locacion == escaner.locacion &&
                       ListaDocumentos.SequenceEqual(escaner.ListaDocumentos);
            }
            return false;
        }

        /// Implementa el método GetHashCode para generar un código hash para el escáner.
        /// <returns>El código hash del escáner.</returns>
        public override int GetHashCode()
        {
            int hash = HashCode.Combine(marca, tipo, locacion);
            foreach (var doc in ListaDocumentos)
            {
                hash = HashCode.Combine(hash, doc.GetHashCode());
            }
            return hash;
        }
    }
}
