using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            //TODO 1.Создать консольное приложения для работы со списком покупок.
            //     2.Добавить возможность добавления покупки «называние» «цена»
            //     3.Добавить возможность «узнать цену товара»
            //     4.Добавить возможность «вывести товары дороже чем»

            var purchasesList = new Dictionary<string, decimal>();

            decimal filterValue = 0m;
            int filterDirection = 0;
            bool isPriceVisible = false;

            int selectedMenuIndex = -1;
            string[] menuOptions =
            {
                "Add purchase", //0
                "Set price filter", //1
                "Show/Hide prices", //2
                "Exit" //3
            };

            InitializePurchasesListByDefault(purchasesList);

            while (true)
            {
                Console.Clear();

                WritePurchasesListToConsole(purchasesList, isPriceVisible, filterDirection, filterValue);

                if (selectedMenuIndex == -1) // Show main menu
                {
                    Console.WriteLine("Options:");
                    selectedMenuIndex = CH.GetChoiceFromUser(menuOptions).ChoisedIndex;
                }
                else
                { 
                    switch (selectedMenuIndex)
                    {
                        case 0:
                            var newPurchase = GetNewPurchaseInfo();

                            if (purchasesList.ContainsKey(newPurchase.Item1))
                                Console.WriteLine("Purchase already exist in list or invalid");
                            else
                            {
                                purchasesList.Add(newPurchase.Item1, newPurchase.Item2);
                                Console.WriteLine("Purchase was added to list");
                            }
                            break;

                        case 1:
                            string[] options =
                            {
                                "No", //0
                                "Yes i do, i want to see purchases with price LOWER than...", //1
                                "Yes i do, i want to see purchases with price HIGHER than..." //2
                            };

                            Console.WriteLine("Do you want to filter list?");
                            filterDirection = CH.GetChoiceFromUser(options).ChoisedIndex;

                            if (filterDirection != 0)
                                filterValue = GetPriceFilterValue();
                            break;

                        case 2:
                            Console.WriteLine("Do you want to see prices in the purchases list?");
                            isPriceVisible = CH.GetChoiceFromUser(new[]{ "No", "Yes" }).ChoisedIndex != 0;
                            break;

                        case 3:
                            return;
                    }

                    selectedMenuIndex = -1;
                }
            }
        }

        private static void InitializePurchasesListByDefault(Dictionary<string, decimal> purchasesList)
        {
            purchasesList.Add("Cheese", 10.6M);
            purchasesList.Add("Wine", 26.6M);
            purchasesList.Add("Bread", 2.5M);
            purchasesList.Add("Bre@d", 2.56M);
        }

        private static void WritePurchasesListToConsole(Dictionary<string, decimal> purchasesList, bool isPriceVisible,
            int filterDirection, decimal filterValue)
        {
            const string captionStr = "Shopping List";
            const string filtrStr = "Filter applied to the list. Items with a price {0} than {1,25:C} are displayed.";
            const string listStrWithPrice = "|{0,25}|{1,15:C}|";
            const string listStrWithoutPrice = "|{0,25}|";


            Console.WriteLine(captionStr);
            CH.WriteSeparator();

            if (filterDirection != 0)
            {
                Console.WriteLine(filtrStr, filterDirection == 2 ? "higher" : "lower", filterValue);
                CH.WriteSeparator();
            }
            Console.WriteLine(isPriceVisible ? listStrWithPrice : listStrWithoutPrice, "Purchase name", "Price");

            foreach (var keyValuePair in purchasesList)
            {
                // TODO Немного 7.0 магии
                switch (filterDirection)
                {
                    case 1 when keyValuePair.Value > filterValue:
                    case 2 when keyValuePair.Value < filterValue:
                        continue;
                }

                Console.WriteLine(isPriceVisible ? listStrWithPrice : listStrWithoutPrice, keyValuePair.Key,
                    keyValuePair.Value);
            }

            Console.WriteLine(Environment.NewLine);
        }


        private static decimal GetPriceFilterValue()
        {
            bool isInputValid;
            decimal priceFilterValue;

            do
            {
                CH.WriteSeparator();

                string priceFilterValueStr = CH.GetStringFromConsole($"filter value [{0.5m:C}/{9.99m:C}]");

                isInputValid = decimal.TryParse(priceFilterValueStr, out priceFilterValue);
            } while (!isInputValid);

            return priceFilterValue;
        }

        private static Tuple<string, decimal> GetNewPurchaseInfo()
        {
            bool isInputValid;

            string purchaseName;
            decimal purchasePrice;

            do
            {
                CH.WriteSeparator();

                purchaseName = CH.GetStringFromConsole("Please input the purchase name [Butter/Wine/Caviar/ e.t.c.]");
                string purchasePriseStr = CH.GetStringFromConsole($"Please input the purchase price [{0.5m:C}/{9.99m:C}/ e.t.c.]");

                bool isValidPurchaseName = !string.IsNullOrWhiteSpace(purchaseName);
                bool isValidPurchasePrice = decimal.TryParse(purchasePriseStr, out purchasePrice);

                isInputValid = isValidPurchaseName && isValidPurchasePrice;


                if (!isInputValid) Console.WriteLine("Incorrect input. Try again.");
            } while (!isInputValid);

            return new Tuple<string, decimal>(purchaseName, purchasePrice);
        }
    }
}
