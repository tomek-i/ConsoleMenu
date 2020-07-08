using TI.CMD.FX.Ansi.Interfaces;

namespace TI.CMD.FX.Ansi.Builder
{
    public class AnsiStringStyleBuilder : IAnsiStyleBuilder
    {
        public string CurrentValue { get; private set; }

        public AnsiStringStyleBuilder(string text)
        {
            CurrentValue = text;
        }

        public IAnsiStyleBuilder Underscore()
        {
            CurrentValue = $"{AnsiCodes.Decorations.Underline}{CurrentValue}";

            return this;
        }
        public IAnsiStyleBuilder Reverse()
        {
            CurrentValue = $"{AnsiCodes.Decorations.Reversed}{CurrentValue}";

            return this;
        }
        public IAnsiStyleBuilder Bright()
        {
            CurrentValue = $"{AnsiCodes.Decorations.Bold}{CurrentValue}";

            return this;
        }
        public IAnsiStyleBuilder Dim()
        {
            CurrentValue = $"{AnsiCodes.Dim}{CurrentValue}";

            return this;
        }
        public IAnsiStyleBuilder Blink()
        {
            CurrentValue = $"{AnsiCodes.Blink}{CurrentValue}";

            return this;
        }

        public string Reset()
        {
            return AnsiCodes.Reset;
        }

        public string Build()
        {
            return CurrentValue + Reset();
        }
    }
}
