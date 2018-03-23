using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cBurch_Final_Project___Poker_Game
{
    public enum HandEnum
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }
    public class Card
    {

        public enum SUIT
        {
            HEARTS,
            SPADES,
            DIAMONDS,
            CLUBS
        }

        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        //properties
        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }



    }



    public class clsEvaluateHand : Card
    {
        private int heartsSum,
            diamondSum,
            clubSum,
            spadesSum;
        private Card[] cards;
        private HandValue handValue;
        private int numberOfCards;
        private List<Card> handList = new List<Card>();
        
        

        public clsEvaluateHand(clsHand inputHand, clsCommunityCards inputBoard)
        {
            numberOfCards = 2 + inputBoard.NumberOfCommunityCards;
            Card[] convertedHand = convertHand(inputHand, inputBoard);  //converts hand to the Card[] evaluation notation
            Card[] sortedHand = sortHand(convertedHand);                //sorts the hand

            
            for(int i = 0; i < numberOfCards; i++)
            {
                handList.Add(sortedHand[i]);
            }

            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            cards = new Card[numberOfCards];
            Cards = sortedHand;
            handValue = new HandValue();




        }
        public HandValue HandValues
            {
                get { return handValue; }
                set { handValue = value; }
            }


        public Card[] Cards
        {
            get { return cards; }
            set
            {
                for(int i = 0; i < numberOfCards; i++)
                {
                    cards[i] = value[i];
                }

            }
        }//close Card[] Cards property

        public HandEnum EvaluateHand()
        {
            //Group is used for pair, two pair, three of a kind, and full house tests, where it will be enumerated
            var cardGroups = handList.GroupBy(o => o.MyValue).OrderByDescending(group => group.Count());

            //get the number of each suit on hand
            getNumberOfSuit();
            if (RoyalFlush())
                return HandEnum.RoyalFlush;
            else if (StraightFlush())
                return HandEnum.StraightFlush;
            else if (FourOfAKind(cardGroups))
                return HandEnum.FourOfAKind;
            else if (FullHouse(cardGroups))
                return HandEnum.FullHouse;
            else if (Flush())
                return HandEnum.Flush;
            else if (Straight())
                return HandEnum.Straight;
            else if (ThreeOfAKind(cardGroups))
                return HandEnum.ThreeOfAKind;
            else if (TwoPair(cardGroups))
                return HandEnum.TwoPair;
            else if (Pair(cardGroups))
                return HandEnum.Pair;

            //Return HighCard with its value if no other types
            handValue.HighCard = (int)cards[numberOfCards - 1].MyValue;
            return HandEnum.HighCard;
        }// close EvaluateHand method

        private void getNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.MySuit == Card.SUIT.HEARTS)
                    heartsSum++;
                else if (element.MySuit == Card.SUIT.DIAMONDS)
                    diamondSum++;
                else if (element.MySuit == Card.SUIT.CLUBS)
                    clubSum++;
                else if (element.MySuit == Card.SUIT.SPADES)
                    spadesSum++;
            }
        }//Close getNumberOfSuit
       
        private bool RoyalFlush()
        {
           
            //check for straight
            if (Cards[0].MyValue + 1 == Cards[1].MyValue &&
                Cards[1].MyValue + 1 == Cards[2].MyValue &&
                Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                Cards[0].MySuit == Cards[1].MySuit &&
                Cards[1].MySuit == Cards[2].MySuit &&
                Cards[2].MySuit == Cards[3].MySuit &&
                Cards[3].MySuit == Cards[4].MySuit &&
                Cards[4].MyValue.ToString() == "ACE" &&
                Cards[3].MyValue.ToString() == "KING" &&
                Cards[2].MyValue.ToString() == "QUEEN" &&
                Cards[1].MyValue.ToString() == "JACK" &&
                Cards[0].MyValue.ToString() == "TEN"
                ){ return true;}
            else if
                (
                Cards[1].MyValue + 1 == Cards[2].MyValue &&
                Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                Cards[4].MyValue + 1 == Cards[5].MyValue &&
                Cards[1].MySuit == Cards[2].MySuit &&
                Cards[2].MySuit == Cards[3].MySuit &&
                Cards[3].MySuit == Cards[4].MySuit &&
                Cards[4].MySuit == Cards[5].MySuit &&
                Cards[5].MyValue.ToString() == "ACE" &&
                Cards[4].MyValue.ToString() == "KING" &&
                Cards[3].MyValue.ToString() == "QUEEN" &&
                Cards[2].MyValue.ToString() == "JACK" &&
                Cards[1].MyValue.ToString() == "TEN"
                ) { return true; }
            else if (

                Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                Cards[4].MyValue + 1 == Cards[5].MyValue &&
                Cards[5].MyValue + 1 == Cards[6].MyValue &&

                Cards[2].MySuit == Cards[3].MySuit &&
                Cards[3].MySuit == Cards[4].MySuit &&
                Cards[4].MySuit == Cards[5].MySuit &&
                Cards[5].MySuit == Cards[6].MySuit &&
                Cards[6].MyValue.ToString() == "ACE" &&
                Cards[5].MyValue.ToString() == "KING" &&
                Cards[4].MyValue.ToString() == "QUEEN" &&
                Cards[3].MyValue.ToString() == "JACK" &&
                Cards[2].MyValue.ToString() == "TEN"
                ) { return true; }
            else
            {
                return false;
            }


        }

        private bool StraightFlush()
        {
            //check for straight
            if (Cards[0].MyValue + 1 == Cards[1].MyValue && //Check straight
                Cards[1].MyValue + 1 == Cards[2].MyValue &&
                Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                
                Cards[0].MySuit == Cards[1].MySuit && // check flush
                Cards[1].MySuit == Cards[2].MySuit &&
                Cards[2].MySuit == Cards[3].MySuit &&
                Cards[3].MySuit == Cards[4].MySuit
                ) { return true; }
            else if
                (
                Cards[1].MyValue + 1 == Cards[2].MyValue && //check straight
                Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                Cards[4].MyValue + 1 == Cards[5].MyValue &&
               
                Cards[1].MySuit == Cards[2].MySuit && // check flush
                Cards[2].MySuit == Cards[3].MySuit &&
                Cards[3].MySuit == Cards[4].MySuit &&
                Cards[4].MySuit == Cards[5].MySuit 
                ) { return true; }
            else if(
                
                Cards[2].MyValue + 1 == Cards[3].MyValue && // check straight
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                Cards[4].MyValue + 1 == Cards[5].MyValue &&
                Cards[5].MyValue + 1 == Cards[6].MyValue &&

                Cards[2].MySuit == Cards[3].MySuit &&   //check flush
                Cards[3].MySuit == Cards[4].MySuit &&
                Cards[4].MySuit == Cards[5].MySuit &&
                Cards[5].MySuit == Cards[6].MySuit
                ) { return true; }
            else
            {
                return false;
            }
        }
        
        private bool FourOfAKind(IOrderedEnumerable<IGrouping<VALUE, Card>> cardGroups)
        {

            var cardEnumerator = cardGroups.GetEnumerator();    //creates IEnumerator<IGrouping> object
            cardEnumerator.MoveNext();
            if (cardEnumerator.Current.Count() == 4)
            {
                return true;
            }

            return false;
        
        }
        private bool FullHouse(IOrderedEnumerable<IGrouping<VALUE, Card>> cardGroups)
        {

            var cardEnumerator = cardGroups.GetEnumerator();     //creates IEnumerator<IGrouping> object
            cardEnumerator.MoveNext();
            if (cardEnumerator.Current.Count() == 3 )       //full house case: first group count is 3
            {
                cardEnumerator.MoveNext();
                if(cardEnumerator.Current.Count() == 2)     //full house case continuted:  both first group count is 3 and second group count is 2, so full house
                {
                    return true;
                }
                
            }
            return false;


        }
        private bool Flush()
        { 
            
                //if all suits are the same
                if (heartsSum >= 5 || diamondSum >= 5 || clubSum >= 5 || spadesSum >= 5)
                {
                    //if flush, the player with higher cards win
                    //whoever has the last card the highest, has automatically all the cards total higher

                    //!!!!!!!!!!!
                    //Case: hearts flush
                    if (heartsSum >= 5)
                    { 
                        if(cards[numberOfCards - 1].MySuit == SUIT.HEARTS)      //7 cards, it is (n - 1) because of arrays
                        {
                            handValue.Total = (int)cards[numberOfCards - 1].MyValue;
                        }
                        else if(cards[numberOfCards - 2].MySuit == SUIT.HEARTS) //6 cards, or the 2nd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 2].MyValue;
                        }
                        else//5 cards, or the 3rd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 3].MyValue;
                        }

                    }
                    //!!!!!!!!!!!!!!!
                    //case: diamonds flush
                    if(diamondSum >= 5)
                    {
                        if (cards[numberOfCards - 1].MySuit == SUIT.DIAMONDS)      //7 cards, it is (n - 1) because of arrays
                        {
                            handValue.Total = (int)cards[numberOfCards - 1].MyValue;
                        }
                        else if (cards[numberOfCards - 2].MySuit == SUIT.DIAMONDS) //6 cards, or the 2nd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 2].MyValue;
                        }
                        else//5 cards, or the 3rd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 3].MyValue;
                        }
                    }

                    //case: club flush
                    if(clubSum >= 5)
                    {
                        if (cards[numberOfCards - 1].MySuit == SUIT.CLUBS)      //7 cards, it is (n - 1) because of arrays
                       {
                            handValue.Total = (int)cards[numberOfCards - 1].MyValue;
                        }
                        else if (cards[numberOfCards - 2].MySuit == SUIT.CLUBS) //6 cards, or the 2nd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 2].MyValue;
                        }
                        else//5 cards, or the 3rd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 3].MyValue;
                        }
                    }

                    if(spadesSum >= 5)
                    {
                        if (cards[numberOfCards - 1].MySuit == SUIT.SPADES)      //7 cards
                        {
                            handValue.Total = (int)cards[numberOfCards - 1].MyValue;
                        }
                        else if (cards[numberOfCards - 2].MySuit == SUIT.SPADES) //6 cards, or the 2nd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 2].MyValue;
                        }
                        else//5 cards, or the 3rd highest card is the highest in the flush suit
                        {
                            handValue.Total = (int)cards[numberOfCards - 3].MyValue;
                        }

                    }


                    return true;


                }//close case: there is a flush

                return false;
                
        }

        private bool Straight()
        {

            if (Cards[0].MyValue + 1 == Cards[1].MyValue &&
                Cards[1].MyValue + 1 == Cards[2].MyValue &&
                Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue)
            {
                //player with the highest value of the last card wins
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            else if (Cards[1].MyValue + 1 == Cards[2].MyValue &&
                Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                Cards[4].MyValue + 1 == Cards[5].MyValue)
            {
                handValue.Total = (int)cards[5].MyValue;
                return true;
            }

            else if(Cards[2].MyValue + 1 == Cards[3].MyValue &&
                Cards[3].MyValue + 1 == Cards[4].MyValue &&
                Cards[4].MyValue + 1 == Cards[5].MyValue &&
                Cards[5].MyValue + 1 == Cards[6].MyValue)
            {
                handValue.Total = (int)cards[6].MyValue;
                return true;
            }

            else
            {
                return false;
            }
        }

        private bool ThreeOfAKind(IOrderedEnumerable<IGrouping<VALUE, Card>> cardGroups)
        {

            var cardEnumerator = cardGroups.GetEnumerator();     //creates IEnumerator<IGrouping> object
            cardEnumerator.MoveNext();
            if(cardEnumerator.Current.Count() == 3)
            {
                return true;
            }

            return false;
        }

        private bool TwoPair(IOrderedEnumerable<IGrouping<VALUE, Card>> cardGroups)
        {

            var cardEnumerator = cardGroups.GetEnumerator();      //creates IEnumerator<IGrouping> object
            cardEnumerator.MoveNext();
            if (cardEnumerator.Current.Count() == 2)
            {
                cardEnumerator.MoveNext();
                if(cardEnumerator.Current.Count() == 2)
                {
                    return true;
                }
            }
            return false;
        }

        private bool Pair(IOrderedEnumerable<IGrouping<VALUE, Card>> cardGroups)
        {

            var cardEnumerator = cardGroups.GetEnumerator();     //creates IEnumerator<IGrouping> object
            cardEnumerator.MoveNext();
            if (cardEnumerator.Current.Count() == 2)
            {
                return true;
            }

            return false;
        }


        //Used to convert the hand from the clsCardDeck notation to clsEvaluateHand notation
        private Card[] convertHand(clsHand inputHand, clsCommunityCards inputBoard)
        {
            //Card[] convertedHand = new Card[numberOfCards];
            Card[] convertedHand = new Card[7];

            //convert cards in hand

            convertedHand[0] = convertCard(inputHand.Card1);
            convertedHand[1] = convertCard(inputHand.Card2);

            convertedHand[2] = convertCard(inputBoard.FirstCard);
            convertedHand[3] = convertCard(inputBoard.SecondCard);
            convertedHand[4] = convertCard(inputBoard.ThirdCard);
            convertedHand[5] = convertCard(inputBoard.FourthCard);
            convertedHand[6] = convertCard(inputBoard.FifthCard);

            //convert cards on board

            return convertedHand;
        }

        private Card convertCard(int inputCard)
        {
            int cardInteger = inputCard % 13;
            Card resultCard = new Card();

        #region Convert Value
            if(cardInteger == 0)
            {
                resultCard.MyValue = Card.VALUE.ACE;
            }
            else if(cardInteger == 1)
            {
                resultCard.MyValue = Card.VALUE.TWO;
            }
            else if (cardInteger == 2)
            {
                resultCard.MyValue = Card.VALUE.THREE;
            }
            else if (cardInteger == 3)
            {
                resultCard.MyValue = Card.VALUE.FOUR;
            }
            else if (cardInteger == 4)
            {
                resultCard.MyValue = Card.VALUE.FIVE;
            }
            else if (cardInteger == 5)
            {
                resultCard.MyValue = Card.VALUE.SIX;
            }
            else if (cardInteger == 6)
            {
                resultCard.MyValue = Card.VALUE.SEVEN;
            }
            else if (cardInteger == 7)
            {
                resultCard.MyValue = Card.VALUE.EIGHT;
            }
            else if (cardInteger == 8)
            {
                resultCard.MyValue = Card.VALUE.NINE;
            }
            else if (cardInteger == 9)
            {
                resultCard.MyValue = Card.VALUE.TEN;
            }
            else if (cardInteger == 10)
            {
                resultCard.MyValue = Card.VALUE.JACK;
            }
            else if (cardInteger == 11)
            {
                resultCard.MyValue = Card.VALUE.QUEEN;
            }
            else if (cardInteger == 12)
            {
                resultCard.MyValue = Card.VALUE.KING;
            }
            #endregion

        #region Convert Suit
            int cardSuit = (inputCard - 1) / 13;
            if(cardSuit == 0)
            { resultCard.MySuit = Card.SUIT.SPADES; }
            else if(cardSuit == 1)
            {
                resultCard.MySuit = Card.SUIT.HEARTS;
            }
            else if (cardSuit == 2)
            {
                resultCard.MySuit = Card.SUIT.DIAMONDS;
            }
            else if (cardSuit == 3)
            {
                resultCard.MySuit = Card.SUIT.CLUBS;
            }
            else
            {
                MessageBox.Show("A card was given a non-valid suit of " + cardSuit + ".\n It was the " + resultCard.MyValue.ToString() + resultCard.MySuit.ToString() + " card.", "Error");
            }


            #endregion

            return resultCard;
        }

        //Used to sort the hand in order from lowest value to highest value
        private Card[] sortHand(Card[] parameterHand)
        {
            Card[] sortedHand = new Card[numberOfCards];

            //create the list
            List<Card> sortCardList = new List<Card>();
            for(int i = 0; i < numberOfCards; i++)
            {
                sortCardList.Add(parameterHand[i]);
            }

            //sort the list
            //List<Card> SortedList = sortCardList.OrderBy(s => s.MyValue).ToList();
            IEnumerable<Card> query = parameterHand.OrderBy(card => card.MyValue);
            List<Card> SortedList = new List<Card>();
            SortedList = query.ToList();
            //List<Card> SortedList = sortCardList.OrderBy(card => card.MyValue).ToList();

            //put the list into sortedHand[]
            for(int i = 0; i < numberOfCards; i++)
            {
                sortedHand[i] = SortedList[i];
            }

            return sortedHand;
        }

        public string getHandValueText(HandEnum handInput)
        {
            if(handInput == HandEnum.HighCard)
            {
                return "High Card";
            }
            else if (handInput == HandEnum.Pair)
            {
                return "Pair";
            }
            else if (handInput == HandEnum.TwoPair)
            {
                return "Two Pair";
            }
            else if (handInput == HandEnum.ThreeOfAKind)
            {
                return "Three of a Kind";
            }
            else if (handInput == HandEnum.Straight)
            {
                return "Straight";
            }
            else if (handInput == HandEnum.FullHouse)
            {
                return "Full House";
            }
            else if (handInput == HandEnum.FourOfAKind)
            {
                return "Four of a Kind";
            }
            else if (handInput == HandEnum.StraightFlush)
            {
                return "Straight Flush";
            }
            else if (handInput == HandEnum.RoyalFlush)
            {
                return "Royal Flush";
            }
            else { return "error."; }

        }

    }//Close clsEvaluateHand class
}//Close namespace

