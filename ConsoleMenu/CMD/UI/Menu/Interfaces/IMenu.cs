using System.Collections.Generic;

namespace TI.CMD.UI.Menu.Interfaces
{

    
    public interface IConsoleMenu: IMenu
    {
        string QuitCode { get; }
        bool Quit { get; }
    }

    /// <summary>
    /// Common properties defining a Menu
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// The title of the menu eg. Main Menu
        /// </summary>
        string Title { get; }

        /// <summary>
        /// A list of menu item within that menu
        /// </summary>
        IReadOnlyList<IMenuItem> MenuItems { get; }

        /// <summary>
        /// Finds a menu item by its key or null.
        /// </summary>
        /// <param name="key">the key to search for</param>
        /// <returns>when found returns the single menu item or null</returns>
        IMenuItem FindMenuItem(string key);

        /// <summary>
        /// clears the menu list items.
        /// </summary>
        void ClearMenuItems();

        /// <summary>
        /// adds a new menu item to the list.
        /// </summary>
        /// <param name="item">the menu item to add to the list</param>
        void AddMenuItem(IMenuItem item);
    }
    
}
