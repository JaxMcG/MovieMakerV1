using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMakerV1
{
    class TicketHolder
    {

        //Attributes or Fields
        private string name;
        private int age;
        private int numberTickets;
        private bool credit;


        //Stores the Indexs of the Snacks that Have Been Ordered
        private List<int> snackOrder = new List<int>();
        private List<int> snackQuantity = new List<int>();
        //Stores the Indexs of the Drinks that Have Been Ordered
        private List<int> drinkOrder = new List<int>();
        private List<int> drinkQuantity = new List<int>();


        //Constructor - Constructs an Object of this Class
        public TicketHolder(string name, int age, int nTickets)
        {
            this.name = name;
            this.age = age;
            numberTickets = nTickets;
        }


        //Returns the Value in the Private Age Variable
        public int GetAge()
        {
            return this.age;
        }


        public int GetTickets()
        {
            return numberTickets;
        }


        //get the snack order
        public List<int> GetSnackOrder()
        {
            return snackOrder;
        }


        //get the snack order quantities
        public List<int> GetSnackQuantity()
        {
            return snackQuantity;
        }


        //get the drinks order
        public List<int> GetDrinkOrder()
        {
            return drinkOrder;
        }


        //get the drinks order quantities
        public List<int> GetDrinkQuantity()
        {
            return drinkQuantity;
        }


        //Sets the Value of the Private Age Variable
        public void SetAge(int newAge)
        {
            this.age = newAge;
        }


        //Sets the 
        public void SetCredit(bool newPaymentType)
        {
            credit = newPaymentType;
        }


        //Add Snacks and Quantities to the snackOrder List and snackQuantities List
        public void AddSnacks(List<int> snacks, List<int> quantities)
        {
            snackOrder = snacks;
            snackQuantity = quantities;
        }


        //Add Drinks and Quantities to the drinksOrder List and drinkQuantities List
        public void AddDrinks(List<int> drinks, List<int> quantities)
        {
            drinkOrder = drinks;
            drinkQuantity = quantities;
        }


        //Returns string stating if the TicketHolder is Paying Cash or Credit
        private string PaymentType()
        {
            string paymentType = "card";

            if (credit == false)
            {
                paymentType = "cash";
            }

            return paymentType;
        }


        //Returns the Total Cost for the Purchased Items
        public float CalculateTotalCost(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            float totalCost = 0f;

            //Loop Through Snack Order and Calculate the Cost for Each Snack
            for (int snackIndex = 0; snackIndex < snackOrder.Count; snackIndex++)
            {
                float snackPrice = sPrices[snackOrder[snackIndex]];

                //Add the Cost of Each Snack to totalCost
                totalCost += snackPrice * snackQuantity[snackIndex];
            }

            //Loop Through Drink Order and Calculate the Cost for Each Drink
            for (int drinkIndex = 0; drinkIndex < drinkOrder.Count; drinkIndex++)
            {
                float drinkPrice = dPrices[drinkOrder[drinkIndex]];

                //Add the Cost of Each Drink to totalCost
                totalCost += drinkPrice * drinkQuantity[drinkIndex];
            }

            totalCost += CalculateTicketCost(ticketPrice);

            return totalCost;
        }


        //Return Ticket Summary
        private string TicketSummary(float ticketPrice)
        {
            return "-------------------------\n" + $"{numberTickets} = Tickets\t${CalculateTicketCost(ticketPrice)}\n-------------------------\n";
        }

        //Calculate the Ticket Cost
        public float CalculateTicketCost(float ticketPrice)
        {
            return numberTickets * ticketPrice;
        }


        //Return a Summary of the Drinks and Snacks Order
        private string SnackDrinkSummary(List<string> sList, List<float> sPrices, List<string> dList, List<float> dPrices)
        {
            string summary = "Snacks and Drinks\n";

            //Loop Through Snack Orders and Add Quantity, Snack, Total Item Cost to Summary
            for (int snackIndex = 0; snackIndex < snackOrder.Count; snackIndex++)
            {
                summary += snackQuantity[snackIndex] + " x  " + sList[snackOrder[snackIndex]] + "\t$"+(snackQuantity[snackIndex] * sPrices[snackOrder[snackIndex]]) + "\n";   
            }

            for (int drinkIndex = 0; drinkIndex < drinkOrder.Count; drinkIndex++)
            {
                summary += drinkQuantity[drinkIndex] + " x  " + dList[drinkOrder[drinkIndex]] + "\t$" + (drinkQuantity[drinkIndex] * dPrices[drinkOrder[drinkIndex]]) + "\n";
            }

            return summary;
        }


        //Check if a Surcharge is Required
        //private bool GetSurcharge()
        //{
            //return credit;
        //}


        //Returns a String Displaying Surcharge Cost
        private string SurchargeSummary(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            string summary = "";

            if (credit)
            {
                summary += "Surcharge\t$" + CalculateSurcharge(sPrices, dPrices, ticketPrice);
            }

            return summary;
        }


        //Return the Surcharge Amount
        private float CalculateSurcharge(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            float surcharge = CalculateTotalCost(sPrices, dPrices, ticketPrice) * 0.05f;

            return surcharge;
        }


        //Calculate the Total Amount to be Paid
        private float CalculateTotalPayment(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            float totalPayment = CalculateTotalCost(sPrices, dPrices, ticketPrice);

            if (credit)
            {
                totalPayment += CalculateSurcharge(sPrices, dPrices, ticketPrice);
            }

            return totalPayment;
        }


        //Return a Summary of the Total Amount to be paid
        private string TotalPaymentSummary(List<float> sPrices, List<float> dPrices, float ticketPrice)
        {
            return "Total\t$" + CalculateTotalPayment(sPrices, dPrices, ticketPrice);
        }


        //Returns a String Displaying the Reciept for the Purchased Items
        public string GenerateReceipt(float tPrice, List<string> sList, List<float> sPrices, List<string> dList, List<float> dPrices)
        {
            string reciept = $"name: {name}\nAge: {age}\nPayment Type: {PaymentType()}\n" +
                $"{TicketSummary(tPrice)}\n{SnackDrinkSummary(sList, sPrices, dList, dPrices)}\n" +
                $"{SurchargeSummary(sPrices, dPrices, tPrice)}\n\n{TotalPaymentSummary(sPrices, dPrices, tPrice)}";

            return reciept;
        }


        //Returns a String Collating All the Values Stored in the Private Variables
        public override string ToString()
        {
            return $"Name: {name}\tAge: {age}\tNoTickets: {numberTickets}";
        }
    }
}
