namespace TI.CMD.UI.Menu.Interfaces
{
    /// <summary>
    /// Common properties defining a item within a menu
    /// </summary>
    public interface IMenuItem
    {
        // TODO: a menu item could have child items
        // TODO: a menu item has a state like: selected, open/closed (if it has children

        /// <summary>
        /// This is used as a unique identifier for that menu item.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// The name of the menu item which will be also displayed.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A description or help on the menu item.
        /// </summary>
        string Description { get;  }




        /// <summary>
        /// The action to execute when executing the menu item.
        /// </summary>
        void Execute();
    }

}
