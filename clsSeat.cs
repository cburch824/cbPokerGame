using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cBurch_Final_Project___Poker_Game
{
    public class clsSeat
    {
        //Fields
        private int _position;     //seat number, or position. min is 1, max is 6
        private int _money; //funds for the character in this seat
        private int _bet;       //bet for that turn for this seat

        private clsCharacter _character;        //the character that is in this seat
        private clsHand _hand;

        //Constructors
        public clsSeat()   //default 0 arg constructor
        {
            _character = new clsCharacter();
            _money = 1000;
            _bet = 10;
            _position = 0;
        }

        public clsSeat(int p, int m, int b, clsCharacter c)
        {
            _position = p;
            _money = m;
            _bet = b;
            _character = c;
            _hand = new clsHand();
        }

        //Properties
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public int Bet
        {
            get { return _bet; }
            set { _bet = value; }
        }

        public clsCharacter Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public clsHand Hand
        {
            get { return _hand; }
            set { _hand = value; }
        }

        //Methods
        public int calculateBet()       //have to write this up to calculate a bet
        {
            int betCalc = 0;
            return betCalc;
        }

    }//close Seat class
}// close namespace
