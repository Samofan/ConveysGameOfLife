using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Field
    {
        Boolean isAlive;

        public Field(Boolean living)
        {
            isAlive = living;
        }

        public void SetAlive(Boolean living)
        {
            isAlive = living;
        }

        public Boolean GetStatus() 
        {
            return isAlive;
        }

        public static Field[] GenerateFields(int quantity)
        {
            Field[] fieldArray = new Field[quantity];
            Random random = new Random();

            for (int i = 0; i < quantity; i++)
            {
                int randomFieldStatus = random.Next(0, 2);
                if (randomFieldStatus == 0)
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
            return fieldArray;
        }
    }
    
}
