using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace guess_the_secret_throw
{
    public class secret
    {
        public int _faceValue;

        public int Throw()
        {
            Random mRandom = new Random();
            _faceValue = mRandom.Next(1, 7);

            return _faceValue;
        }

    }

    public class SecretNumber
    {
        public const int MaxNumber = 7;

        private my_Guessed_Number[] _guessedNumbers;
        private int? _number;

        public bool MakeGuess
        {
            get
            { 
                return Outcome != Outcome.NoMoreGuesses && Outcome.Right;
            }
        }

        // Clone = It clones the number that i typed in and holds it there. Really awesome!
        public GuessedNumber[] GuessedNumbers
        {
            get
            { 
                return GuessedNumber[]) _guessedNumbers.Clone();
            }
        }
        public bool CanMakeGuess
        {
            get
            {
                return Outcome != Outcome.NoMoreGuesses && Outcome != Outcome.Right;
            }
        }
        public int Count
        {
            get;
            private set;
        }

        public int? Guess
        {
            get;
            private set;
        }

        // Creating up some methods

        public SecretNumber() 
        {
        
        }

        public void Initialize() 
        {
        
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess > 101 || guess <= 0)
            {
                throw new ArgumentOutOfRangeException("Guess need to be in range between 1 and 100");
            }


            Guess = guess;

        }
        return Outcome;

        }
    }
    

    // Specify list
    public enum Outcome
    { 
        Indefinite,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }

}
