using System.Linq;
using System;
using AluraTunes2.Data;

namespace AluraTunes
{
    class LinqToEntitiesOrderBy
    {
        static void Main(string[] args)
        {

            // 5 - Linq to entities orderby
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
            //Sintaxe de consulta
            var query = from f in contexto.Faixas
                        where f.Album.Artista.Nome.Contains(buscaArtista)
                        && (!string.IsNullOrEmpty(buscaAlbum) 
                        ? f.Album.Titulo.Contains(buscaAlbum) 
                        : true)
                        orderby f.Album.Titulo, f.Nome
                        select f;


            /*if (!string.IsNullOrEmpty(buscaAlbum)) 
            {
                //query = query.Where(q => q.Album.Titulo.Contains(buscaAlbum));
            }*/
            //Sintaxe de método
            //query = query.OrderBy(q => q.Album.Titulo).ThenBy(q => q.Nome);
            //query = query.OrderBy(q => q.Album.Titulo).ThenByDescending(q => q.Nome);

            foreach (var faixa in query)
            {
                Console.WriteLine("{0}\t{1}", faixa.Album.Titulo.PadRight(40), faixa.Nome);
            }
        }
    }
}