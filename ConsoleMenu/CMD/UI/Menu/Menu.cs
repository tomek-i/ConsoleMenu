using System.Collections.Generic;
using System.Linq;
using TI.CMD.UI.Menu.Interfaces;

namespace TI.CMD.UI.Menu
{

    public class Menu
    {
        public Menu(string title)
        {
            _menuItems = new Dictionary<string, IMenuItem>();

            Title = title;
        }

        public string Title { get; }

        public IDictionary<string, IMenuItem> _menuItems;
        public IReadOnlyList<IMenuItem> MenuItems => _menuItems.Values.ToList();

        public void AddMenuItem(IMenuItem item)
        {
            _menuItems.Add(item.Key, item);
        }

        public void ClearMenuItems()
        {
            _menuItems.Clear();
        }

        public IMenuItem FindMenuItem(string key)
        {
            var result = _menuItems.Where(item => item.Key == key).SingleOrDefault();
            return result.Value;
        }
    }

}
