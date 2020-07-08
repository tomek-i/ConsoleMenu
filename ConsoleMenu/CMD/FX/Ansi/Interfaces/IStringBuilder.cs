namespace TI.CMD.FX.Ansi.Interfaces
{
    //TODO: this probably should live somewhere under the root namespace, it is not bound under FX/ansi
    public interface IStringBuilder
    {
        string CurrentValue { get; }

        string Build();
    }
}