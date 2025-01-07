using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EparMetodo
{
    internal class Program
    {
        static void Epar(int num)
        {
            if (num % 2 == 0) 
            {
                Console.WriteLine("O número é par!");
            }
            else
            {
                Console.WriteLine("O número é ímpar!");
            }
        }

        static bool Eprimo(int numP)
        {
            if (numP <= 1)
                return false;

            for (int i =2; i <= Math.Sqrt(numP); i++)
            {
                if(numP % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("\nIntroduza um número: ");
            int numero = int.Parse(Console.ReadLine());
            Epar(numero);

            if (Eprimo(numero))
            {
                Console.WriteLine("O número é Primo!");
            }
            else 
            {
                Console.WriteLine("O número não é Primo!");
            }

            Console.ReadKey();
        }
    }
}
