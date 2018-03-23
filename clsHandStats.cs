using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * I would eventually make a class that will be used in a binding list for a second datagridview which will contain
 * information regarding the number of each type of hands that have been dealt, and the calculated odds of each being dealt.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */


namespace cBurch_Final_Project___Poker_Game
{
    class clsHandStats
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



        static int _TotalHands = 0;



    }//close class
}//close namespace
