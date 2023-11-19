using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieLibrary library = new MovieLibrary();
            Cycle(library.OrdinaryMovies);
            Cycle(library.AdultsMovies);


            string ordinaryMovies1 = library.GetArticle(1, "Ordinary");
            Console.WriteLine($"Article for ordinary movie: {ordinaryMovies1}");

            string adultMovies1 = library.GetArticle(3, "Adult");
            Console.WriteLine($"Article for ordinary movie: {adultMovies1}");

            string adultMovies2 = library.GetArticle(10, "Adult");
            Console.WriteLine($"Article for ordinary movie: {adultMovies2}");


        }

        public static void Cycle(IEnumerable collection )
        {
            foreach (object item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
