using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoFront_End
{
    public class Complaint
    {
        private int complaintNo;
        private string title;
        private string details;
        private string respond;
       


        public Complaint(int complaintNo, string title, string details)
        {
            this.ComplaintNo = complaintNo;
            this.Title = title;
            this.Details = details;
            this.Respond = "Not responded yet";
            
        }


        public string Title { get => title; set => title = value; }
        public string Details { get => details; set => details = value; }
        public string Respond { get => respond; set => respond = value; }
        public int ComplaintNo { get => complaintNo; set => complaintNo = value; }
        
    }
}
