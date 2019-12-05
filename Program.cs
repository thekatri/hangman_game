using System;
using System.IO;
using System.Text; 
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Hangman_Game
{
    class Program
    {
        static void Main(string[] args)
        {   
            Random random = new Random();

            string[] wordList = File.ReadAllLines(@"C:\Users\katri\Documents\Projects\Hangman Game\Hagman_Wordlist.txt");

            Random random1 = new Random(); 

            string wordToGuess = wordList[random.Next(0, wordList.Length)];
            string wordToGuessUpper = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                displayToPlayer.Append("_ ");

            }

            List<char> correctGuess = new List<char>();
            List<char> wrongGuess = new List<char>();

            int lives = 5; 
            bool win = false;
            int lettersRevealed = 0;

            string input; 
            char guess;
            Console.WriteLine(displayToPlayer);

            while(!win && lives > 0)
            {
                Console.WriteLine("Guess a letter");
                input = Console.ReadLine().ToUpper();
                guess = input[0];


                if(correctGuess.Contains(guess))
                {
                
                    Console.WriteLine("You already tried {0}", guess);
                }
                else if (wrongGuess.Contains(guess))
                {
                    Console.WriteLine("You already tried {0}", guess);
                }

                if(wordToGuessUpper.Contains(guess))
                {
                    correctGuess.Add(guess);

                    for(int i = 0; i < wordToGuess.Length; i++)
                    {
                        if(wordToGuessUpper[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }

                    }

                    if(lettersRevealed == wordToGuess.Length)
                    {
                        win = true; 
                    }
                }
                else 
                {
                    wrongGuess.Add(guess);

                    Console.WriteLine("{0} is not found in the word", guess);
                    lives --;

                }

                Console.WriteLine(displayToPlayer.ToString());

            }

            if(win)
            {
                Console.WriteLine("You won");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You lost, right answer was {0}", wordToGuess);
                Console.ReadLine();
            }


        }
    }
}
