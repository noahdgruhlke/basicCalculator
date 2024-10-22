using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Channels;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator;

public class Calculator
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("The answer is " + GetInput());
        }

    }
    public enum OPERATIONTYPES
    {
        addition,
        subtraction,
        mulit,
        divide,
        none
    }

    public static OPERATIONTYPES Operation
    { get; set; }

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
                default:
                    int result = int.Parse(part);

                    numbersMason.Add(result);

                    continue;
            }
        }

        var finalResult = DoTheThingMason(numbersMason, Operation);

        return finalResult;
    }

    public static int DoTheThingMason(List<int> allMyNumbers, OPERATIONTYPES operation) 
    {
        int result = allMyNumbers[0];

        for(int i = 1; i < allMyNumbers.Count; i++)
        {
            switch (operation)
            {
                case OPERATIONTYPES.addition:
                    result += allMyNumbers[i];
                    break;
                case OPERATIONTYPES.subtraction:
                    result -= allMyNumbers[i];
                    break;
                case OPERATIONTYPES.mulit:
                    result *= allMyNumbers[i];
                    break;
                case OPERATIONTYPES.divide:
                    result /= allMyNumbers[i];
                    break;
            }
        } 

        return result;
    }
}