using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class User
    {

    }
    class Program
    {
        static void Main(string[] args) {
            int hits = 0;   // how many ship hits
            int diff = 0;   // the difficulty level
            int att = 0;   // the player moves/attempts
            bool play = true;  // bool for loop to play again

            while (play == true)  // bool while for play again/play
            {
                string[,] pmap = new string[11, 11] {  // player map for tracking
                {"  ", " A", " B", " C", " D", " E", " F", " G", " H", " I", " J" },
                {" 1", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 2", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 3", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 4", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 5", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 6", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 7", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 8", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 9", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {"10", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                };
                string[,] smap = new string[11, 11] {  // static ship map
                {"  ", " A", " B", " C", " D", " E", " F", " G", " H", " I", " J" },
                {" 1", "  ", " S", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 2", "  ", " S", "  ", "  ", "  ", "  ", "  ", " S", "  ", "  " },
                {" 3", "  ", "  ", "  ", "  ", "  ", "  ", "  ", " S", "  ", "  " },
                {" 4", "  ", "  ", "  ", "  ", "  ", "  ", "  ", " S", "  ", "  " },
                {" 5", "  ", "  ", " S", " S", " S", "  ", "  ", " S", "  ", "  " },
                {" 6", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 7", "  ", " S", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {" 8", "  ", " S", "  ", "  ", "  ", " S", " S", " S", " S", " S" },
                {" 9", "  ", " S", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                {"10", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  " },
                };
                welcome(ref diff);  // Calls to welcome method for opening and difficulty setting
                hits = move(pmap, smap, att, diff, hits);  // calls to move method for game play and returns hits if need be
                if (hits == 17) {  // if loop for win-lose output
                    Console.WriteLine("You Win!");
                    Console.WriteLine("Thanks for playing Battleship! Your final score was {0}", ((100 - att) + (hits + 25)));
                }
                else {
                    Console.WriteLine("You Lose!");
                    Console.WriteLine("Thanks for playing Battleship! Your final score is 0");
                }
                Console.WriteLine("To Continue Enter P");  // play again functinality after completion
                char cont = char.Parse(Console.ReadLine());  
                if ((cont.Equals ('P')) || (cont.Equals ('p'))) {
                    play = true;
                }
                else {
                    play = false;
                }
                Console.Clear();
            }
        }

        static void welcome(ref int diff) {  // method to determin difficulty and introduce program
            Console.WriteLine("          Welcome to Battleship:");
            Console.WriteLine();
            Console.WriteLine(@"              |    |    |");
            Console.WriteLine(@"             )_)  )_)  )_)");
            Console.WriteLine(@"            )___))___))___)\");
            Console.WriteLine(@"           )____)____)_____)\\");
            Console.WriteLine(@"         _____|____|____|____\\\__");
            Console.WriteLine(@"         \                   /");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"  ^^^^^ ^^^^^^^^^^^^^^^^^^^^^   ^^^^");
            Console.WriteLine(@"    ^^^^      ^^^^     ^^^    ^^");
            Console.WriteLine(@"         ^^^^      ^^^");
            Console.ResetColor();
            Console.WriteLine("Please Select A Difficulty (1-3) and press enter:\n 1. Easy\n 2. Normal\n 3. Brutal");
            diff = int.Parse(Console.ReadLine());
            if (diff == 1) {  // if loop to set difficulty for 3 different levels 90, 75, 50
                diff = 90;
            }
            else if (diff == 2) {
                diff = 75;
            }
            else {
                diff = 50;
            }
            Console.Clear();
        }

        static void pmapdraw(string[,]pmap)  // method to handle board draw each turn
        {
            for (int r = 0; r < pmap.GetLength(1); r++)  // for each row
            {
                for (int c = 0; c < pmap.GetLength(0); c++)  // for each col
                {
                    Console.Write(pmap[r, c]);  // write element col
                }

                Console.WriteLine();
            }
        }

        static int move(string[,] pmap, string[,] smap, int att, int diff, int hits)
        {  // Game play method
            do
            {
                Console.Clear();
                Console.WriteLine(" ------Battleship------");
                pmapdraw(pmap);  // draws map from pmap method
                Console.WriteLine(" -----Score is {0}-----", ((100 - att) + hits));  // writes current score below board
                Console.WriteLine("\nPlease enter a letter between A-J:");
                char c = char.Parse(Console.ReadLine());  // collects a char for col selection
                int cc = c % 32;  // converts from ltr to num based on hex
                Console.WriteLine("Please enter a number between 1-10:");
                int r = int.Parse(Console.ReadLine()); // collects row
                att++;  // adds to user attempts
                if (smap[r, cc] == " S")  // if element on ship map is a hit
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("It's a Hit! Press Enter to Continue.");
                    hits++;  // add to hit value
                    pmap[r, cc] = " *";  // change player map to show hit
                    Console.ReadKey(); Console.ResetColor();
                }
                else  // if element on shipmap is a miss
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Miss! Press Enter to Continue.");
                    pmap[r, cc] = " M";  // add miss to player map
                    Console.ReadKey(); Console.ResetColor();
                }
            } while (hits != 17 & att != diff);
            return hits;
        } 
    }
}
