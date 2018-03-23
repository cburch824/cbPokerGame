using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace cBurch_Final_Project___Poker_Game
{
    public partial class frmHandEvalTest : Form
    {

        clsSeat testSeat;

        Boolean startNextHand;

        clsCardDeck gameDeck;
        clsCommunityCards board;

        string pocketCard1,
            pocketCard2,
            boardCard1,
            boardCard2,
            boardCard3,
            boardCard4,
            boardCard5,
            handValue;

        List<clsHandEvalTest> handsList = new List<clsHandEvalTest>();
        clsHandsData handsDataCounter;


        public frmHandEvalTest(clsCharacter c1)
        {
            InitializeComponent();

            testSeat = new clsSeat(1, 1000, 10, c1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHandEvalTest_Load(object sender, EventArgs e)
        {


            gameDeck = new clsCardDeck();       //instantiate the deck
            gameDeck.shuffleDeck();             //shuffle it for the first time

            board = new clsCommunityCards();
        }

        private void btnDealHands_Click(object sender, EventArgs e)
        {
            //deal the hands
            for (int i = 0; i < int.Parse(txtNumberOfHands.Text); i++)
            {
                dealSingleHand();
            }

            //send the datalist
            handsDataCounter = new clsHandsData(handsList);


            //print results of random hands to grid, print data to RichTextBox
            printResultsToDataGridView();
            updateRTBHandsData(handsDataCounter);

        }

        private void btnCustomHand_Click(object sender, EventArgs e)
        {
            /*
            //Deal the hand
            gameDeck.shuffleDeck();     //shuffle the deck
            board.clearCommunityCards();

            dealNextHand();
            dealFlop();
            dealTurn();
            dealRiver();
            */
            //Must convert from pip input to numeric form which the HandEvaluator can work with
            string pocketCard1 = txtPC1.Text.ToString();
            string pocketCard2 = txtPC2.Text.ToString();
            string boardCard1 = txtBC1.Text.ToString();
            string boardCard2 = txtBC2.Text.ToString();
            string boardCard3 = txtBC3.Text.ToString();
            string boardCard4 = txtBC4.Text.ToString();
            string boardCard5 = txtBC5.Text.ToString();

            int numPocketCard1 = clsCardDeck.convertPipToNumeric(pocketCard1);
            int numPocketCard2 = clsCardDeck.convertPipToNumeric(pocketCard2);
            int numBoardCard1 = clsCardDeck.convertPipToNumeric(boardCard1);
            int numBoardCard2 = clsCardDeck.convertPipToNumeric(boardCard2);
            int numBoardCard3 = clsCardDeck.convertPipToNumeric(boardCard3);
            int numBoardCard4 = clsCardDeck.convertPipToNumeric(boardCard4);
            int numBoardCard5 = clsCardDeck.convertPipToNumeric(boardCard5);
            //should be converted at this point

            //Now populate the seats and board with those values
            testSeat.Hand.Card1 = numPocketCard1;
            testSeat.Hand.Card2 = numPocketCard2;
            board.FirstCard = numBoardCard1;
            board.SecondCard = numBoardCard2;
            board.ThirdCard = numBoardCard3;
            board.FourthCard = numBoardCard4;
            board.FifthCard = numBoardCard5;

            board.setCommunityCardsToFive(); //required since flop, turn, and river increase community cards


            clsEvaluateHand playerHandEvaluator = new clsEvaluateHand(testSeat.Hand, board);
            HandEnum playerHandValue = playerHandEvaluator.EvaluateHand();
            handValue = playerHandValue.ToString();

            int numericHandValue = determineNumbericHandValue(handValue);

            //create and add current hand object to the list
            clsHandEvalTest currentHandList = new clsHandEvalTest(pocketCard1, pocketCard2, boardCard1, boardCard2, boardCard3, boardCard4, boardCard5, handValue, numericHandValue);  //create the hand object
            handsList.Add(currentHandList);

            //send the datalist
            handsDataCounter = new clsHandsData(handsList);


            //print results of custom hand to grid
            printResultsToDataGridView();
            updateRTBHandsData(handsDataCounter);
        }

        private void updateRTBHandsData(clsHandsData inputDataList)
        {
            double rfPercentage = (double)inputDataList.RoyalFlushCount / clsHandsData.NumberOfHands;
            double sfPercentage = (double)inputDataList.StraightFlushCount / clsHandsData.NumberOfHands;
            double fourOfKindPercentage = (double)inputDataList.FourOfAKindCount / clsHandsData.NumberOfHands;
            double fhPercentage = (double)inputDataList.FullHouseCount / clsHandsData.NumberOfHands;
            double fPercentage = (double)inputDataList.FlushCount / clsHandsData.NumberOfHands;
            double sPercentage = (double)inputDataList.StraightCount / clsHandsData.NumberOfHands;
            double threeOfKindPercentage = (double)inputDataList.ThreeOfAKindCount / clsHandsData.NumberOfHands;
            double twoPairPercentage = (double)inputDataList.TwoPairCount / clsHandsData.NumberOfHands;
            double pairPercentage = (double)inputDataList.PairCount / clsHandsData.NumberOfHands;
            double hcPercentage = (double)inputDataList.HighCardCount / clsHandsData.NumberOfHands;



            rtbHandData.Clear();
            rtbHandData.AppendText("Hands Data - Christopher Burch 2017");
            rtbHandData.AppendText("\nTotal number of hands: " + clsHandsData.NumberOfHands);
            rtbHandData.AppendText("\n     Royal Flush Count: " + inputDataList.RoyalFlushCount + " - " + rfPercentage.ToString("P"));
            rtbHandData.AppendText("\n  Straight Flush Count: " + inputDataList.StraightFlushCount + " - " + sfPercentage.ToString("P"));
            rtbHandData.AppendText("\n Four of a Kind Count: " + inputDataList.FourOfAKindCount + " - " + fourOfKindPercentage.ToString("P"));
            rtbHandData.AppendText("\n       Full House Count: " + inputDataList.FullHouseCount + " - " + fhPercentage.ToString("P"));
            rtbHandData.AppendText("\n               Flush Count: " + inputDataList.FlushCount + " - " + fPercentage.ToString("P"));
            rtbHandData.AppendText("\n            Straight Count: " + inputDataList.StraightCount + " - " + sPercentage.ToString("P"));
            rtbHandData.AppendText("\nThree of a Kind Count: " + inputDataList.ThreeOfAKindCount + " - " + threeOfKindPercentage.ToString("P"));
            rtbHandData.AppendText("\n          Two Pair Count: " + inputDataList.TwoPairCount + " - " + twoPairPercentage.ToString("P"));
            rtbHandData.AppendText("\n                  Pair Count: " + inputDataList.PairCount + " - " + pairPercentage.ToString("P"));
            rtbHandData.AppendText("\n        High Card Count: " + inputDataList.HighCardCount + " - " + hcPercentage.ToString("P"));

        }


        private void dealSingleHand()
        {

            //Deal the hand
            gameDeck.shuffleDeck();     //shuffle the deck
            board.clearCommunityCards();

            dealNextHand();
            dealFlop();
            dealTurn();
            dealRiver();
            clsEvaluateHand playerHandEvaluator = new clsEvaluateHand(testSeat.Hand, board);
            HandEnum playerHandValue = playerHandEvaluator.EvaluateHand();
            handValue = playerHandValue.ToString();

            int numericHandValue = determineNumbericHandValue(handValue);

            //create and add current hand object to the list
            clsHandEvalTest currentHandList = new clsHandEvalTest(pocketCard1, pocketCard2, boardCard1, boardCard2, boardCard3, boardCard4, boardCard5, handValue, numericHandValue);  //create the hand object
            handsList.Add(currentHandList);
        }
        private void printResultsToDataGridView()
        {
            //create a sortable binding list ( a child of the binding list class, as defined below)
            SortableBindingList<clsHandEvalTest> handBindingList = new SortableBindingList<clsHandEvalTest>(handsList);

            //bind the data grid view to that list
            dgvHandTestResults.DataSource = handBindingList;



        }
        #region REGION : Deal Hand methods
        public void dealNextHand()
        {

            //deal out both pocket cards to player
            testSeat.Hand.Card1 = gameDeck.deck[gameDeck.CurrentCard];
            gameDeck.moveToNextCard();

            testSeat.Hand.Card2 = gameDeck.deck[gameDeck.CurrentCard];
            gameDeck.moveToNextCard();


            //Store the traditional card values into a string (e.g. 10S or 3C)
           pocketCard1 = gameDeck.getCardPip(testSeat.Hand.Card1);
           pocketCard2 = gameDeck.getCardPip(testSeat.Hand.Card2);
           

        }//close dealNextHand() method

        public void dealFlop()
        {
            board.FirstBurn = gameDeck.deck[gameDeck.CurrentCard];
            gameDeck.moveToNextCard();

            board.FirstCard = gameDeck.deck[gameDeck.CurrentCard];
            boardCard1 = gameDeck.getCardPip(board.FirstCard);
            gameDeck.moveToNextCard();

            board.SecondCard = gameDeck.deck[gameDeck.CurrentCard];
            boardCard2 = gameDeck.getCardPip(board.SecondCard);
            gameDeck.moveToNextCard();

            board.ThirdCard = gameDeck.deck[gameDeck.CurrentCard];
            boardCard3 = gameDeck.getCardPip(board.ThirdCard);
            gameDeck.moveToNextCard();

            board.communityFlopAddCards();

        }//close dealFlop method

        public void dealTurn()
        {
            board.SecondBurn = gameDeck.CurrentCard;
            gameDeck.moveToNextCard();

            board.FourthCard = gameDeck.deck[gameDeck.CurrentCard];
            boardCard4 = gameDeck.getCardPip(board.FourthCard);
            gameDeck.moveToNextCard();

            board.communityTurnAddCards();

        }//close dealTurn method

        public void dealRiver()
        {
            board.FifthCard = gameDeck.deck[gameDeck.CurrentCard];
            boardCard5 = gameDeck.getCardPip(board.FifthCard);
            gameDeck.moveToNextCard();

            board.communityRiverAddCards();

        }//close dealRiver method
        #endregion



        private int determineNumbericHandValue(string handValue)
        {
            int numericHandValue = -1;
            if(handValue == "RoyalFlush")
            {
                numericHandValue = 10;
            }
            else if(handValue == "StraightFlush")
            {
                numericHandValue = 9;
            }
            else if (handValue == "FourOfAKind")
            {
                numericHandValue = 8;
            }
            else if (handValue == "FullHouse")
            {
                numericHandValue = 7;
            }
            else if (handValue == "Flush")
            {
                numericHandValue = 6;
            }
            else if (handValue == "Straight")
            {
                numericHandValue = 5;
            }
            else if (handValue == "ThreeOfAKind")
            {
                numericHandValue = 4;
            }
            else if (handValue == "TwoPair")
            {
                numericHandValue = 3;
            }
            else if (handValue == "Pair")
            {
                numericHandValue = 2;
            }
            else if (handValue == "HighCard")
            {
                numericHandValue = 1;
            }

            return numericHandValue;

        }


        

    }//close frmHandEvalTest class
    #region HandEvalTest Class
    public class clsHandEvalTest
    {

        //Multiple arg constructor, populates all class members
        public clsHandEvalTest(string p1, string p2, string b1, string b2, string b3, string b4, string b5, string handValue, int handValueNumber)
        {
            pc1 = p1;
            pc2 = p2;
            bc1 = b1;
            bc2 = b2;
            bc3 = b3;
            bc4 = b4;
            bc5 = b5;
            hv = handValue;
            hvn = handValueNumber;

        }

       public string pc1 { get; set; }    //pocket cards
        public string pc2 { get; set; }
        public string bc1 { get; set; }      //board cards
        public string bc2 { get; set; }
        public string bc3 { get; set; }
        public string bc4 { get; set; }
        public string bc5 { get; set; }
        public string hv { get; set; }     //hand values
        public int hvn { get; set; }


    }
    #endregion

    #region Hands Data Class
    public class clsHandsData
    {
        private int _RoyalFlushCount,
            _StraightFlushCount,
            _FourOfAKindCount,
            _FullHouseCount,
            _FlushCount,
            _StraightCount,
            _ThreeOfAKindCount,
            _TwoPairCount,
            _PairCount,
            _HighCardCount;
        private string _HandResultName;
        private static int _NumberOfHands = 0;



        #region Constructors
        public clsHandsData(List<clsHandEvalTest> evaluatedHandsList )
        {
            #region Counting Loops
            for(int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if(evaluatedHandsList[i].hvn == 10)
                { RoyalFlushCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 9)
                { StraightFlushCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 8)
                {FourOfAKindCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 7)
                { FullHouseCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 6)
                { FlushCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 5)
                { StraightCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 4)
                { ThreeOfAKindCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 3)
                { TwoPairCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 2)
                { PairCount++; }
            }

            for (int i = 0; i < evaluatedHandsList.Count - 1; i++)
            {
                if (evaluatedHandsList[i].hvn == 1)
                { HighCardCount++; }
            }

            #endregion

            NumberOfHands = evaluatedHandsList.Count;
            //this._HandNumber = NumberOfHands; //post-increment NumberOfHands
        }





        #endregion


        #region Property Blocks
        

        
        public static int NumberOfHands
        {
            get
            {
                return _NumberOfHands;
            }

            set
            {
                _NumberOfHands = value;
            }
        }

        public int RoyalFlushCount
        {
            get
            {
                return _RoyalFlushCount;
            }

            set
            {
                _RoyalFlushCount = value;
            }
        }

        public int StraightFlushCount
        {
            get
            {
                return _StraightFlushCount;
            }

            set
            {
                _StraightFlushCount = value;
            }
        }

        public int FourOfAKindCount
        {
            get
            {
                return _FourOfAKindCount;
            }

            set
            {
                _FourOfAKindCount = value;
            }
        }

        public int FullHouseCount
        {
            get
            {
                return _FullHouseCount;
            }

            set
            {
                _FullHouseCount = value;
            }
        }

        public int FlushCount
        {
            get
            {
                return _FlushCount;
            }

            set
            {
                _FlushCount = value;
            }
        }

        public int StraightCount
        {
            get
            {
                return _StraightCount;
            }

            set
            {
                _StraightCount = value;
            }
        }

        public int ThreeOfAKindCount
        {
            get
            {
                return _ThreeOfAKindCount;
            }

            set
            {
                _ThreeOfAKindCount = value;
            }
        }

        public int TwoPairCount
        {
            get
            {
                return _TwoPairCount;
            }

            set
            {
                _TwoPairCount = value;
            }
        }

        public int PairCount
        {
            get
            {
                return _PairCount;
            }

            set
            {
                _PairCount = value;
            }
        }

        public int HighCardCount
        {
            get
            {
                return _HighCardCount;
            }

            set
            {
                _HighCardCount = value;
            }
        }




        #endregion



    }

    #endregion

    #region Sortable Binding List Class Override
    public class SortableBindingList<T> : BindingList<T>
    {
        private ArrayList sortedList;
        private ArrayList unsortedItems;
        private bool isSortedValue;

        public SortableBindingList()
        {
        }

        public SortableBindingList(IList<T> list)
        {
            foreach (object o in list)
            {
                this.Add((T)o);
            }
        }

        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
            T item;

            if (key != null)
            {
                for (int i = 0; i < Count; ++i)
                {
                    item = (T)Items[i];
                    if (propInfo.GetValue(item, null).Equals(key))
                        return i;
                }
            }
            return -1;
        }

        public int Find(string property, object key)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor prop = properties.Find(property, true);

            if (prop == null)
                return -1;
            else
                return FindCore(prop, key);
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }


        protected override bool IsSortedCore
        {
            get { return isSortedValue; }
        }

        ListSortDirection sortDirectionValue;
        PropertyDescriptor sortPropertyValue;

        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            sortedList = new ArrayList();

            Type interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType)
            {
                Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null)
                {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }

            if (interfaceType != null)
            {
                sortPropertyValue = prop;
                sortDirectionValue = direction;

                IEnumerable<T> query = base.Items;
                if (direction == ListSortDirection.Ascending)
                {
                    query = query.OrderBy(i => prop.GetValue(i));
                }
                else
                {
                    query = query.OrderByDescending(i => prop.GetValue(i));
                }
                int newIndex = 0;
                foreach (object item in query)
                {
                    this.Items[newIndex] = (T)item;
                    newIndex++;
                }
                isSortedValue = true;
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));

            }
            else
            {
                throw new NotSupportedException("Cannot sort by " + prop.Name +
                    ". This" + prop.PropertyType.ToString() +
                    " does not implement IComparable");
            }
        }

        protected override void RemoveSortCore()
        {
            int position;
            object temp;

            if (unsortedItems != null)
            {
                for (int i = 0; i < unsortedItems.Count;)
                {
                    position = this.Find("LastName",
                        unsortedItems[i].GetType().
                        GetProperty("LastName").GetValue(unsortedItems[i], null));
                    if (position > 0 && position != i)
                    {
                        temp = this[i];
                        this[i] = this[position];
                        this[position] = (T)temp;
                        i++;
                    }
                    else if (position == i)
                        i++;
                    else
                        unsortedItems.RemoveAt(i);
                }
                isSortedValue = false;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        public void RemoveSort()
        {
            RemoveSortCore();
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyValue; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionValue; }
        }

    }


    #endregion


}//close namespace
