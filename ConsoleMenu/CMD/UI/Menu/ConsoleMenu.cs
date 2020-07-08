using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using TI.CMD.FX.Ansi;
using TI.CMD.FX.Ansi.Extensions;
using TI.CMD.UI.Menu.Interfaces;

namespace TI.CMD.UI.Menu
{


    public class ConsoleMenu : Menu, IConsoleMenu
    {


        private readonly Func<string> GetUserInput = Console.ReadLine;


        private readonly string TitleStyle = "".AddStyle().Underscore().CurrentValue;
        private readonly string KeyStyle = "".AddColor().Foregorund.RedColor().CurrentValue;

        public string QuitCode { get; set; } = "q";
        public string HelpCode { get; set; } = "h";

        public bool Quit { get; private set; }




        public ConsoleMenu(string title, Func<string> getUserInput = null) : base(title)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            if (getUserInput != null)
                GetUserInput = getUserInput;
        }



        public bool AnsiEnabled { get; set; } = true;

        private string Style(string style, string text)
        {

            return AnsiEnabled ? $"{style}{text}{ResetStyle()}" : $"{text}";
        }
        private string ResetStyle()
        {
            return AnsiCodes.Reset;
        }

        public void Show()
        {
            while (!Quit)
            {
                Clear();

                WriteLine($"{Style(TitleStyle, Title)}");
                WriteLine();
                if (MenuItems.Count > 0)
                {
                    WriteLine("Please select one of the following menu items: ");
                    WriteLine();
                    var length = MenuItems.Max(item => item.Key.Length);
                    foreach (IMenuItem item in MenuItems)
                    {
                        var key = item.Key.PadLeft(length);
                        WriteLine($"{Style(KeyStyle, key)}) {item.Name}");
                    }
                }
                else
                {
                    WriteLine("There are currently no menu items available.");
                }
                WriteLine();
                WriteLine($"type in '{Style(KeyStyle, QuitCode)}' to quit the application");

                var stylecode = "".AddColor().Foregorund.CyanColor().CurrentValue;

                Write($"Select menu: ");
                INVALIDENTRY:
                var input = GetInput(stylecode).ToLower();

                ClearLinesBelow();

                Write("".AddStyle().Reset());


                if (input == QuitCode.ToLower())
                {
                    Quit = true;
                }
                else if (input == HelpCode.ToLower())
                {
                    WriteLine();
                    WriteLine("HELP".AddUnderline());
                    WriteLine($"{Style(KeyStyle, HelpCode)}: will display this message");
                    WriteLine($"{Style(KeyStyle, QuitCode)}: will terminate the console application");
                    WriteLine($"{Style(KeyStyle, HelpCode)} {Style(KeyStyle, "<KEY>")}: Will show you some help/description about the menu item specified as <KEY>");
                    RestoreCursorPosition();


                    goto INVALIDENTRY;
                }
                else if (input.StartsWith("help ") && MenuItems.Any(item => item.Key.ToLower() == input.Split(" ")[1].Trim()))
                {
                    var selectedMenu = MenuItems.Where(item => item.Key.ToLower() == input.Split(" ")[1].Trim()).SingleOrDefault();
                    WriteLine();
                    WriteLine($"{selectedMenu.Name.AddUnderline()}");
                    WriteLine($"{selectedMenu.Description}");
                    RestoreCursorPosition();
                    goto INVALIDENTRY;
                }
                else if (MenuItems.Any(item => item.Key.ToLower() == input))
                {
                    var selectedMenu = MenuItems.Where(item => item.Key.ToLower() == input).SingleOrDefault();

                        Clear();
                        //TODO: if we are in a submenu, we should not wait for a readkey and print press any key, also quit message should be different
                        selectedMenu.Execute();
                        WriteLine();
                        WriteLine("press any key to continue");
                        Console.ReadKey(true);
                }
                else
                {

                    Write($"{"ERROR".AddColor().Background.RedColor().Foregorund.White()}: Your menu selection was invalid. Please select a valid menu item or type in '{Style(KeyStyle, HelpCode)}' to view the help.");
                    RestoreCursorPosition();
                    goto INVALIDENTRY;
                }
            }
        }

        protected virtual string GetInput(string message = "")
        {
            Write(message);
            ClearLine();
            CursorVisible(true);
            SaveCursorPosition();
            var result = GetUserInput.Invoke().Trim();
            CursorVisible(false);
            return result;
        }

        protected virtual void CursorVisible(bool visible)
        {
            Console.CursorVisible = visible;
        }

        protected virtual string GetClearLineCode()
        {
            return $"{AnsiCodes.EscapeSequence}K";
        }
        protected virtual void ClearLine()
        {
            Write(GetClearLineCode());
        }

        protected virtual void SaveCursorPosition()
        {
            Write($"{AnsiCodes.EscapeSequence}s");
        }
        protected virtual void RestoreCursorPosition()
        {
            Write($"{AnsiCodes.EscapeSequence}u");
        }
        protected virtual void Clear()
        {
            Console.Clear();
        }

        protected virtual void Write(string text = "")
        {
            Console.Write(text);
        }

        int currentLine = 0;
        int writtenLines = 0;
        protected void MoveCursorUp(int amount)
        {
            currentLine -= amount;
            Write($"{AnsiCodes.EscapeSequence}{amount}A");
        }
        protected void MoveCursorDown(int amount)
        {
            currentLine += amount;
            Write($"{AnsiCodes.EscapeSequence}{amount}B");
        }
        protected void ClearLinesBelow()
        {
            var linesToClear = writtenLines - Console.CursorTop;

            Console.CursorVisible = true;
            if (linesToClear > 0)
            {
                MoveCursorDown(linesToClear);
                for (int i = 0; i < linesToClear; i++)
                {
                    ClearLine();
                    MoveCursorUp(1);
                    writtenLines -= 1;
                }
            }
        }
        protected virtual void WriteLine(string text = "")
        {
            if (string.IsNullOrEmpty(text))
                text = GetClearLineCode();
            Write(text + Environment.NewLine);

            writtenLines++;
            currentLine = writtenLines;

        }
    }

}
