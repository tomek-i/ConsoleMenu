namespace TI.CMD.FX.Ansi.Interfaces
{
    public interface IAnsiColorMode //: IStringBuilder
    {
        //TODO: want to access it like this: "test".AddColor().Foreground.Red.Background.Cyan.Build()
        IAnsiColors Foregorund { get; }
        IAnsiColors Background { get; }

        string Reset();
    }
}