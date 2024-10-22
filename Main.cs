using basicCalculator;
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
            Console.WriteLine("The answer is " + Input_Handling.GetInput());
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