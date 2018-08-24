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
        private string name;
        private MenuItem[] menuItems;
        private bool isExit;

        public Menu(string name)
        {
            this.name = name;
            this.isExit = false;
        }

        /**
         * <summary>
         * Adds menu items to menu.
         * </summary>
         **/
        public void SetMenu(MenuItem[] menuItems)
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
            Console.WriteLine("{0}:", name);
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i+1, menuItems[i].Message);
            }

            while (!isExit)
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
                    chosenOne = ConsoleUtils.ReadInt("Choose a menu item: ") - 1;
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

        /**
         * <summary>
         * Exit menu.
         * </summary>
         **/
        public void Exit()
        {
            isExit = true;
        }
    }
}
