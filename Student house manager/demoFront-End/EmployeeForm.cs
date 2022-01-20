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
    public partial class EmployeeForm : Form
    {
        //Form1 loginPage;
        public Form1 form1 { get; set; }


        public Household tasklist;
        public List<RandomGame> randGameList = new List<RandomGame>();

        public ComplaintService complaintService;
        public FinanceService financeService;
        public ReservationService reservationService;

        public Household listOfTen;
        public HouseholdManager householdManager;
        int selectedHouseholdItem;
        int selectedTenantItem;
        int selectedAnnouncement;

        Form1 login;

        public EmployeeForm(Form1 form1)
        {
            InitializeComponent();
            login = form1;
            complaintService = new ComplaintService(dataGridView2);
            financeService = new FinanceService();
            this.reservationService = new ReservationService();
            complaintService.DummyDataComplaint(dataGridView1);
            financeService.DummyDataFinance(dataGridView2, listBox1);

            householdManager = new HouseholdManager();

            UpdateTaskTenForGame();
            UpdateTaskTen();
            UpdateHousehold();
            UpdateTaskHousehold();
            UpdateHHSelection();
            UpdateHouseholdForReservationFinance();

            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "HH:mm";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "HH:mm";
        }

        private void lbxHouseholds_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

        private void UpdateHHSelection()
        {
            foreach(Household household in householdManager.GetList())
            {
                cbHouseholdSelectMail.Items.Add(household.GetHouseholdAddress());
            }

            foreach (Household household in householdManager.GetList())
            {
                cbHouseholdSelectAnnouncement.Items.Add(household.GetHouseholdAddress());
            }
        }

        private void UpdateTaskTen()
        {
            cbSelectTen.Items.Clear();

            foreach (User item in login.selectedHouseholdTenantlist)
            {
                cbSelectTen.Items.Add(item.GetFullName());
            }

        }

        private void tpHomePage_Click(object sender, EventArgs e)
        {
            
        }

        public void updateListView()
        {
            dataGridView1.Rows.Clear();
            foreach (var complaint in complaintService.complaintList)
            {
                dataGridView1.Rows.Add(complaint.ComplaintNo, complaint.Title, complaint.Respond);
            }
        }
        private void btnCalanderPopUp_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void tpHouseRules_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (tbAddOrEdit.Text == string.Empty || tbDescription.Text == string.Empty)
            {
                MessageBox.Show("Fields can't be empty");

            }
            else
            {
                string rule = tbAddOrEdit.Text;
                string content = tbDescription.Text;

                foreach (Houserule t in login.selectedHouseholdRulelist)
                {

                    if (tbAddOrEdit.Text == t.Content)
                    {
                        MessageBox.Show("Rule already exists");
                        return;
                    }
                }
                login.selectedHousehold.AddHouseRuleToHousehold(rule, content);

                login.selectedHousehold.ViewRuleChange(dgvForRules);
            }
        }

        private void tpAgreeAndTask_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRow = dgvForRules.CurrentCell.RowIndex;

            if (tbAddOrEdit.Text == string.Empty || tbDescription.Text == string.Empty)
            {
                MessageBox.Show("Fields can't be empty");

            }
            else
            {
                if (selectedRow >= 0)
                {
                    login.selectedHousehold.houseRuleList[selectedRow].RuleId = tbAddOrEdit.Text;
                    login.selectedHousehold.houseRuleList[selectedRow].Content = tbDescription.Text;
                    login.selectedHousehold.ViewRuleChange(dgvForRules);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int indexRuleToDelete = dgvForRules.CurrentCell.RowIndex;

            if (tbAddOrEdit.Text == string.Empty || tbDescription.Text == string.Empty)
            {
                MessageBox.Show("Fields can't be empty");

            }
            else
            {
                if (indexRuleToDelete >= 0)
                {
                    login.selectedHousehold.DeleteHouseRule(tbAddOrEdit.Text, tbDescription.Text, indexRuleToDelete);
                    login.selectedHousehold.ViewRuleChange(dgvForRules);
                }
            }
        }

        private void lbHouseRulesDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {

        }

        private void cbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbTask_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpHomePage_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddTask_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEditTask_Click_1(object sender, EventArgs e)
        {
        }

        private void btnDeleteTask_Click_1(object sender, EventArgs e)
        {
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
        }

        private void btnShowTask_Click(object sender, EventArgs e)
        {

        }

        private void rbAgree_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbDisagree_CheckedChanged(object sender, EventArgs e)
        {
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
        //a button which delete and complaint in the list
        private void button1_Click(object sender, EventArgs e)
        {
            complaintService.delete(dataGridView1);
            complaintService.updateListView(dataGridView1);
        }
        //a button to give an respond to a complaint and update table
        private void btnRespond_Click(object sender, EventArgs e)
        {
            complaintService.respond(dataGridView1, tbDetails.Text);
            complaintService.updateListView(dataGridView1);
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            //financeService.updateFinance(dataGridView2, listBox1);
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

        private void btnDeleteTask_Click_2(object sender, EventArgs e)
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

        private void btnShowTask_Click_1(object sender, EventArgs e)
        {
            login.selectedHousehold.ViewTaskChange(dgvViewData);
        }

        private void rbAgree_CheckedChanged_1(object sender, EventArgs e)
        {
            AgreeEditTask();
        }

        private void rbDisagree_CheckedChanged_1(object sender, EventArgs e)
        {
            DisagreeEditTask();
        }
        private void updateHouseholdList()
        {
            // Show households in list.
            lbxHouseholds.Items.Clear();
            foreach (Household household in householdManager.GetList())
            {
                lbxHouseholds.Items.Add(household.GetHouseholdAddress());
            }
        }

        private void AddTenantList()
        {
            // Show tenants in selected household in list.
            lbxTenants.Items.Clear();
            foreach (Household currentHousehold in householdManager.GetList())
            {
                if (currentHousehold.HouseholdId == selectedHouseholdItem)
                {
                    foreach (Tenant tenant in currentHousehold.GetTenantList())
                    {
                        lbxTenants.Items.Add(tenant.GetFullName());
                    }
                }
            }
        }

        private void btAddHousehold_Click(object sender, EventArgs e)
        {

        }
        private void HouseholdAddEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When addedit form is closed update household list.
            updateHouseholdList();
        }
        private void TenantAddEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When addedit form is closed update tenant list.
            AddTenantList();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btAddHousehold_Click_1(object sender, EventArgs e)
        {
            /* When button clicked make a new householdaddeditform. 
Make event when form is closed. Show form */
            HouseholdAddEditForm householdAddEditForm = new HouseholdAddEditForm(householdManager, selectedHouseholdItem);
            householdAddEditForm.FormClosed += HouseholdAddEditForm_FormClosed;
            householdAddEditForm.Show();
            UpdateHHSelection();
        }

        private void btEditHousehold_Click_1(object sender, EventArgs e)
        {
            // When edited give selected item and 
            HouseholdAddEditForm householdAddEditForm = new HouseholdAddEditForm(householdManager, selectedHouseholdItem);
            householdAddEditForm.FormClosed += HouseholdAddEditForm_FormClosed;
            householdAddEditForm.Show();
            UpdateHHSelection();
        }

        private void btDeleteHousehold_Click_1(object sender, EventArgs e)
        {
            // When clicked get selected item and delete.
            householdManager.DeleteFromHouseholdList(Convert.ToInt32(selectedHouseholdItem));
            updateHouseholdList();
            AddTenantList();
            UpdateHHSelection();
        }

        private void btAddTenant_Click(object sender, EventArgs e)
        {
            TenantAddEditForm tenantAddEditForm = new TenantAddEditForm(selectedHouseholdItem, selectedTenantItem, householdManager);
            tenantAddEditForm.FormClosed += TenantAddEditForm_FormClosed;
            tenantAddEditForm.Show();
        }

        //a button which shows details of selected complaint
        private void btnDetails_Click(object sender, EventArgs e)
        {
            complaintService.GetDetails(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ////Form1 form1 = new Form1();
            //form1.Show();


            //loginPage.Show();
            
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();

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

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        private void btnLogOut6_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
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

        private void btnLogOut1_MouseHover(object sender, EventArgs e)
        {
            btnLogOut1.ImageIndex = 0;
            btnLogOut1.FlatAppearance.BorderSize = 1;
            btnLogOut1.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut1_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut1.ImageIndex = 1;
            btnLogOut1.FlatAppearance.BorderSize = 0;
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

        private void btnLogOut6_MouseHover(object sender, EventArgs e)
        {
            btnLogOut6.ImageIndex = 0;
            btnLogOut6.FlatAppearance.BorderSize = 1;
            btnLogOut6.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut6_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut6.ImageIndex = 1;
            btnLogOut6.FlatAppearance.BorderSize = 0;
        }


        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void lbxHouseholds_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selectedHouseholdItem = lbxHouseholds.SelectedIndex;
            foreach (Household currentHousehold in householdManager.GetList())
            {
                if (currentHousehold.HouseholdId == selectedHouseholdItem)
                {
                    lblHouseholdAddressInfo.Text = currentHousehold.GetHouseholdAddress();
                }
            }

            AddTenantList();
        }

        private void lbxTenants_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Save selected tenant index.
            selectedTenantItem = lbxTenants.SelectedIndex;

            // Show tenant information in labels.
            foreach (Household currentHousehold in householdManager.GetList())
            {
                if (currentHousehold.HouseholdId == selectedHouseholdItem)
                {
                    foreach (Tenant tenant in currentHousehold.GetTenantList())
                    {
                        if (tenant.GetTenantId() == selectedTenantItem)
                        {
                            lblTenantNameInfo.Text = tenant.GetFullName();
                            lblTenantUsernameInfo.Text = tenant.GetUserName();
                        }
                    }
                }
            }
        }

        private void btEditTenant_Click(object sender, EventArgs e)
        {
            TenantAddEditForm tenantAddEditForm = new TenantAddEditForm(selectedHouseholdItem, selectedTenantItem, householdManager);
            tenantAddEditForm.FormClosed += TenantAddEditForm_FormClosed;
            tenantAddEditForm.Show();
        }

        private void btDeleteTenant_Click(object sender, EventArgs e)
        {
            householdManager.DeleteFromTenantList(selectedHouseholdItem, selectedTenantItem);
            AddTenantList();
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

        private void UpdateHousehold()
        {

            cbForHouseHolds.Items.Clear();

            foreach (Household i in householdManager.GetList())
            {
                cbForHouseHolds.Items.Add(i.GetHouseholdAddress());
            }

        }
        private void UpdateTaskHousehold()
        {

            cbForTaskHouseHold.Items.Clear();

            foreach (Household i in householdManager.GetList())
            {
                cbForTaskHouseHold.Items.Add(i.GetHouseholdAddress());
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            login.selectedHousehold = householdManager.GetHouseholdById(cbForHouseHolds.SelectedIndex);
            login.selectedHouseholdTenantlist = login.selectedHousehold.GetTenantList();
            login.selectedHouseholdTasklist = login.selectedHousehold.GetTasktList();
            login.selectedHouseholdRulelist = login.selectedHousehold.GetHouseRulesList();
            login.selectedHousehold.ViewRuleChange(dgvForRules);          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            login.selectedHousehold = householdManager.GetHouseholdById(cbForTaskHouseHold.SelectedIndex);
            login.selectedHouseholdTenantlist = login.selectedHousehold.GetTenantList();
            login.selectedHouseholdTasklist = login.selectedHousehold.GetTasktList();
            login.selectedHouseholdRulelist = login.selectedHousehold.GetHouseRulesList();
            login.selectedHousehold.ViewTaskChange(dgvViewData);
        }

        private void cbHouseholds_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear tenants from checked listbox.

            chlbxMail.Items.Clear();

            // When mail household combobox changes show only mail content for selected household.
            foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectMail.SelectedIndex)
                {
                    foreach (Tenant tenant in household.GetTenantList())
                    {
                        chlbxMail.Items.Add(tenant.GetFullName());
                    }

                    break;
                }
            }


            // When household selection changes check tenants that have hasMail set to true.
            foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectMail.SelectedIndex)
                {
                    foreach (Tenant tenant in household.GetTenantList())
                    {
                        if (tenant.GetHasMail() == true)
                        {
                            chlbxMail.SetItemChecked(tenant.GetTenantId(), true);
                        }
                    }
                }
            }
        }

        private void chlbxMail_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {   
            foreach (Household household in householdManager.GetList())
            {
                if(household.HouseholdId == cbHouseholdSelectMail.SelectedIndex)
                {
                    // Add checked items index to list and add newest item index if checked to list.
                    List<int> checkedItems = new List<int>();
                    
                    foreach (int item in chlbxMail.CheckedIndices)
                    {
                        checkedItems.Add(item);
                    }

                    if (e.NewValue == CheckState.Checked)
                    {
                        checkedItems.Add(e.Index);
                    }

                    // When item is checked reset hasMail for users and set true for checked.
                    foreach (Tenant tenant in household.GetTenantList())
                    {
                        foreach (int index in checkedItems)
                        {

                            if (tenant.GetTenantId() == index)
                            {
                                tenant.SetHasMail(true);
                            }
                            else
                            {
                                tenant.SetHasMail(false);
                            }
                        }
                    }
                }
                
            }
        }

        private void tcHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When tab changes to householdoverview refresh the listbox of households.
            if (tcHome.SelectedTab.Name == "tpHouseholdOverview")
            {
                updateHouseholdList();
            }
        }

        // ------ Announcements ------

        /*foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectAnnouncement.SelectedIndex)
                {

                }
            }*/

        public void UpdateAnnouncementList()
        {
            foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectAnnouncement.SelectedIndex)
                {
                    // Add announcements to listbox.
                    lbxAnnouncements.Items.Clear();

                    foreach (Announcement announcement in household.GetAnnouncementList())
                    {
                        lbxAnnouncements.Items.Add(announcement.GetAnnouncementTitle());
                    }
                }
            }

           
        }

        private void btAddAnnouncement_Click_1(object sender, EventArgs e)
        {

            // Functionality for adding announcement to list.

            // Make title and description variables.
            string title = txbAnnouncementTitle.Text;
            string description = txbAnnouncementDescription.Text;

            foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectAnnouncement.SelectedIndex)
                {
                    // Add announcement to list, if textboxes empty show error.
                    if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(description))
                    {
                        lbAnnouncementError.Text = "Please fill in all fields.";
                    }
                    else
                    {

                        household.AddAnnouncementToList(title, description);

                    }

                    // Update announcement list.

                    UpdateAnnouncementList();
                }
            }
            

            
        }

        private void btEditAnnouncement_Click(object sender, EventArgs e)
        {
            foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectAnnouncement.SelectedIndex)
                {
                    // Make title and description variables.
                    string title = txbAnnouncementTitle.Text;
                    string description = txbAnnouncementDescription.Text;

                    // Edit selected announcement.
                    household.EditAnnouncementFromList(selectedAnnouncement, title, description);
                    UpdateAnnouncementList();
                }
            }
        }

        private void lbxAnnouncements_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Save selected announcement.
            selectedAnnouncement = lbxAnnouncements.SelectedIndex;

            // Show title and description in textboxes to edit.
            // Show title and description in label for info.

            foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectAnnouncement.SelectedIndex)
                {
                    foreach (Announcement announcement in household.GetAnnouncementList())
                    {
                        if (announcement.GetAnnouncementId() == selectedAnnouncement)
                        {
                            txbAnnouncementDescription.Text = announcement.GetAnnouncementDescription();
                            txbAnnouncementTitle.Text = announcement.GetAnnouncementTitle();
                            lbAnnouncementDescriptionInfo.Text = announcement.GetAnnouncementDescription();
                            lbAnnouncementTitleInfo.Text = announcement.GetAnnouncementTitle();
                        }
                    }
                }
            }
            
        }

        private void btDeleteAnnouncement_Click(object sender, EventArgs e)
        {
            foreach (Household household in householdManager.GetList())
            {
                if (household.HouseholdId == cbHouseholdSelectAnnouncement.SelectedIndex)
                {
                    // Delete selected announcement from list.
                    household.DeleteAnnouncementFromList(selectedAnnouncement);
                    UpdateAnnouncementList();
                }
            }
            
        }

        private void cbHouseholdSelectAnnouncement_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show announcements specific to household selected.
            UpdateAnnouncementList();
        }

        private void btChangePassword_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txbPasswordChange.Text))
            {
                login.GetLoggedInAdmin().SetPassword(txbPasswordChange.Text);
                lbPasswordChangeError.Text = "Password succesfully changed.";
            }
            else
            {
                lbPasswordChangeError.Text = "Password cannot be empty.";
            }
        }

        //a button which adds a reservation in the listbox
        private void btnReservation_Click(object sender, EventArgs e)
        {
            DateTime selectedDay = monthCalendarReservation.SelectionRange.End;
            var startAt = dateTimePickerStart.Value;
            var endAt = dateTimePickerEnd.Value;

            reservationService.AddReservation(cBHouseholdReservation.Text, login.GetLoggedInAdmin().GetUserName(), cBPlaces.Text, selectedDay, startAt, endAt, listBoxReservation);
        }

        //a button which deletes selected reservation
        private void btnCancellation_Click(object sender, EventArgs e)
        {
            int selectedItem = listBoxReservation.SelectedIndex;
            reservationService.DeleteReservation(selectedItem, listBoxReservation);
        }

        private void btnLogOut1_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
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

        private void btnLogOut1_MouseHover_1(object sender, EventArgs e)
        {
            btnLogOut1.ImageIndex = 0;
            btnLogOut1.FlatAppearance.BorderSize = 1;
            btnLogOut1.FlatAppearance.BorderColor = Color.White;
        }

        private void btnLogOut1_MouseLeave_1(object sender, EventArgs e)
        {
            btnLogOut1.ImageIndex = 1;
            btnLogOut1.FlatAppearance.BorderSize = 0;
        }

        private void cbForTaskHouseHold_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        //The button which shows total spending and how much everybody have to give more or get back
        private void btnShowFinance_Click(object sender, EventArgs e)
        {
            financeService.updateFinance(dataGridView2, listBox1, cBHouseholdFinance.Text);
        }
    }
    }
