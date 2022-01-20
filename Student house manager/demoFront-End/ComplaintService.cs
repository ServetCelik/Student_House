using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace demoFront_End
{
    public class ComplaintService
    {
        public List<Complaint> complaintList { get; set; } = new List<Complaint>();
        private int complaintID = 1;
        private DataGridView dgv;
        // new field

        public static int count = 0;

        public ComplaintService(DataGridView dgv)
        {
            this.dgv = dgv;
        }

        //This is the method which is used to update datagridview on the complaint page
        public void updateListView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (var complaint in complaintList)
            {
                dataGridView.Rows.Add(complaint.ComplaintNo, complaint.Title, complaint.Respond);
            }
        }

        //This method is used to add new complaint
        public void create(string title, string details)
        {
            complaintList.Add(new Complaint(complaintID, title, details));
            complaintID++;

        }

        // This method is used to edit a complaint and update page
        internal void editItem(DataGridView dataGridView, string tbTitle, string tbDetails)
        {
            int selectedRow = this.dgv.CurrentCell.RowIndex;
            if (selectedRow >= 0)
            {
                this.complaintList[selectedRow].Title = tbTitle;
                this.complaintList[selectedRow].Details = tbDetails;
                this.updateListView(dataGridView);
            }
            
        }

        //This is a method to delete selected compliment
        public void delete(DataGridView dataGridView)
        {
            int selectedRow = dataGridView.CurrentCell.RowIndex;
            if (selectedRow >= 0)
            {
                complaintList.RemoveAt(selectedRow);
                updateListView(dataGridView);

            }
        }

        //This method is used when an admin wnat to respont to a complaint
        public void respond(DataGridView dataGridView, string respond)
        {
            int selectedRow = dataGridView.CurrentCell.RowIndex;
            if (selectedRow >= 0)
            {
                complaintList[selectedRow].Respond = respond;
                updateListView(dataGridView);

            }
        }

        //some dummy data for complaint page
        public void DummyDataComplaint(DataGridView dataGridView)
        {
            create("Garbage", "Due to the fact that some people do not fulfill their duty to dispose of the garbage, garbage accumulates in the kitchen and this causes a bad smell.");
            create("Noise", "Especially after midnight, we are disturbed by the noises coming from some rooms.");
            create("Crowded", "Since there are more people staying in the rooms than we planned, our personal spaces are limited and we cannot study comfortably.");
            create("Activities", "Due to the activities during the exam week, we cannot concentrate on our lessons. Is it possible to prevent these activities during the exam week?");
            updateListView(dataGridView);

        }

        //it shows details about a compliment of selected index
        public void GetDetails(DataGridView dataGridView)
        {
            int selectedRow = dataGridView.CurrentCell.RowIndex;

            if (selectedRow >= 0)
            {
                string details = complaintList[selectedRow].Details;
                MessageBox.Show(details);
            }
        }
    }
}