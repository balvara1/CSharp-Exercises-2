using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernadette_Alvarado_Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            // create countries list
            List<Country> Countries = Country.GetCountries();

            Console.WriteLine("Countries List:\n");
            foreach (var item in Countries)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n\n");

            // 1.1 List the names of the countries in alphabetical order 

            Console.WriteLine("1.1 List the names of the countries in alphabetical order:\n");
            var countriesAsc = from country in Countries orderby country.Name select country;
            foreach (var item in countriesAsc)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n\n");

            // 1.2 List the names of the countries in descending order of number of resources

            Console.WriteLine("1.2 List the names of the countries in descending order of number of resources:\n");
            var countriesNoResources = from country in Countries orderby country.Resources.Count descending select country;
            foreach (var item in countriesNoResources)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n\n");

            // 1.3 List the names of the countries that shares a border with Argentina

            Console.WriteLine("1.3 List the names of the countries that shares a border with Argentina:\n");
            var countryBorderArgentina = from country in Countries where country.Borders.Contains("Argentina") select country;
            foreach (var item in countryBorderArgentina)
            {
                Console.WriteLine($"{item.Name,-15}{string.Join(", ", item.Borders),-25}");
            }

            Console.WriteLine("\n\n");

            // 1.4 List the names of the countries that has more than 10,000,000 population 
            Console.WriteLine("1.4 List the names of the countries that has more than 10,000,000 population:\n");
            var countryPopulation = from country in Countries where country.Population > 10000000 orderby country.Population ascending select country;
            foreach (var item in countryPopulation)
            {
                Console.WriteLine($"{item.Name,-15}{string.Join(", ", item.Population),-25}");
            }

            Console.WriteLine("\n\n");

            // 1.5 List the country with highest population 
            Console.WriteLine("1.5 List the country with highest population:\n");
            var countryHighPopulation = (from country in Countries orderby country.Population descending select country).First();

            Console.WriteLine($"{countryHighPopulation.Name,-15}{string.Join(", ", countryHighPopulation.Population),-25}");

            Console.WriteLine("\n\n");

            // 1.6 List all the religion in south America in dictionary order
            Console.WriteLine("1.6 List all the religion in south America in dictionary order:\n");
            var countryReligion = (from country in Countries from religions in country.Religions orderby religions select religions).Distinct();
            foreach (var item in countryReligion)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
