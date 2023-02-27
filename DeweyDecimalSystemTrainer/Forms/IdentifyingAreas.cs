using DeweyDecimalSystemTrainer.Logic;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeweyDecimalSystemTrainer.Forms
{
    public partial class IdentifyingAreas : Form
    {
        //objects
        Details userDetails = new Details();
        matchTheColumn match = new matchTheColumn();


        //Variables
        List<string> correctCallNumOrder = new List<string>();
        List<string> correctCategoryOrder = new List<string>();
        List<string> randomCallNumOrder = new List<string>();
        List<string> randomCategoryOrder = new List<string>();
        Dictionary<string, string> dictionaryCallNum = new Dictionary<string, string>();
        Dictionary<string, string> userInputDictionary = new Dictionary<string, string>();
        List<string> userInputColumnA = new List<string>();
        List<string> userInputColumnB = new List<string>();
        bool alternateColumns;



        public IdentifyingAreas()
        {
            InitializeComponent();
            userDetails = userDetails.Instance();

        }


        private void IdentifyingAreas_Load(object sender, EventArgs e)
        {
            //sets username label
            welcomeLabel.Text = "Welcome: " + userDetails.getUsername(0);
            //  name = userDetails.getUsername(0); 

            //sets column boolean
            alternateColumns = true;

            //generate call numbers & category methods
            correctCallNumOrder = match.generateCallNumbers();
            match.CovertTo3Digit(correctCallNumOrder);
            dictionaryCallNum = match.getCorrectCallNumDictionary(correctCallNumOrder);

            //randomize the order of call numbers and categories
            match.randomizeCallNum(correctCallNumOrder, randomCallNumOrder);
            match.randomizeCategories(dictionaryCallNum, randomCategoryOrder);

            setButtonTextNumLeft();
            setUserText();
            resetCorrectButtonText();

        }

        #region ButtonEvents
        private void columnAButton1_Click(object sender, EventArgs e)
        {
            var Button = (Button)sender;
            switch (Button.Name)
            {
                case "columnAButton1":
                    //Disables button once clicked
                    columnAButton1.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnA.Add(columnAButton1.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnAButton2":
                    //Disables button once clicked
                    columnAButton2.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnA.Add(columnAButton2.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnAButton3":
                    //Disables button once clicked
                    columnAButton3.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnA.Add(columnAButton3.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnAButton4":
                    //Disables button once clicked
                    columnAButton4.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnA.Add(columnAButton4.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;

                case "columnBButton1":
                    //Disables button once clicked
                    columnBButton1.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnB.Add(columnBButton1.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnBButton2":
                    //Disables button once clicked
                    columnBButton2.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnB.Add(columnBButton2.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnBButton3":
                    //Disables button once clicked
                    columnBButton3.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnB.Add(columnBButton3.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnBButton4":
                    //Disables button once clicked
                    columnBButton4.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnB.Add(columnBButton4.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnBButton5":
                    //Disables button once clicked
                    columnBButton5.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnB.Add(columnBButton5.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnBButton6":
                    //Disables button once clicked
                    columnBButton6.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnB.Add(columnBButton6.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                case "columnBButton7":
                    //Disables button once clicked
                    columnBButton7.Enabled = false;
                    //adds button text to userInput list
                    userInputColumnB.Add(columnBButton7.Text);
                    //calls method to set answer button text
                    setUserText();
                    limitUserInput(userInputColumnA, userInputColumnB);
                    break;
                default:

                    break;
            }


        }

        private void checkAnswerButtons_Click(object sender, EventArgs e)
        {

            orderUserInput(alternateColumns);

            //try catch to check for user input
            try
            {
                //adds user inputs into dictionary
                if (alternateColumns == true)
                {
                    //call numbers on left dictionary
                    match.getUserInputDictionary(userInputColumnA, userInputColumnB, userInputDictionary);
                }
                else
                {
                    //call numbers on right dictionary
                    match.getUserInputDictionary(userInputColumnB, userInputColumnA, userInputDictionary);
                }
            }
            catch (Exception)
            {
                //error label
                checkErrorProvider.SetError(checkAnswerButtons, "Please select 4 Call Numbers and 4 categories!");
            }





            SQLiteConnection con = userDetails.getConnection();

            checkErrorProvider.Clear();

            //if to check for 4 call inputs and 4 category inputs
            if (userInputColumnA.Count() < 4 && userInputColumnB.Count() < 4)
            {
                checkErrorProvider.SetError(checkAnswerButtons, "Please select 4 Call Numbers and 4 categories!");
            }
            else
            {

                //if statement to check if user answer is correct
                if (userInputDictionary.OrderBy(r => r.Key).SequenceEqual(dictionaryCallNum.OrderBy(r => r.Key)))
                {
                    //if user input is correct: Changes label and updates total wins
                    answerLabel.Visible = true;
                    answerLabel.Text = "Correct!";
                    answerLabel.ForeColor = Color.Green;
                    succPictureBox.Visible = true;
                    setCorrectButtonText();

                    //disables check button so user cant submit same answer twice
                    checkAnswerButtons.Enabled = false;

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
                    command2.CommandText = "UPDATE UserInfo SET IdentifyWins=IdentifyWins + 1 WHERE Username=@Username";
                    command2.Parameters.AddWithValue("@Username", userDetails.getUsername(0));

                    command2.ExecuteReader();

                    con.Close();
                    setCorrectButtonText();
                }
                else
                {
                    //if user input is incorrect: changes label and updates total losses 
                    answerLabel.Visible = true;
                    answerLabel.Text = "Incorrect!";
                    answerLabel.ForeColor = Color.Red;
                    failPictureBox.Visible = true;
                    setCorrectButtonText();

                    //disables check button so user cant submit same answer twice
                    checkAnswerButtons.Enabled = false;

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
                    command2.CommandText = "UPDATE UserInfo SET IdentifyLoses=IdentifyLoses + 1 WHERE Username=@Username";
                    command2.Parameters.AddWithValue("@Username", userDetails.getUsername(0));

                    command2.ExecuteReader();

                    con.Close();
                    setCorrectButtonText();
                    changeButtonColour();
                    changeCorrectButtonColour();
                }
            }

        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            //clears lists and dictionaries
            correctCallNumOrder.Clear();
            randomCallNumOrder.Clear();
            randomCategoryOrder.Clear();
            dictionaryCallNum.Clear();
            userInputDictionary.Clear();
            userInputColumnA.Clear();
            userInputColumnB.Clear();

            //hides labels and enables buttons
            answerLabel.Visible = false;
            succPictureBox.Visible = false;
            failPictureBox.Visible = false;
            checkAnswerButtons.Enabled = true;

            //calls method to reset answer button text
            resetButtonColour();
            resetCorrectButtonText();
            setUserText();



            //if statement to alternate columns
            if (alternateColumns == false)
            {
                alternateColumns = true;
                //set button text



                //generate call numbers & category methods
                correctCallNumOrder = match.generateCallNumbers();
                match.CovertTo3Digit(correctCallNumOrder);
                dictionaryCallNum = match.getCorrectCallNumDictionary(correctCallNumOrder);

                //randomize the order of call numbers and categories
                match.randomizeCallNum(correctCallNumOrder, randomCallNumOrder);
                match.randomizeCategories(dictionaryCallNum, randomCategoryOrder);

                setButtonTextNumLeft();
            }
            else
            {

                alternateColumns = false;


                //generate call numbers & category methods
                correctCallNumOrder = match.generateSevenRandomCallNumbers();

                //converts 2 digit to 3 digit
                match.CovertTo3Digit(correctCallNumOrder);

                //gets correct categories saves to dictionary
                dictionaryCallNum = match.getCorrectCategoryDictonary(correctCallNumOrder);

                //randomize the order of call numbers and categories
                randomCallNumOrder = match.randomizeSevenCallNum(correctCallNumOrder);

                //sets categories                                             
                correctCategoryOrder = match.getCorrectCategoryOrder(dictionaryCallNum);

                //randomized list again incase of same memory address            
                randomCallNumOrder = Randomize(randomCallNumOrder);

                //set button text 

                setButtonTextNumRight();


            }





        }
        private void leaderboardButtons_Click(object sender, EventArgs e)
        {
            //sends user to next page and starts form at previous form location
            IdentifyAreaLeaderboard next = new IdentifyAreaLeaderboard();
            this.Hide();
            next.StartPosition = FormStartPosition.Manual;
            next.Location = new Point(this.Location.X, this.Location.Y);
            next.ShowDialog();
            this.Close();

        }

        #endregion

        //method to randomize call numbers incase program uses same memory slot
        public List<string> Randomize(List<string> items)
        {
            Random rand = new Random();
            string temp;
            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Count - 1; i++)
            {
                int j = rand.Next(i, items.Count);
                temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }

            return items;
        }


        #region setButtonText/Colour       
        private void setButtonTextNumLeft()
        {
            //sets column A button text
            columnAButton1.Text = randomCallNumOrder.ElementAt(0).ToString();
            columnAButton2.Text = randomCallNumOrder.ElementAt(1).ToString();
            columnAButton3.Text = randomCallNumOrder.ElementAt(2).ToString();
            columnAButton4.Text = randomCallNumOrder.ElementAt(3).ToString();

            //reenables buttons
            columnAButton1.Enabled = true;
            columnAButton2.Enabled = true;
            columnAButton3.Enabled = true;
            columnAButton4.Enabled = true;

            //sets column B button text
            columnBButton1.Text = randomCategoryOrder.ElementAt(0).ToString();
            columnBButton2.Text = randomCategoryOrder.ElementAt(1).ToString();
            columnBButton3.Text = randomCategoryOrder.ElementAt(2).ToString();
            columnBButton4.Text = randomCategoryOrder.ElementAt(3).ToString();
            columnBButton5.Text = randomCategoryOrder.ElementAt(4).ToString();
            columnBButton6.Text = randomCategoryOrder.ElementAt(5).ToString();
            columnBButton7.Text = randomCategoryOrder.ElementAt(6).ToString();

            //reenables buttons
            columnBButton1.Enabled = true;
            columnBButton2.Enabled = true;
            columnBButton3.Enabled = true;
            columnBButton4.Enabled = true;
            columnBButton5.Enabled = true;
            columnBButton6.Enabled = true;
            columnBButton7.Enabled = true;
        }

        private void setButtonTextNumRight()
        {
            //sets column A button text
            columnAButton1.Text = correctCategoryOrder.ElementAt(0).ToString();
            columnAButton2.Text = correctCategoryOrder.ElementAt(1).ToString();
            columnAButton3.Text = correctCategoryOrder.ElementAt(2).ToString();
            columnAButton4.Text = correctCategoryOrder.ElementAt(3).ToString();

            //reenables buttons
            columnAButton1.Enabled = true;
            columnAButton2.Enabled = true;
            columnAButton3.Enabled = true;
            columnAButton4.Enabled = true;

            //sets column B button text
            columnBButton1.Text = randomCallNumOrder.ElementAt(0).ToString();
            columnBButton2.Text = randomCallNumOrder.ElementAt(1).ToString();
            columnBButton3.Text = randomCallNumOrder.ElementAt(2).ToString();
            columnBButton4.Text = randomCallNumOrder.ElementAt(3).ToString();
            columnBButton5.Text = randomCallNumOrder.ElementAt(4).ToString();
            columnBButton6.Text = randomCallNumOrder.ElementAt(5).ToString();
            columnBButton7.Text = randomCallNumOrder.ElementAt(6).ToString();

            //reenables buttons
            columnBButton1.Enabled = true;
            columnBButton2.Enabled = true;
            columnBButton3.Enabled = true;
            columnBButton4.Enabled = true;
            columnBButton5.Enabled = true;
            columnBButton6.Enabled = true;
            columnBButton7.Enabled = true;

        }

        //sets the button text for the correct answer
        private void setCorrectButtonText()
        {

            List<string> tempCorrectColumnA = new List<string>(this.dictionaryCallNum.Keys);
            List<string> tempCorrectColumnB = new List<string>(this.dictionaryCallNum.Values);

            //sets button text to specific index in random call numbers list
            firstCorrectColumnAB.Text = tempCorrectColumnA.ElementAt(0).ToString();
            secondCorrectColumnAB.Text = tempCorrectColumnA.ElementAt(1).ToString();
            thirdCorrectColumnAB.Text = tempCorrectColumnA.ElementAt(2).ToString();
            fourthCorrectColumnAB.Text = tempCorrectColumnA.ElementAt(3).ToString();

            firstCorrectColumnBB.Text = tempCorrectColumnB.ElementAt(0).ToString();
            secondCorrectColumnBB.Text = tempCorrectColumnB.ElementAt(1).ToString();
            thirdCorrectColumnBB.Text = tempCorrectColumnB.ElementAt(2).ToString();
            fourthCorrectColumnBB.Text = tempCorrectColumnB.ElementAt(3).ToString();

        }

        //sets the button text to hide correct answer
        private void resetCorrectButtonText()
        {
            firstCorrectColumnAB.Text = "***";
            secondCorrectColumnAB.Text = "***";
            thirdCorrectColumnAB.Text = "***";
            fourthCorrectColumnAB.Text = "***";
            firstCorrectColumnBB.Text = "***";
            secondCorrectColumnBB.Text = "***";
            thirdCorrectColumnBB.Text = "***";
            fourthCorrectColumnBB.Text = "***";
        }

        //sets user input button text
        private void setUserText()
        {


            //sets button text or leaves blank
            try
            {
                firstInputColumnAB.Text = userInputColumnA.ElementAt(0).ToString();
            }
            catch (Exception)
            {

                firstInputColumnAB.Text = "???";
            }

            try
            {
                secondInputColumnAB.Text = userInputColumnA.ElementAt(1).ToString();
            }
            catch (Exception)
            {

                secondInputColumnAB.Text = "???";
            }

            try
            {
                thirdInputColumnAB.Text = userInputColumnA.ElementAt(2).ToString();
            }
            catch (Exception)
            {

                thirdInputColumnAB.Text = "???";
            }

            try
            {
                fourthInputColumnAB.Text = userInputColumnA.ElementAt(3).ToString();
            }
            catch (Exception)
            {

                fourthInputColumnAB.Text = "???";
            }

            try
            {
                firstInputColumnBB.Text = userInputColumnB.ElementAt(0).ToString();
            }
            catch (Exception)
            {

                firstInputColumnBB.Text = "???";
            }

            try
            {
                secondInputColumnBB.Text = userInputColumnB.ElementAt(1).ToString();
            }
            catch (Exception)
            {

                secondInputColumnBB.Text = "???";
            }

            try
            {
                thirdInputColumnBB.Text = userInputColumnB.ElementAt(2).ToString();
            }
            catch (Exception)
            {

                thirdInputColumnBB.Text = "???";
            }

            try
            {
                fourthInputColumnBB.Text = userInputColumnB.ElementAt(3).ToString();
            }
            catch (Exception)
            {

                fourthInputColumnBB.Text = "???";
            }



        }

        //sets the order of User input buttons
        private void orderUserInput(bool alt)
        {

            if (alt == true)
            {
                firstInputColumnAB.Text = userInputColumnA.ElementAt(0).ToString();
                secondInputColumnAB.Text = userInputColumnA.ElementAt(1).ToString();
                thirdInputColumnAB.Text = userInputColumnA.ElementAt(2).ToString();
                fourthInputColumnAB.Text = userInputColumnA.ElementAt(3).ToString();

                firstInputColumnBB.Text = userInputColumnB.ElementAt(0).ToString();
                secondInputColumnBB.Text = userInputColumnB.ElementAt(1).ToString();
                thirdInputColumnBB.Text = userInputColumnB.ElementAt(2).ToString();
                fourthInputColumnBB.Text = userInputColumnB.ElementAt(3).ToString();

            }
            else
            {
                firstInputColumnAB.Text = userInputColumnB.ElementAt(0).ToString();
                secondInputColumnAB.Text = userInputColumnB.ElementAt(1).ToString();
                thirdInputColumnAB.Text = userInputColumnB.ElementAt(2).ToString();
                fourthInputColumnAB.Text = userInputColumnB.ElementAt(3).ToString();

                firstInputColumnBB.Text = userInputColumnA.ElementAt(0).ToString();
                secondInputColumnBB.Text = userInputColumnA.ElementAt(1).ToString();
                thirdInputColumnBB.Text = userInputColumnA.ElementAt(2).ToString();
                fourthInputColumnBB.Text = userInputColumnA.ElementAt(3).ToString();
            }




        }

        //changes button colour of wrong answers
        private void changeButtonColour()
        {

            var WrongAnswers = dictionaryCallNum.Except(userInputDictionary).Concat(userInputDictionary.Except(dictionaryCallNum));

            //for loop with wrong answers
            foreach (var item in WrongAnswers)
            {
                //if statement to change button colour if button text contains wrong answer
                if (item.Key == firstInputColumnAB.Text)
                {
                    firstInputColumnAB.BackColor = Color.Red;
                }

                if (item.Key == secondInputColumnAB.Text)
                {
                    secondInputColumnAB.BackColor = Color.Red;
                }

                if (item.Key == thirdInputColumnAB.Text)
                {
                    thirdInputColumnAB.BackColor = Color.Red;
                }

                if (item.Key == fourthInputColumnAB.Text)
                {
                    fourthInputColumnAB.BackColor = Color.Red;
                }

            }

            //if statement to change button colour if button text contains wrong answer
            foreach (var item in WrongAnswers)
            {

                if (item.Value == firstInputColumnBB.Text)
                {
                    firstInputColumnBB.BackColor = Color.Red;
                }

                if (item.Value == secondInputColumnBB.Text)
                {
                    secondInputColumnBB.BackColor = Color.Red;
                }

                if (item.Value == thirdInputColumnBB.Text)
                {
                    thirdInputColumnBB.BackColor = Color.Red;
                }

                if (item.Value == fourthInputColumnBB.Text)
                {
                    fourthInputColumnBB.BackColor = Color.Red;
                }
            }

        }

        private void changeCorrectButtonColour()
        {

            var CorrectAnswers = userInputDictionary.Except(dictionaryCallNum).Concat(dictionaryCallNum.Except(userInputDictionary));

            //for loop with wrong answers
            foreach (var item in CorrectAnswers)
            {
                //if statement to change button colour if button text contains wrong answer
                if (item.Key == firstCorrectColumnAB.Text)
                {
                    firstCorrectColumnAB.BackColor = Color.Green;
                }

                if (item.Key == secondCorrectColumnAB.Text)
                {
                    secondCorrectColumnAB.BackColor = Color.Green;
                }

                if (item.Key == thirdCorrectColumnAB.Text)
                {
                    thirdCorrectColumnAB.BackColor = Color.Green;
                }

                if (item.Key == fourthCorrectColumnAB.Text)
                {
                    fourthCorrectColumnAB.BackColor = Color.Green;
                }

            }

            //if statement to change button colour if button text contains wrong answer
            foreach (var item in CorrectAnswers)
            {

                if (item.Value == firstCorrectColumnBB.Text)
                {
                    firstCorrectColumnBB.BackColor = Color.Green;
                }

                if (item.Value == secondCorrectColumnBB.Text)
                {
                    secondCorrectColumnBB.BackColor = Color.Green;
                }

                if (item.Value == thirdCorrectColumnBB.Text)
                {
                    thirdCorrectColumnBB.BackColor = Color.Green;
                }

                if (item.Value == fourthCorrectColumnBB.Text)
                {
                    fourthCorrectColumnBB.BackColor = Color.Green;
                }
            }

        }

        //disables buttons once correct number of answers inputted
        private void limitUserInput(List<string> userInputColumnA, List<string> userInputColumnB)
        {

            if (userInputColumnA.Count() == 4 && userInputColumnB.Count() == 4)
            {
                columnBButton1.Enabled = false;
                columnBButton2.Enabled = false;
                columnBButton3.Enabled = false;
                columnBButton4.Enabled = false;
                columnBButton5.Enabled = false;
                columnBButton6.Enabled = false;
                columnBButton7.Enabled = false;
            }

            if (userInputColumnB.Count() == 4)
            {

                columnBButton1.Enabled = false;
                columnBButton2.Enabled = false;
                columnBButton3.Enabled = false;
                columnBButton4.Enabled = false;
                columnBButton5.Enabled = false;
                columnBButton6.Enabled = false;
                columnBButton7.Enabled = false;
            }

        }

        //changes button colours back to default 
        private void resetButtonColour()
        {
            firstInputColumnAB.BackColor = Color.DimGray;
            secondInputColumnAB.BackColor = Color.DimGray;
            thirdInputColumnAB.BackColor = Color.DimGray;
            fourthInputColumnAB.BackColor = Color.DimGray;

            firstInputColumnBB.BackColor = Color.DimGray;
            secondInputColumnBB.BackColor = Color.DimGray;
            thirdInputColumnBB.BackColor = Color.DimGray;
            fourthInputColumnBB.BackColor = Color.DimGray;

            firstCorrectColumnAB.BackColor = Color.DimGray;
            secondCorrectColumnAB.BackColor = Color.DimGray;
            thirdCorrectColumnAB.BackColor = Color.DimGray;
            fourthCorrectColumnAB.BackColor = Color.DimGray;
            firstCorrectColumnBB.BackColor = Color.DimGray;
            secondCorrectColumnBB.BackColor = Color.DimGray;
            thirdCorrectColumnBB.BackColor = Color.DimGray;
            fourthCorrectColumnBB.BackColor = Color.DimGray;
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
