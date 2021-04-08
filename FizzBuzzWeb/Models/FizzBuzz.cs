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
        public int Id { set; get; }
        [Display(Name = "Number [1-1000]")]
        [Required(ErrorMessage = "number is required")]
        [Range(1, 1000, ErrorMessage = "Number between 1-1000")]
        public int Number { set; get; }
        public DateTime Date { set; get; }
        public int State { set; get; } = -1;

        public void Check()
        {
            State = 0;
            try
            {
                if (Number < 1 && Number > 1000)
                    throw new Exception("Number not between 1-1000");

                if (Number % 3 == 0)
                    State += 1;
                if (Number % 5 == 0)
                    State += 2;
            }
            catch (Exception e)
            {
                State = 4;
            }
        }

        public string GetMessage()
        {
            if (State == -1) Check();
            string mess = "";
            switch (State)
            {
                case 0: mess = "The number:" + Number + " does not meet the FizzBuzz requirements"; break;
                case 1: mess = "Fizz"; break;
                case 2: mess = "Buzz"; break;
                case 3: mess = "FizzBuzz"; break;
                case 4: mess = "problem"; break;
            }

            return mess;
        }

    }
}
