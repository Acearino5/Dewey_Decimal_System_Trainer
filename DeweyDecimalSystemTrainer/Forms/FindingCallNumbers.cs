using DeweyDecimalSystemTrainer.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeweyDecimalSystemTrainer.Forms
{
    public partial class FindingCallNumbers : Form
    {
        //declarations
        Details userDetails = new Details();
        FindingCallNum findingCallNum = new FindingCallNum();
        Tree treeList;

        List<string> correctAnswer = new List<string>();
        List<string> topLevelRandom = new List<string>();
        List<string> secondLevelRandom = new List<string>();
        List<string> thirdLevelRandom = new List<string>();
        int questionLevel = 1;

        public FindingCallNumbers()
        {
            InitializeComponent();
            userDetails = userDetails.Instance();
        }



        private void FindingCallNumbers_Load(object sender, EventArgs e)
        {
            //set lists
            treeList = findingCallNum.loadNumbers();
            correctAnswer = findingCallNum.generateFindCallNum();
            topLevelRandom = findingCallNum.generateTopLevel(correctAnswer);
            secondLevelRandom = findingCallNum.generateSecondLevel(correctAnswer);
            thirdLevelRandom = findingCallNum.generateThirdLevel(correctAnswer);
            questionLabel.Text = correctAnswer[1].ToString();
            welcomeLabel.Text = "Welcome: " + userDetails.getUsername(0);

            //method calls
            setTopLevelButtonText();

        }

        #region ButtonEvents
        //calls methods to check answer on button click
        private void inputButton1_Click(object sender, EventArgs e)
        {
            var Button = (Button)sender;
            switch (Button.Name)
            {
                case "inputButton1":

                    checkAnswer(inputButton1);
                    checkLevel2Answer(inputButton1);
                    checkLevel3Answer(inputButton1);
                    disableAllButtons();
                    break;
                case "inputButton2":

                    checkAnswer(inputButton2);
                    checkLevel2Answer(inputButton2);
                    checkLevel3Answer(inputButton2);
                    disableAllButtons();
                    break;
                case "inputButton3":

                    checkAnswer(inputButton3);
                    checkLevel2Answer(inputButton3);
                    checkLevel3Answer(inputButton3);
                    disableAllButtons();
                    break;
                case "inputButton4":

                    checkAnswer(inputButton4);
                    checkLevel2Answer(inputButton4);
                    checkLevel3Answer(inputButton4);
                    disableAllButtons();
                    break;

                default:

                    break;
            }

        }

        //sends user to the next level if answered correct
        private void nextLevelButtons1_Click(object sender, EventArgs e)
        {
            questionLevel = questionLevel + 1;
            nextLevelButtons1.Visible = false;

            if (questionLevel == 2)
            {
                //hides answer labels
                successLabel.Visible = false;
                failPictureBox.Visible = false;
                succPictureBox.Visible = false;
                levelLabel.Text = "Level 2:";

                //re enables buttons
                inputButton1.Enabled = true;
                inputButton2.Enabled = true;
                inputButton3.Enabled = true;
                inputButton4.Enabled = true;

                //resets button color
                inputButton1.BackColor = Color.DimGray;
                inputButton2.BackColor = Color.DimGray;
                inputButton3.BackColor = Color.DimGray;
                inputButton4.BackColor = Color.DimGray;

                //sets button text
                inputButton1.Text = secondLevelRandom.ElementAt(0).ToString();
                inputButton2.Text = secondLevelRandom.ElementAt(1).ToString();
                inputButton3.Text = secondLevelRandom.ElementAt(2).ToString();
                inputButton4.Text = secondLevelRandom.ElementAt(3).ToString();
            }

            if (questionLevel == 3)
            {
                //hides answer labels
                successLabel.Visible = false;
                failPictureBox.Visible = false;
                succPictureBox.Visible = false;
                levelLabel.Text = "Level 3:";

                //re enables buttons
                inputButton1.Enabled = true;
                inputButton2.Enabled = true;
                inputButton3.Enabled = true;
                inputButton4.Enabled = true;

                //resets button color
                inputButton1.BackColor = Color.DimGray;
                inputButton2.BackColor = Color.DimGray;
                inputButton3.BackColor = Color.DimGray;
                inputButton4.BackColor = Color.DimGray;

                //sets button text
                inputButton1.Text = thirdLevelRandom.ElementAt(0).ToString();
                inputButton2.Text = thirdLevelRandom.ElementAt(1).ToString();
                inputButton3.Text = thirdLevelRandom.ElementAt(2).ToString();
                inputButton4.Text = thirdLevelRandom.ElementAt(3).ToString();
            }


        }

        //resets all variables and lets user start again
        private void playAgainButton_Click(object sender, EventArgs e)
        {
            //clears lists
            correctAnswer.Clear();
            topLevelRandom.Clear();
            secondLevelRandom.Clear();
            thirdLevelRandom.Clear();


            //resets question level
            questionLevel = 1;

            //hides answer labels
            successLabel.Visible = false;
            nextLevelButtons1.Visible = false;
            playAgainButton.Visible = false;
            failPictureBox.Visible = false;
            succPictureBox.Visible = false;

            //re enables buttons
            inputButton1.Enabled = true;
            inputButton2.Enabled = true;
            inputButton3.Enabled = true;
            inputButton4.Enabled = true;

            //resets button color
            inputButton1.BackColor = Color.DimGray;
            inputButton2.BackColor = Color.DimGray;
            inputButton3.BackColor = Color.DimGray;
            inputButton4.BackColor = Color.DimGray;

            //set lists
            treeList = findingCallNum.loadNumbers();
            correctAnswer = findingCallNum.generateFindCallNum();
            topLevelRandom = findingCallNum.generateTopLevel(correctAnswer);
            secondLevelRandom = findingCallNum.generateSecondLevel(correctAnswer);
            thirdLevelRandom = findingCallNum.generateThirdLevel(correctAnswer);
            questionLabel.Text = correctAnswer[1].ToString();

            //method calls
            setTopLevelButtonText();
        }

        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            //sends user to next page and starts form at previous form location
            FindingCallNumbersLeaderboard next = new FindingCallNumbersLeaderboard();
            this.Hide();
            next.StartPosition = FormStartPosition.Manual;
            next.Location = new Point(this.Location.X, this.Location.Y);
            next.ShowDialog();
            this.Close();
        }

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
        #endregion

        #region checkAnswers
        public void checkAnswer(Button buttonText)
        {


            if (questionLevel == 1)
            {
                string answerTemp = correctAnswer.ElementAt(0).ToString();
                char answerChar = answerTemp[0];

                string inputTemp = buttonText.Text.ToString();
                char inputChar = inputTemp[0];

                if (answerChar == inputChar)
                {
                    successLabel.Visible = true;
                    successLabel.Text = "Correct!";
                    nextLevelButtons1.Visible = true;
                    succPictureBox.Visible = true;
                    buttonText.BackColor = Color.Green;
                    //   findingCallNum.databaseCallWin(userDetails.getUsername(0));
                }
                else
                {
                    successLabel.Visible = true;
                    successLabel.Text = "Incorrect!";
                    playAgainButton.Visible = true;
                    findingCallNum.databaseCallLose(userDetails.getUsername(0));
                    failPictureBox.Visible = true;
                    buttonText.BackColor = Color.Red;
                    highlightCorrectAnswer();
                }
            }



        }

        public void checkLevel2Answer(Button buttonText)
        {
            StringBuilder sb = new StringBuilder();


            if (questionLevel == 2)
            {
                string answerLevel2Temp = correctAnswer.ElementAt(0).ToString();
                char firstCharLevel2 = answerLevel2Temp[0];
                char secondtCharLevel2 = answerLevel2Temp[1];
                string answerHolder;

                sb.Append(firstCharLevel2);
                sb.Append(secondtCharLevel2);
                answerHolder = sb.ToString();
                sb.Clear();

                string inputLevel2Temp = buttonText.Text.ToString();
                char inputLevel2Char = inputLevel2Temp[0];
                char secondInputLevel2Char = inputLevel2Temp[1];
                string inputHolder;

                sb.Append(inputLevel2Char);
                sb.Append(secondInputLevel2Char);
                inputHolder = sb.ToString();
                sb.Clear();

                if (answerHolder == inputHolder)
                {
                    successLabel.Visible = true;
                    successLabel.Text = "Correct!";
                    succPictureBox.Visible = true;
                    nextLevelButtons1.Visible = true;
                    buttonText.BackColor = Color.Green;
                    //   findingCallNum.databaseCallWin(userDetails.getUsername(0));

                }
                else
                {
                    successLabel.Visible = true;
                    successLabel.Text = "Incorrect!";
                    nextLevelButtons1.Visible = false;
                    playAgainButton.Visible = true;
                    findingCallNum.databaseCallLose(userDetails.getUsername(0));
                    failPictureBox.Visible = true;
                    buttonText.BackColor = Color.Red;
                    highlightCorrectAnswer();
                }

            }


        }

        public void checkLevel3Answer(Button buttonText)
        {

            StringBuilder sb = new StringBuilder();

            if (questionLevel == 3)
            {
                string answerLevel3Temp = correctAnswer.ElementAt(0).ToString();
                char firstCharLevel3 = answerLevel3Temp[0];
                char secondtCharLevel3 = answerLevel3Temp[1];
                char thirdCharLevel3 = answerLevel3Temp[2];
                string answerHolder;

                sb.Append(firstCharLevel3);
                sb.Append(secondtCharLevel3);
                sb.Append(thirdCharLevel3);
                answerHolder = sb.ToString();
                sb.Clear();

                string inputLevel3Temp = buttonText.Text.ToString();
                char inputLevel3Char = inputLevel3Temp[0];
                char secondInputLevel3Char = inputLevel3Temp[1];
                char thirdInputLevel3Char = inputLevel3Temp[2];
                string inputHolder;

                sb.Append(inputLevel3Char);
                sb.Append(secondInputLevel3Char);
                sb.Append(thirdInputLevel3Char);
                inputHolder = sb.ToString();
                sb.Clear();

                if (answerHolder == inputHolder)
                {
                    successLabel.Visible = true;
                    successLabel.Text = "Correct!";
                    succPictureBox.Visible = true;
                    nextLevelButtons1.Visible = false;
                    playAgainButton.Visible = true;
                    findingCallNum.databaseCallWin(userDetails.getUsername(0));
                    buttonText.BackColor = Color.Green;

                }
                else
                {
                    successLabel.Visible = true;
                    successLabel.Text = "Incorrect!";
                    nextLevelButtons1.Visible = false;
                    playAgainButton.Visible = true;
                    findingCallNum.databaseCallLose(userDetails.getUsername(0));
                    failPictureBox.Visible = true;
                    buttonText.BackColor = Color.Red;
                    highlightCorrectAnswer();
                }
            }


        }
        #endregion

        #region ButtonMethods

        //sets button text 
        public void setTopLevelButtonText()
        {
            inputButton1.Text = topLevelRandom.ElementAt(0).ToString();
            inputButton2.Text = topLevelRandom.ElementAt(1).ToString();
            inputButton3.Text = topLevelRandom.ElementAt(2).ToString();
            inputButton4.Text = topLevelRandom.ElementAt(3).ToString();
        }

        //diables buttons 
        public void disableAllButtons()
        {
            inputButton1.Enabled = false;
            inputButton2.Enabled = false;
            inputButton3.Enabled = false;
            inputButton4.Enabled = false;

        }

        //sets the button color of the correct answer
        public void highlightCorrectAnswer()
        {
            StringBuilder sb = new StringBuilder();

            //checks question level
            if (questionLevel == 1)
            {
                //declarations
                string answerTemp = correctAnswer.ElementAt(0).ToString();
                char answerChar = answerTemp[0];

                //loops through each button and checks if it contains answer
                foreach (Button btn in Controls.OfType<Button>())
                {
                    string inputTemp = btn.Text.ToString();
                    char inputChar = inputTemp[0];

                    if (answerChar == inputChar)
                    {
                        btn.BackColor = Color.Green;
                    }


                }


            }
            else if (questionLevel == 2)
            {

                //declarations
                string answerLevel2Temp = correctAnswer.ElementAt(0).ToString();
                char firstCharLevel2 = answerLevel2Temp[0];
                char secondtCharLevel2 = answerLevel2Temp[1];
                string answerHolder;

                sb.Append(firstCharLevel2);
                sb.Append(secondtCharLevel2);
                answerHolder = sb.ToString();
                sb.Clear();

                //loops through each button and checks if it contains answer             
                foreach (Button btn in Controls.OfType<Button>())
                {
                    //declarations
                    string inputLevel2Temp = btn.Text.ToString();
                    char inputLevel2Char = inputLevel2Temp[0];
                    char secondInputLevel2Char = inputLevel2Temp[1];
                    string inputHolder;

                    sb.Append(inputLevel2Char);
                    sb.Append(secondInputLevel2Char);
                    inputHolder = sb.ToString();
                    sb.Clear();

                    if (answerHolder == inputHolder)
                    {
                        btn.BackColor = Color.Green;
                    }

                }

            }
            else
            {
                //declarations
                string answerLevel3Temp = correctAnswer.ElementAt(0).ToString();
                char firstCharLevel3 = answerLevel3Temp[0];
                char secondtCharLevel3 = answerLevel3Temp[1];
                char thirdCharLevel3 = answerLevel3Temp[2];
                string answerHolder;

                sb.Append(firstCharLevel3);
                sb.Append(secondtCharLevel3);
                sb.Append(thirdCharLevel3);
                answerHolder = sb.ToString();
                sb.Clear();

                //loops through each button and checks if contains answer
                foreach (Button btn in Controls.OfType<Button>())
                {
                    //declarations
                    string inputLevel3Temp = btn.Text.ToString();
                    char inputLevel3Char = inputLevel3Temp[0];
                    char secondInputLevel3Char = inputLevel3Temp[1];
                    char thirdInputLevel3Char = inputLevel3Temp[2];
                    string inputHolder;

                    sb.Append(inputLevel3Char);
                    sb.Append(secondInputLevel3Char);
                    sb.Append(thirdInputLevel3Char);
                    inputHolder = sb.ToString();
                    sb.Clear();

                    if (answerHolder == inputHolder)
                    {
                        btn.BackColor = Color.Green;
                    }

                }
            }





        }
        #endregion


    }
}
