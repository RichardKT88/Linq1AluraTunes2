using System.Linq;
using System;
using System.Xml.Linq;

namespace AluraTunes
{
    class LinqToXML
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"C:\GitEstudos\AluraTunes\AluraTunes\Data\AluraTunes.xml");

            var queryXML =
                from g in root.Element("Generos").Elements("Genero")
                select g;

            foreach (var genero in queryXML)
            {
                Console.WriteLine("{0}\t{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
            }

            var query = from g in root.Element("Generos").Elements("Genero")
                        join m in root.Element("Musicas").Elements("Musica")
                            on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                        select new
                        {
                            Musica = m.Element("Nome").Value,
                            Genero = g.Element("Nome").Value
                        };

            Console.WriteLine();

            foreach (var musicaEgenero in query)
            {
                Console.WriteLine("{0}\t{1}", musicaEgenero.Musica, musicaEgenero.Genero);
            }

            Console.ReadKey();
        }
    }
}