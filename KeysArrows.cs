using System.Diagnostics;
using FullInfoN;
using TaskManagerN;

namespace ArrowName
{
    public class Arrows
    {
        internal enum keys
        {
            key_D = 1,
            key_Del = 9
        }
        public static int max;
        public static int min;
        public Arrows(int _min, int _max)
        {
            max = _max;
            min = _min;
        }
    
        public void ShowArrow(int leftstep, int mincoord, int step, string selector, Process[] procarr)
        {
            // TaskManager.ShowAllProcesses();
            int coord = mincoord;
            // List<string> dirs = _dirs;
            int counter = 0;
            while (true)
            {
                
                Console.SetCursorPosition(leftstep, coord);
                Console.WriteLine(selector);
                ConsoleKeyInfo key = Console.ReadKey();
                if (coord == 0)
                {
                    counter = 0;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (coord - step >= min)
                    {
                        Console.SetCursorPosition(leftstep, coord);
                        Console.WriteLine(" ");
                        coord -= step;
                        counter += 1;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (coord + step < max)
                    {
                        Console.SetCursorPosition(leftstep, coord);
                        Console.WriteLine(" ");
                        coord += step;
                        if (counter - 1 > 0)
                        {
                            counter -= 1;
                        }

                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    FullInfo.ShowFullInfo(procarr[counter]);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        public static void KeyProcess(Process proc)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if ((int)key.Key == (int)keys.key_D)
            {
                TaskManager.ShowAllProcesses();
                proc.Kill();

            }
            else if ((int)key.Key == (int)keys.key_Del)
            {
                TaskManager.ShowAllProcesses();
                proc.Kill(true);
            }
        }
    }
}