//-----------------------------------------------------------------
//    <copyright file="AlturaMedia"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-07</date>
//    <time>12:10</time>
//    <version>0.1</version>
//    <author>D.Oliveira</author>
//    <description></description>
//-----------------------------------------------------------------
using System;
using System.Data;


namespace AlturaMedia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nPessoas = 0;

            Console.Write("Quantas alturas de pessoas vai introduzir: ");
            nPessoas = int.Parse(Console.ReadLine());

            double[] alturas = new double[nPessoas];
            double media = 0;
            double total = 0;

            for (int i = 0; i < nPessoas; i++)
            {
                Console.Write("\nIntroduza a altura da " + (i + 1) + "ª pessoa: ");
                alturas[i] = double.Parse(Console.ReadLine());
            }

            foreach (double i in alturas)
            {
                media += i; 
            }

            total = media / nPessoas;
            Console.Write($"\nA média das alturas é: {total}");

            Console.ReadKey();
        }
    }
}
