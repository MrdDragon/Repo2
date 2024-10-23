using System;


namespace AppRepoTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cond = 1;

            while(cond != 69) 
            {
                Console.WriteLine("Hey, who told you to open this?\nGive the right number!");
                cond = int.Parse(Console.ReadLine());
            }
            
        }
    }
}
