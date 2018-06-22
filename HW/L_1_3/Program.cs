using System;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            const int numberOfPeriods = 12;

            const string inputMsg1 = "Введите cумму кредитования, \u00A4";
            const string inputMsg2 = "Введите ставку кредитования, % [1 - 100% как 15,5% ]";
            const string paymentTypeMsg = "Выберите вид платежа:";
            const string paymentTypeMsg1 =
                "1 - аннуитетный платеж - это равный по сумме ежемесячный платеж по кредиту;";
            const string paymentTypeMsg2 =
                "2 - дифференцированный платеж -  это ежемесячный платеж, уменьшающийся к концу срока кредитования.";
            const string invalidInputMsg = "Введены неверные значения...";
            const string tableLineMsg =
                " | {0,6} | {1,13:0.##}\u00A4 | {2,13:0.##}\u00A4 | {3,13:0.##}\u00A4 | {4,13:0.##}\u00A4 |";
            const string tableFooterLineMsg = " | Итого: | {0,30:0.##}\u00A4 | {1,13:0.##}\u00A4 | {2,13:0.##}\u00A4 |";

            CH.WriteSeparator();

            //input
            var creditAmountString = CH.GetStringFromConsole(inputMsg1);
            var creditRateString = CH.GetStringFromConsole(inputMsg2);
            CH.WriteSeparator();

            var amountIsInvalid = !decimal.TryParse(creditAmountString, out var originalCreditAmount);
            var rateIsInvalid = !double.TryParse(creditRateString, out var creditInterestRate);


            if (amountIsInvalid || rateIsInvalid || originalCreditAmount <= 1 || creditInterestRate < 1 ||
                creditInterestRate > 100)
            {
                Console.WriteLine(invalidInputMsg);
                Console.ReadKey();
                return;
            }


            Console.WriteLine(paymentTypeMsg);
            var choosedStringIndex = CH.GetChoiceFromUser(new[] {paymentTypeMsg1, paymentTypeMsg2}, true).ChoisedIndex;

            CH.WriteSeparator();


            var sumOfInterestCharges = 0m;
            var sumOfPayments = 0m;
            var debt = originalCreditAmount;

            creditInterestRate *= 0.01;

            //Table
            Console.WriteLine(tableLineMsg, "Период", "Задолженность", "Начисленные %",
                "Основной долг", "Сумма платежа");

            if (choosedStringIndex == 0) //аннуитетный платеж
            {
                var monthlyCreditInterestRate = creditInterestRate / 12;
                var amountOfPayment = originalCreditAmount *
                                      (decimal) (monthlyCreditInterestRate +
                                                 monthlyCreditInterestRate /
                                                 (Math.Pow(1 + monthlyCreditInterestRate, 12d) - 1d));

                for (var period = 1; period <= 12; period++)
                {
                    var interestCharges = debt * (decimal) monthlyCreditInterestRate;
                    var repaymentOfCredit = amountOfPayment - interestCharges;

                    Console.WriteLine(tableLineMsg, period, debt, interestCharges,
                        repaymentOfCredit, amountOfPayment);

                    debt -= repaymentOfCredit;

                    sumOfInterestCharges += interestCharges;
                    sumOfPayments += amountOfPayment;
                }
            }
            else //дифференцированный платеж
            {
                var repaymentOfCredit = originalCreditAmount / numberOfPeriods;
                var currentYear = DateTime.Today.Year;

                for (var period = 1; period <= 12; period++)
                {
                    var interestCharges =
                        debt * (decimal) (creditInterestRate * DateTime.DaysInMonth(currentYear, period) / 365d);
                    var amountOfPayment = repaymentOfCredit + interestCharges;

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