using System.Linq;
using System;
using AluraTunes2.Data;
using System.Linq.Expressions;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 - Linq to entities min max avg
            /* using (var contexto = new AluraTunesEntities())
             {
                 contexto.Database.Log = Console.WriteLine;

                 var maiorVenda = contexto.NotaFiscals.Max(nf => nf.Total);
                 var menorVenda = contexto.NotaFiscals.Min(nf => nf.Total);
                 var vendaMedia = contexto.NotaFiscals.Average(nf => nf.Total);

                 Console.WriteLine("A maior venda é de R$ {0}", maiorVenda);
                 Console.WriteLine("A menor venda é de R$ {0}", menorVenda);
                 Console.WriteLine("A venda média é de R$ {0}", vendaMedia);

                 var vendas = (from nf in contexto.NotaFiscals
                              group nf by 1 into agrupado
                              select new
                              {
                                  maiorVenda = agrupado.Max(nf => nf.Total),
                                  menorVenda = agrupado.Min(nf => nf.Total),
                                  vendaMedia = agrupado.Average(nf => nf.Total)
                              }).Single();

                 Console.WriteLine("A maior venda é de R$ {0}", vendas.maiorVenda);
                 Console.WriteLine("A menor venda é de R$ {0}", vendas.menorVenda);
                 Console.WriteLine("A venda média é de R$ {0}", vendas.vendaMedia);

             }*/

            //2 - Linq métodos extensão
            /*using (var contexto = new AluraTunesEntities())
            {
                var vendaMedia = contexto.NotaFiscals.Average(nf => nf.Total);

                Console.WriteLine("Venda Média: {0}", vendaMedia);
                //Venda Media: 5.651941

                var query = from nf in contexto.NotaFiscals
                            select nf.Total;

                var contagem = query.Count();

                var queryOrdenada = query.OrderBy(total => total);

                var elementoCentral = queryOrdenada.Skip(contagem / 2).First();

                var mediana = elementoCentral;

                Console.WriteLine("Mediana: {0}", mediana);
            }*/

            //3 - Linq métodos extensão
            using (var contexto = new AluraTunesEntities())
            {
                var vendaMedia = contexto.NotaFiscals.Average(nf => nf.Total);

                Console.WriteLine("Venda Média: {0}", vendaMedia);
                //Venda Media: 5.651941

                var query = from nf in contexto.NotaFiscals
                            select nf.Total;

                decimal mediana = Mediana(query);

                Console.WriteLine("Mediana: {0}", mediana);

                var vendaMediana = contexto.NotaFiscals.Mediana(nf => nf.Total);

                Console.WriteLine("Mediana (com método de extensão): {0}", vendaMediana);

            }

            Console.ReadKey();
        }

        private static decimal Mediana(IQueryable<decimal> query)
        {
            var contagem = query.Count();

            var queryOrdenada = query.OrderBy(total => total);

            var elementoCentral_1 = queryOrdenada.Skip(contagem / 2).First();
            var elementoCentral_2 = queryOrdenada.Skip((contagem - 1) / 2).First();

            var mediana = (elementoCentral_1 + elementoCentral_2) / 2;

            return mediana;
        }
    }
    static class LinqExtension 
    {
        public static decimal Mediana<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector) 
        {
            var contagem = source.Count();

            var funcSelector = selector.Compile();

            var queryOrdenada = source.Select(funcSelector).OrderBy(total => total);

            var elementoCentral_1 = queryOrdenada.Skip(contagem / 2).First();
            var elementoCentral_2 = queryOrdenada.Skip((contagem - 1) / 2).First();

            var mediana = (elementoCentral_1 + elementoCentral_2) / 2;

            return mediana;
        }
    }
}