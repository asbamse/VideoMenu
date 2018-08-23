using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    /**
     * <summary>
     * Handles console parsing.
     * </summary>
     **/
    class ConsoleUtils
    {
        /**
         * Read an integer from console ReadLine();
         * Returns given integer.
         **/
        public int ReadInt()
        {
            int j;
            if (Int32.TryParse(Console.ReadLine(), out j))
            {
                return j;
            }
            else
            {
                Console.WriteLine("It can be an integer only!");
                return ReadInt();
            }
        }

        /**
         * Read an float from console ReadLine();
         * Returns given float.
         **/
        public float ReadFloat()
        {
            float j;
            if (float.TryParse(Console.ReadLine(), out j))
            {
                return j;
            }
            else
            {
                Console.WriteLine("It can be an float only!");
                return ReadFloat();
            }
        }
    }
}
