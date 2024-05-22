using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        private static void MostrarDocumentosPorEstado(Escaner e,Paso paso, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            switch (paso)
            {
                case Paso.Inicio:
                    extension = 1;
                    break;
                case Paso.Distribuido:
                    extension = 2;
                    break;
                case Paso.EnEscaner:
                    extension = 3;
                    break;
                case Paso.EnRevision:
                    extension = 4;
                    break;
                case Paso.Terminado:
                    extension = 5;
                    break;
            }
            if (e.Tipo == TipoDoc.libro || e.Tipo == TipoDoc.mapa)
            {
                foreach (var item in e.ListaDocumentos)
                {
                    cantidad++;
                    resumen += item.ToString() + "\n";
                }
            }

            if (cantidad == 0)
            {
                resumen = "Nulo";
            }
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}
