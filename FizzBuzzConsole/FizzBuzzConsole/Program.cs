using System;
using System.Text.RegularExpressions;

namespace FizzBuzzConsole
{

    static class FizzBuzz
    {
        static public void Check()
        {
            Regex regex = new Regex(@"\D");
            Console.WriteLine("Type : exit; To close application");
            string input = "";
            string message;

            do
            {
                message = "";
                input = Console.ReadLine();
                try
                {
                    if (regex.IsMatch(input))
                        throw new Exception("not number");

                    if (CheckModThree(input))
                       message = String.Concat(message ,"fizz");
                    if (CheckModFive(input))
                       message =  String.Concat(message ,"buzz");
                }
                catch (Exception)
                {
                    message = "Not valid input";
                }
                finally
                {
                    Console.WriteLine(message);
                }
            } while (input != "exit");
        }

        static private bool CheckModThree(string value)
        {
            char[] charArray = value.ToCharArray();
            int sum = 0;
            foreach (var charElem in charArray)
            {
                sum += int.Parse(charElem.ToString());
            }

            return (sum % 3 == 0 && sum != 0) ? true : false;
        }

        static private bool CheckModFive(string value)
        {
            string lastChar = value.Substring(value.Length - 1);
            return (lastChar == "0" || lastChar == "5") ? true : false;
        }


    }

    class Program
    {

        static void Main(string[] args)
        {
            FizzBuzz.Check();
        }
    }
}
