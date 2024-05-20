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
    }
}
