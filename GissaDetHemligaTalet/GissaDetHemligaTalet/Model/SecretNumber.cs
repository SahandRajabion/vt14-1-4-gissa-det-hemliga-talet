using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaDetHemligaTalet.Model.SecretNumber
{

    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess };

    public class SecretNumber
    {
        //_number innehåller det hemliga talet.
        private int _number;

        //_previousGuesses lagrar samtliga gissningar gjorda sedan aktuellt hemligt tal slumpades fram.
        public List<int> _previousGuesses;

        //MaxNumberOfGuesses ger antalet försök en användare har på sig att gissa det hemliga talet.
        public const int MaxNumberOfGuesses = 7;

        //CanMakeGuess ger ett värde som indikerar om en gissning kan göras eller inte.
        public bool CanMakeGuesses
        {

            get
            {
                //Retunerar bolean true om användaren har gissat under 7 gissningar. 
                return Count < MaxNumberOfGuesses && !_previousGuesses.Contains(_number);
            }
        }

        //Count ger antalet gjorda gissningar sedan det hemliga talet slumpades fram.
        public int Count
        {

            get
            {
                //Retunerar antal redan gissade nummer.(Håller reda på de gissade talen som användaren gjort).
                return _previousGuesses.Count();
            }
        }


        /*Number ger eller sätter det hemliga talet."int?" kan retunera ett tal av typen int men även "null". 
         * Men "null" retuneras fram till dess att användaren knappat rätt hemligt tal eller fram till dess att 7 gissningar är uppnått.
         * Kan ej fler gissningar göras, ges egenskapen det hemliga värdet*/

        public int? Number
        {

            get
            {
                if (CanMakeGuesses)
                {
                    return null;
                }
                return _number;
            }

        }


        //Ger referensen till listsamlingen innehållande användarens gjorda gissningar. Listar upp dem i samma ordning som användaren knappat in talen.
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }

        }


        //Outcome ger resultatet av den senast utförda gissningen för att senare kolla om den senaste gissade talet är högre eller lägre genom metoden Initialize.
        public Outcome Outcome { get; private set; }

        //Skapar klassens alla medlemmar
        public void Initialize()
        {

            //Slumpar det hemliga talet.
            Random random = new Random();
            _number = random.Next(1, 101);

            _previousGuesses.Clear();

            Outcome = Model.SecretNumber.Outcome.Indefinite;

        }

        //Metoden ser till om det gissade talet är det rätta eller ej, genom en retunering.
        public Outcome MakeGuess(int number)
        {
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            //Kollar om antal gissningar ej överträder 7.
            if (Count > MaxNumberOfGuesses)
            {
                throw new ArgumentException();
            }
            //KOllar om antal gissningar är lika med 7.
            if (Count == MaxNumberOfGuesses)
            {
                return Outcome = Outcome.NoMoreGuesses;
            }

            // Kollar om samma tal gissats igen.
            if (PreviousGuesses.Contains(number))
            {
                return Outcome = Outcome.PreviousGuess;
            }

            // Lägger till gissningen i listan innehållande alla gissningar.
            _previousGuesses.Add(number);

            //Om gissningen är för hög.
            if (number > _number)
            {
                return Outcome = Outcome.High;

            }
            //Om gissningen är för låg.
            else if (number < _number)
            {
                return Outcome = Outcome.Low;

            }
            //Om gissningen är rätt
            else
            {
                return Outcome = Outcome.Correct;
            }
        }


        //Konstruktor
        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();

        }
    }
}


