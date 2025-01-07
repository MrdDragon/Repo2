//-----------------------------------------------------------------
//    <copyright file="Progam.cs"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-12</date>
//    <time>11:10</time>
//    <version>0.1</version>
//    <author>Daniel Oliveira</author>
//    <description></description>
//-----------------------------------------------------------------

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
                Console.Write("\nAdvinhe o numero de 1 a 100 (" + (11-i) +" Tentativa(s)): ");

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
