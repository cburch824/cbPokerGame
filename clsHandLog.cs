using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cBurch_Final_Project___Poker_Game
{
    public class clsHandLog
    {

        //Fields
        private string[] _playerCards = new string[12];
        private string[] _boardCards = new string[5];


        //Constructors
        public clsHandLog(string p11, string p12, string p21, string p22, string p31, string p32, string p41, string p42, string p51, string p52, string p61, string p62,
                            string b1, string b2, string b3, string b4, string b5)
        {
            _playerCards[0] = p11;
            _playerCards[1] = p12;
            _playerCards[2] = p21;
            _playerCards[3] = p22;
            _playerCards[4] = p31;
            _playerCards[5] = p32;
            _playerCards[6] = p41;
            _playerCards[7] = p42;
            _playerCards[8] = p51;
            _playerCards[9] = p52;
            _playerCards[10] = p61;
            _playerCards[11] = p62;

            _boardCards[0] = b1;
            _boardCards[1] = b2;
            _boardCards[2] = b3;
            _boardCards[3] = b4;
            _boardCards[4] = b5;

        }

        //Properties
        public string[] PlayerCards
        {
            get { return _playerCards; }
            set { _playerCards = value; }
        }

        public string[] BoardCards
        {
            get { return _boardCards; }
            set { _playerCards = value; }
        }

        public string printLog()
        {
            string spacer = " - ";
            string returnString = "\n     P1          P2            P3            P4           P5           P6           B1  B2  B3  B4  B5\n";

            returnString += _playerCards[0] + "  " + _playerCards[1];

            for (int i = 2; i < 12; i += 2)
            {
                returnString += spacer;
                returnString += _playerCards[i];
                returnString += "  ";
                returnString += _playerCards[i + 1];
            }

            returnString += "       ";
            for(int i = 0; i < 5; i++)
            {
                returnString += _boardCards[i] + "  ";
            }

            return returnString;
        }// close printLog method

    }
}
