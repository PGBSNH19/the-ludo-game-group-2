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
<<<<<<< Updated upstream
=======
        public bool HasReachedGoal { get; set; }
>>>>>>> Stashed changes

        public Pawn(int PawnID, int Position, string Color)
        {
            this.PawnID = PawnID;
            this.Position = Position;
<<<<<<< Updated upstream
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
            return userChoice switch
            {
                "1" => "Blue",
                "2" => "Green",
                "3" => "Red",
                "4" => "Yellow",
                _ => "Gold"
            };
        }

        public static void SetStartPosition(Pawn pawn)
        {
            pawn.Position = pawn.Color switch
            {
                "Red" => 0,
                "Yellow" => 10,
                "Green" => 20,
                "Blue" => 30,
                 _=> 0
            };
        }

        public static void IfNotStartedSetStartPosition(Pawn pawn)
        {
            if (pawn.HasStarted == false)
            {
                Pawn.SetStartPosition(pawn);
                pawn.HasStarted = true;
            }
        }
=======
            this.Color = Color;
            this.HasReachedGoal = false;
        }


>>>>>>> Stashed changes
    }
}
