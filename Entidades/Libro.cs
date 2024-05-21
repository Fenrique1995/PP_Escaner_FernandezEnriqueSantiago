using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        private int numPaginas;

        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas) 
            : base( titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }


        public string ISBN { get{ return NumNormalizado; } } 
        public int NumPaginas { get { return numPaginas; } } 

        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append(base.ToString());
            mensaje.AppendLine($"ISBN: {NumNormalizado}");
            mensaje.AppendLine($"Numero de Paginas: {numPaginas}");
            return mensaje.ToString();
        }


        public static bool operator == (Libro? l1, Libro? l2)
        {
            if (l1 == null || l2 == null) return true;
            if (l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || l1.Titulo == l2.Titulo && l1.Autor == l2.Autor) return true;
            
           return false;
        }
        public static bool operator !=(Libro? l1, Libro? l2)
        {
            return !(l1 == l2);
        }

    }
}
