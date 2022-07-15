using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        List<Card> cards = new List<Card>();
        bool isPlaying = true;
        int totalScore = 300;
        public string guess;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            for (int i = 0; i < 2; i++)
            {
                Card card = new Card();
                cards.Add(card);
            }
        }

    

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Asks the user if they want to roll.
        /// </summary>
        public void GetInputs()
        {
            Console.Write("Draw a Card? [y/n] ");
            string drawCard = Console.ReadLine();
            isPlaying = (drawCard == "y");
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            if (!isPlaying)
            {
                return;
            }

            int score = 0;
            foreach (Card card in cards)
            {
                card.Draw();
                Console.WriteLine(card.value);
                if (score == 0)
                {
                    Console.WriteLine("Is the Next card Heigher or Lower? [h/l] ");
                    guess = Console.ReadLine();
                }
                score += 1;    
                
            }
        }

        /// <summary>
        /// Displays the dice and the score. Also asks the player if they want to roll again. 
        /// </summary>
        public void DoOutputs()
        {
            if (!isPlaying)
            {
                return;
            }
            string final;
            if (cards[0].value > cards[1].value)
            {
                final = "l";
            }
            else
            {
                final = "h";
            }
            
            if (final == guess)
            {
                totalScore += 50;
            }
            else
            {
                totalScore -= 100;
            }
            Console.WriteLine($"Your score is: {totalScore}\n");
            isPlaying = (totalScore > 0);
        }
    }
}


