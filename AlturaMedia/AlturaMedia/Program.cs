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


namespace AlturaMedia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nPessoas = 0;
            Console.WriteLine("Quantas alturas de pessoas vai introduzir: ");
            nPessoas = int.Parse(Console.ReadLine());

            double[] alturas = new double[nPessoas];

            for(int i = 0; i < nPessoas; i++)
            {
                Console.WriteLine("Introduza a altura da " + (i + 1) + "ª pessoa: ");
                alturas[i] = double.Parse(Console.ReadLine());
            }
        }
    }
}
