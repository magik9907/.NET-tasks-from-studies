using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace net_task.Models
{
    public class FizzBuzz
    {   
        [Display(Name = "Number [1-1000]")]
        [Required(ErrorMessage ="number is required")]
        [Range(1,1000,ErrorMessage ="Number between 1-1000")]
        public int Number { set; get; }
        public DateTime Date { set; get; }
        public string Result { set; get; }

         public void Check()
        {
            Regex regex = new Regex(@"[^-0-9]+");
            string message;

                message = "";
                try
                {
                    if (Number <1 && Number >1000)
                        throw new Exception("Number not between 1-1000");

                    if (CheckModThree(Number))
                        message = String.Concat(message, "fizz");
                    if (CheckModFive(Number))
                        message = String.Concat(message, "buzz");
                    if (message == "")
                        message = String.Concat(message, Number);
                }
                catch (Exception e)
                {
                    message =e.Message;
                }
                finally
                {
                    Result = message;
                }
        }

         private bool CheckModThree(int value)
        {
            char[] charArray = value.ToString().ToCharArray();
            int sum = 0;
            foreach (var charElem in charArray)
            {
                if (charElem != '-')
                    sum += int.Parse(charElem.ToString());
            }

            return (sum % 3 == 0 && sum != 0) ? true : false;
        }

         private bool CheckModFive(int num)
        {
            string value = Number.ToString();
            if (value.CompareTo("0") == 0) return false;
            string lastChar = value.Substring(value.Length - 1);
            return (lastChar == "0" || lastChar == "5") ? true : false;
        }

    }
}
