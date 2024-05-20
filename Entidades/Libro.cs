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

        public override void MostrarInformacion()
        {

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


        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Libro other = (Libro)obj;
            return ISBN == other.ISBN && Titulo == other.Titulo && Autor == other.Autor && Barcode == other.Barcode;
        }



        public static bool operator == (Libro? l1, Libro? l2)
        {
            if (ReferenceEquals(l1, l2))
            {
                return true;
            }

            if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null))
            {
                return false;
            }

            return l1.Equals(l2);
        }
        public static bool operator !=(Libro? l1, Libro? l2)
        {
            return !(l1 == l2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Titulo, Autor, ISBN, Barcode);
        }
    }
}
