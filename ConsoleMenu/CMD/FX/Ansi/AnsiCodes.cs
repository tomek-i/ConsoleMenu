namespace TI.CMD.FX.Ansi
{
    public static class AnsiCodes
    {
        public const string EscapeSequence = "\x1b[";

        public const string Reset = EscapeSequence + "0m";

        public const string Dim = EscapeSequence + "2m";

        public const string Blink = EscapeSequence + "5m";

        public const string Hidden = EscapeSequence + "8m";

        public static class Decorations
        {
            public const string Underline = EscapeSequence + "4m";
            public const string Bold = EscapeSequence + "1m";
            public const string Reversed = EscapeSequence + "7m";
        }

        public static class Colors
        {
            public const string ForegroundCode = EscapeSequence + "3";
            public const string BackgroundCode = EscapeSequence + "4";

            public const string Black = "0m";
            public const string Red = "1m";
            public const string Green = "2m";
            public const string Yellow = "3m";
            public const string Blue = "4m";
            public const string Magenta = "5m";
            public const string Cyan = "6m";
            public const string White = "7m";

            public static class Foreground
            {

                public const string Black = ForegroundCode + Colors.Black;
                public const string Red = ForegroundCode + Colors.Red;
                public const string Green = ForegroundCode + Colors.Green;
                public const string Yellow = ForegroundCode + Colors.Yellow;
                public const string Blue = ForegroundCode + Colors.Blue;
                public const string Magenta = ForegroundCode + Colors.Magenta;
                public const string Cyan = ForegroundCode + Colors.Cyan;
                public const string White = ForegroundCode + Colors.White;
            }
            public static class Background
            {
                public const string Black = BackgroundCode + Colors.Black;
                public const string Red = BackgroundCode + Colors.Red;
                public const string Green = BackgroundCode + Colors.Green;
                public const string Yellow = BackgroundCode + Colors.Yellow;
                public const string Blue = BackgroundCode + Colors.Blue;
                public const string Magenta = BackgroundCode + Colors.Magenta;
                public const string Cyan = BackgroundCode + Colors.Cyan;
                public const string White = BackgroundCode + Colors.White;
            }
        }

        public static class Cursor
        {

            /*
             * 
             * 
             * 
             * 
             Cursor Position:
                Moves the cursor to the specified position (coordinates).
                If you do not specify a position, the cursor moves to the home position 
                at the upper-left corner of the screen (line 0, column 0). 
                This escape sequence works the same way as the following Cursor Position escape sequence.
                \x1b[Line;ColumnH
                \x1b[Line;Columnf

            Up: \x1b[{n}A
          Down: \x1b[{n}B
         Right: \x1b[{n}C
          Left: \x1b[{n}D
                
                  

    
            */

        }
    }
}
