using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cBurch_Final_Project___Poker_Game
{
    public class clsHand
    {

        public int Card1 { get; set; }
        public int Card2 { get; set; }

        public clsHand()
        {
            Card1 = 0;
            Card2 = 0;
        }

        public int getHandStrength(clsCharacter character)
        {
            int characterIntelligence = character.Intelligence;
            int characterAggression = character.Aggression;
            int characterRandomness = character.Randomness;

            double multiplier = 1;     //used to add additional value to handStrength due to same suit, sequential values, same value
            bool sameValue;
            bool sequential;
            bool sameSuit;

            int handStrength = -1;  //evaluates from 0 (least strength) to 100 (highest strength)


            int card1Value = Card1 % 13;                    //so ace = 0, 2 = 1, king = 12,
            if(card1Value == 0) { card1Value = 13; }        //    and now set ace to 13 instead of 0
            int card2Value = Card2 % 13;
            if(card2Value == 0) { card2Value = 13; }

            int card1Suit = (Card1 - 1) / 12;  //this is 12 because the next suit starts every 12 cards. We subtract 1 since
            int card2Suit = (Card2 - 1) / 12;   //  the cards are indexed to 1 instead of zero. In this case, Spades = 0, Heart = 1, Diamonds = 3, Clubs = 4


            //Determine truth value of sameValue, sequential
            if(card1Value - card2Value == 0)    //case: card1 and card2 have the same value (e.g. both are jacks)
            {
                sameValue = true;
                sequential = false;
            }
            else if(Math.Abs(card1Value - card2Value) == 1 || Math.Abs(card1Value - card2Value) == 12)     //case: the absolute value of the 
            {                                                                // difference between card1 and card 2 is 1 (1 number away from each other)
                                                                             // or 12 away from each other since ace and 2 are sequential
                sequential = true;
                sameValue = false;
            }
            else
            {
                sequential = false;
                sameValue = false;
            }

            //Determine the truth value of sameSuit
            if (card1Suit == card2Suit)
            {
                sameSuit = true;
            }
            else
            {
                sameSuit = false;
            }


            //if- if else - else artificial intelligence structure for determining hand strength (depends on character intelligence)
            if(characterIntelligence >= 90) //case: character intelligence is greater than or equal to 90
            {
                //superior concept of both same suit and sequential cards, good concept of pocket pairs (same card)
                if (sameSuit)
                { multiplier += .6; }
                if (sequential)
                { multiplier += .3; }
                if (sameValue)
                { multiplier += .6; }
                if(card1Value > 9 && card2Value > 9) //case: both face cards
                { multiplier += .5; }


                handStrength = (int)((25 * 2) - 2);
                handStrength = (int)(multiplier * handStrength);


            }
            else if( characterIntelligence >= 70) //case: character intelligence is greater than or equal to 70
            {
                //good concept of same suit and sequential cards, some concept of pocket pairs (same card)
                if (sameSuit)
                { multiplier += .5; }
                if (sequential)
                { multiplier += .3; }
                if(sameValue)
                { multiplier += .2; }

                handStrength = 25 * 2;
                handStrength = (int)(multiplier * handStrength);
            }
            else if(characterIntelligence >= 50) //case: character intelligence is greater than or equal to 50
            {
                //slight concept of same suit and good concept of sequential cards
                if(sameSuit)
                { multiplier += .2; }
                if(sequential)
                { multiplier += .3; }

                handStrength = (int)((25 * 2.5) + 2);
                handStrength = (int)(multiplier * handStrength);

            }
            else if(characterIntelligence >= 20) //case: character intelligence is greater than or equal to 20
            {
                //no concept of same suit, values seqential numeric cards
                if(sequential == true)
                {
                    multiplier = 1.93;
                }

                handStrength = (card1Value + card2Value) * 2;
                handStrength = (int)(handStrength * multiplier);

            }
            else //case: character intelligence is less than 20
            {

                //character has no concept of sequential numbers,  believes same color is equal value to same suit :)
                bool sameColor;
                if (sameSuit == true || card1Suit == 0 && card2Suit == 3 || card1Suit == 3 && card2Suit == 0 || card1Suit == 1 && card2Suit == 2 || card1Suit == 2 && card2Suit == 1)
                {
                    sameColor = true;
                }
                else
                {
                    sameColor = false;
                }

                if(sameColor == true)
                {
                    multiplier = 1.93;
                }

                handStrength = (card1Value + card2Value) * 2;
                handStrength = (int)(handStrength * multiplier);


            }
            //case: handStrength is still the default value of -1, send an error message and set it to zero
            if(handStrength == -1)
            {
                MessageBox.Show("Hand strength has a value of -1", "Error");
                handStrength = 0;
            }

            //case: handStrength is greater than 100, set it to 100 
            if(handStrength > 100)
            {
                handStrength = 100;
            }
            return handStrength;
        }//close calculateHandStrength()
    }//close Hand class
}//close namespace
