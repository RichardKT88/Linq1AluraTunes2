using System.Linq;
using System;
using AluraTunes2.Data;

namespace AluraTunes
{
    class LinqToEntities2
    {
        static void Main(string[] args)
        {
            // 1 - Linq to entities join
            /*using(var contexto = new AluraTunesEntities())
            {
                var textoEmBusca = "Led";

                var query = from a in contexto.Artistas
                            join alb in contexto.Albums
                                on a.ArtistaId equals alb.ArtistaId
                            where a.Nome.Contains(textoEmBusca)
                            select new 
                            {
                                NomeArtista = a.Nome,
                                NomeAlbum = alb.Titulo
                            };
                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
                }
             
                Console.ReadKey();
            }*/
            // 2 - Linq to entities sem join
            /*using(var contexto = new AluraTunesEntities())
            {
                var textoEmBusca = "Led";

                var query = from alb in contexto.Albums
                            where alb.Artista.Nome.Contains(textoEmBusca)
                            select new
                            {
                                NomeArtista = alb.Artista.Nome,
                                NomeAlbum = alb.Titulo
                            };
                foreach (var album in query)
                {
                    Console.WriteLine("{0}\t{1}", album.NomeArtista, album.NomeAlbum);
                }
             
                Console.ReadKey();
            }*/
            // 3 - Linq to entities refinando consultas
            using (var contexto = new AluraTunesEntities())
            {
                

                GetFaixas(contexto, "Led Zeppelin", "");

                Console.WriteLine();

                GetFaixas(contexto, "Led Zeppelin", "Graffiti");

                Console.ReadKey();
            }

        }

        private static void GetFaixas(AluraTunesEntities contexto, string buscaArtista, string buscaAlbum)
        {
            var query = from f in contexto.Faixas
                        where f.Album.Artista.Nome.Contains(buscaArtista)
                        select f;

            if (!string.IsNullOrEmpty(buscaAlbum)) 
            {
                query = query.Where(q => q.Album.Titulo.Contains(buscaAlbum));
            }

            foreach (var faixa in query)
            {
                Console.WriteLine("{0}\t{1}", faixa.Album.Titulo.PadRight(40), faixa.Nome);
            }
        }
    }
}