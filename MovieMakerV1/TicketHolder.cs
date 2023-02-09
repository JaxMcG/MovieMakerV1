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
        private List<string> snackOrder = new List<string>();
        private List<int> snackQuantity = new List<int>();
        private List<string> drinkOrder = new List<string>();
        private List<int> drinkQuantity = new List<int>();

        //Constructor - Constructs an Object of this Class
        public TicketHolder()
        {

        }
        //Returns the Value in the Private Age Variable
        public int GetAge()
        {
            return 0;
        }
        //Sets the Value of the Private Age Variable
        public void SetAge(int newAge)
        {

        }
        //Returns the Total Cost for the Purchased Items
        public float CalculateTotalCost()
        {
            return 0.0f;
        }
        //Returns a String Displaying the Reciept for the Purchased Items
        public string CreateReceipt()
        {
            return "";
        }
        //Returns a String Collating All the Values Stored in the Private Variables
        public override string ToString()
        {
            return "";
        }

    }
}
