namespace TI.CMD.FX.Ansi.Interfaces
{
    public interface IAnsiStyleBuilder: IAnsiStyles<IAnsiStyleBuilder>, IStringBuilder
    {
        string Reset();
    }
}