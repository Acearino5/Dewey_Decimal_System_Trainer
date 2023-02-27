using DeweyDecimalSystemTrainer.Forms;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace DeweyDecimalSystemTrainer
{
    public partial class MainMenu : Form
    {
        //user details object
        Details userDetails = new Details();


        public MainMenu()
        {
            InitializeComponent();



            //calls singleton instance
            userDetails = userDetails.Instance();


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //clears logged in user when main menu return
            userDetails.username.Clear();
        }



        //button to send user to replacing books form
        private void replacingBookBtn_Click_1(object sender, EventArgs e)
        {
            SQLiteConnection con = userDetails.getConnection();
            //if statement displays errorprovider if textbox is empty
            if (usernameTextBox.Text == "")
            {
                errorProvider1.SetError(usernameTextBox, "Please enter a Username!");
            }
            else
            {
                //if statment calls CheckUsername method
                if (CheckUsername() == true)
                {
                    ////opens connection to SQLite DB
                    try
                    {

                        con.Open();
                        Console.WriteLine("Opened");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("DB con error");
                    }


                    //inserts username and temp values for wins/loses to SQLite DB
                    SQLiteCommand command2 = con.CreateCommand();
                    command2.CommandText = "INSERT INTO UserInfo (Username,ReplaceWins, ReplaceLoses,IdentifyWins,IdentifyLoses,FindingCallWins,FindingCallLoses) values (@Username,@ReplaceWins,@ReplaceLoses,@IdentifyWins,@IdentifyLoses,@FindingCallWins,@FindingCallLoses)";
                    command2.Parameters.AddWithValue("@Username", usernameTextBox.Text);
                    command2.Parameters.AddWithValue("@ReplaceWins", 0);
                    command2.Parameters.AddWithValue("@ReplaceLoses", 0);
                    command2.Parameters.AddWithValue("@IdentifyWins", 0);
                    command2.Parameters.AddWithValue("@IdentifyLoses", 0);
                    command2.Parameters.AddWithValue("@FindingCallWins", 0);
                    command2.Parameters.AddWithValue("@FindingCallLoses", 0);


                    command2.ExecuteReader();

                    con.Close();

                    //sets username
                    userDetails.setUsername(usernameTextBox.Text);

                    //sends user to Identifying Area form and passes username
                    ReplacingBooks next = new ReplacingBooks();
                    this.Hide();
                    next.StartPosition = FormStartPosition.Manual;
                    next.Location = new Point(this.Location.X, this.Location.Y);
                    next.ShowDialog();
                    this.Close();
                }
                else
                {
                    //sets username 
                    userDetails.setUsername(usernameTextBox.Text);

                    //sends user to Identifying Area form and passes username
                    ReplacingBooks next = new ReplacingBooks();
                    this.Hide();
                    next.StartPosition = FormStartPosition.Manual;
                    next.Location = new Point(this.Location.X, this.Location.Y);
                    next.ShowDialog();
                    this.Close();

                }

            }

        }

        private void identifyAreaButton1_Click(object sender, EventArgs e)
        {

            SQLiteConnection con = userDetails.getConnection();
            //if statement displays errorprovider if textbox is empty
            if (usernameTextBox.Text == "")
            {
                errorProvider1.SetError(usernameTextBox, "Please enter a Username!");
            }
            else
            {
                //if statment calls CheckUsername method
                if (CheckUsername() == true)
                {
                    ////opens connection to SQLite DB
                    try
                    {

                        con.Open();
                        Console.WriteLine("Opened");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("DB con error");
                    }


                    //inserts username and temp values for wins/loses to SQLite DB
                    SQLiteCommand command2 = con.CreateCommand();
                    command2.CommandText = "INSERT INTO UserInfo (Username,ReplaceWins, ReplaceLoses,IdentifyWins,IdentifyLoses,FindingCallWins,FindingCallLoses) values (@Username,@ReplaceWins,@ReplaceLoses,@IdentifyWins,@IdentifyLoses,@FindingCallWins,@FindingCallLoses)";
                    command2.Parameters.AddWithValue("@Username", usernameTextBox.Text);
                    command2.Parameters.AddWithValue("@ReplaceWins", 0);
                    command2.Parameters.AddWithValue("@ReplaceLoses", 0);
                    command2.Parameters.AddWithValue("@IdentifyWins", 0);
                    command2.Parameters.AddWithValue("@IdentifyLoses", 0);
                    command2.Parameters.AddWithValue("@FindingCallWins", 0);
                    command2.Parameters.AddWithValue("@FindingCallLoses", 0);

                    command2.ExecuteReader();

                    con.Close();

                    //sets username
                    userDetails.setUsername(usernameTextBox.Text);

                    //sends user to Identifying Area form and passes username
                    IdentifyingAreas next = new IdentifyingAreas();
                    this.Hide();
                    // next.StartPosition = FormStartPosition.CenterScreen;
                    next.StartPosition = FormStartPosition.Manual;
                    next.Location = new Point(this.Location.X, this.Location.Y);
                    next.ShowDialog();
                    this.Close();
                }
                else
                {
                    //sets username 
                    userDetails.setUsername(usernameTextBox.Text);

                    //sends user to Identifying Area form and passes username
                    IdentifyingAreas next = new IdentifyingAreas();
                    this.Hide();
                    // next.StartPosition = FormStartPosition.CenterScreen;
                    next.StartPosition = FormStartPosition.Manual;
                    next.Location = new Point(this.Location.X, this.Location.Y);
                    next.ShowDialog();
                    this.Close();

                }

            }
        }

        private void findingCallNumButton1_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = userDetails.getConnection();
            //if statement displays errorprovider if textbox is empty
            if (usernameTextBox.Text == "")
            {
                errorProvider1.SetError(usernameTextBox, "Please enter a Username!");
            }
            else
            {
                //if statment calls CheckUsername method
                if (CheckUsername() == true)
                {
                    ////opens connection to SQLite DB
                    try
                    {

                        con.Open();
                        Console.WriteLine("Opened");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("DB con error");
                    }


                    //inserts username and temp values for wins/loses to SQLite DB
                    SQLiteCommand command2 = con.CreateCommand();
                    command2.CommandText = "INSERT INTO UserInfo (Username,ReplaceWins, ReplaceLoses,IdentifyWins,IdentifyLoses,FindingCallWins,FindingCallLoses) values (@Username,@ReplaceWins,@ReplaceLoses,@IdentifyWins,@IdentifyLoses,@FindingCallWins,@FindingCallLoses)";
                    command2.Parameters.AddWithValue("@Username", usernameTextBox.Text);
                    command2.Parameters.AddWithValue("@ReplaceWins", 0);
                    command2.Parameters.AddWithValue("@ReplaceLoses", 0);
                    command2.Parameters.AddWithValue("@IdentifyWins", 0);
                    command2.Parameters.AddWithValue("@IdentifyLoses", 0);
                    command2.Parameters.AddWithValue("@FindingCallWins", 0);
                    command2.Parameters.AddWithValue("@FindingCallLoses", 0);

                    command2.ExecuteReader();

                    con.Close();

                    //sets username
                    userDetails.setUsername(usernameTextBox.Text);

                    //sends user to Identifying Area form and passes username
                    FindingCallNumbers next = new FindingCallNumbers();
                    this.Hide();
                    next.StartPosition = FormStartPosition.Manual;
                    next.Location = new Point(this.Location.X, this.Location.Y);
                    next.ShowDialog();
                    this.Close();
                }
                else
                {
                    //sets username 
                    userDetails.setUsername(usernameTextBox.Text);

                    //sends user to Identifying Area form and passes username
                    FindingCallNumbers next = new FindingCallNumbers();
                    this.Hide();
                    next.StartPosition = FormStartPosition.Manual;
                    next.Location = new Point(this.Location.X, this.Location.Y);
                    next.ShowDialog();
                    this.Close();

                }

            }



        }

        //------------------------------Methods---------------------------------------//

        //checks if username exsists in SQLite DB
        public Boolean CheckUsername()
        {
            string username = "!!!!";
            SQLiteConnection con = userDetails.getConnection();
            //opens connection to DB
            try
            {

                con.Open();
                Console.WriteLine("Opened");
            }
            catch (Exception)
            {
                Console.WriteLine("DB con error");
            }

            SQLiteDataReader dataReader;
            SQLiteCommand command = con.CreateCommand();

            //Selects username from DB that matches entered username
            command.CommandText = "SELECT Username FROM UserInfo WHERE Username=@username";
            command.Parameters.AddWithValue("@Username", usernameTextBox.Text);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                //if username exists in DB changes username string
                username = dataReader.GetString(0);

            }

            con.Close();

            //if username string changes then returns false
            if (username.Equals("!!!!"))
            {
                return true;
            }
            else
            {
                return false;
            }


        }




    }
}
//------------------------------End Of File---------------------------------------//