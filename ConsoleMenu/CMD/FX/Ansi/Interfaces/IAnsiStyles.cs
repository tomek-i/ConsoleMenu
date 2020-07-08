namespace TI.CMD.FX.Ansi.Interfaces
{
    public interface IAnsiStyles<T> where T: IAnsiStyles<T>
    {
        T Blink();
        T Bright();
        T Dim();
        T Reverse();
        T Underscore();
    }
}