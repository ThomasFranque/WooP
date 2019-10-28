using System;
using System.Collections.Generic;
using System.Text;

namespace WoopWoop
{
    public static class UserInterface
    {
        public static string GetStringInput()
            => Console.ReadLine();

        public static int GetByteInput()
        {
            int intToReturn = 0;
            string input = "";
            bool success = false;


            while (!success)
            {
                input = Console.ReadLine();
                success = int.TryParse(input, out intToReturn);
                if (!success) ShowInputErrorMsg("number");
            }

            return intToReturn;
        }

        private static void ShowInputErrorMsg(string varType)
        {
            Console.WriteLine($"Please input a valid {varType}.");
        }
    }
}
