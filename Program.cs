using System;
using System.Security.Cryptography;

namespace Lab4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string rerun = "";
            int diceSize = 0;
            int dice1;
            int dice2;

            Console.WriteLine("WELCOME TO THE DICE ROLLING SIMULATOR! ");

            diceSize = DiceSize(diceSize);

            do
            {
                dice1 = DiceRoll(diceSize);
                dice2 = DiceRoll(diceSize);

                RollCheck(dice1, dice2, diceSize);

                rerun = Rerun(rerun);
            }
            while (rerun == "y");
        }

        static int DiceRoll (int diceSize)
        {
            Random rnd = new Random();
            int diceRoll = rnd.Next(1, diceSize + 1);

            return diceRoll;
        }

        static int DiceSize(int diceSize)
        {
            bool worked;
            do
            {
                Console.Write("Please enter the amount of side you would like on the die: ");
                worked = int.TryParse(Console.ReadLine(), out diceSize);
                if (!worked)
                {
                    Console.WriteLine("Sorry, this is not a valid input. Please try again.");
                }
            } while (!worked);
            return diceSize;
        }
        static void RollCheck(int dice1, int dice2, int diceSize)
        {
            int rollTotal = dice1 + dice2;
            if (diceSize == 6)
            {
                if (dice1 == 1 && dice2 == 1)
                {
                    Console.WriteLine("**** You rolled snake eyes! Two 1's ****");
                }
                else if ((dice1 == 1 && dice2 == 2) || (dice2 == 1 && dice1 == 2))
                {
                    Console.WriteLine("**** You rolled Ace duce! 1 and 2 ****");
                }
                else if (dice1 == 6 && dice2 == 6)
                {
                    Console.WriteLine("**** You rolled Box Cars! Two 6's ****");
                }
                else
                {
                    Console.WriteLine($"The first roll is {dice1} and the second roll is {dice2}.");
                }
                Console.WriteLine($"The total of the dice are {rollTotal}");

                if (rollTotal == 2 || rollTotal == 3 || rollTotal == 12)
                {
                    Console.WriteLine("***** ACCORDING TO RULES I DONT UNDERSTAND THIS IS \n" +
                        "ALSO APPARENTLY A GOOD NUMBER FOR CRAPS! *****");
                }
                else if (rollTotal == 7 || rollTotal == 11)
                {
                    Console.WriteLine("***** YOU WIN!!!! *****");
                }

                Console.WriteLine("\n=====================================================");
            }
            else
            {
                Console.WriteLine($"The first roll is {dice1} and the second roll is {dice2}.");
                Console.WriteLine($"The total of the dice are {rollTotal}");
            }
        }
        static string Rerun (string rerun)
        {
            Console.WriteLine("Would you like to roll the dice again? y/n");
            rerun = Console.ReadLine();
            rerun = rerun.ToLower();

            while (rerun != "y" && rerun != "n")
            {
                Console.WriteLine("This is not a valid input. Would you like to continue: y/n");
                rerun = Console.ReadLine();
                rerun = rerun.ToLower();
            }
            return rerun;
        }

    }
}
