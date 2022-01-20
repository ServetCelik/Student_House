using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoFront_End
{
    public class FinanceService
    {
        public List<Finance> financeList { get; set; } = new List<Finance>();        

        public FinanceService()
        {
            this.financeList = new List<Finance>();
        }

        //A method which is used when somebody buys sth and add it to this app
        public void buyItem(string household, string who, string what, int quantity, double price)
        {
            financeList.Add(new Finance(household, who, what, quantity, price));
        }

        //This method is used when we update datagridview and listbox in the finance page
        public void updateFinance(DataGridView dataGridView, ListBox listBox, string household)
        {
            dataGridView.Rows.Clear();
            listBox.Items.Clear();            
            double totalSpending = 0;

            //update datagridview and calculate total spending
            foreach (Finance item in financeList)
            {
                if (item.Household == household)
                {
                    dataGridView.Rows.Add(item.PurchaseNo, item.ByWho, item.ItemName, item.Quantity, item.Price, item.TotalPrice);
                    totalSpending += item.TotalPrice;
                }
            }

            listBox.Items.Add($"Total amount of money spent in this household is: {totalSpending}");


            //Calculate how much each person should pay more or get back
           
            foreach (var item in Form1.lTenant)
            {
                double userExpense = 0;


                foreach (Finance items in financeList)
                {
                    if (item.GetUserName() == items.ByWho & items.Household == household)
                    {
                        userExpense += items.TotalPrice;
                    }
                }


                if (userExpense > (totalSpending / Form1.lTenant.Count))
                {
                    listBox.Items.Add($"{item.GetUserName()} spent {userExpense} totally and will get back {userExpense - (totalSpending / Form1.lTenant.Count)}");
                }
                else
                {
                    listBox.Items.Add($"{item.GetUserName()} spent {userExpense} totally and will give {(totalSpending / Form1.lTenant.Count) - userExpense} more");
                }

            }
        }

        //Dummy data which is added on the finance page when we start this app
        public void DummyDataFinance(DataGridView dataGridView, ListBox listBox)
        {
            buyItem("Toothbrushlane 86D\r\n6719BO Brooklyn", "LiveLaughLove", "apple", 5, 10);
            buyItem("Burgundy Street 42B\r\n5584TR Asgard", "VisserMan", "paper", 2, 5);
            buyItem("Toothbrushlane 86D\r\n6719BO Brooklyn", "BerendBotje", "food", 1, 7);
            buyItem("Burgundy Street 42B\r\n5584TR Asgard", "KikkerKop", "vegatable", 3, 10);
            buyItem("Toothbrushlane 86D\r\n6719BO Brooklyn", "LiveLaughLove", "fruit ", 4, 8);
            buyItem("Burgundy Street 42B\r\n5584TR Asgard", "VisserMan", "cleaning materials", 1, 1);
            buyItem("Burgundy Street 42B\r\n5584TR Asgard", "BerendBotje", "cleaning materials", 5, 6);
            buyItem("Toothbrushlane 86D\r\n6719BO Brooklyn", "KikkerKop", "cleaning materials", 5, 20);

            //updateFinance(dataGridView, listBox);
        }

        //This is the method which we use when we delete an item from finance list
        public void delete(DataGridView dataGridView, string name)
        {
            int selectedRow = dataGridView.CurrentCell.RowIndex;
            int selectedPurchaseNumber =Convert.ToInt32(dataGridView.Rows[selectedRow].Cells[0].Value);
            string selectedName = Convert.ToString(dataGridView.Rows[selectedRow].Cells[1].Value);
            if (selectedRow >= 0 & selectedName == name)
            {
                for (int i = 0; i < financeList.Count; i++)
                {
                    if (financeList[i].PurchaseNo == selectedPurchaseNumber)
                    {
                        financeList.RemoveAt(i);
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Select one of the rows which you made");
            }
        }
    }
}
