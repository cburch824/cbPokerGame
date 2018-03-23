using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
namespace cBurch_Final_Project___Poker_Game
{
    public class clsCharacter
    {
        //Fields
        private string _name;
        private int _aggresion;
        private int _intelligence;
        private int _randomness;
        private int _luck;
        private Image _picture;

        //Constructors
        public clsCharacter()  //0-arg constructor
        {
            _name = "Default Name";
            _aggresion = 0;
            _intelligence = 0;
            _randomness = 0;
            _luck = 0;
            _picture = Image.FromFile("defaultimage.jpg");
        }
        public clsCharacter(string n, int a, int i, int r, int l, Image p)  //full constructor
        {
            _name = n;
            _aggresion = a;
            _intelligence = i;
            _randomness = r;
            _luck = l;
            _picture = p;
        }

        //Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Aggression
        {
            get { return _aggresion; }
            set { _aggresion = value; }
        }

        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }

        public int Randomness
        {
            get { return _randomness; }
            set { _randomness = value; }
        }

        public int Luck
        {
            get { return _luck; }
            set { _luck = value; }
        }

        public Image Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
    }
}
