using System.Linq;
using System;
using System.Xml.Linq;
using AluraTunes2.Data;
using AluraTunes2;

namespace AluraTunes
{
    class LinqToEntities
    {
        static void Main(string[] args)
        {
            // 1 - Linq to entities contexto join take log sql
            /*using (var contexto = new AluraTunesEntities())
            {
                //definição de consulta
                var query = from g in contexto.Generos
                            select g;
                foreach (var genero in query)
                {
                    Console.WriteLine("{0}\t{1}", genero.GeneroId, genero.Nome);
                }

                var faixaEGenero = from g in contexto.Generos
                                   join f in contexto.Faixas
                                   on g.GeneroId equals f.GeneroId
                                   select new { f, g };

                faixaEGenero = faixaEGenero.Take(10);

                contexto.Database.Log = Console.WriteLine;
                
                Console.WriteLine();
                
                foreach (var item in faixaEGenero)
                {
                    Console.WriteLine("{0}\t{1}", item.f.Nome, item.g.Nome);
                }
                Console.ReadKey();
                //imprimir no console
            }*/
            // 2 - Linq to entities where
            /*using(var contexto = new AluraTunesEntities())
            {
                var textoEmBusca = "Led";

                var query = from a in contexto.Artistas
                            where a.Nome.Contains(textoEmBusca)
                            select a;
                foreach (var artista in query)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }
                Console.ReadKey();
            }*/
            
            // 3 - Linq to entities sintaxe de método
            using(var contexto = new AluraTunesEntities())
            {
                var textoEmBusca = "Led";

                var query = from a in contexto.Artistas
                            where a.Nome.Contains(textoEmBusca)
                            select a;
                foreach (var artista in query)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }
                var query2 = contexto.Artistas.Where(a => a.Nome.Contains(textoEmBusca));

                Console.WriteLine();
                
                foreach (var artista in query2)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);

                }
                Console.ReadKey();
            }


        }
    }
}