using TI.CMD.UI.Menu.Interfaces;

namespace TI.CMD.UI.Menu.MenuItems
{
    public abstract class MenuItemBase : IMenuItem
    {
        public MenuItemBase(string key, string name, string description)
        {
            Key = key;
            Name = name;
            Description = description;
        }
        public string Key { get; }

        public string Name { get; }

        public string Description { get; }

        public abstract void Execute();
        
    }

}
