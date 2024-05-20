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
        }

        public List<Documento> ListaDocumentos { get{ return listaDocumentos; } }
        public Departamento Locacion { get { return locacion;} }
        public string Marca { get {  return marca; } }
        public TipoDoc Tipo { get { return tipo; } }

        public static bool CambiarEstadoDocumento (Documento d)
        {
            return true;
        }
    }
}
