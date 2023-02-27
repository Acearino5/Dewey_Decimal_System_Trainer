using System;
using System.Collections.Generic;
using System.Text;

namespace DeweyDecimalSystemTrainer.Logic
{
    public class Generate
    {
        string valueHolder;

        //generates random call numbers
        public List<string> generateCallNumbers()
        {
            //declarations
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            List<double> tempList = new List<double>();

            for (int i = 0; i < 9; i++)
            {

                //Generate random double 
                tempList.Add(Convert.ToDouble(Math.Round(rnd.NextDouble() * (1000 - 1) + 1, 2).ToString()));

            }




            //selects random index from list and adds duplicate
            int index = rnd.Next(tempList.Count);

            //global varaible to hold duplicates index
            valueHolder = tempList[index].ToString();

            //adds duplicate to list based off random index
            tempList.Add(tempList[index]);

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

        //locates double and puts them into the correct order
        public void orderDouble(List<string> correctCallNum)
        {

            List<string> onlyDupValues = new List<string>();

            // for loop to select the duplicate values based on first 3 number chars
            string temp;
            for (int i = 0; i < correctCallNum.Count; i++)
            {
                temp = correctCallNum[i];
                var charArray = temp.ToCharArray();

                if (charArray[0] == valueHolder[0])
                {
                    if (charArray[1] == valueHolder[1])
                    {
                        if (charArray[2] == valueHolder[2])
                        {
                            onlyDupValues.Add(temp);
                        }
                    }
                }


            }


            //sets variables to values in duplicate list
            string listValue = onlyDupValues[0];
            string listValue2 = onlyDupValues[1];

            //gets the index of duplicates in the correct call number list
            int indexTemp = correctCallNum.IndexOf(listValue);
            int indexTemp2 = correctCallNum.IndexOf(listValue2);

            //lists to store the numbers and letters
            List<string> orderLetters = new List<string>();
            List<string> correctDupOrder = new List<string>();

            //splits the numbers and letters 
            string numberHolder = listValue.Split(' ')[0];
            string letterHolder = listValue.Split(' ')[1];
            string letterHolder2 = listValue2.Split(' ')[1];

            //adds only letters to order letter list
            orderLetters.Add(letterHolder);
            orderLetters.Add(letterHolder2);

            //sorts the letters alphabetically
            orderLetters.Sort();

            StringBuilder sb = new StringBuilder();

            //appends the numbers back to the ordered letters
            foreach (var item in orderLetters)
            {
                sb.Append(numberHolder);
                sb.Append(" ");
                sb.Append(item);
                correctDupOrder.Add(sb.ToString());
                sb.Clear();

            }

            //inserts ordered duplicates into the correct call number list
            correctCallNum[indexTemp] = correctDupOrder[0];
            correctCallNum[indexTemp2] = correctDupOrder[1];



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

        public void randomizeCallNum(List<string> correctCallNum, List<string> rndCallNum)
        {
            //declarations
            List<string> randomCall = new List<string>();
            List<string> tempList = new List<string>();
            Random rnd = new Random();

            //for loop to add call numbers to a temp list
            foreach (var item in correctCallNum)
            {
                tempList.Add(item);

            }

            //for loop to select random index and insert that indexs value into random call number list
            for (int i = 0; i < 10; i++)
            {
                int index = rnd.Next(tempList.Count);
                rndCallNum.Add(tempList[index]);
                tempList.RemoveAt(index);

            }



        }
    }
}
//------------------------------End Of File---------------------------------------//