using System;

namespace ConsoleGUI
{
    public static class Menu
    {
        public static int HowManyPlayers()
        {
            Console.WriteLine($"Number of players:");
            var amount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return amount;
        }

        public static string DisplayMessageReturnUserInput(string message)
        {
            Console.WriteLine(message);
            var output = Console.ReadLine();
            
            return output;
        }

        public static int DisplayMessageReturnInt(string message)
        {
            Console.WriteLine(message);

            bool isValid = false;
            int num;

            while (isValid == false)
            {
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out num))
                {
                    isValid = true;
                    return num;
                }
                else
                {
                    Console.WriteLine("Not a number, try again: ");
                }
            }
            return default;
        }
    }
}
