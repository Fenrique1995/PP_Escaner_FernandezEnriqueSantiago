using Entidades;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Escaner bookScanner = new Escaner("HP", TipoDoc.libro);
            Escaner mapScanner = new Escaner("Epson", TipoDoc.mapa);

            List<Libro> books = new List<Libro>
            {
                new Libro("Libro 1", "Autor 1", 2019, "11111", "22222", 5),
                new Libro("Libro 2", "Autor 2", 2020, "22222", "33333", 15),
                new Libro("Libro 3", "Autor 3", 2021, "33333", "44444", 20),
                new Libro("Libro 4", "Autor 4", 2022, "44444", "55555", 25)
            };

            List<Mapa> maps = new List<Mapa>
            {
                new Mapa("Mapa 1", "Autor mapa 1", 2019, "11111", "22222", 5, 5),
                new Mapa("Mapa 2", "Autor mapa 2", 2020, "22222", "33333", 15, 15),
                new Mapa("Mapa 3", "Autor mapa 3", 2021, "33333", "44444", 20, 20),
                new Mapa("Mapa 4", "Autor mapa 4", 2022, "44444", "55555", 25, 25)
            };

            foreach (var book in books)
            {
                bool result = bookScanner + book;
                if (result)
                {
                    Console.WriteLine("Se agregó el libro:");
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("-----------------------");
                }
            }

            Console.WriteLine("#########################################################################");
            Console.WriteLine($"Se agregaron {bookScanner.ListaDocumentos.Count} libros, al escaner de libros");
            Console.WriteLine("#########################################################################");

            foreach (var map in maps)
            {
                bool result = mapScanner + map;
                if (result)
                {
                    Console.WriteLine("Se agregó el mapa:");
                    Console.WriteLine(map.ToString());
                    Console.WriteLine("-----------------------");
                }
            }

            Console.WriteLine("#########################################################################");
            Console.WriteLine($"Se agregaron {mapScanner.ListaDocumentos.Count} mapas, al escaner de mapas");
            Console.WriteLine("#########################################################################");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Libro bookFive = new Libro("Libro 5", "Autor 5", 2023, "55555", "666666", 30);

            if (mapScanner + bookFive)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Se agregó el libro [{bookFive.Titulo}] al escaner de MAPAS");
                Console.WriteLine("-----------------------");

            }
            else
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"No se pudo agregar el libro [{bookFive.Titulo}] al escaner de MAPAS");
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Mapa mapFive = new Mapa("Mapa 5", "Autor mapa 5", 2023, "55555", "66666", 30, 30);

            if (bookScanner + mapFive)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Se agregó el libro [{mapFive.Titulo}] al escaner de LIBROS");
                Console.WriteLine("-----------------------");

            }
            else
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"No se pudo agregar el libro [{mapFive.Titulo}] al escaner de LIBROS");
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("#########################################################################");
            Console.WriteLine($"Listado del escaner de mapas {mapScanner.Marca}:");
            Console.WriteLine("#########################################################################");

            // Si haces foreach (Mapa map in mapScanner.ListaDocumentos), pincha porque tiene un mapa dentro (esto si todavia no lo validaste en el + del escaner)
            foreach (Documento map in mapScanner.ListaDocumentos)
            {
                Console.WriteLine(map.ToString());
            }

            Console.WriteLine("#########################################################################");
            Console.WriteLine($"Listado del escaner de libros {bookScanner.Marca}:");
            Console.WriteLine("#########################################################################");

            // Si haces foreach (Libro map in mapScanner.ListaDocumentos), pincha porque tiene un mapa dentro (esto si todavia no lo validaste en el + del escaner)
            foreach (Documento book in bookScanner.ListaDocumentos)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
