using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cBurch_Final_Project___Poker_Game
{
    public class clsCommunityCards
    {
        //Fields
        int _firstCard,
            _secondCard,
            _thirdCard,
            _fourthCard,
            _fifthCard,
            _firstBurn,
            _secondBurn,
            _numberOfCommunityCards;

        //Constructor
        public clsCommunityCards()  //0- arg constructor
        {
            FirstCard = 0;
            SecondCard = 0;
            ThirdCard = 0;
            FourthCard = 0;
            FifthCard = 0;
            FirstBurn = 0;
            SecondBurn = 0;
            NumberOfCommunityCards = 0;
            
        }


        //Properties
        public int NumberOfCommunityCards
        {
            get { return _numberOfCommunityCards; }
            set { _numberOfCommunityCards = value; }
        }

        public int FirstCard
        {
            get { return _firstCard; }
            set { _firstCard = value; }
        }

        public int SecondCard
        {
            get { return _secondCard; }
            set { _secondCard = value; }
        }

        public int ThirdCard
        {
            get { return _thirdCard; }
            set { _thirdCard = value; }
        }

        public int FourthCard
        {
            get { return _fourthCard; }
            set { _fourthCard = value; }
        }

        public int FifthCard
        {
            get { return _fifthCard; }
            set { _fifthCard = value; }
        }

        public int FirstBurn
        {
            get { return _firstBurn; }
            set { _firstBurn = value; }
        }

        public int SecondBurn
        {
            get { return _secondBurn; }
            set { _secondBurn = value; }
        }

        //Methods
        public void clearCommunityCards()
        {
            FirstCard = 0;
            SecondCard = 0;
            ThirdCard = 0;
            FourthCard = 0;
            FifthCard = 0;
            FirstBurn = 0;
            SecondBurn = 0;
            NumberOfCommunityCards = 0;
        }

        public void communityFlopAddCards()
        {
            NumberOfCommunityCards = 3;
        }

        public void communityTurnAddCards()
        {
            NumberOfCommunityCards++;
        }

        public void communityRiverAddCards()
        {
            NumberOfCommunityCards++;
        }
        
        public void setCommunityCardsToFive() //exists for debug purposes, specifically in the frmHandEvalTest.cs form
        {
            NumberOfCommunityCards = 5;
        }

    }
}
