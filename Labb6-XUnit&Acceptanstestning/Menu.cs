using Labb6_XUnit_Acceptanstestning.Models;
using System;
using System.Collections.Generic;

namespace Labb6_XUnit_Acceptanstestning
{
    public class Menu
    {
        //Hämtar och skapar calculator för att kunna anväda dess metoder i klassen.
        private readonly Calculator _calculator;

        //Hämtar och initierar listan för CalculationLog för att lagra beräkningar
        private readonly List<CalculationLog> _history;

        public Menu()
        {
            _calculator = new Calculator();
            _history = new List<CalculationLog>();
        }

        public void ShowMenu()
        {
            while (true)
            {
                DisplayMenu();

                int choice = GetUserChoice();

                if (choice == 6)
                {
                    Console.WriteLine("Miniräknaren avslutas...");
                    break;
                }

                if (choice == 5)
                {
                    PrintHistory();
                    continue;
                }

                PerformOperation(choice);
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("===== Miniräknaren =====");
            Console.WriteLine("Välj ett räknesätt:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraktion");
            Console.WriteLine("3. Multiplikation");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Visa historik");
            Console.WriteLine("6. Avsluta");
            Console.Write("Ditt val: ");
        }

        //Retunerar en int mellan 1-6
        private int GetUserChoice()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 6)
                {
                    return choice;
                } else
                {
                    PrintError();
                }
            }
        }

        //Utför operation baserat på inparameter
        private void PerformOperation(int choice)
        {
            Console.WriteLine();
            double num1 = GetFirstDouble();
            double num2 = GetSecondDouble(choice);
            double result = 0;
            string operationSymbol = "";

            try
            {
                switch (choice)
                {
                    case 1:
                        result = _calculator.Addition(num1, num2);
                        operationSymbol = "+";
                        break;
                    case 2:
                        result = _calculator.Subtraction(num1, num2);
                        operationSymbol = "-";
                        break;
                    case 3:
                        result = _calculator.Multiplication(num1, num2);
                        operationSymbol = "*";
                        break;
                    case 4:
                        result = _calculator.Division(num1, num2);
                        operationSymbol = "/";
                        break;
                }

                //Skapar och sparar log till _history.
                var log = new CalculationLog(num1, num2, result, operationSymbol);
                _history.Add(log);

                Console.WriteLine(log.ToString());

                PressAnyKeyToContinue();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private double GetFirstDouble()
        {
            Console.WriteLine("Ange första talet:");
            return GetValidDoubleFromUser();
        }

        //Metod för att få det andra numret. Kontrollerar att man inte väljer 0 om man har valt division
        private double GetSecondDouble(int choice)
        {
            while (true)
            {
                Console.WriteLine("Ange andra talet:");
                double result = GetValidDoubleFromUser();

                if (choice == 4 && result == 0)
                {
                    PrintError();
                } else
                {
                    return result;
                }
            }
        }

        public double GetValidDoubleFromUser()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                } else
                {
                    PrintError();
                }
            }
        }

        private void PrintHistory()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("Ingen historik tillgänglig.");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n=== Historik över tidigare beräkningar ===");
                foreach (var log in _history)
                {
                    Console.WriteLine(log);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            PressAnyKeyToContinue();
        }

        private void PrintError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ogiltigt val, vänligen ange ett giltig nummer...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PressAnyKeyToContinue()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
