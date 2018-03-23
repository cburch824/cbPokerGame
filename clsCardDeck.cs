using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //for message box error

namespace cBurch_Final_Project___Poker_Game
{
    public class clsCardDeck
    {
        private const int DECKSIZE = 52;
        private static string[] pips = {"",
            "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS", "AS",
            "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH", "AH",
            "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD", "AD",
            "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC", "AC"  };

        private int currentCard;
        public int[] deck { get; set; } = new int[53];
        private int passCount;

        Random rnd = new Random();  //Used for shuffling, this must be created on class instatiation
                                    //   to prevent common seeding (e.g. all generated random numbers are
                                    //   the same because clock time on instantiation is the same).

        public clsCardDeck()
        {
            currentCard = 1;
        }


        public int DeckSize
        {
            get
            {
                return DECKSIZE;        //number of cards in the deck
            }// no setter method required since this is a read-only property
        }

        public int CurrentCard
        {
            get
            {
                return currentCard;
            }
            set
            {
                if (value > 0 && value <= deck.Length)
                {
                    currentCard = value;
                }
            }
        }

        public int PassCount
        {
            get
            {
                return passCount;
            }//no setter method because it is a read-only property
        }




        public int shuffleDeck()
        {
            int index;
            int val;
            

            passCount = 0;  //count how many times through deck while looping
            index = 1;
            Array.Clear(deck, 0, deck.Length);  //initialize array to 0's

            while(index < deck.Length)
            {
                //add 1 to offset 0-based arrays
                val = rnd.Next(DECKSIZE) + 1;  //generates values from 1 through 52
                if(deck[val] == 0)
                {
                    //is this card place in the deck "unused"?
                    deck[val] = index;      //yep, so assign it a card place
                    index++;                //get ready for next card
                }
                passCount++;
            }
            currentCard = 1;   //prepare to deal the first card
            return passCount;

        }

        public string getCardPip(int index)
        {
            if(index > 0 && index <= DECKSIZE)
            {
                return pips[index];

            }
            else
            {
                return ""; //ERROR
            }


        }

        public static int convertPipToNumeric(string inputCard)
        {

            int numericValue = -1; //returned when determined
    
            if (inputCard.Length == 3) // case: it is a 10 with some suit
            {
                numericValue = 9;
                char suit10 = inputCard[2];
                if(suit10 == 'S')
                {
                    numericValue += (0 * 13);
                }
                else if (suit10 == 'H')
                {
                    numericValue += (1 * 13);
                }
                else if (suit10 == 'D')
                {
                    numericValue += (2 * 13);
                }
                else if (suit10 == 'C')
                {
                    numericValue += (3 * 13);
                }
                else { MessageBox.Show("An error has occured - Value = 10, Suit = Unknown. For card " + inputCard.ToString()); }
                return numericValue;
            }

            //Otherwise, continue with rest of method
            char value = inputCard[0];
            char suit = inputCard[1];

            //Determine numeric value for corresponding card value (e.g. TWO = 1, K = 12
            try
            {
                numericValue = (int.Parse(value.ToString())) + 1;
            }
            catch //parse error
            {
                if (value == 'J')
                {
                    numericValue = 10;
                }
                else if (value == 'Q')
                {
                    numericValue = 11;
                }
                else if (value == 'K')
                {
                    numericValue = 12;
                }
                else if (value == 'A')
                {
                    numericValue = 13;
                }
                else
                { MessageBox.Show("Error - Cannont determine non-numeric value for " + inputCard.ToString()); }
            }

            //Apply a multiplier for the appropriate suit
            if (suit == 'S')
            {
                //do not change numeric value
                numericValue += (0 * 13);
            }
            else if (suit == 'H')
            {
                numericValue += (1 * 13);
            }
            else if (suit == 'D')
            {
                return numericValue += (2 * 13);
            }
            else if (suit == 'C')
            {
                return numericValue += (3 * 13);
            }
            else { MessageBox.Show("An error has occured - Value was determined, Suit = Unknown. For card " + inputCard.ToString()); }


            return numericValue;
            
    }

        public void moveToNextCard()
        {
            currentCard++;
        }
        



    }
}
