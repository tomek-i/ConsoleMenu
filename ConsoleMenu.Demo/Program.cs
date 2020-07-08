using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TI.CMD.FX.Ansi;
using TI.CMD.UI.Menu;
using TI.CMD.UI.Menu.MenuItems;

namespace ConsoleMenuDemo
{
    class Program
    {
        public static void Echo()
        {
            Console.WriteLine("Hello World");
        }

        static void Main()
        {
            Console.CursorVisible = false;

            ConsoleMenu menu = new ConsoleMenu("Main Menu") { QuitCode = "quit", HelpCode = "help" };
            ConsoleMenu submenu = new ConsoleMenu("Sub Menu", () => Console.ReadKey().KeyChar.ToString());

            submenu.AddMenuItem(new ActionMenuItem("e", "Echo", "print hello world", () => Console.WriteLine("Hello World")));
            menu.AddMenuItem(new ActionMenuItem("test", "Hello World", "It will simply print 'Hello World' in the console.", Echo));
            menu.AddMenuItem(new ActionMenuItem("m", "Submenu Test", "Even a menu within a menu is working ☻.", submenu.Show));

            menu.AddMenuItem(new ActionMenuItem(
                "r",
                "Show me a Rainbow",
                "Displays the color pallettes for the Foreground and Background colors.", () =>
                {
                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            int code = i * 16 + j;
                            Console.Write($"{AnsiCodes.EscapeSequence}38;5;{code}m" + code.ToString().PadLeft(4));
                        }

                    }
                    Console.WriteLine();
                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            int code = i * 16 + j;
                            Console.Write($"{AnsiCodes.EscapeSequence}48;5;{code}m" + code.ToString().PadLeft(4));

                        }
                    }
                    Console.WriteLine();
                    Console.Write(AnsiCodes.Reset);

                }
                ));
       
            menu.AddMenuItem(new ActionMenuItem(
                "l",
                "Loading Animation",
                "Showcasing some loading animations done with ansi codes.", () =>
                {
                    Console.CursorVisible = false;
                    Console.WriteLine("Loading...");

                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(0.01));
                        Console.Write($"{AnsiCodes.EscapeSequence}4D{i + 1}%"); //keeps moving 4 to the left
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("press any key for the next animation");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("Loading...");
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(0.01));
                        var width = (i + 1) / 4;
                        var bar = $"[{new string('■', width)}{new string(' ', 25 - width)}]";
                        Console.Write($"{AnsiCodes.EscapeSequence}1000D{bar}");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("press any key for the next animation");
                    Console.ReadKey(true);
                    Console.Clear();
                    int amount = 4;
                    Console.WriteLine($"Loading {amount} ...");
                    for (int i = 0; i < amount; i++)
                    {
                        Console.WriteLine();
                    }
                    var all_progress = new int[amount];
                    Random r = new Random();
                    while (all_progress.Any(x => x < 100))
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(0.01));
                        var randomIndex = r.Next(0, amount);
                        all_progress[randomIndex] += 1;
                        if (all_progress[randomIndex] > 100)
                            all_progress[randomIndex] = 100;
                        Console.Write($"{AnsiCodes.EscapeSequence}1000D"); // Move left
                        Console.Write($"{AnsiCodes.EscapeSequence}{amount}A"); // Move up

                        foreach (var progress in all_progress)
                        {
                            var width = progress / 4;
                            var bar = $"[{new string('■', width)}{new string(' ', 25 - width)}]";
                            Console.WriteLine(bar);
                        }
                    }


                    Console.Write(AnsiCodes.Reset);
                }
                ));


            menu.AddMenuItem(new ActionMenuItem(
               "s",
               "Show me some Symbols ==> ฿",
               "Yeah.", () =>
               {
                   Console.OutputEncoding = Encoding.Unicode;
                   var dim = (Console.WindowHeight * Console.WindowWidth) / 2;

                   for (int i = 0; i <= 16 * 16 *16*8; i++)
                   {

                       Console.Write($"{(char)i} ");
                       Thread.Sleep(1);
                       if (i % dim == 0)
                       {
                           if (i != 0)
                               Thread.Sleep(1000);
                           Console.Clear();

                       }
                   }

                   Console.Write(AnsiCodes.Reset);
               }
               ));

            menu.Show();


        }



        public static IEnumerable<int> GetAllWritableCodepoints(Encoding encoding)
        {
            encoding = Encoding.GetEncoding(encoding.WebName, new EncoderExceptionFallback(), new DecoderExceptionFallback());

            var i = -1;
            // Docs for char.ConvertFromUtf32() say that 0x10ffff is the maximum code point value.
            while (i != 0x10ffff)
            {
                i++;

                var success = false;
                try
                {
                    encoding.GetByteCount(char.ConvertFromUtf32(i));
                    success = true;
                }
                catch (ArgumentException)
                {
                }
                if (success)
                {
                    yield return i;
                }
            }
        }
    }
}
