﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace guess_the_secret_throw
{
    public class SecretNumber
    {
        public const int MaxNumber = 7;

        private GuessedNumber[] _guessedNumbers;
        private int? _number;


        public bool CanMakeGuess
        {
            get
            {
                return Outcome != Outcome.NoMoreGuesses && Outcome != Outcome.Right;
            }
        }

        public Outcome Outcome
        {
            get;
            private set;
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

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
            private set
            {
                _number = value;
            }
        }

        // Clone = It clones the number that i typed in and holds it there. Really awesome!
        public GuessedNumber[] GuessedNumbers
        {
            get
            {
                return (GuessedNumber[])_guessedNumbers.Clone();
            }
        }

        // Creating up some methods
        public void Initialize()
        {
            for (int i = 0; i < _guessedNumbers.Length; i++)
            {
                _guessedNumbers[i].Number = null;
                _guessedNumbers[i].Outcome = Outcome.Indefinite;
            }
            Random r = new Random();

            Number = r.Next(1, 101);

            Count = 0;
            Guess = null;
            Outcome = Outcome.Indefinite;
        }

        public SecretNumber()
        {
            _guessedNumbers = new GuessedNumber[MaxNumber];
            Initialize();
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess > 100 || guess < 1)
            {
                throw new ArgumentOutOfRangeException("Guess need to be in range between 1 and 100.");
            }

            Guess = guess;

            foreach (GuessedNumber i in _guessedNumbers)
            {
                if (i.Number == Guess)
                {
                    Outcome = Outcome.OldGuess;
                    return Outcome.OldGuess;
                }
            }
            if (Count >= MaxNumber - 1)
            {
                Count = MaxNumber;
                Outcome = Outcome.NoMoreGuesses;
                return Outcome;
            }

            if (Guess < _number)
            {
                Outcome = Outcome.Low;
            }
            else if (Guess > _number)
            {
                Outcome = Outcome.High;
            }
            else
            {
                Outcome = Outcome.Right;
                return Outcome;
            }

            _guessedNumbers[Count].Number = Guess;
            _guessedNumbers[Count].Outcome = Outcome;

            Count++;

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