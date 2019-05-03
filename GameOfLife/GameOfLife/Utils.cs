using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Utils
    {
        public static void GenerateFields(int quantity)
        {
            Field[] fieldArray = new Field[quantity];
            for (int i = 0; i < quantity; i++)
            {
                Random random = new Random();
                int randomField = random.Next(0, 1);
                if (randomField == 0)
                {
                    Field field = new Field(false);
                    fieldArray[i] = field;
                }
                else
                {
                    Field field = new Field(true);
                    fieldArray[i] = field;
                }
            }
        }

        public static void printFields(Field[] fieldArray)
        {
          Field[] fieldFeatures = new Field[];
        }
    }
}
