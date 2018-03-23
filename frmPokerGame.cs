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

namespace cBurch_Final_Project___Poker_Game
{
    public partial class frmPokerGame : Form
    {
        clsSeat seat1,
            seat2,
            seat3,
            seat4,
            seat5,
            seat6;

        Boolean startNextHand;

        clsCardDeck gameDeck;
        clsCommunityCards board;

        List<clsHandLog> handArrayList = new List<clsHandLog>();

        

        private void btnNextHand_Click(object sender, EventArgs e)
        {
            dealNextHand();
            dealFlop();
            dealTurn();
            dealRiver();
            recordHand();
            clsEvaluateHand playerHandEvaluator = new clsEvaluateHand(seat1.Hand, board);
            HandEnum playerHandValue = playerHandEvaluator.EvaluateHand();
            lblSeat1HandValue.Text = playerHandEvaluator.getHandValueText(playerHandValue);

        }



        private void radioBtnStartNextHand_CheckedChanged(object sender, EventArgs e)
        {
            if(radioBtnStartNextHand.Checked == true)
                { startNextHand = true; }

            if(radioBtnStartNextHand.Checked == false)
                { startNextHand = false; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmPokerGame(clsCharacter c1, clsCharacter c2, clsCharacter c3, clsCharacter c4, clsCharacter c5, clsCharacter c6, int startingMoney, int smallBlind, int bigBlind, Color bc, Color fc)
        {

            InitializeComponent();

            int initialBet = bigBlind;

            seat1 = new clsSeat(1, startingMoney, initialBet, c1);
            seat2 = new clsSeat(2, startingMoney, initialBet, c2);
            seat3 = new clsSeat(3, startingMoney, initialBet, c3);
            seat4 = new clsSeat(4, startingMoney, initialBet, c4);
            seat5 = new clsSeat(5, startingMoney, initialBet, c5);
            seat6 = new clsSeat(6, startingMoney, initialBet, c6);
            this.BackColor = bc;
            this.ForeColor = fc;
        }

        private void PokerGame_Load(object sender, EventArgs e)
        {
            startNextHand = false;

            lblSeat1Name.Text = seat1.Character.Name;
            lblSeat1Status.Text = "Waiting for game to start.";
            lblMoneySeat1.Text = seat1.Money.ToString();
            picSeat1.Image = seat1.Character.Picture;

            lblSeat2Name.Text = seat2.Character.Name;
            lblSeat2Status.Text = "Waiting for game to start.";
            lblMoneySeat2.Text = seat2.Money.ToString();
            picSeat2.Image = seat2.Character.Picture;

            lblSeat3Name.Text = seat3.Character.Name;
            lblSeat3Status.Text = "Waiting for game to start.";
            lblMoneySeat3.Text = seat3.Money.ToString();
            picSeat3.Image = seat3.Character.Picture;

            lblSeat4Name.Text = seat4.Character.Name;
            lblSeat4Status.Text = "Waiting for game to start.";
            lblMoneySeat4.Text = seat4.Money.ToString();
            picSeat4.Image = seat4.Character.Picture;

            lblSeat5Name.Text = seat5.Character.Name;
            lblSeat5Status.Text = "Waiting for game to start.";
            lblMoneySeat5.Text = seat5.Money.ToString();
            picSeat5.Image = seat5.Character.Picture;

            lblSeat6Name.Text = seat6.Character.Name;
            lblSeat6Status.Text = "Waiting for game to start.";
            lblMoneySeat6.Text = seat6.Money.ToString();
            picSeat6.Image = seat6.Character.Picture;

            gameDeck = new clsCardDeck();       //instantiate the deck
            gameDeck.shuffleDeck();                         //shuffle it for the first time

            board = new clsCommunityCards();

        }

        public void dealNextHand()
        {
            gameDeck.shuffleDeck();     //shuffle the deck
            board.clearCommunityCards();

            clsSeat[] seatArray = new clsSeat[6] { seat1, seat2, seat3, seat4, seat5, seat6 };

            //deal out first card to each player
            for (int i = 0; i < 6; i++) //array size of 6, therefore i < 6 for count control
            {
                seatArray[i].Hand.Card1 = gameDeck.deck[gameDeck.CurrentCard];
                gameDeck.moveToNextCard();
            }

            //deal out second card to each player
            for(int i = 0; i < 6; i++)
            {
                seatArray[i].Hand.Card2 = gameDeck.deck[gameDeck.CurrentCard];
                gameDeck.moveToNextCard();
            }

            //change the test labels to the cards for the player
            lblPlayerCard1.Text = gameDeck.getCardPip(seat1.Hand.Card1);
            lblPlayerCard2.Text = gameDeck.getCardPip(seat1.Hand.Card2);

        }//close dealNextHand() method

        private void btnPrintHands_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }//close click print button

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Top - 80;
            int y = e.MarginBounds.Left - 80;

            Font headerFont = new Font("Arial", 18);
            Font smallFont = new Font("Times New Roman", 12);
            Brush blackBrush = Brushes.Black;

            e.Graphics.DrawString("Poker Hand Log", headerFont, blackBrush, x, y);

            y += 40;

            for(int i = 0; i < handArrayList.Count; i++)
            {
                //e.Graphics.DrawString("Hand " + (i + 1), smallFont, blackBrush, x, y);
                //y += 20;
                e.Graphics.DrawString(("Hand" + (i+1) + handArrayList[i].printLog()), smallFont, blackBrush, x, y);
                y += 80;

            }

        }//close printDocument1_PrintPage method

