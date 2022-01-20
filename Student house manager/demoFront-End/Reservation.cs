using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoFront_End
{
    public class Reservation
    {
        private string household;
        private string whoReserved;
        private string place;
        private DateTime day;
        private DateTime startTime;
        private DateTime endTime;


        public Reservation(string household, string whoReserved, string place, DateTime day, DateTime startTime, DateTime endTime)
        {
            this.household = household;
            this.whoReserved = whoReserved;
            this.place = place;
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public string WhoReserved { get => whoReserved; set => whoReserved = value; }
        public string Place { get => place; set => place = value; }
        public DateTime Day { get => day; set => day = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public string Household { get => household; set => household = value; }
    }
}
