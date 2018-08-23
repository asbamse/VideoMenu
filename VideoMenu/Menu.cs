using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    /**
     * <summary>
     * Menu in console.
     * </summary>
     **/
    class Menu
    {
        private ConsoleUtils cu = new ConsoleUtils();
        private MenuItem[] menuItems;

        /**
         * <summary>
         * Adds menu items to menu.
         * </summary>
         **/
        public void setMenu(MenuItem[] menuItems)
        {
            this.menuItems = menuItems;
        }

        /**
         * <summary>
         * Shows menu.
         * </summary>
         **/
        public void Show()
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i+1, menuItems[i].Message);
            }

            while (true)
            {
                ReadChosenItem();
            }
        }

        /**
         * <summary>
         * Reads user input and what item they choose.
         * </summary>
         **/
        private void ReadChosenItem()
        {
            if (menuItems.Length > 0)
            {

                int chosenOne;
                while (true)
                {
                    Console.Write("Choose a menu item: ");
                    chosenOne = cu.ReadInt() - 1;
                    if (chosenOne < menuItems.Length && chosenOne >= 0)
                    {
                        break;
                    }
                    Console.WriteLine("The chosen item has to be between 1 and {0}", menuItems.Length);
                }

                menuItems[chosenOne].Run();
            }
            else
            {
                Console.WriteLine("The menu is empty!");
            }
        }
    }
}
