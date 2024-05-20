using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        private int alto;
        private int ancho;

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        public override void MostrarInformacion()
        {

        }

        public int Alto { get { return alto; } }
        public int Ancho { get { return ancho; } }
        public int Superficie { get { return Ancho * Alto; } }

        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append(base.ToString());
            mensaje.AppendLine($"Superficie:{Ancho} * {Alto}:{Superficie} cm2.");
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

            Mapa other = (Mapa)obj;
            return Titulo == other.Titulo && Autor == other.Autor && Barcode == other.Barcode && Anio == other.Anio && Superficie == other.Superficie;
        }

        public static bool operator ==(Mapa? M1, Mapa? M2)
        {
            if (ReferenceEquals(M1, M2))
            {
                return true;
            }

            if (ReferenceEquals(M1, null) || ReferenceEquals(M2, null))
            {
                return false;
            }

            return M1.Equals(M2);
        }

        public static bool operator !=(Mapa? M1, Mapa? M2)
        {
            return !(M1 == M2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Titulo, Autor, Barcode, Anio, Superficie);
        }
    }
}