        public void dealFlop()
        {
            board.FirstBurn = gameDeck.deck[gameDeck.CurrentCard];
            gameDeck.moveToNextCard();

            board.FirstCard = gameDeck.deck[gameDeck.CurrentCard];
            lblFlop1.Text = gameDeck.getCardPip(board.FirstCard);
            gameDeck.moveToNextCard();

            board.SecondCard = gameDeck.deck[gameDeck.CurrentCard];
            lblFlop2.Text = gameDeck.getCardPip(board.SecondCard);
            gameDeck.moveToNextCard();

            board.ThirdCard = gameDeck.deck[gameDeck.CurrentCard];
            lblFlop3.Text = gameDeck.getCardPip(board.ThirdCard);
            gameDeck.moveToNextCard();

            board.communityFlopAddCards();

        }//close dealFlop method

        public void dealTurn()
        {
            board.SecondBurn = gameDeck.CurrentCard;
            gameDeck.moveToNextCard();

            board.FourthCard = gameDeck.deck[gameDeck.CurrentCard];
            lblTurn.Text = gameDeck.getCardPip(board.FourthCard);
            gameDeck.moveToNextCard();

            board.communityTurnAddCards();

        }//close dealTurn method

        public void dealRiver()
        {
            board.FifthCard = gameDeck.deck[gameDeck.CurrentCard];
            lblRiver.Text = gameDeck.getCardPip(board.FifthCard);
            gameDeck.moveToNextCard();

            board.communityRiverAddCards();

        }//close dealRiver method

        public void determineWinner()
        {


        }

        public void recordHand()
        {
            clsHandLog handLog = new clsHandLog(gameDeck.getCardPip(seat1.Hand.Card1), gameDeck.getCardPip(seat1.Hand.Card2),
                gameDeck.getCardPip(seat2.Hand.Card1), gameDeck.getCardPip(seat2.Hand.Card2), 
                gameDeck.getCardPip(seat3.Hand.Card1), gameDeck.getCardPip(seat3.Hand.Card2), 
                gameDeck.getCardPip(seat4.Hand.Card1), gameDeck.getCardPip(seat4.Hand.Card2), 
                gameDeck.getCardPip(seat5.Hand.Card1), gameDeck.getCardPip(seat5.Hand.Card2), 
                gameDeck.getCardPip(seat6.Hand.Card1), gameDeck.getCardPip(seat6.Hand.Card2), 
                gameDeck.getCardPip(board.FirstCard), gameDeck.getCardPip(board.SecondCard), gameDeck.getCardPip(board.ThirdCard), gameDeck.getCardPip(board.FourthCard) ,  gameDeck.getCardPip(board.FifthCard));

            handArrayList.Add(handLog);
        }//close recordHand method


       

    }//close PokerGame class
}// close namespace
