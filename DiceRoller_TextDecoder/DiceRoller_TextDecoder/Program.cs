using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DiceRoller_TextDecoder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*d*+*d*\n");
            while (true)
            {
                Console.Write("Type in you dice roll: ");
                string diceString = Console.ReadLine();
                DiceStringSpliter(diceString);
            }

        }
        //-- Splits the string into smaller chucks and fires other functions
        public static void DiceStringSpliter(string diceString)
        {
            string[] diceSets = diceString.Split('+');
            foreach (string set in diceSets)
            {
                if (Validator(set))
                {
                    string[] diceGroup = set.Split('d');
                    DiceResultPrinter(DiceRoller(Convert.ToInt32(diceGroup[0]), Convert.ToInt32(diceGroup[1])), Convert.ToInt32(diceGroup[1]));
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }
        //-- Rolls the dices and returns int[]array, put total in last index
        public static int[] DiceRoller(int diceSum, int diceSize)
        {
            Random random = new Random();
            int[] result = new int[diceSum+1];
            int total = 0;
            for (int i = 0; i < diceSum; i++)
            {
                result[i] = random.Next(1, diceSize + 1);
                Task.Delay(1).Wait();
                total += result[i];
            }
            result[diceSum] = total;
            return result;
        }
        //-- prints result out to console
        public static void DiceResultPrinter(int[] diceArray, int diceHighestSide)
        {
            int n = 0;
            foreach (var item in diceArray)
            {
                if (item != diceArray.Last())
                {
                    Console.Write(item + ", ");
                    if (item == diceHighestSide)
                    {
                        n++;
                    }
                }
                else
                {
                    Console.WriteLine("Result = " +item + " w. " + n + " rolled Max");
                    if (diceArray[0] == diceArray[1])
                    {
                        break;
                    }
                }
            }
        }
        //-- Validates the input from the user
        public static bool Validator(string diceString)
        {
            var isValid = true;

            Regex regex = new Regex("^[0-9]{1,9}d[0-9]{1,9}$");
            if (!regex.IsMatch(diceString)) isValid = false;
            return isValid;
        }
    }
}
