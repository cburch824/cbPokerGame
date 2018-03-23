using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace cBurch_Final_Project___Poker_Game
{
    class clsCharacterDataLayer
    {

        #region Class Data Members
        private OleDbConnection charConnection;
        private OleDbCommand charComm;
        private OleDbDataReader charReader;

        #endregion

        #region Class Constructors
        /// <summary>
        /// Attempts to connect to the character database. Failure will close the program.
        /// </summary>
        /// <param name="f1">The form that is currently attempting to connect to the database.</param>
        public clsCharacterDataLayer(Form f1)
        {
            //Attempt to establish a connection to the database
            try
            {
                string charConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=characterDatabase.accdb";
                charConnection = new OleDbConnection(charConnString);
                charConnection.Open();
            }
            catch(OleDbException)
            {
                MessageBox.Show("Could not open a database connection with the specified charConnString.The Program will now close.", "OLEDBConnection Error");
                f1.Close();
            }
        }
        #endregion

        #region Class Property Blocks
        //None.
        #endregion

        #region Class Methods
            /// <summary>
            /// Retrieves a list of characters and their stats from the characterDatabase's Characters table.
            /// </summary>
            /// <returns></returns>
        public List<clsCharacter> getCharactersFromDatabase()
        {
            //create a list to store the character data
            List<clsCharacter> allCharacters = new List<clsCharacter>();

            //SQL command string - select all from the characterDatabase Characters table
            string selCharacters = "SELECT * FROM Characters";

            //prepare the charComm object for executing the SQL command stored in selCharacters
            charComm = new OleDbCommand(selCharacters, charConnection);

            //use the charReader object to execute the charComm's SQL command, and close the connection when it is done
            charReader = charComm.ExecuteReader(CommandBehavior.CloseConnection);

            while (charReader.Read())  //read until the end of the database is reached
            {

                //store the data from the current character object in individual variables
                string name = charReader["CharacterName"].ToString();
                int aggression = (int)charReader["Aggression"];
                int luck = (int)charReader["Luck"];
                int randomness = (int)charReader["Randomness"];
                int intelligence = (int)charReader["Intelligence"];
                string imageString = charReader["Picture"].ToString();


                //populate a new character object with those variables
                clsCharacter c = new clsCharacter(name, aggression, intelligence, randomness, luck, Image.FromFile(imageString));

                //add that new character to the List<clsCharacter> object
                allCharacters.Add(c);

            }

            charReader.Close();

            return allCharacters;

        }
        /// <summary>
        /// Retrieves the database's Money value for a given character.
        /// </summary>
        /// <param name="c">The character whose money value we are retrieving.</param>
        /// <returns>The returned money value that was stored in the database.</returns>
        public int getCharacterMoneyAmount(clsCharacter c)
        {

            int characterMoneyValue = 0;

            //SQL command string - select all from the characterDatabase Characters table
            string selMoney = "SELECT * FROM Characters "  +
                "WHERE CharacterName=?";

            //Add a parameter for the above statement
            OleDbParameter paramCharName = new OleDbParameter("CharacterName", c.Name);
            charComm.Parameters.Add(paramCharName);

            //prepare the charComm object for executing the SQL command stored in selCharacters
            charComm = new OleDbCommand(selMoney, charConnection);

            //use the charReader object to execute the charComm's SQL command, and close the connection when it is done
            charReader = charComm.ExecuteReader(CommandBehavior.CloseConnection);

            while(charReader.Read())
            {
                characterMoneyValue = (int)charReader["Money"];
            }

            return characterMoneyValue;
        }
        #endregion






    }//close clsCharacterDataLayer Class
}//close namespace
