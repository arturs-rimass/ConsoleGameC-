using System;
using System.Collections.Generic;
using System.Linq;
namespace Game
{
    class WordGuesser
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game guesser!");
            Console.WriteLine("Choose the topic:");
            Console.WriteLine("1 - Car Brands");
            Console.WriteLine("2 - Phone Brands");
            int hintsLeft = 5;
            string randomWord;
            if (TopicChooser() == 1)
            {
                randomWord = Cars();
            }
            else
            {
                randomWord = Phones();
            }
            while (hintsLeft > 0)
            {
                Console.WriteLine("\nHints left: " + hintsLeft);
                int hintType = HintChooser();
                switch (hintType)
                {
                    case 1:
                        GuessTheWholeWord(randomWord);
                        break;
                    case 2:
                        WordLength(randomWord, hintsLeft);
                        break;
                    case 3:
                        GuessTheLetter(randomWord, hintsLeft);
                        break;
                    case 4:
                        RandomLetter(randomWord, hintsLeft);
                        break;
                    case 5:
                        FirstLetter(randomWord, hintsLeft);
                        break;
                    case 6:
                        LastLetter(randomWord, hintsLeft);
                        break;
                    case 7:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                }
            }
            Console.WriteLine("You lost, sorry...");
            Console.WriteLine("The correct word was " + randomWord);
        }
        public static int TopicChooser()
        {
            int number;
            bool isValid = false;
            do
            {
                Console.Write("Enter number between 1 and 2: ");
                isValid = int.TryParse(Console.ReadLine(), out number)
                              && number > 0
                              && number < 3;
            }
            while (!isValid);
            return number;
        }
        public static int HintChooser()
        {
            Console.WriteLine("Choose a hint:");
            Console.WriteLine("1 - Guess the word");
            Console.WriteLine("2 - Find out the total amount of characters in the word");
            Console.WriteLine("3 - Find out if the word contains the specific letter");
            Console.WriteLine("4 - Open one letter from the word");
            Console.WriteLine("5 - Find out the first letter of the word");
            Console.WriteLine("6 - Find out the last letter of the word");
            Console.WriteLine("7 - Exit");
            int number;
            bool isValid = false;
            do
            {
                Console.Write("Enter number between 1 and 7: ");
                isValid = int.TryParse(Console.ReadLine(), out number)
                              && number > 0
                              && number < 8;
            }
            while (!isValid);
            return number;
        }
        public static string Cars()
        {
            IList<string> stringList = new List<string>() { "Audi", "BMW", "Toyota", "Tesla", "Mazda", "Volksvagen", "Honda", "Hyundai", "Subaru" };
            var rnd = new Random();
            return stringList[rnd.Next(stringList.Count)];
        }
        public static string Phones()
        {
            IList<string> stringList = new List<string>() { "Apple", "Samsung", "Huawei", "Xiaomi", "LG" };
            var rnd = new Random();
            return stringList[rnd.Next(stringList.Count)];
        }

        public static void GuessTheWholeWord(string randomWord)
        {
            string guess;
            guess = Console.ReadLine();
            if (guess == randomWord)
            {
                Console.WriteLine("You are the winner! Thank you for participating!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("You lost, sorry...");
                Console.WriteLine("The correct word was " + randomWord);
                Environment.Exit(0);
            }
        }

        public static void WordLength(string randomWord, int hintsLeft)
        {
            Console.WriteLine(randomWord.Count(x => x == '?'));
            hintsLeft--;
        }

        public static void GuessTheLetter(string randomWord, int hintsLeft)
        {
            char inputChar = Console.ReadKey().KeyChar;
            if (randomWord.Contains(inputChar))
            {
                Console.WriteLine("\nThere is a " + inputChar + " in the word!");
            }
            else
            {
                Console.WriteLine("\n404 Not Found");
            }
            hintsLeft--;
        }
        public static void RandomLetter(string randomWord, int hintsLeft)
        {
            var rnd = new Random();
            Console.WriteLine("Random letter from the word is " + randomWord[rnd.Next(randomWord.Length - 1)]);
            hintsLeft--;
        }

        public static void FirstLetter(string randomWord, int hintsLeft)
        {
            Console.WriteLine(randomWord.First());
            hintsLeft--;
        }

        public static void LastLetter(string randomWord, int hintsLeft)
        {
            Console.WriteLine(randomWord.Last());
            hintsLeft--;
        }
    }
}
