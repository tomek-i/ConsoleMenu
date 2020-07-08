using System;

namespace TI.CMD.UI.Menu.MenuItems
{
    public class ActionMenuItem : MenuItemBase
    {
        private Action Action { get; }
        public ActionMenuItem(string key, string name, string description, Action action):base(key,name,description)
        {
            Action = action;
        }

        public override void Execute()
        {
            Action.Invoke();
        }
    }

}
