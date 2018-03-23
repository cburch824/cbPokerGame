using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cBurch_Final_Project___Poker_Game
{
    

    public partial class frmMainMenu : Form
    {

        clsCharacter ch1;
        clsCharacter ch2;
        clsCharacter ch3;
        clsCharacter ch4;
        clsCharacter ch5;
        clsCharacter ch6;

        public int defaultMoney,
            bigBlind,
            smallBlind;

        public Color boardColor = Color.DarkGreen;
        public Color fontColor = Color.Yellow;

    
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Set the starting money, big blind, small blind, and bets
            defaultMoney = int.Parse(txtInitialMoney.Text);
            smallBlind = int.Parse(txtSmallBlind.Text);
            bigBlind = int.Parse(txtBigBlind.Text);

        


            //Create strings to try to load files with
            string seat1FileName = cmbSeat1.Text;
            string seat2FileName = cmbSeat2.Text;
            string seat3FileName = cmbSeat3.Text;
            string seat4FileName = cmbSeat4.Text;
            string seat5FileName = cmbSeat5.Text;
            string seat6FileName = cmbSeat6.Text;

            //Instantiate the characters to avoid null reference exceptions when setting their stats from files
            ch1 = new clsCharacter();
            ch2 = new clsCharacter();
            ch3 = new clsCharacter();
            ch4 = new clsCharacter();
            ch5 = new clsCharacter();
            ch6 = new clsCharacter();

            //Then load the character stats and images from file, if the files do not exist, then catch the exception and load defaults
            ch1 = readStatsFromFile(ch1, seat1FileName);
            ch1 = readCharacterImageFromFile(ch1, seat1FileName);

            ch2 = readStatsFromFile(ch2, seat2FileName);
            ch2 = readCharacterImageFromFile(ch2, seat2FileName);

            ch3 = readStatsFromFile(ch3, seat3FileName);
            ch3 = readCharacterImageFromFile(ch3, seat3FileName);

            ch4 = readStatsFromFile(ch4, seat4FileName);
            ch4 = readCharacterImageFromFile(ch4, seat4FileName);

            ch5 = readStatsFromFile(ch5, seat5FileName);
            ch5 = readCharacterImageFromFile(ch5, seat5FileName);

            ch6 = readStatsFromFile(ch6, seat6FileName);
            ch6 = readCharacterImageFromFile(ch6, seat6FileName);


            //Then open a PokerGame.cs form, sending the characters as parameters
            frmPokerGame gameInstance = new frmPokerGame(ch1, ch2, ch3, ch4, ch5, ch6, defaultMoney, smallBlind, bigBlind, boardColor, fontColor);
            gameInstance.Show();



        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialogFont.ShowDialog();
            if(result == DialogResult.OK)
            {
                fontColor = colorDialogFont.Color;
            }
        }

        private void btnBoardColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialogBoard.ShowDialog();
            if (result == DialogResult.OK)
            {
                boardColor = colorDialogBoard.Color;
            }
        }

        private void btnOpenHandEvalTest_Click(object sender, EventArgs e)
        {
            frmHandEvalTest testInstance = new frmHandEvalTest(ch1);
            testInstance.Show();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'characterDatabaseDataSet.Characters' table. You can move, or remove it, as needed.
            this.charactersTableAdapter.Fill(this.characterDatabaseDataSet.Characters);


            //set default characters for the comboboxes
            charactersBindingSource.Position = 0;
            charactersBindingSource1.Position = 1;
            charactersBindingSource2.Position = 2;
            charactersBindingSource3.Position = 3;
            charactersBindingSource4.Position = 4;
            charactersBindingSource5.Position = 5;

            string testString = "joe";
            readStatsFromDatabase(new clsCharacter(), testString, 10);


        }

        private clsCharacter readStatsFromDatabase(clsCharacter c, string s, int databaseIndex)
        {

            try
            {
                c.Name = characterDatabaseDataSet.Characters.CharacterNameColumn.ToString();
                //c.Name = characterDatabaseDataSet.Character["CharacterName"][databaseIndex];
                

            }
            catch
            {
                MessageBox.Show("An error has occurred - readStatsFromDatabase");
            }

            return c;


        }



        private clsCharacter readStatsFromFile(clsCharacter c, string s)
        {
            try
            {
                System.IO.StreamReader charFile = new System.IO.StreamReader(s + ".txt");
                c.Name = charFile.ReadLine();
                c.Aggression = int.Parse(charFile.ReadLine());
                c.Intelligence = int.Parse(charFile.ReadLine());
                c.Randomness = int.Parse(charFile.ReadLine());
                c.Luck = int.Parse(charFile.ReadLine());

            }
            catch(System.IO.FileNotFoundException)
            {
                MessageBox.Show("Stats file not found.\nCould not find " + s + ".txt file\nUsing default Character values.", "FNF Error");
                c = new clsCharacter();
            }
            catch(FormatException)
            {
                MessageBox.Show("Unable to parse a value in the character textfile.\nUsing default Character values.", "Integer Parsing Error");
                c = new clsCharacter();
            }
            catch
            {
                MessageBox.Show("Non-File Not Found Error.\nCheck to ensure character textfile follows the proper order and structure.\nUsing default Character values.", "Non-FNF Error.");
                c = new clsCharacter();
            }

            return c;
        }

        private clsCharacter readCharacterImageFromFile(clsCharacter c, string s)
        {
            try
            {
                c.Picture = Image.FromFile(s + ".jpg");

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Image file not found.\nUsing default Character values.", "FNF Error");
                c = new clsCharacter();
            }
            catch
            {
                MessageBox.Show("Non-File Not Found Error.\n\nUsing default Character values.", "Non-FNF Error.");
                c = new clsCharacter();
            }

            return c;

        }
    }
}
