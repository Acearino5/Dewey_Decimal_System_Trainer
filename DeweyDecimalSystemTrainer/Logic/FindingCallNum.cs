using DeweyDecimalSystemTrainer.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DeweyDecimalSystemTrainer.Logic
{
    public class FindingCallNum
    {

        Details userDetails = new Details();

        #region declarations
        Tree treeList;

        string category000 = "000 Computer science, Information and General works";
        string category100 = "100 Philosophy and Psychology";
        string category200 = "200 Religion";
        string category300 = "300 Social Sciences";
        string category400 = "400 Language";
        string category500 = "500 Science";
        string category600 = "600 Technology";
        string category700 = "700 Arts and Recreation";
        string category800 = "800 Literature";
        string category900 = "900 History and Geography";



        #endregion

        #region load&GenerateAnswer
        //loads all values to tree
        public Tree loadNumbers()
        {

            string text = System.IO.File.ReadAllText(@"DeweryDecimalNumbers.txt");

            treeList = JsonConvert.DeserializeObject<Tree>(text);

            return treeList;
        }


        //Generates the answer and adds to list
        public List<string> generateFindCallNum()
        {
            //declarations
            Random rnd = new Random();
            List<string> correctAnswer = new List<string>();

            //variables to hold index
            int firstIndex = 0;
            int secondIndex = 0;
            int thirdIndex = 0;

            //selects random index 
            firstIndex = rnd.Next(0, 9);

            secondIndex = rnd.Next(0, 3);

            thirdIndex = rnd.Next(0, 3);

            //adds value from tree to list
            correctAnswer.Add(treeList.treeList[firstIndex].treeList[secondIndex].treeList[thirdIndex].callNum);
            correctAnswer.Add(treeList.treeList[firstIndex].treeList[secondIndex].treeList[thirdIndex].category);
            correctAnswer.Add(treeList.treeList[firstIndex].treeList[secondIndex].callNum);
            correctAnswer.Add(treeList.treeList[firstIndex].treeList[secondIndex].category);

            return correctAnswer;

        }
        #endregion

        #region GenerateQuestions
        //method to generate Top level questions
        public List<string> generateTopLevel(List<string> correctAnswer)
        {
            List<string> correctList = new List<string>();
            List<string> randomizeList = new List<string>();
            List<string> templist = new List<string>();
            List<double> OrderedList = new List<double>();

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            //appends call number to description for answer
            sb.Append(correctAnswer[0]);
            sb.Append(" ");
            sb.Append(correctAnswer[1]);
            string temp = sb.ToString();

            //gets the category of answer
            char firstchar = temp[0];
            string answerTopLevel = getCategory(firstchar);

            randomizeList.Add(answerTopLevel);
            sb.Clear();


            //adds all categories that are wrong to list
            foreach (var item in addCategoriesToList())
            {
                if (!randomizeList.Contains(item))
                {
                    templist.Add(item);
                }

            }

            //selects 3 random wrong categories from list and adds to list with correct and wrong answers
            for (int i = 0; i < 3; i++)
            {
                int index = rnd.Next(templist.Count);
                randomizeList.Add(templist[index]);
                templist.RemoveAt(index);

            }

            //splits items in list and orders them
            double tempDouble;
            string[] placeholder;

            foreach (var item in randomizeList)
            {
                placeholder = item.Split(' ');
                tempDouble = Convert.ToDouble(placeholder[0]);
                OrderedList.Add(tempDouble);

            }

            OrderedList.Sort();

            //converts double orderlist to string list
            char tempChar;
            List<string> convertList = new List<string>();

            foreach (var item in OrderedList)
            {
                convertList.Add(item.ToString());
            }

            //gets category and adds to list
            foreach (var item in convertList)
            {
                tempChar = item[0];

                correctList.Add(getCategory(tempChar));
            }



            return correctList;

        }

        //method to generate second level questions
        public List<string> generateSecondLevel(List<string> correctAnswer)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            List<string> secondLevel = new List<string>();
            List<string> tempList = new List<string>();
            int firstIndex = 0;
            int secondIndex = 0;

            //appends call number to desciption for answer
            sb.Append(correctAnswer[2]);
            sb.Append(' ');
            sb.Append(correctAnswer[3]);
            string tempHolder = sb.ToString();
            tempList.Add(tempHolder);
            sb.Clear();

            //generates 4 random call numbers & desciption including answer
            while (tempList.Count < 4)
            {
                firstIndex = rnd.Next(0, 9);
                secondIndex = rnd.Next(0, 3);

                //appends call number to description
                sb.Append(treeList.treeList[firstIndex].treeList[secondIndex].callNum);
                sb.Append(' ');
                sb.Append(treeList.treeList[firstIndex].treeList[secondIndex].category);
                string builtString = sb.ToString();

                //ensures answer isnt added twice
                if (!tempList.Contains(builtString))
                {

                    tempList.Add(builtString);

                }

                sb.Clear();
            }

            tempList.Sort();


            return tempList;
        }

        //method to generate third level questions
        public List<string> generateThirdLevel(List<string> correctAnswer)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            List<string> tempList = new List<string>();
            int firstIndex = 0;
            int secondIndex = 0;
            int thirdIndex = 0;

            //appends call number & description for answer
            sb.Append(correctAnswer[0]);
            sb.Append(' ');
            sb.Append(correctAnswer[1]);
            string tempHolder = sb.ToString();
            tempList.Add(tempHolder);
            sb.Clear();

            //generates 4 random call numbers & desciption including answer
            while (tempList.Count < 4)
            {
                firstIndex = rnd.Next(0, 9);
                secondIndex = rnd.Next(0, 3);
                thirdIndex = rnd.Next(0, 3);

                //appends call number to description
                sb.Append(treeList.treeList[firstIndex].treeList[secondIndex].treeList[thirdIndex].callNum);
                sb.Append(' ');
                sb.Append(treeList.treeList[firstIndex].treeList[secondIndex].treeList[thirdIndex].category);
                string builtString = sb.ToString();

                //ensures answer isnt added twice
                if (!tempList.Contains(builtString))
                {

                    tempList.Add(builtString);

                }

                sb.Clear();
            }


            tempList.Sort();

            return tempList;
        }

        #endregion


        #region categoryMethods

        //adds categories to list
        public List<string> addCategoriesToList()
        {
            List<string> categoryTempList = new List<string>();

            categoryTempList.Add(category000);
            categoryTempList.Add(category100);
            categoryTempList.Add(category200);
            categoryTempList.Add(category300);
            categoryTempList.Add(category400);
            categoryTempList.Add(category500);
            categoryTempList.Add(category600);
            categoryTempList.Add(category700);
            categoryTempList.Add(category800);
            categoryTempList.Add(category900);


            return categoryTempList;
        }

        //switch statement to select correct catergory based on first char
        public string getCategory(char firstChar)
        {

            string category = null;

            switch (firstChar)
            {
                case '0':
                    category = category000;
                    break;
                case '1':
                    category = category100;
                    break;
                case '2':
                    category = category200;
                    break;
                case '3':
                    category = category300;
                    break;
                case '4':
                    category = category400;
                    break;
                case '5':
                    category = category500;
                    break;
                case '6':
                    category = category600;
                    break;
                case '7':
                    category = category700;
                    break;
                case '8':
                    category = category800;
                    break;
                case '9':
                    category = category900;
                    break;


            };

            return category;

        }


        #endregion


        #region DatabaseCalls
        public void databaseCallWin(string username)
        {
            //gets db connection string
            SQLiteConnection con = userDetails.getConnection();

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
            command2.CommandText = "UPDATE UserInfo SET FindingCallWins=FindingCallWins + 1 WHERE Username=@Username";
            command2.Parameters.AddWithValue("@Username", username);

            command2.ExecuteReader();

            con.Close();


        }


        public void databaseCallLose(string username)
        {
            //gets db connection string
            SQLiteConnection con = userDetails.getConnection();

            //tries to open DB connection
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
            command2.CommandText = "UPDATE UserInfo SET FindingCallLoses=FindingCallLoses + 1 WHERE Username=@Username";
            command2.Parameters.AddWithValue("@Username", username);

            command2.ExecuteReader();

            con.Close();


        }

        #endregion


    }




}
