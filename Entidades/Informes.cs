using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// Clase estática que proporciona métodos para mostrar informes de documentos según su estado.
    public static class Informes
    {

        /// Muestra los documentos que están en el estado "Distribuido" para un escáner específico.
        /// <param name="e">El escáner cuyos documentos se deben mostrar.</param>
        /// <param name="extension">La suma de las extensiones de los documentos distribuidos (número de páginas o superficie).</param>
        /// <param name="cantidad">La cantidad de documentos distribuidos.</param>
        /// <param name="resumen">El resumen de los documentos distribuidos.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// Método privado que muestra los documentos de un escáner específico según el estado especificado.
        /// <param name="e">El escáner cuyos documentos se deben mostrar.</param>
        /// <param name="paso">El estado de los documentos a mostrar.</param>
        /// <param name="extension">La suma de las extensiones de los documentos en el estado especificado.</param>
        /// <param name="cantidad">La cantidad de documentos en el estado especificado.</param>
        /// <param name="resumen">El resumen de los documentos en el estado especificado.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Paso paso, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";

            if (e.Tipo == TipoDoc.libro || e.Tipo == TipoDoc.mapa)
            {
                foreach (var item in e.ListaDocumentos)
                {
                    if (item.Estado == paso)
                    {
                        cantidad++;
                        if (e.Tipo == TipoDoc.libro || e.Tipo == TipoDoc.mapa)
                        {
                            if (item is Libro libro)
                            {
                                extension += libro.NumPaginas;
                            }
                            else if (item is Mapa mapa)
                            {
                                extension += mapa.Superficie;
                            }
                        }
                        resumen += item.ToString() + "\n";
                    }
                }
            }
            /*
            if (cantidad == 0)
            {
                resumen = "Nulo";
            }*/
        }

        /// Muestra los documentos que están en el estado "EnEscaner" para un escáner específico.
        /// <param name="e">El escáner cuyos documentos se deben mostrar.</param>
        /// <param name="extension">La suma de las extensiones de los documentos en escaneo (número de páginas o superficie).</param>
        /// <param name="cantidad">La cantidad de documentos en escaneo.</param>
        /// <param name="resumen">El resumen de los documentos en escaneo.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// Muestra los documentos que están en el estado "EnRevision" para un escáner específico.
        /// <param name="e">El escáner cuyos documentos se deben mostrar.</param>
        /// <param name="extension">La suma de las extensiones de los documentos en revisión (número de páginas o superficie).</param>
        /// <param name="cantidad">La cantidad de documentos en revisión.</param>
        /// <param name="resumen">El resumen de los documentos en revisión.</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// Muestra los documentos que están en el estado "Terminado" para un escáner específico.
        /// <param name="e">El escáner cuyos documentos se deben mostrar.</param>
        /// <param name="extension">La suma de las extensiones de los documentos terminados (número de páginas o superficie).</param>
        /// <param name="cantidad">La cantidad de documentos terminados.</param>
        /// <param name="resumen">El resumen de los documentos terminados.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}