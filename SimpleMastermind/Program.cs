using System;
using System.Linq;
using System.Text;

namespace SimpleMastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Mastermind Lite!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You will be playing as the CodeBreaker, enter player name:");
            string playerName = Console.ReadLine();

            // digits cannot be 0, 7, 8, 9
            var masterCode = new int[] { new Random().Next(1, 7), new Random().Next(1, 7), new Random().Next(1, 7), new Random().Next(1, 7) };
            Console.WriteLine("Full code is {0}", string.Join("", masterCode));

            var hasCodeBreakerWon = false;
            int numAttemptsTakenToWin = 0;
            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine($"Chance# {i + 1}. Please enter your 4-digit code guess:");
                Console.WriteLine("=======================================================" + Environment.NewLine);
                
                var guessCode = Console.ReadLine();
                var codeSegments = guessCode.ToList();
                var codeBreakerResponse = new int[] { Convert.ToInt32(codeSegments[0].ToString()), Convert.ToInt32(codeSegments[1].ToString()), Convert.ToInt32(codeSegments[2].ToString()), Convert.ToInt32(codeSegments[3].ToString()) };

                // analyze the code entered by the player
                var answer = PlayerCodeAnalyzer.GenerateAnswer(masterCode, codeBreakerResponse);
                Console.WriteLine(string.Join("", answer));
                if (answer.All(ch => ch == '+'))
                {
                    hasCodeBreakerWon = true;
                    numAttemptsTakenToWin = i + 1;
                    break;
                }

                
            }

            // print game results to the console
            PrintResults(hasCodeBreakerWon, playerName, masterCode, numAttemptsTakenToWin);

            Console.WriteLine("Press any key to exit the game.");
            Console.ReadKey();
        }

        private static void PrintResults(bool hasCodeBreakerWon, string playerName, int[] masterCode, int numAttemptsTakenToWin)
        {
            if (hasCodeBreakerWon)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Congratulations {playerName}! You cracked the mastermind code {string.Join("", masterCode)} in {numAttemptsTakenToWin} chances." + Environment.NewLine);
            }
            else
            {
                Console.WriteLine($"====================Master code is {string.Join("", masterCode)}=============================" + Environment.NewLine);
                Console.WriteLine($"Sorry {playerName}, you lost this time but don't give up. Try again you'll get there!");
                Console.WriteLine($"===========================================================================================" + Environment.NewLine);
            }
        }
    }
}
