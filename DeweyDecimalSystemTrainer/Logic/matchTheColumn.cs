using System;
using System.Collections.Generic;
using System.Text;

namespace DeweyDecimalSystemTrainer.Logic
{
    public class matchTheColumn
    {
        #region strings
        //category strings
        string category000 = "Computer science, Information and General works";
        string category100 = "Philosophy and Psychology";
        string category200 = "Religion";
        string category300 = "Social Sciences";
        string category400 = "Language";
        string category500 = "Science";
        string category600 = "Technology";
        string category700 = "Arts and Recreation";
        string category800 = "Literature";
        string category900 = "History and Geography";

        #endregion

        #region DictionaryMethods
        //add User inputs to dictionary
        public Dictionary<string, string> getUserInputDictionary(List<string> userInputColumnA, List<string> UserInputColumnB, Dictionary<string, string> userInputDictionary)
        {

            for (int i = 0; i < 4; i++)
            {
                userInputDictionary.Add(userInputColumnA[i], UserInputColumnB[i]);

            }


            return userInputDictionary;
        }


        //adds call numbers and corresponding catergory to dictionary
        public Dictionary<string, string> getCorrectCallNumDictionary(List<string> correctCallNumOrder)
        {
            Dictionary<string, string> dictionaryCallNum = new Dictionary<string, string>();
            char firstChar;

            foreach (var item in correctCallNumOrder)
            {

                firstChar = item[0];
                dictionaryCallNum.Add(item, getCategory(firstChar));


            }



            return dictionaryCallNum;
        }

        //stores correct answer in dictionary 
        public Dictionary<string, string> getCorrectCategoryDictonary(List<string> correctCallNumOrder)
        {
            Dictionary<string, string> dictionaryCallNum = new Dictionary<string, string>();
            char firstChar;
            Random rnd = new Random();
            List<string> tempList = new List<string>();
            List<string> addToDictionary = new List<string>();

            foreach (var item in correctCallNumOrder)
            {
                tempList.Add(item);
            }

            for (int i = 0; i < 4; i++)
            {
                int index = rnd.Next(tempList.Count);
                addToDictionary.Add(tempList[index]);
                tempList.RemoveAt(index);

            }

            foreach (var item in addToDictionary)
            {

                firstChar = item[0];
                dictionaryCallNum.Add(item, getCategory(firstChar));


            }

            return dictionaryCallNum;
        }

