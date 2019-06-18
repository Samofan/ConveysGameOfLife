using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Utils
    {
        public static void PrintFields(Field[] fieldArray)
        {
            int rowsAndCols = RowsAndCols(fieldArray.Length);
            int counter = 0;

            for(int y = 0; y < rowsAndCols; y++)
            {
                for(int i = 0; i < rowsAndCols; i++)
                {
                    WriteInColor(fieldArray[counter].GetStatus());
                    counter++;
                }
                Console.Write("\n");
            }

            counter = 0;            
        }

        private static void WriteInColor(Boolean status)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            if (status)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("# ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("# ");
                Console.ResetColor();
            }           
        }

        private static int RowsAndCols(double length)
        {
            double square = Math.Sqrt(length);

            //try
            //{
                int squareInt = Convert.ToInt32(square);
                return squareInt;
            //}
            //catch (InvalidCastException)
            //{
                //Console.WriteLine("Mit der Zahl funktioniert es nicht!");
                //Console.ReadLine();
                //Environment.Exit(0);
                //return 0;
            //}
        }

        public static void NextRound(Field[] fieldArray)
        {
            int length = fieldArray.Length;
            int aliveNeighbours = 0;
            int sqrt = Convert.ToInt32(Math.Sqrt(length));
            
            for(int i = 0; i < length; i++)
            {
                
                if(i > 29 && i < 800)
                {
                    if (fieldArray[i - sqrt].GetStatus())
                    {
                        aliveNeighbours++;
                    }
                    if (fieldArray[i - sqrt - 1].GetStatus())
                    {
                        aliveNeighbours++;
                    }
                    if (fieldArray[i - sqrt + 1].GetStatus())
                    {
                        aliveNeighbours++;
                    }
                    if (fieldArray[i + sqrt].GetStatus())
                    {
                        aliveNeighbours++;
                    }
                    if (fieldArray[i - sqrt - 1].GetStatus())
                    {
                        aliveNeighbours++;
                    }
                    if (fieldArray[i - sqrt + 1].GetStatus())
                    {
                        aliveNeighbours++;
                    }
                    if (fieldArray[i - 1].GetStatus())
                    {
                        aliveNeighbours++;
                    }
                    if (fieldArray[i + 1].GetStatus())
                    {
                        aliveNeighbours++;
                    }

                    
                    if (fieldArray[i].GetStatus())
                    {
                        if (aliveNeighbours != 2 || aliveNeighbours != 3)
                        {
                            fieldArray[i].SetAlive(false);
                        }
                        aliveNeighbours = 0;
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            fieldArray[i].SetAlive(true);
                        }
                        aliveNeighbours = 0;
                    }
                }
            }

            Utils.PrintFields(fieldArray);
        }
    }
}
