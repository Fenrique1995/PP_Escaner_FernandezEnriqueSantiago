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

        public static bool operator ==(Mapa? M1, Mapa? M2)
        {
            if (M1 == null || M2 == null) return true;
            if (M1.Barcode == M2.Barcode || M1.Titulo == M2.Titulo && M1.Autor == M2.Autor && M1.Superficie == M2.Superficie) return true;

            return false;
        }

        public static bool operator !=(Mapa? M1, Mapa? M2)
        {
            return !(M1 == M2);
        }

        
    }
}