        //adds correct answer to correct category list
        public List<string> getCorrectCategoryOrder(Dictionary<string, string> dictionaryCallNum)
        {
            List<string> tempList = new List<string>();

            foreach (var item in dictionaryCallNum)
            {
                tempList.Add(item.Value);
            }



            return tempList;
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

        #region Generate
        public void randomizeCategories(Dictionary<string, string> dictionaryCallNum, List<string> randomCategoryOrder)
        {
            List<string> tempList = new List<string>();
            List<string> categoryTempList = new List<string>();
            Random rnd = new Random();


            //for loop to add call numbers to a temp list
            foreach (var item in dictionaryCallNum)
            {
                tempList.Add(item.Value);
                //categoryTempList.Add(item.Value);
            }

            //adds all categories that are wrong to list
            foreach (var item in addCategoriesToList())
            {
                if (!tempList.Contains(item))
                {
                    categoryTempList.Add(item);
                }

            }


            //selects 3 random wrong categories from list and adds to list with correct and wrong answers
            for (int i = 0; i < 3; i++)
            {
                int index = rnd.Next(categoryTempList.Count);
                tempList.Add(categoryTempList[index]);
                categoryTempList.RemoveAt(index);

            }

            //for loop to select random index and insert that indexs value into random category list
            for (int i = 0; i < 7; i++)
            {
                int index = rnd.Next(tempList.Count);
                randomCategoryOrder.Add(tempList[index]);
                tempList.RemoveAt(index);

            }

        }

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

        public void randomizeCallNum(List<string> correctCallNumOrder, List<string> randomCallNumOrder)
        {
            //declarations
            // List<string> randomCall = new List<string>();
            List<string> tempList = new List<string>();
            Random rnd = new Random();

            //for loop to add call numbers to a temp list
            foreach (var item in correctCallNumOrder)
            {
                tempList.Add(item);

            }

            //for loop to select random index and insert that indexs value into random call number list
            for (int i = 0; i < 4; i++)
            {
                int index = rnd.Next(tempList.Count);
                randomCallNumOrder.Add(tempList[index]);
                tempList.RemoveAt(index);

            }

        }


        public List<string> randomizeSevenCallNum(List<string> correctCallNumOrder)
        {
            List<string> randomCallNumOrder = new List<string>();
            //declarations
            // List<string> randomCall = new List<string>();
            List<string> tempList = new List<string>();
            Random rnd = new Random();

            //for loop to add call numbers to a temp list
            foreach (var item in correctCallNumOrder)
            {
                tempList.Add(item);

            }

            //for loop to select random index and insert that indexs value into random call number list
            for (int i = 0; i < 7; i++)
            {
                int index = rnd.Next(tempList.Count);
                randomCallNumOrder.Add(tempList[index]);
                tempList.RemoveAt(index);

            }

            return randomCallNumOrder;

        }


        //generates random call numbers
        public List<string> generateCallNumbers()
        {
            //declarations
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            List<double> tempList = new List<double>();
            List<int> noDupList = new List<int>();
            List<string> convertToDouble = new List<string>();
            int firstchar = 0;


            //while loop to generate 4 unique single digit numbers
            while (!noDupList.Count.Equals(4))
            {
                firstchar = rnd.Next(0, 9);
                if (!noDupList.Contains(firstchar))
                {
                    noDupList.Add(firstchar);
                }
            }


            //for loop to append random double to unique single digit number
            foreach (var item in noDupList)
            {


                sb.Append(item);
                sb.Append((Math.Round(rnd.NextDouble() * (99 - 10) + 10, 2)));
                convertToDouble.Add(sb.ToString());
                sb.Clear();
            }

            //converts values to double and adds them to double list for sorting 
            foreach (var item in convertToDouble)
            {
                double temp;

                temp = Convert.ToDouble(item);
                tempList.Add(temp);

            }


            //sorts list numerically 
            tempList.Sort();

            List<string> calls = new List<string>();

            //calls generate letters method and adds to calls list
            calls = generateLetters(tempList);

            return calls;



        }

        //generates random call numbers
        public List<string> generateSevenRandomCallNumbers()
        {
            //declarations
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            List<double> tempList = new List<double>();
            List<int> noDupList = new List<int>();
            List<string> convertToDouble = new List<string>();
            int firstchar = 0;


            //while loop to generate 4 unique single digit numbers
            while (!noDupList.Count.Equals(7))
            {
                firstchar = rnd.Next(0, 9);
                if (!noDupList.Contains(firstchar))
                {
                    noDupList.Add(firstchar);
                }
            }


            //for loop to append random double to unique single digit number
            foreach (var item in noDupList)
            {


                sb.Append(item);
                sb.Append((Math.Round(rnd.NextDouble() * (99 - 10) + 10, 2)));
                convertToDouble.Add(sb.ToString());
                sb.Clear();
            }

            //converts values to double and adds them to double list for sorting 
            foreach (var item in convertToDouble)
            {
                double temp;

                temp = Convert.ToDouble(item);
                tempList.Add(temp);

            }


            //sorts list numerically 
            tempList.Sort();

            List<string> calls = new List<string>();

            //calls generate letters method and adds to calls list
            calls = generateLetters(tempList);

            return calls;



        }

        //method to generate 3 random letters and append to randomly generated numbers
        private List<string> generateLetters(List<double> temp)
        {
            //declarations
            List<string> letters = new List<string>();
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            char myRandomUpperCase;

            //for loop to generate random letters and append numbers
            for (int i = 0; i < temp.Count; i++)
            {
                //appends numbers to randomly generated
                sb.Append(temp[i]);
                sb.Append(" ");

                //for loop to generate 3 random letters
                for (int k = 0; k < 3; k++)
                {
                    int ascii_index = rnd.Next(65, 91); //ASCII character codes 65-90
                    myRandomUpperCase = Convert.ToChar(ascii_index); //produces any char A-Z

                    sb.Append(myRandomUpperCase);

                }

                //adds appended letters to letters list
                letters.Add(sb.ToString());
                sb.Clear();
            }



            return letters;

        }

        //converts 1 digit and 2 digit numbers into 3 digit
        public void CovertTo3Digit(List<string> correctCallNum)
        {
            StringBuilder sb = new StringBuilder();
            List<string> tempList = new List<string>();
            List<string> threeDigit = new List<string>();
            List<int> indexHolder = new List<int>();

            //adds call numbers below 100 to temp list       
            // string temp = "55.55";
            foreach (var item in correctCallNum)
            {
                if (item[2].Equals('.'))
                {
                    int index = correctCallNum.IndexOf(item);
                    indexHolder.Add(index);
                    tempList.Add(item);

                }

            }

            //appends 0 to start of 2 digit number and adds to list
            foreach (var item in tempList)
            {
                sb.Append("0");
                sb.Append(item);
                threeDigit.Add(sb.ToString());
                sb.Clear();
            }

            //inserts three digit numbers into correctCallNum list
            for (int i = 0; i < indexHolder.Count; i++)
            {
                correctCallNum[indexHolder[i]] = threeDigit[i];

            }

            List<string> tempList2 = new List<string>();
            List<string> threeDigit2 = new List<string>();
            List<int> indexHolder2 = new List<int>();

            //adds single digit number to temp list
            // string temp2 = "5.55";
            foreach (var item2 in correctCallNum)
            {
                if (item2[1].Equals('.'))
                {
                    int index = correctCallNum.IndexOf(item2);
                    indexHolder2.Add(index);
                    tempList2.Add(item2);

                }

            }

            //appends 00 to start of 1 digit number and adds to list
            foreach (var item in tempList2)
            {
                sb.Append("00");
                sb.Append(item);
                threeDigit2.Add(sb.ToString());
                sb.Clear();
            }

            //inserts three digit numbers into correctCallNum list
            for (int i = 0; i < indexHolder2.Count; i++)
            {
                correctCallNum[indexHolder2[i]] = threeDigit2[i];

            }



        }
        #endregion
    }
}
//------------------------------End Of File---------------------------------------//