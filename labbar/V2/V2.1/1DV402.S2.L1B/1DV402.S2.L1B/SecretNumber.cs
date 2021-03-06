﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1B
{
    public class SecretNumber
    {
        // MaxGuesses needed to be seven. Cant change it.
        public const int MaxNumberOfGuesses = 7;

        // Looping this.
        private bool _canMakeGuess;

        // Private int _number
        private int _number;

        // Array of guessednumbers.
        private int[] _guessedNumbers;


        // My SM method creating an new array. And init a method inside it.
        public SecretNumber()
        {
            _guessedNumbers = new int[7];

            Initialize();
        }
        // My integear variable Number that just return get set _number.
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

        // Enable if user can make a guess or not.
        public bool CanMakeGuess
        {
            get
            {
                if (Count >= MaxNumberOfGuesses || _canMakeGuess == false)
                { 
                    return false; 
                }

                else
                { 
                    return true; 
                }
            }
            private set
            {
                _canMakeGuess = value;
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

            // Doing a random guess number
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
            if (number < 1 || number > 100)
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

            // Puts it into the array.
            _guessedNumbers[Count] = number;

            Count++;

            // Ex: 23 correct guess type out correct guess. And jumping out of the do while loop
            if (number == Number)
            {
                Console.WriteLine(Strings.Guess_Correct, Count);

                CanMakeGuess = false;
                return true;
            }
            else
            {
                // If number to low writing out number to low.
                if (number < Number)
                {
                    Console.Write(Strings.Guess_Low, number);
                }
                else
                {
                    Console.Write(Strings.Guess_High, number);
                }
                // How many guesses left.
                Console.WriteLine(Strings.Guess_Left, GuessesLeft);
                return false;
            }
        }
    }
}
