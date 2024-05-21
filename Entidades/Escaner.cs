using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Departamento
    {
        nulo,
        mapoteca,
        procesosTecnicos
    }
    public enum TipoDoc
    {
        libro,
        mapa
    }
    public class Escaner
    {
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
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

        public List<Documento> ListaDocumentos { get{ return listaDocumentos; } }
        public Departamento Locacion { get { return locacion;} }
        public string Marca { get {  return marca; } }
        public TipoDoc Tipo { get { return tipo; } }

        public static bool CambiarEstadoDocumento (Documento? d)
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
    }
}
