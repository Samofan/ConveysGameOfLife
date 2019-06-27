using System;

namespace GameOfLife
{
    class Utils
    {
        //******************************************
        //Displays the '#' on the console
        //******************************************
        public static void PrintFields(Field[] fieldArray)
        {
            int rowsAndCols = RowsAndCols(fieldArray.Length);
            int counter = 0;

            for (int y = 0; y < rowsAndCols; y++)
            {
                for (int i = 0; i < rowsAndCols; i++)
                {
                    WriteInColor(fieldArray[counter].GetStatus());
                    counter++;
                }
                Console.Write("\n");
            }

            counter = 0;
        }

        //******************************************
        //Colors the '#'
        //******************************************
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

        //******************************************
        //returns the value how much rows are displayed 
        //******************************************
        private static int RowsAndCols(double length)
        {
            double square = Math.Sqrt(length);
            int squareInt = Convert.ToInt32(square);

            return squareInt;
        }

        //******************************************
        //Starts a new round 
        //******************************************
        public static void NextRound(Field[] fieldArray)
        {
            int sqrt = Convert.ToInt32(Math.Sqrt(fieldArray.Length));

            //go through every cell
            for (int i = 0; i < fieldArray.Length; i++)
            {
                //get the amount of living neighbours
                int aliveNeighbours = GetAliveNeigbours(i, fieldArray, sqrt);

                //if the cell is alive
                if (fieldArray[i].GetStatus())
                {
                    if (aliveNeighbours == 2 || aliveNeighbours == 3)
                    {
                        fieldArray[i].SetAlive(true);
                    }
                    else
                    {
                        fieldArray[i].SetAlive(false);
                    }
                }
                else
                {
                    if (aliveNeighbours == 3)
                    {
                        fieldArray[i].SetAlive(true);
                    }
                    else
                    {
                        fieldArray[i].SetAlive(false);
                    }
                }
            }

            //hab das Gefühl, dass immer mit dem ersten Array gerechnet wird... Deswegen hier die aktualisierung aber es
            //funktioniert immer noch nicht
            Field.fieldArray = fieldArray;
            Console.Clear();

            if (IsGameOver(fieldArray) > 0)
            {
                PrintFields(fieldArray);
            }
            else
            {
                Program.timer.Stop();
                PrintGameOver();
            }
            
        }

        private static void PrintGameOver()
        {
            String gameOver =
                @"                     *              )               (     " + "\n" + 
                @"   (        (      (  `          ( /(               )\ )  " + "\n" +
                @"   )\ )     )\     )\))(   (     )\()) (   (   (   (()/(  " + "\n" +
                @"  (()/(  ((((_)(  ((_)()\  )\   ((_)\  )\  )\  )\   /(_)) " + "\n" +
                @"   /(_))_ )\ _ )\ (_()((_)((_)    ((_)((_)((_)((_) (_))   " + "\n" +
                @"  (_)) __|(_)_\(_)|  \/  || __|  / _ \\ \ / / | __|| _ \  " + "\n" +
                @"    | (_ | / _ \  | |\/| || _|  | (_) |\ V /  | _| |   /  " + "\n" +
                @"     \___|/_/ \_\ |_|  |_||___|  \___/  \_/   |___||_|_\  " + "\n" +
                @"                                                          ";

            String gameOverPlain = "Game Over";

            Console.WriteLine(gameOverPlain);
        }

        //******************************************
        //Checks wether the neighbour exists and if it´s alive
        //******************************************
        private static int GetAliveNeigbours(int i, Field[] fieldArray, int sqrt)
        {
            int aliveNeighbours = 0;

            if (i - sqrt >= 0)
            {
                if (fieldArray[i - sqrt].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            if (i - sqrt - 1 >= 0)
            {
                if (fieldArray[i - sqrt - 1].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            if (i - sqrt + 1 > 0)
            {
                if (fieldArray[i - sqrt + 1].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            if (i + sqrt < fieldArray.Length)
            {
                if (fieldArray[i + sqrt].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            if (i - sqrt - 1 > 0)
            {
                if (fieldArray[i - sqrt - 1].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            if (i - sqrt + 1 > 0)
            {
                if (fieldArray[i - sqrt + 1].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            if (i - 1 > 0)
            {
                if (fieldArray[i - 1].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            if (i + 1 < fieldArray.Length)
            {
                if (fieldArray[i + 1].GetStatus())
                {
                    aliveNeighbours++;
                }
            }

            return aliveNeighbours;
        }

        //******************************************
        //Checks if there are any cells alive
        //******************************************
        private static int IsGameOver(Field[] fieldArray)
        {
            int aliveCells = 0;

            for (int i = 0; i < fieldArray.Length; i++)
            {
                if (fieldArray[i].GetStatus())
                {
                    aliveCells++;
                }
            }

            return aliveCells;
        }
    }
}
