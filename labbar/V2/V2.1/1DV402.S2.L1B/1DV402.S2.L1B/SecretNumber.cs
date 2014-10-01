using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1B
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;
        private bool _canMakeGuess;
        private int _number;
        private int[] _guessedNumbers;

        public SecretNumber()
        {
            _guessedNumbers = new int[7];
        }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            { 
                _number = value; 
            }
        }
        public bool CanMakeGuess
        {
            get 
            {
                return false;
            }
            set
            {
                return;
            }

        }
        public int Count 
        { 
            get; 
            private set; 
        }

        // How many Guesses i have left - Count,
        public int GuessesLeft
        {
            get
            {
                return MaxNumberOfGuesses - Count;
            }
            set
            {
                return;
            }
        }

        // Init with no return path.
        public void Initialize()
        {
            // Creating zero, Clearing array
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);

            Random random = new Random();
            Number = random.Next(101);


            CanMakeGuess = true;

            Count = 0;
        }

        // In this class you can putin (try, catch Exceptions to)
        public bool MakeGuess(int number)
        {
            // More than 7 wrong answer.
            if (Count >= 7)
            {
                throw new ApplicationException();
            }
            // +1 -100
            if (number < 1 || number > 101)
            {
                throw new ArgumentOutOfRangeException();
            }
            // Foreach guesses in gNumbers, See if its already been used. 
            foreach (int guessedNumber in _guessedNumbers)
            {
                if (number == guessedNumber)
                {
                    Console.WriteLine(Strings.Guesses, number);
                        return false;
                }
            }
            _guessedNumbers[Count] = number;

            Count++;

            if (number == Number)
            {
                Console.WriteLine(Strings.Guess_Correct, Count);
            }
            else
            {
                if (number < Number)
                {
                    Console.Write(Strings.Guess_Low, number);
                }
                else
                {
                    Console.Write(Strings.Guess_High, number);
                }

                Console.WriteLine(Strings.Guess_Left, GuessesLeft);
                return false;
            }
            return true;
        }
    }
}
