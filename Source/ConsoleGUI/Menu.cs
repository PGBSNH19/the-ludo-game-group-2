using GameEngine.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGUI
{
    public class Menu
    {       
        public int NumbersOfPlayers()
        {
            Console.WriteLine($"Number of players");
            return int.Parse(Console.ReadLine());           
        }

        public List<User> CreateUser(int numberOfPlayers)
        {
            List<User> users= new List<User>();
            for(int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Please enter your name: ");
                var userName= Console.ReadLine();
                users.Add(new User(userName));                           
            }
            return users;
        }
    }
}
