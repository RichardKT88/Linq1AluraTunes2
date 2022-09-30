using System.Linq;
using System;
using AluraTunes2.Data;

namespace AluraTunes
{
    class LinqToEntitiesCountAndSum
    {
        static void Main(string[] args)
        {

            // 1 - Linq to entities count
            /*using (var contexto = new AluraTunesEntities())
            {
                var query = from f in contexto.Faixas
                            where f.Album.Artista.Nome == "Led Zeppelin"
                            select f;

                //var quantidade = query.Count();

                //Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados.", quantidade);

                var quantidade = contexto.Faixas
                                 .Count(f => f.Album.Artista.Nome == "Led Zeppelin");

                //Console.WriteLine("O banco de dados tem {0} faixas de músicas.", quantidade);

                Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados.", quantidade);

            }
            Console.ReadKey();*/

            //2 - Linq to entities Sum
            /* using (var contexto = new AluraTunesEntities())
             {
                 var query = from inf in contexto.ItemNotaFiscals
                             where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                             select new {
                                 totalDoItem = inf.Quantidade * inf.PrecoUnitario
                             };

                 //foreach (var inf in query)
                 //{
                 //    Console.WriteLine("{0}", inf.totalDoItem);
                 //}

                 var totalDoArtista = query.Sum(q => q.totalDoItem);

                 Console.WriteLine("Total do artista: R${0}", totalDoArtista);

                 Console.ReadKey();
             }*/

            //3 - Linq to entities groupby
            using (var contexto = new AluraTunesEntities())
            {
                var query = from inf in contexto.ItemNotaFiscals
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            group inf by inf.Faixa.Album into agrupado
                            let vendasPorAlbum = agrupado.Sum(a => a.Quantidade * a.PrecoUnitario)
                            orderby vendasPorAlbum
                                descending
                            select new 
                            {
                                TituloDoAlbum = agrupado.Key.Titulo,
                                TotalPorAlbum = vendasPorAlbum
                            };
                            

                foreach (var agrupado in query)
                {
                    Console.WriteLine("{0}\t{1}",
                        agrupado.TituloDoAlbum.PadRight(40),
                        agrupado.TotalPorAlbum);
                }
                Console.ReadKey();

            }

        }
    }
}