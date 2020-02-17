using System;

using BerlinClock.Abstraction;
using BerlinClock.Classes;

namespace BerlinClock.ConsoleOutput
{
    /// <summary>
    /// Very basic console visualizer for Berlin Clock for visual tests
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ITimeConverter timeConverter = new TimeConverter(new TextClockRenderer(), new ClockBuilder(new TimeParser()));
            while (Console.KeyAvailable == false)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.CursorVisible = false;
                String currentTimeText = timeConverter.ConvertTime(DateTime.Now.ToString("HH:mm:ss"));
                String[] splittedTime = currentTimeText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string time in splittedTime)
                {
                    foreach(Char bulb in time)
                    {
                        ConsoleColor bulbColor = ConsoleColor.White;
                        switch(bulb)
                        {
                            case 'Y':
                                bulbColor = ConsoleColor.Yellow;
                                break;
                            case 'R':
                                bulbColor = ConsoleColor.Red;
                                break;
                            case 'O':
                                bulbColor = ConsoleColor.Black;
                                break;
                        }
                        Console.BackgroundColor = bulbColor;
                        Console.Write(' ');
                    }
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
