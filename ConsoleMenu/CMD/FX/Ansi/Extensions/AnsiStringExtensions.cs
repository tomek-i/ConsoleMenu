
using TI.CMD.FX.Ansi.Builder;
using TI.CMD.FX.Ansi.Interfaces;

namespace TI.CMD.FX.Ansi.Extensions
{
    public static class AnsiStringExtensions
    {
        public static IAnsiStyleBuilder AddStyle(this string text)
        {
            return new AnsiStringStyleBuilder(text);
        }
        public static IAnsiColorBuilder AddColor(this string text)
        {
            return new AnsiStringColorBuilder(text);
        }



        //below short hand codes
        public static string AddUnderline(this string text)
        {
            return new AnsiStringStyleBuilder(text).Underscore().Build();
        }

        
    }
}
