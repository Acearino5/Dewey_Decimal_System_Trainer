using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace DeweyDecimalSystemTrainer.Forms
{
    public class Details
    {
        private static Details myInstance;

        //singleton for user details
        public Details Instance()
        {
            if (myInstance == null)
                myInstance = new Details();

            return myInstance;
        }

        //username list
        public List<string> username = new List<string>();

        //sets and adds usernames to username list
        public void setUsername(string value1)
        {

            username.Add(value1);

        }

        //returns username from username list
        public string getUsername(int i)
        {

            return username.ElementAt(i).ToString();

        }




        //SQLite connection string 
        public SQLiteConnection getConnection()
        {

            SQLiteConnection con = new SQLiteConnection(@"Data Source=..\..\LeaderboardDB.db");
            return con;

        }

    }
}
//------------------------------End Of File---------------------------------------//
