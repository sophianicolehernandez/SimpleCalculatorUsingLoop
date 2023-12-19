using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculatorUsingLoop //this is the assembly
{
    //Declare Variables

    public class CalculatorInput
    {
        public double checkIfNumber(string userInput)
        {
            double finalAnswer;
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("input is null");
                Console.Write("Enter the number again: ");
                userInput = Console.ReadLine();
            }

            while (!double.TryParse(userInput, out _))
            {
                Console.WriteLine(userInput + " is not a number.");
                Console.Write("Enter the number again: ");
                userInput = Console.ReadLine();
            }
            finalAnswer = Convert.ToDouble(userInput);
            return finalAnswer;
        }

        public char mathematicalOperation(string operation)
        {
            char newOperationValue;
            // check if null
            while (string.IsNullOrWhiteSpace(operation))
            {
                Console.WriteLine("input is null");
                Console.Write("Enter the operation (+, -, *, /) you want to perform: ");
                operation = Console.ReadLine();
            }
            //check if one character ang string
            while (operation.Length != 1)
            {
                Console.WriteLine("input is not one character. Input again.");
                Console.Write("Enter the operation (+, -, *, /) you want to perform: ");
                operation = Console.ReadLine();
            }
            //check if char is a math operation
            newOperationValue = char.Parse(operation);
            while ((newOperationValue != '/') && (newOperationValue != '-') && (newOperationValue != '*') && 
                   (newOperationValue != '+'))
            {
                Console.WriteLine("input is not a mathematical operation. input again");
                Console.Write("Enter the operation (+, -, *, /) you want to perform: ");
                newOperationValue = char.Parse(Console.ReadLine());
            }
            return newOperationValue;
        }

        public void mathSolution(double firstValue, double secondValue, char operation)
        {
            double finalResult;
                switch (operation)
                {
                    case '/':
                        while(secondValue == 0)
                        {
                            Console.WriteLine("Divisor is 0. Result is undefined. Try again");
                            Console.Write("Enter the number again: ");
                            secondValue = Convert.ToDouble(Console.ReadLine());
                        }
                        finalResult = firstValue / secondValue;
                        Console.WriteLine("Result: " + finalResult);
                    break;
                    case '-':
                        finalResult = firstValue - secondValue;
                        Console.WriteLine("Result: " + finalResult);
                    break;
                    case '+':
                        finalResult = firstValue + secondValue;
                        Console.WriteLine("Result: " + finalResult);
                    break;
                    case '*':
                        finalResult = firstValue * secondValue;
                        Console.WriteLine("Result: " + finalResult);
                    break;
                    default: break;
                }
        }

        public bool inputAgain(string performAgain)
        {
            bool tryAgainValue = true;

            while (string.IsNullOrWhiteSpace(performAgain))
            {
                Console.WriteLine("Make sure that your input is not empty.");
                Console.Write("Do you want to perform another calculation? (y/n): ");
                performAgain = Console.ReadLine();
            }

            if ((char.Parse(performAgain) == 'y') || (performAgain.ToLower() == "yes"))
            {
                tryAgainValue = true;
            }
            else if ((char.Parse(performAgain) == 'n') || (performAgain.ToLower() == "no"))
            {
                tryAgainValue = false;
            }
            else
            {
                Console.WriteLine("Incorrect input. This calculator is forced to end.");
                tryAgainValue = false;
            }
            return tryAgainValue;
        }
    }

    class Program  // no access modifier because this is what actually runs in application
    {             // but when creating other classes, then it need access modifier

        static void Main(string[] args)
        {
            // Declare variable and method
            double firstNumber;
            double secondNumber;
            char mathOperation;
            string performAgain;
            bool tryAgainValue;
            CalculatorInput firstCalculatorInput = new CalculatorInput();
            CalculatorInput secondCalculatorInput = new CalculatorInput();
            CalculatorInput mathOperationValue = new CalculatorInput();

            //main program when run. dont need to return variable (void)

            do
            {
                Console.WriteLine("\nWelcome to the Simple Calculator!");
                //input and validate first number
                Console.Write("Enter the first number: ");
                firstNumber = firstCalculatorInput.checkIfNumber(Console.ReadLine());
                //input and validate second number
                Console.Write("Enter the second number: ");
                secondNumber = secondCalculatorInput.checkIfNumber(Console.ReadLine());
                //input and validate operation
                Console.Write("Enter the operation (+, -, *, /) you want to perform: ");
                mathOperation = mathOperationValue.mathematicalOperation(Console.ReadLine());
                //Final result
                mathOperationValue.mathSolution(firstNumber, secondNumber, mathOperation);

                
                //check if want to do again
                Console.Write("Do you want to perform another calculation? (y/n): ");
                performAgain = Console.ReadLine();

                tryAgainValue = mathOperationValue.inputAgain(performAgain);
            } while (tryAgainValue);
            Console.WriteLine("Thank you for using the Simple Calculator. Goodbye!.");
        }
    }
}