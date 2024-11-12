using System;


namespace JogoAdivinhaNumero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int numAleatorio = random.Next(1, 101);
            int numIntroduzido;

            for (int i = 1; i <= 10; i++)
            {
                Console.Write("\nAdvinhe o numero (1-100): ");

                numIntroduzido = int.Parse(Console.ReadLine());

                if (numIntroduzido > numAleatorio)
                {
                    Console.WriteLine("A solução é mais baixa!");
                }
                else if (numIntroduzido < numAleatorio)
                {
                    Console.WriteLine("A solução é mais alta!");
                }
                else
                {
                    Console.WriteLine("Ganhaste o euromilhões!!!");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
