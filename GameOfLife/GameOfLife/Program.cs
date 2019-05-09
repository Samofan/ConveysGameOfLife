using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    class Program
    {
        static void Main(string[] args)
        {
            Field[] test = Field.GenerateFields(30);

            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test[i].GetStatus());
            }

            Console.ReadKey();   
        }
    }
}
