using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    class Program
    {
        public static Timer timer;

        static void Main(string[] args)
        {
            Field[] fieldArray = Field.GenerateFields(841);
            Field.fieldArray = fieldArray;
            Utils.PrintFields(fieldArray);
            SetTimer();
            timer.Start();
            Console.ReadKey();
        }

        private static void SetTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled =  true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {

            Utils.NextRound(Field.fieldArray);
        }
    }
}
