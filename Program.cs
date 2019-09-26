using System;
using static System.Console;
using bankomat.Domain;
using System.Threading;
namespace bankomat
{
    class Program
    {
        static Card[] cardList = new Card[100];
        static void Main(string[] args)
        {
            bool isValidCard = false;
            Account stinasKonto = new Account(10000m);
            Account nissesKonto = new Account(10000m);

            cardList[0] = new DebitCard(cardNumber: "123", pinCode: "123", stinasKonto);
            cardList[1] = new DebitCard(cardNumber: "321", pinCode: "321", nissesKonto);

            while (true)
            {
                Clear();

                Write("Card number: ");

                string cardNumber = ReadLine();

                Write("Pin code: ");

                string pinCode = ReadLine();

                Clear();

                Card validCard = FindValidCard(cardNumber, pinCode);

                if (validCard != null)
                {
                    isValidCard = true;
                }
                else
                {
                    WriteLine("Invalid card");

                    Thread.Sleep(2000); // 2 sec
                }

                while (isValidCard)
                {
                    WriteLine("1. Withdraw");
                    WriteLine("2. View details");
                    WriteLine("3. Abort");

                    ConsoleKeyInfo keyPressed = ReadKey(true);

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:

                            Write("Amount: ");

                            decimal amount = decimal.Parse(ReadLine());
                            WriteLine();

                            if (validCard.Withdraw(amount))
                            {
                                WriteLine("Success");
                            }
                            else
                            {
                                WriteLine("Not enough Founds");
                            }
                            Thread.Sleep(2000);
                            break;
                        case ConsoleKey.D3:

                            isValidCard = false;

                            break;
                    }
                }
    }
        }

        static Card FindValidCard(string cardNumber, string pinCode)
            {
                Card foundCard = null;

                for (int i = 0; i < cardList.Length; i++)
                {
                    if (cardList[i] == null) continue;

                    if (cardList[i].CardNumber == cardNumber && cardList[i].PinCode == pinCode)
                    {
                        foundCard = cardList[i];
                        break;
                    }
                }

                return foundCard;
            }
        }
    }

