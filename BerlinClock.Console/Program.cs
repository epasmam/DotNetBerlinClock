using BerlinClock.Abstraction;
using System;

namespace BerlinClock.ConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            ITimeConverter timeConverter = new BerlinClock.TimeConverter(new BerlinClock.Classes.TextClockRenderer());
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
