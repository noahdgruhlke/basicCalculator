using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using static Calculator.Calculator;

namespace basicCalculator
{
    internal class Input_Handling
    {
        public static int GetInput()
        {

            Console.WriteLine("Do math with two numbers: ");
            var userInput = Console.ReadLine();

            if (userInput == "quit")
            {
                Console.WriteLine("Thank you for using the calculator! Exiting now...");

                System.Threading.Thread.Sleep(1000);

                Environment.Exit(0);
            }
            if (userInput == "")
            {
                Console.WriteLine("No input! Please try again!");

                return GetInput();
            }

            string[] parts = userInput.Split(' ');

            List<int> numbersMason = new List<int>();

            foreach (string part in parts)
            {
                switch (part)
                {
                    case "+":
                        Operation = OPERATIONTYPES.addition;
                        continue;
                    case "-":
                        Operation = OPERATIONTYPES.subtraction;
                        continue;
                    case "*":
                        Operation = OPERATIONTYPES.mulit;
                        continue;
                    case "/":
                        Operation = OPERATIONTYPES.divide;
                        continue;
                    case "=":
                        //question: tried the following: throw new NotImplementedException();
                        //this code didn't work. Why?
                        Console.WriteLine("This is not a valid input");
                        return GetInput();
                    default:
                        int result = int.Parse(part);

                        numbersMason.Add(result);

                        continue;
                }
            }

            var finalResult = DoTheThingMason(numbersMason, Operation);

            return finalResult;
        }
    }
}
