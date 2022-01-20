using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoFront_End
{
    public partial class tbTenName : Form
    {

        public Form1 form1 { get; set; }

        public Household tasklist;
        public List<RandomGame> randGameList = new List<RandomGame>();

        public ComplaintService complaintService;
        public FinanceService financeService;
        public ReservationService reservationService;
        public HouseholdManager householdManager;


        public Finance finance;
        Form1 login;

        // Announcement variables.
        private int selectedAnnouncement;

        public tbTenName(Form1 form1)
        {
            InitializeComponent();
            login = form1;
            this.complaintService = new ComplaintService(dataGridView1);
            this.financeService = new FinanceService();
            this.reservationService = new ReservationService();
            this.householdManager = new HouseholdManager();
            complaintService.DummyDataComplaint(dataGridView1);
            financeService.DummyDataFinance(dataGridView2, listBox1);
            UpdateHouseholdForReservationFinance();



            login.selectedHousehold.ViewRuleChange(dgvForRules);
            login.selectedHousehold.ViewTaskChange(dgvViewData);

            UpdateTaskTen();
            UpdateTaskTenForGame();

            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "HH:mm";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "HH:mm";

        }

        private void tpHomePage_Click(object sender, EventArgs e)
        {

        }
        private void UpdateTaskTen()
        {
            cbSelectTen.Items.Clear();

            foreach (Tenant item in login.selectedHouseholdTenantlist)
            {
                cbSelectTen.Items.Add(item.GetFullName());
            }

        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void tpGroceriesTab_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {

            if (cbTaskType.SelectedItem == null || tbTaskName.Text == string.Empty || cbSelectTen.SelectedItem == null)
            {
                MessageBox.Show("Fields can't be empty");

            }
            else
            {
                string taskName = tbTaskName.Text;
                string taskType = cbTaskType.SelectedItem.ToString();
                string assignedTenant = cbSelectTen.SelectedItem.ToString();

                foreach (Task t in login.selectedHouseholdTasklist)
                {

                    if (tbTaskName.Text == t.TaskName)
                    {
                        MessageBox.Show("Task already exists");
                        return;
                    }
                }

                login.selectedHousehold.AddTaskToHousehold(taskName, taskType, assignedTenant, "");
                login.selectedHousehold.ViewTaskChange(dgvViewData);
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (cbTaskType.SelectedItem == null || tbTaskName.Text == string.Empty || cbSelectTen.SelectedItem == null)
            {
                MessageBox.Show("Fields can't be empty");

            }
            else
            {
                EditTask();
            }
        }
        private void EditTask()
        {
            int indexTaskToBeEdited = dgvViewData.CurrentCell.RowIndex;

            if (indexTaskToBeEdited >= 0)
            {            
                login.selectedHousehold.taskList[indexTaskToBeEdited].TaskName = tbTaskName.Text;
                login.selectedHousehold.taskList[indexTaskToBeEdited].TaskType = cbTaskType.SelectedItem.ToString();
                login.selectedHousehold.taskList[indexTaskToBeEdited].AssignedTenant = cbSelectTen.SelectedItem.ToString();
                login.selectedHousehold.ViewTaskChange(dgvViewData);
            }
        }

        private void AgreeEditTask()
        {
            int indexTaskToBeEdited = dgvViewData.CurrentCell.RowIndex;

            if (cbTaskType.SelectedItem == null || tbTaskName.Text == string.Empty || cbSelectTen.SelectedItem == null)
            {
                login.selectedHousehold.taskList[indexTaskToBeEdited].AgreeBy = "Agree";
                login.selectedHousehold.ViewTaskChange(dgvViewData);

            }
            else if (indexTaskToBeEdited >= 0)
            {
                login.selectedHousehold.taskList[indexTaskToBeEdited].AgreeBy = "Agree";
                login.selectedHousehold.ViewTaskChange(dgvViewData);
            }
        }
        private void DisagreeEditTask()
        {
            int indexTaskToBeEdited = dgvViewData.CurrentCell.RowIndex;

            if (cbTaskType.SelectedItem == null || tbTaskName.Text == string.Empty || cbSelectTen.SelectedItem == null)
            {
                login.selectedHousehold.taskList[indexTaskToBeEdited].AgreeBy = "Disagree";
                login.selectedHousehold.ViewTaskChange(dgvViewData);

            }
            else if (indexTaskToBeEdited >= 0)
            {
                login.selectedHousehold.taskList[indexTaskToBeEdited].AgreeBy = "Disagree";
                login.selectedHousehold.ViewTaskChange(dgvViewData);
            }
        }
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            int indexTaskToDelete = dgvViewData.CurrentCell.RowIndex;

            if (indexTaskToDelete < 0)
            {
                MessageBox.Show("You need to choose something");

            }
            else if (indexTaskToDelete >= 0)
            {
                login.selectedHousehold.DeleteTask(tbTaskName.Text, cbTaskType.SelectedItem.ToString(), cbSelectTen.SelectedItem.ToString(), cbSelectTen.SelectedItem.ToString(), indexTaskToDelete);
                login.selectedHousehold.ViewTaskChange(dgvViewData);
            }
        }

        private void lbTask_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void rbAgree_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tpAgreeAndTask_Click(object sender, EventArgs e)
        {

        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            login.selectedHousehold.ViewRuleChange(dgvForRules);

        }

        private void dgvForRules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnShowTask_Click(object sender, EventArgs e)
        {
            login.selectedHousehold.ViewTaskChange(dgvViewData);
        }

        private void rbDisagree_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
        //a button which add complaint in the complaint tab of tenant form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string details = tbDetails.Text;
            if (!string.IsNullOrEmpty(title) & !string.IsNullOrEmpty(details))
            {
                complaintService.create(title, details);
                complaintService.updateListView(dataGridView1);
            }
            else
            {
                MessageBox.Show("Pls fill all the boxes");
            }

        }
        //void b_Click(object sender, EventArgs e)
        //{
        //    var button = sender As Button;
        //    button.Text = counter.ToString();
        //    button.Click -= b_Click;
        //    counter++;
        //}


        //a button which edits an complaint of tenant form
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            complaintService.editItem(dataGridView1, tbTitle.Text, tbDetails.Text);
            complaintService.updateListView(dataGridView1);
        }

        //a button which deletes selected complaint in the compaint tab of tenant form
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            complaintService.delete(dataGridView1);
            complaintService.updateListView(dataGridView1);
        }


        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            int checkQuantity;
            double checkPrice;

            if ((int.TryParse(tbQuantity.Text, out checkQuantity)) & (double.TryParse(tbPrice.Text, out checkPrice)))
            {
                int quantity = Convert.ToInt32(tbQuantity.Text);
                double price = Convert.ToDouble(tbPrice.Text);
                financeService.buyItem(cBHouseholdFinance.Text, login.GetLoggedInTen().GetUserName(), tbItem.Text, quantity, price);
                financeService.updateFinance(dataGridView2, listBox1, cBHouseholdFinance.Text);
            }
            else
            {
                MessageBox.Show($"Please fill all the box correctly");
            }
        }


        private void rbAgree_CheckedChanged_1(object sender, EventArgs e)
        {
            AgreeEditTask();
        }

        private void rbDisagree_CheckedChanged_1(object sender, EventArgs e)
        {
            DisagreeEditTask();
        }

        private void tbDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        //a button which shows details of selected complaint of tenant form
        private void btnDetails_Click(object sender, EventArgs e)
        {
            complaintService.GetDetails(dataGridView1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnLogOut_MouseHover(object sender, EventArgs e)
        {
            btnLogOut.ImageIndex = 0;
            btnLogOut.FlatAppearance.BorderSize = 1;
            btnLogOut.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut.ImageIndex = 1;
            btnLogOut.FlatAppearance.BorderSize = 0;
        }

        private void btnLogOut2_MouseHover(object sender, EventArgs e)
        {
            btnLogOut2.ImageIndex = 0;
            btnLogOut2.FlatAppearance.BorderSize = 1;
            btnLogOut2.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut2_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut2.ImageIndex = 1;
            btnLogOut2.FlatAppearance.BorderSize = 0;
        }

        private void btnLogOut3_MouseHover(object sender, EventArgs e)
        {
            btnLogOut3.ImageIndex = 0;
            btnLogOut3.FlatAppearance.BorderSize = 1;
            btnLogOut3.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut3_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut3.ImageIndex = 1;
            btnLogOut3.FlatAppearance.BorderSize = 0;
        }

        private void btnLogOut4_MouseHover(object sender, EventArgs e)
        {
            btnLogOut4.ImageIndex = 0;
            btnLogOut4.FlatAppearance.BorderSize = 1;
            btnLogOut4.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut4_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut4.ImageIndex = 1;
            btnLogOut4.FlatAppearance.BorderSize = 0;
        }

        private void btnLogOut5_MouseHover(object sender, EventArgs e)
        {
            btnLogOut5.ImageIndex = 0;
            btnLogOut5.FlatAppearance.BorderSize = 1;
            btnLogOut5.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut5_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut5.ImageIndex = 1;
            btnLogOut5.FlatAppearance.BorderSize = 0;
        }

        private void btnLogOut5_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void btnLogOut4_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void btnLogOut3_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void btnLogOut2_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void btnLogOut1_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        private void UpdateTaskTenForGame()
        {
            cbAssignedTenForGame.Items.Clear();

            foreach (User item in login.selectedHouseholdTenantlist)
            {
                cbAssignedTenForGame.Items.Add(item.GetFullName());
            }

        }

        private void RandomGame()
        {
            Random randGame = new Random();
            int index = randGame.Next(0, randGameList.Count);

            string answerOfRandGame = lbDisplayTenForGame.Items[index].ToString();

            lbGameAnswer.Text = "Chosen tenant is: " + answerOfRandGame;

        }
        private void btnForGameAddTen_Click(object sender, EventArgs e)
        {
            string selectedTenForGame = cbAssignedTenForGame.SelectedItem.ToString();

            RandomGame randGameTen;

            randGameTen = new RandomGame(selectedTenForGame);

            if (lbDisplayTenForGame.Items.Contains(selectedTenForGame))
            {
                return;
            }

            randGameList.Add(randGameTen);
            lbDisplayTenForGame.Items.Add(randGameTen.GetInfo());
        }

        private void btnRemoveGameTen_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbDisplayTenForGame.SelectedIndex;

            randGameList.RemoveAt(selectedIndex);
            lbDisplayTenForGame.Items.RemoveAt(selectedIndex);
        }

        private void btnForRandomGame_Click(object sender, EventArgs e)
        {
            RandomGame();
        }

        private void tcHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When tab changes to mail tab refresh mail.
            if (tcHome.SelectedTab.Name == "tpMail")
            {
                foreach (Tenant tenant in login.selectedHouseholdTenantlist)
                {
                    chlbxMail.Items.Add(tenant.GetFullName());
                }
            }
        }

        // ------- Announcements -------

        public void UpdateAnnouncementList()
        {
            // Add announcements to listbox.
            lbxAnnouncements.Items.Clear();
            
            foreach (Announcement announcement in login.selectedHouseholdAnnouncementsList)
            {
                lbxAnnouncements.Items.Add(announcement.GetAnnouncementTitle());
            }
        }
        private void btAddAnnouncement_Click(object sender, EventArgs e)
        {
            // Make title and description variables.
            string title = txbAnnouncementTitle.Text;
            string description = txbAnnouncementDescription.Text;

            // Add announcement to list, if textboxes empty show error.
            if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(description))
            {
                lbAnnouncementError.Text = "Please fill in all fields.";
            }
            else
            {

                login.selectedHousehold.AddAnnouncementToList(title, description);

            }

            // Update announcement list.

            UpdateAnnouncementList();
        }

        private void btEditAnnouncement_Click(object sender, EventArgs e)
        {
            // Make title and description variables.
            string title = txbAnnouncementTitle.Text;
            string description = txbAnnouncementDescription.Text;

            // Edit selected announcement.
            login.selectedHousehold.EditAnnouncementFromList(selectedAnnouncement, title, description);
            UpdateAnnouncementList();
        }

        private void lbxAnnouncements_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            // Show title and description in textboxes to edit.
            // Show title and description in label for info.
            foreach (Announcement announcement in login.selectedHousehold.GetAnnouncementList())
            {
                if (announcement.GetAnnouncementId() == selectedAnnouncement)
                {
                    txbAnnouncementDescription.Text = announcement.GetAnnouncementDescription();
                    txbAnnouncementTitle.Text = announcement.GetAnnouncementTitle();
                    lbAnnouncementDescriptionInfo.Text = announcement.GetAnnouncementDescription();
                    lbAnnouncementTitleInfo.Text = announcement.GetAnnouncementTitle();
                }
            }
            // Save selected announcement.
            selectedAnnouncement = lbxAnnouncements.SelectedIndex;
        }

        private void btDeleteAnnouncement_Click(object sender, EventArgs e)
        {
            // Delete selected announcement from list.
            login.selectedHousehold.DeleteAnnouncementFromList(selectedAnnouncement);
            UpdateAnnouncementList();
        }

        // ------ Mail ------

        private void chlbxMail_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // When item is checked in checked listbox, check if logged in tenant has mail.
            // If so show you have mail message.
            foreach (Tenant tenant in login.selectedHouseholdTenantlist)
            {
                foreach(int index in chlbxMail.CheckedIndices)
                {
                    if (index == login.GetLoggedInTenId())
                    {
                        lbHasMail.Text = "You have mail!";
                    }
                }
            }
        }

        // ------ Password changeing ------
        private void btChangePassword_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txbPasswordChange.Text))
            {
                login.GetLoggedInTen().SetPassword(txbPasswordChange.Text);
                lbPasswordChangeError.Text = "Password succesfully changed.";
            } else
            {
                lbPasswordChangeError.Text = "Password cannot be empty.";
            }
            
        }

        //a button which deletes an item in the finance tab of tenant form
        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            
            financeService.delete(dataGridView2, login.GetLoggedInTen().GetUserName());
            financeService.updateFinance(dataGridView2, listBox1, cBHouseholdFinance.Text);
        }

        //a button which adds an item in the finance tab of tenant form
        private void btnItemAdd_Click_1(object sender, EventArgs e)
        {
            int checkQuantity;
            double checkPrice;

            if ((int.TryParse(tbQuantity.Text, out checkQuantity)) & (double.TryParse(tbPrice.Text, out checkPrice)))
            {
                int quantity = Convert.ToInt32(tbQuantity.Text);
                double price = Convert.ToDouble(tbPrice.Text);
                financeService.buyItem(cBHouseholdFinance.Text, login.GetLoggedInTen().GetUserName(), tbItem.Text, quantity, price);
                financeService.updateFinance(dataGridView2, listBox1, cBHouseholdFinance.Text);
            }
            else
            {
                MessageBox.Show($"Please fill all the box correctly");
            }
        }

        //a button which adds an reservation for tenants
        private void btnReservation_Click(object sender, EventArgs e)
        {
            DateTime selectedDay = monthCalendarReservation.SelectionRange.End;
            var startAt = dateTimePickerStart.Value;
            var endAt = dateTimePickerEnd.Value;

            reservationService.AddReservation(cBHouseholdReservation.Text, login.GetLoggedInTen().GetUserName(), cBPlaces.Text, selectedDay, startAt, endAt, listBoxReservation);
        }

        //a button which deletes an reservation for tenants
        private void btnCancellation_Click(object sender, EventArgs e)
        {
            int selectedItem = listBoxReservation.SelectedIndex;
            reservationService.DeleteReservation(selectedItem, listBoxReservation);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ImageIndex = 0;
            button1.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ImageIndex = 1;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ImageIndex = 0;
            button2.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ImageIndex = 1;
            button2.FlatAppearance.BorderSize = 0;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ImageIndex = 0;
            button3.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ImageIndex = 1;
            button3.FlatAppearance.BorderSize = 0;
        }

        private void UpdateHouseholdForReservationFinance()
        {
            cBHouseholdFinance.Items.Clear();
            cBHouseholdReservation.Items.Clear();

            foreach (Household item in householdManager.GetList())
            {
                cBHouseholdFinance.Items.Add(item.GetHouseholdAddress());
                cBHouseholdReservation.Items.Add(item.GetHouseholdAddress());
            }
        }

        //a button which shows details in the finance tab of tenant form
        private void btnShow_Click_1(object sender, EventArgs e)
        {
            financeService.updateFinance(dataGridView2, listBox1, cBHouseholdFinance.Text);
        }
    }
}