using DeweyDecimalSystemTrainer.Forms;
using DeweyDecimalSystemTrainer.Logic;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeweyDecimalSystemTrainer
{
    public partial class ReplacingBooks : Form
    {
        //userDetails object
        Details userDetails = new Details();



        //Declarations
        public List<string> correctCallNum = new List<string>();
        public List<string> userInput = new List<string>();
        public List<string> rndCallNum = new List<string>();


        public ReplacingBooks()
        {
            InitializeComponent();

            userDetails = userDetails.Instance();


        }


        private void ReplacingBooks_Load(object sender, EventArgs e)
        {
            //sets username label
            usernameLabel.Text = "Welcome: " + userDetails.getUsername(0);

            //calls methods on form start

            Generate gen = new Generate();

            correctCallNum = gen.generateCallNumbers();
            //  correctCallNum = generateCallNumbers();

            gen.orderDouble(correctCallNum);
            // orderDouble();

            gen.CovertTo3Digit(correctCallNum);

            gen.randomizeCallNum(correctCallNum, rndCallNum);

            setButtonText();

        }

        #region AnswerButtons
        //checks if answer is correct or incorrect and updates DB
        private void checkButton1_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = userDetails.getConnection();

            checkErrorProvider.Clear();

            if (userInput.Count() < 10)
            {
                checkErrorProvider.SetError(checkButton1, "Please select 10 Call Numbers!");
            }
            else
            {

                //if statement to check if user answer is correct
                if (userInput.SequenceEqual(correctCallNum))
                {
                    //if user input is correct: Changes label and updates total wins
                    successlabel.Visible = true;
                    successlabel.Text = "Correct!";
                    successlabel.ForeColor = Color.Green;
                    succPictureBox.Visible = true;
                    setCorrectButtonText();

                    //disables check button so user cant submit same answer twice
                    checkButton1.Enabled = false;

                    //opens connection to DB
                    try
                    {
                        //userDetails.getConnection().Open();
                        con.Open();
                        Console.WriteLine("Opened");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("DB con error");
                    }

                    //updates specific users total wins in SQLite DB
                    SQLiteCommand command2 = con.CreateCommand();
                    command2.CommandText = "UPDATE UserInfo SET ReplaceWins=ReplaceWins + 1 WHERE Username=@Username";
                    command2.Parameters.AddWithValue("@Username", userDetails.getUsername(0));

                    command2.ExecuteReader();

                    con.Close();

                }
                else
                {
                    //if user input is incorrect: changes label and updates total losses 
                    successlabel.Visible = true;
                    successlabel.Text = "Incorrect!";
                    successlabel.ForeColor = Color.Red;
                    failPictureBox.Visible = true;
                    setCorrectButtonText();

                    //disables check button so user cant submit same answer twice
                    checkButton1.Enabled = false;

                    try
                    {

                        con.Open();
                        Console.WriteLine("Opened");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("DB con error");
                    }

                    //updates specific users total loses in SQLite DB
                    SQLiteCommand command2 = con.CreateCommand();
                    command2.CommandText = "UPDATE UserInfo SET ReplaceLoses=ReplaceLoses + 1 WHERE Username=@Username";
                    command2.Parameters.AddWithValue("@Username", userDetails.getUsername(0));

                    command2.ExecuteReader();

                    con.Close();
                }
            }


        }

        //resets answers and allows user to try again
        private void tryAgainButtons_Click(object sender, EventArgs e)
        {

            //clears all textboxes and lists
            correctCallNum.Clear();
            userInput.Clear();
            rndCallNum.Clear();
            successlabel.Visible = false;
            succPictureBox.Visible = false;
            failPictureBox.Visible = false;

            //re enables buttons
            firstNumBtn.Enabled = true;
            secondNumBtn.Enabled = true;
            thirdNumBtn.Enabled = true;
            fourthNumBtn.Enabled = true;
            fifthNumBtn.Enabled = true;
            sixthNumBtn.Enabled = true;
            seventhNumBtn.Enabled = true;
            eightNumBtn.Enabled = true;
            nineNumBtn.Enabled = true;
            tenNumBtn.Enabled = true;
            checkButton1.Enabled = true;

            //calls methods on form start
            Generate gen = new Generate();
            correctCallNum = gen.generateCallNumbers();
            // correctCallNum = generateCallNumbers();

            gen.orderDouble(correctCallNum);

            gen.CovertTo3Digit(correctCallNum);

            gen.randomizeCallNum(correctCallNum, rndCallNum);

            setButtonText();

            setUserText();

            resetCorrectButtonText();

        }

        #endregion
        private void leaderboardButtons1_Click(object sender, EventArgs e)
        {

            //sends user to Identifying Area form and passes username
            ReplacingBooksLeaderboard next = new ReplacingBooksLeaderboard();
            this.Hide();
            next.StartPosition = FormStartPosition.Manual;
            next.Location = new Point(this.Location.X, this.Location.Y);
            next.ShowDialog();
            this.Close();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            //sends user to Identifying Area form and passes username
            MainMenu next = new MainMenu();
            this.Hide();
            next.StartPosition = FormStartPosition.Manual;
            next.Location = new Point(this.Location.X, this.Location.Y);
            next.ShowDialog();
            this.Close();
        }




        //-----------------------------Methods---------------------------------------//
        #region ButtonEvents

        private void firstNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            firstNumBtn.Enabled = false;


            //adds button text to userInput list
            userInput.Add(firstNumBtn.Text);

            setUserText();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            secondNumBtn.Enabled = false;


            //adds button text to userInput list
            userInput.Add(secondNumBtn.Text);

            //sets user input button text
            setUserText();



        }

        private void thirdNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            thirdNumBtn.Enabled = false;


            //adds button text to userInput list
            userInput.Add(thirdNumBtn.Text);

            //sets user input button text
            setUserText();

        }

        private void fourthNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            fourthNumBtn.Enabled = false;

            //adds button text to userInput list
            userInput.Add(fourthNumBtn.Text);

            //sets user input button text
            setUserText();

        }

        private void fifthNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            fifthNumBtn.Enabled = false;

            //adds button text to userInput list
            userInput.Add(fifthNumBtn.Text);

            //sets user input button text
            setUserText();

        }

        private void sixthNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            sixthNumBtn.Enabled = false;

            //adds button text to userInput list
            userInput.Add(sixthNumBtn.Text);

            //sets user input button text
            setUserText();

        }

        private void seventhNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            seventhNumBtn.Enabled = false;

            //adds button text to userInput list
            userInput.Add(seventhNumBtn.Text);

            //sets user input button text
            setUserText();

        }

        private void eightNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            eightNumBtn.Enabled = false;


            //adds button text to userInput list
            userInput.Add(eightNumBtn.Text);

            //sets user input button text
            setUserText();

        }

        private void nineNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            nineNumBtn.Enabled = false;


            //adds button text to userInput list
            userInput.Add(nineNumBtn.Text);

            //sets user input button text
            setUserText();

        }

        private void tenNumBtn_Click(object sender, EventArgs e)
        {
            //Disables button once clicked
            tenNumBtn.Enabled = false;


            //adds button text to userInput list
            userInput.Add(tenNumBtn.Text);

            //sets user input button text
            setUserText();

        }
        #endregion
        private void successlabel_Click(object sender, EventArgs e)
        {

        }

        #region setButtonText
        //method to set all button text and button colours
        private void setButtonText()
        {
            //sets button text to specific index in random call numbers list
            firstNumBtn.Text = rndCallNum.ElementAt(0).ToString();
            secondNumBtn.Text = rndCallNum.ElementAt(1).ToString();
            thirdNumBtn.Text = rndCallNum.ElementAt(2).ToString();
            fourthNumBtn.Text = rndCallNum.ElementAt(3).ToString();
            fifthNumBtn.Text = rndCallNum.ElementAt(4).ToString();
            sixthNumBtn.Text = rndCallNum.ElementAt(5).ToString();
            seventhNumBtn.Text = rndCallNum.ElementAt(6).ToString();
            eightNumBtn.Text = rndCallNum.ElementAt(7).ToString();
            nineNumBtn.Text = rndCallNum.ElementAt(8).ToString();
            tenNumBtn.Text = rndCallNum.ElementAt(9).ToString();


        }

        //sets the button text for the correct answer
        private void setCorrectButtonText()
        {
            //sets button text to specific index in random call numbers list
            correctButton1.Text = correctCallNum.ElementAt(0).ToString();
            correctButton2.Text = correctCallNum.ElementAt(1).ToString();
            correctButton3.Text = correctCallNum.ElementAt(2).ToString();
            correctButton4.Text = correctCallNum.ElementAt(3).ToString();
            correctButton5.Text = correctCallNum.ElementAt(4).ToString();
            correctButton6.Text = correctCallNum.ElementAt(5).ToString();
            correctButton7.Text = correctCallNum.ElementAt(6).ToString();
            correctButton8.Text = correctCallNum.ElementAt(7).ToString();
            correctButton9.Text = correctCallNum.ElementAt(8).ToString();
            correctButton10.Text = correctCallNum.ElementAt(9).ToString();

        }

        //sets the button text to hide correct answer
        private void resetCorrectButtonText()
        {
            correctButton1.Text = "***";
            correctButton2.Text = "***";
            correctButton3.Text = "***";
            correctButton4.Text = "***";
            correctButton5.Text = "***";
            correctButton6.Text = "***";
            correctButton7.Text = "***";
            correctButton8.Text = "***";
            correctButton9.Text = "***";
            correctButton10.Text = "***";


        }

        //sets user input button text
        private void setUserText()
        {


            //sets button text or leaves blank
            try
            {
                userInputButton1.Text = userInput.ElementAt(0).ToString();
            }
            catch (Exception)
            {

                userInputButton1.Text = "???";
            }

            try
            {
                userInputButton2.Text = userInput.ElementAt(1).ToString();
            }
            catch (Exception)
            {

                userInputButton2.Text = "???";
            }

            try
            {
                userInputButton3.Text = userInput.ElementAt(2).ToString();
            }
            catch (Exception)
            {

                userInputButton3.Text = "???";
            }

            try
            {
                userInputButton4.Text = userInput.ElementAt(3).ToString();
            }
            catch (Exception)
            {

                userInputButton4.Text = "???";
            }

            try
            {
                userInputButton5.Text = userInput.ElementAt(4).ToString();
            }
            catch (Exception)
            {

                userInputButton5.Text = "???";
            }

            try
            {
                userInputButton6.Text = userInput.ElementAt(5).ToString();
            }
            catch (Exception)
            {

                userInputButton6.Text = "???";
            }

            try
            {
                userInputButton7.Text = userInput.ElementAt(6).ToString();
            }
            catch (Exception)
            {

                userInputButton7.Text = "???";
            }

            try
            {
                userInputButton8.Text = userInput.ElementAt(7).ToString();
            }
            catch (Exception)
            {

                userInputButton8.Text = "???";
            }

            try
            {
                userInputButton9.Text = userInput.ElementAt(8).ToString();
            }
            catch (Exception)
            {

                userInputButton9.Text = "???";
            }

            try
            {
                userInputButton10.Text = userInput.ElementAt(9).ToString();
            }
            catch (Exception)
            {

                userInputButton10.Text = "???";
            }

        }





        #endregion

        private void homeButtons_Click(object sender, EventArgs e)
        {
            //sends user to next page and starts form at previous form location
            MainMenu next = new MainMenu();
            this.Hide();
            next.StartPosition = FormStartPosition.Manual;
            next.Location = new Point(this.Location.X, this.Location.Y);
            next.ShowDialog();
            this.Close();
        }
    }



}

//------------------------------End Of File---------------------------------------//
