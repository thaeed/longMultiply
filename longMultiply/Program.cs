using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace longMultiply
{
    #region credits
    //By Mr. Saeed Da' © 2018
    #endregion

    class Program
    {
        #region Multiply
        static string Multiply(string[] first, string[] second)
        {
            string[] multiplyRows = new string[second.Length];
            string currentRow = "";
            for (int i = second.Length - 1; i >= 0; i--)
            {
                currentRow = "";
                int carryFlag = 0;
                for (int j = first.Length - 1; j >= 0; j--)
                {

                    int x1 = Convert.ToInt32(first[j]), x2 = Convert.ToInt32(second[i]);

                    int x1x2 = x1 * x2;

                    if (x1x2 > 9)
                    {
                        carryFlag = x1x2 / 10;
                        x1x2 %= 10;
                    }
                    string lastValue = currentRow;

                    if (x1x2 != 0)
                        currentRow = carryFlag.ToString() + x1x2.ToString() + lastValue;
                    else
                        currentRow = x1x2.ToString() + lastValue;

                }
                multiplyRows[i] = currentRow;

            }
            foreach (string x in multiplyRows)
                Console.WriteLine(x);
            return null;
        }
        #endregion

        static string[] toArray(string input, int length)
        {
            string[] output = new string[length];
            int count = 0;
            foreach (char c in input)
            {
                output[count++] = c.ToString();
            }

            return output;
        }
        static void Main(string[] args)
        {
            string firstNum, secNum;
            int firstLength, secLength;
            string[] first, second;
            //***************************
            while (true)
            {
                Console.Write("Insert first number: \n");

                firstNum = Console.ReadLine();
                if (!Regex.IsMatch(firstNum, @"^\d+$"))
                    continue;
                break;
            }
            //***************************
            while (true)
            {
                Console.Write("Insert second number: \n");

                secNum = Console.ReadLine();
                if (!Regex.IsMatch(secNum, @"^\d+$"))
                    continue;
                break;
            }
            //***************************
            if (firstNum.Length >= secNum.Length)
            {
                firstLength = firstNum.Length;
                first = new string[firstLength];
                first = toArray(firstNum, firstLength);

                secLength = secNum.Length;
                second = new string[secLength];
                second = toArray(secNum, secLength);
            }
            else
            {
                firstLength = secNum.Length;
                first = new string[firstLength];
                first = toArray(secNum, firstLength);

                secLength = firstNum.Length;
                second = new string[secLength];
                second = toArray(firstNum, secLength);
            }
            //***************************

            Multiply(first, second);
            Console.Read();


        }



    }
}
