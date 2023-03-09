using System;
using System.Collections.Generic;

namespace MovieMakerV1
{
    class Program
    {
        static void Main(string[] args)
        { 
            List<string> availableSnacks = new List<string>() { "Popcorn", "Chips", "Chocolate"};
            List<float> snackPrices = new List<float>() { 2.50f, 1.50f, 2 };

            List<string> availableDrinks = new List<string>() { "Fanta", "L&P",};
            List<float> drinkPrices = new List<float>() { 2.50f, 1.50f,};

            float ticketPrice = 5f;

            Console.WriteLine("~~~~~~~~~~~~~~~~ Ticket Holder Testing ~~~~~~~~~~~~~~~~");

            TicketHolder testTH = new TicketHolder("Charlie", 18, 3);

            Console.WriteLine(testTH.ToString());

            List<int> s = new List<int>() { 0, 2};
            List<int> sq = new List<int>() {2, 1};

            testTH.AddSnacks(s, sq);

            List<int> d = new List<int>() {1};
            List<int> dq = new List<int>() {2};

            testTH.AddDrinks(d, dq);

            testTH.SetAge(18);

            testTH.SetCredit(true);

            Console.WriteLine(testTH.GenerateReceipt(ticketPrice, availableSnacks, snackPrices, availableDrinks, drinkPrices));

            Console.WriteLine("~~~~~~~~~~~~~~~~ Ticket Manager Testing ~~~~~~~~~~~~~~~\n");

            TicketManager tm = new TicketManager();

            string name = "Charlie";
            int age = 18;
            int tickets = 3;

            if(tm.CheckAge(age, 0))
            {
                if (tm.CheckAvailableSeats(tickets))
                {
                    tm.AddTicketHolder(new TicketHolder(name, age, tickets));
                }
                else
                {
                    Console.WriteLine($"There are only {tm.CalculateAvailableSeats()} tickets available");
                }
            }
            else
            {
                Console.WriteLine("You are too young to watch this movie");
            }

            tm.AddSnacksDrinksOrder(s, sq, d, dq);

            Console.WriteLine($"Total seats sold: {tm.GetSeatLimit() - tm.CalculateAvailableSeats()}");

            Console.ReadLine();
        }
    }
}
