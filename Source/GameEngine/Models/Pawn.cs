using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Library.Models
{
    public class Pawn
    {
        public int PawnID { get; set; }
        public int Position { get; set; }
        public string Color { get; set; }
        public bool HasStarted { get; set; }
        public int Count { get; set; }

        public GameBoard GameBoard { get; set; }
        //public int SquareID { get; set; }
        //public int UserID { get; set; }
              
        public Pawn(int PawnID, int Position, string Color)
        {
            this.PawnID = PawnID;
            this.Position = Position;
            this.Color = Color;        
        }

        public static List<Pawn> GetSetOfPawns()
        {
            ShowPawnColorMenu();

            var color = SetColorOnPawn(Console.ReadLine());
            List<Pawn> pawns = new List<Pawn>();
            for (int i = 1; i <= 4; i++)
            {                             
                    var pawn = new Pawn(i, default, color);
                    pawns.Add(pawn);            
            }
            return pawns;
        }

        private static void ShowPawnColorMenu()
        {
            Console.WriteLine();
            Console.WriteLine($"1. Blue");
            Console.WriteLine($"2. Green");
            Console.WriteLine($"3. Red");
            Console.WriteLine($"4. Yellow");
            Console.WriteLine();
        }

        private static string SetColorOnPawn(string userChoice)
        {

            switch (userChoice)
            {
                case "1":
                    return "Blue";

                case "2":
                    return "Green";

                case "3":
                    return "Red";

                case "4":
                    return "Yellow";

                default:
                    break;
            }

            return "Gold";
        }

        public void SetStartPosition(Pawn pawn)
        {
            if (pawn.Color == "Red")
                pawn.Position = 0; 
            if (pawn.Color == "Yellow")
                pawn.Position = 10;
            if (pawn.Color == "Green")
                pawn.Position = 20;
            if (pawn.Color == "Blue")
                pawn.Position = 30;

            //pawn.HasStarted = true;
        }
    }
}
