using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller_TextDecoder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*d*+*d*\n");
            Console.Write("Type in you dice roll: ");
            string diceString = Console.ReadLine();
            DiceStringSpliter(diceString);
            Console.ReadLine();

        }
        //-- Splits the string into smaller chucks
        public static void DiceStringSpliter(string diceString)
        {
            string[] diceSets = diceString.Split('+');
            foreach (string set in diceSets)
            {
                string[] diceGroup = set.Split('d');
                DiceResultPrinter(DiceRoller(Convert.ToInt32(diceGroup[0]), Convert.ToInt32(diceGroup[1])));
            }
            // Code...
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
                total += result[i];
            }
            result[diceSum] = total;
            return result;
        }
        //-- prints result out to console
        public static void DiceResultPrinter(int[] diceArray)
        {
            foreach (var item in diceArray)
            {
                if (item != diceArray.Last())
                {
                    Console.Write(item + ", ");
                }
                else
                {
                    Console.WriteLine("Result = " +item);
                }
            }
        }
    }
}
