using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            const int numberOfPeriods = 12;

            const string inputMsg1 = "Введите cумму кредитования, \u00A4";
            const string inputMsg2 = "Введите ставку кредитования, % [1 - 100% как 15,5% ]";
            const string paymentTypeMsg = "Выберите вид платежа:";
            const string paymentTypeMsg1 = "1 - аннуитетный платеж - это равный по сумме ежемесячный платеж по кредиту;";
            const string paymentTypeMsg2 = "2 - дифференцированный платеж -  это ежемесячный платеж, уменьшающийся к концу срока кредитования.";
            const string invalidInputMsg = "Введены неверные значения...";
            const string tableLineMsg = " | {0,6} | {1,13:0.##}\u00A4 | {2,13:0.##}\u00A4 | {3,13:0.##}\u00A4 | {4,13:0.##}\u00A4 |";
            const string tableFooterLineMsg = " | Итого: | {0,30:0.##}\u00A4 | {1,13:0.##}\u00A4 | {2,13:0.##}\u00A4 |";

            CH.WriteSeparator();

            //input
            string creditAmountString = CH.GetStringFromConsole(inputMsg1);
            string creditRateString = CH.GetStringFromConsole(inputMsg2);
            CH.WriteSeparator();

            bool amountIsInvalid = !decimal.TryParse(creditAmountString, out decimal originalCreditAmount);
            bool rateIsInvalid = !double.TryParse(creditRateString, out double creditInterestRate);


            if (amountIsInvalid || rateIsInvalid || originalCreditAmount <= 1 || creditInterestRate < 1 || creditInterestRate > 100)
            {
                Console.WriteLine(invalidInputMsg);
                Console.ReadKey();
                return;
            }


            Console.WriteLine(paymentTypeMsg);
            int choosedStringIndex = CH.GetChoiceFromUser(new[] { paymentTypeMsg1, paymentTypeMsg2 }, true).Item1;

            CH.WriteSeparator();

            
            decimal sumOfInterestCharges = 0m;
            decimal sumOfPayments = 0m;
            decimal debt = originalCreditAmount;

            creditInterestRate *= 0.01;

            //Table
            Console.WriteLine(tableLineMsg, "Период", "Задолженность", "Начисленные %",
                "Основной долг", "Сумма платежа");

            if (choosedStringIndex == 0) //аннуитетный платеж
            {
                double monthlyCreditInterestRate = creditInterestRate / 12;
                decimal amountOfPayment = originalCreditAmount *
                                          (decimal)(monthlyCreditInterestRate +
                                                     monthlyCreditInterestRate /
                                                     (Math.Pow(1 + monthlyCreditInterestRate, 12d) - 1d));

                for (int period = 1; period <= 12; period++)
                {
                    decimal interestCharges = debt * (decimal)monthlyCreditInterestRate;
                    decimal repaymentOfCredit = amountOfPayment - interestCharges;

                    Console.WriteLine(tableLineMsg, period, debt, interestCharges,
                        repaymentOfCredit, amountOfPayment);

                    debt -= repaymentOfCredit;

                    sumOfInterestCharges += interestCharges;
                    sumOfPayments += amountOfPayment;
                }
            }
            else //дифференцированный платеж
            {
                decimal repaymentOfCredit = originalCreditAmount / numberOfPeriods;
                int currentYear = DateTime.Today.Year;

                for (int period = 1; period <= 12; period++)
                {
                    decimal interestCharges =
                        debt * (decimal)(creditInterestRate * DateTime.DaysInMonth(currentYear, period) / 365d);
                    decimal amountOfPayment = repaymentOfCredit + interestCharges;

                    Console.WriteLine(tableLineMsg, period, debt, interestCharges,
                        repaymentOfCredit, amountOfPayment);

                    debt -= repaymentOfCredit;

                    sumOfInterestCharges += interestCharges;
                    sumOfPayments += amountOfPayment;
                }
            }


            CH.WriteSeparator();
            Console.WriteLine(tableFooterLineMsg, sumOfInterestCharges, originalCreditAmount, sumOfPayments);
            CH.WriteSeparator();

            //Exit
            Console.ReadKey();
        }
    }
}
