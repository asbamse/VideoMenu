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
    static class ConsoleUtils
    {
        /**
         * Read a string which is not empty from console ReadLine();
         * Returns given string.
         **/
        public static string ReadNotEmpty()
        {
            return ReadNotEmpty("");
        }

        public static string ReadNotEmpty(string message)
        {
            Console.Write(message);

            string str = Console.ReadLine();
            if(str.Length > 0)
            {
                return str;
            }
            else
            {
                Console.WriteLine("It cannot be empty!");
                return ReadNotEmpty(message);
            }
        }

        /**
         * Read an integer from console ReadLine();
         * Returns given integer.
         **/
        public static int ReadInt()
        {
            return ReadInt("");
        }
        public static int ReadInt(string message)
        {
            Console.Write(message);

            int j;
            if (Int32.TryParse(Console.ReadLine(), out j))
            {
                return j;
            }
            else
            {
                Console.WriteLine("It can be an integer only!");
                return ReadInt(message);
            }
        }

        /**
         * Read an float from console ReadLine();
         * Returns given float.
         **/
        public static float ReadFloat()
        {
            return ReadFloat("");
        }
        public static float ReadFloat(string message)
        {
            Console.Write(message);

            float j;
            if (float.TryParse(Console.ReadLine(), out j))
            {
                return j;
            }
            else
            {
                Console.WriteLine("It can be an float only!");
                return ReadFloat(message);
            }
        }
    }
}
