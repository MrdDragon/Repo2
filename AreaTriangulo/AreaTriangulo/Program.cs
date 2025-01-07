using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaTriangulo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            double x1, x2, x3, y1, y2, y3;
            ClassTriangulo areaT = new ClassTriangulo();

            Console.WriteLine("Entre com as medidas do triângulo X: ");
            x1 = double.Parse(Console.ReadLine());
            x2 = double.Parse(Console.ReadLine());
            x3 = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com as medidas do triângulo Y: ");
            y1 = double.Parse(Console.ReadLine());
            y2 = double.Parse(Console.ReadLine());
            y3 = double.Parse(Console.ReadLine());

            Console.WriteLine("Área de X: {0:F4}", areaT.AreaTriangulo(x1, x2, x3));
            Console.WriteLine("Área de Y: {0:F4}", ClassTriangulo.AreaTrianguloStatic(y1, y2, y3));

            if (areaT.AreaTriangulo(x1, x2, x3) > areaT.AreaTriangulo(y1, y2, y3))
            {
                Console.WriteLine("Maior área X");
            }
            else if(areaT.AreaTriangulo(x1, x2, x3) < areaT.AreaTriangulo(y1, y2, y3))
            {
                Console.WriteLine("Maior área Y");
            }
            else
            {
                Console.WriteLine("Devem ser iguais!");
            }
            Console.ReadKey();
        }
    }
}
