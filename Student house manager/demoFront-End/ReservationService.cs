using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoFront_End
{
    public class ReservationService
    {
        //This is a list which contains all the reservations.
        List<Reservation> reservationList { get; set; } = new List<Reservation>();

        //this method controls whether selected time and place was reserved by someone else
        public bool CheckDate(DateTime day, DateTime date, string where, string household)
        {
            foreach (var item in reservationList)
            {
                if (item.Place == where & item.Day == day & item.StartTime <= date & item.EndTime >= date & item.Household == household)
                {
                    return false;
                }
            }
            return true;
        }

        //This method is used when a new reservation is added
        public void AddReservation(string household, string who, string where, DateTime day, DateTime start, DateTime end, ListBox listBoxReservation)
        {
            if (!string.IsNullOrEmpty(where) & !string.IsNullOrEmpty(household))
            {
                if (CheckDate(day, start, where, household) & CheckDate(day, end, where, household))
                {
                    if (start < end)
                    {
                        reservationList.Add(new Reservation(household, who, where, day, start, end));
                    }
                    else
                    {
                        reservationList.Add(new Reservation(household, who, where, day, end, start));
                    }


                    UpdateLB(listBoxReservation);
                }
                else
                {
                    MessageBox.Show("It is already reserved");
                }
            }
            else
            {
                MessageBox.Show("First choose which place you want to reserve");
            }

        }

        //A method to update our listbox in reservation page
        public void UpdateLB(ListBox listBoxReservation)
        {
            listBoxReservation.Items.Clear();
            foreach (var item in reservationList)
            {
                listBoxReservation.Items.Add($"{item.Place} is reserved on {item.Day.ToString("dd/MM/yyyy")} between {item.StartTime.ToString("HH:mm")} and {item.EndTime.ToString("HH:mm")} by {item.WhoReserved} in {item.Household.Split(' ').FirstOrDefault()}");
            }
        }

        //a method which delete specific reservation in the reservation list and update listbox
        public void DeleteReservation(int selectedIndex, ListBox listBoxReservation)
        {
            if (selectedIndex != -1)
            {
                reservationList.RemoveAt(selectedIndex);
                UpdateLB(listBoxReservation);
            }
            else
            {
                MessageBox.Show("Firstly select an item of the listbox");
            }
        }


    }
}
