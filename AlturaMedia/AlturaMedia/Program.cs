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
