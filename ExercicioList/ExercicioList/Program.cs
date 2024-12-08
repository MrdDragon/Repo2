using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<string> listaNomes = new List<string> { "Alice", "Joana", "Jose" };
            listaNomes.Add("Daniel");

            Console.WriteLine("List<T>:");

            foreach (string nome in listaNomes)
            {
                Console.WriteLine("\t"+nome);
            }
            Console.ReadKey();
        }
    }
}
