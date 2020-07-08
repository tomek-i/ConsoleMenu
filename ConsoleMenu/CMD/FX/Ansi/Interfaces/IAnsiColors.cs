namespace TI.CMD.FX.Ansi.Interfaces
{
    public interface IAnsiColors
    {
        string Black();
        string Red();
        string Green();
        string Yellow();
        string Blue();
        string Magenta();
        string Cyan();
        string White();


        IAnsiColorBuilder BlackColor();
        IAnsiColorBuilder RedColor();
        IAnsiColorBuilder GreenColor();
        IAnsiColorBuilder YellowColor();
        IAnsiColorBuilder BlueColor();
        IAnsiColorBuilder MagentaColor();
        IAnsiColorBuilder CyanColor();
        IAnsiColorBuilder WhiteColor();

    }
}