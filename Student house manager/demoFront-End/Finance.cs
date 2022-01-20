using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class Finance
    {
        private static int numberSeeder = 1000;

        private string household;
        private string byWho;
        private string itemName;
        private int quantity;
        private double price;
        private double totalPrice;
        private int purchaseNo;

        public Finance(string household, string byWho, string itemName, int quantity, double price)
        {
            this.household = household;
            this.byWho = byWho;
            this.itemName = itemName;
            this.quantity = quantity;
            this.price = price;
            this.totalPrice = price * quantity;
            this.purchaseNo = numberSeeder++;
        }

        public string ByWho { get => byWho; set => byWho = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Household { get => household; set => household = value; }
        public int PurchaseNo { get { return this.purchaseNo; } }
    }
}
