using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class Household
    {
        private int householdId;
        public int HouseholdId { get; }
        private string householdAddress;

        int taskId = 1;
        int selectedHouseId = 0;
        int houseRuleId = 1;
        int announcementId = 0;

        public List<Tenant> tenantList = new List<Tenant>();
        public List<Task> taskList = new List<Task>();
        public List<Houserule> houseRuleList = new List<Houserule>();
        // List for containing the announcements.
        private List<Announcement> announcementList = new List<Announcement>();



        public Household(int householdId, List<object> parameterList)
        {
            this.HouseholdId = householdId;

            // Convert items in list to needed types for address.
            string streetname = Convert.ToString(parameterList[0]);
            int houseNo = Convert.ToInt32(parameterList[1]);
            string noAddition = Convert.ToString(parameterList[2]);
            string postalcode = Convert.ToString(parameterList[3]);
            string city = Convert.ToString(parameterList[4]);


            // Create household address string from info provided.
            this.householdAddress = $"{streetname} {houseNo}{noAddition}{System.Environment.NewLine}{postalcode} {city}";
        }

        public string GetHouseholdAddress()
        {
            return householdAddress;
        }

        public List<Tenant> GetTenantList()
        {
            return tenantList;
        }

        public void AddTenantToHousehold(Tenant tenant)
        {
            tenantList.Add(tenant);
        }

        public void EditTenant(Tenant tenant, int selectedTenant)
        {
            int selected = selectedTenant;
            tenantList.RemoveAt(selected);
            tenantList.Insert(selected, tenant);
        }

        public void DeleteTenant(int selectedTenant)
        {
            tenantList.RemoveAt(selectedTenant);
        }

        // task
        public List<Task> GetTasktList()
        {
            return taskList;
        }

        public void AddTaskToHousehold(string taskName, string taskType, string assignedTenant, string agreeByTask)
        {
                taskList.Add(new Task(taskId, selectedHouseId, taskName, taskType, assignedTenant, ""));
                taskId++;
        }

        public void DeleteTask(string taskName, string taskType, string assignedTenant, string agreeByTask, int selectedIndex)
        {
            taskList.RemoveAt(selectedIndex);
        }
        public void ViewTaskChange(DataGridView dgvViewData)
        {
            dgvViewData.Rows.Clear();

            foreach (var t in taskList)
            {
                dgvViewData.Rows.Add(t.TaskName, t.TaskType, t.AssignedTenant, t.AgreeBy);
            }

        }
        //House rules

        public List<Houserule> GetHouseRulesList()
        {
            return houseRuleList;
        }

        public void AddHouseRuleToHousehold(string ruleId, string content)
        {
            houseRuleList.Add(new Houserule(selectedHouseId, ruleId, content));
        }

        public void DeleteHouseRule(string ruleId, string content, int selectedIndex)
        {
            houseRuleList.RemoveAt(selectedIndex);
        }
        public void ViewRuleChange(DataGridView dgvForRules)
        {
            dgvForRules.Rows.Clear();

            foreach (var t in houseRuleList)
            {
                dgvForRules.Rows.Add(t.RuleId, t.Content);
            }

        }

        // ----------- Announcements -----------
        public List<Announcement> GetAnnouncementList()
        {
            // Get announcement list.
            return announcementList;
        }

        public void AddAnnouncementToList(string title, string description)
        {
            // Make new announcement and add to list. Increase announcement Id.
            Announcement newAnnouncement = new Announcement(announcementId, title, description);
            announcementList.Add(newAnnouncement);
            announcementId += 1;
        }

        public void EditAnnouncementFromList(int selectedAnnouncement, string title, string description)
        {
            // Save selected announcementId and remove it from list.
            int selected = selectedAnnouncement;
            announcementList.RemoveAt(selectedAnnouncement);

            // Make new announcement with same announcementId as previous and add to list.
            Announcement editedAnnouncement = new Announcement(selected, title, description);
            announcementList.Add(editedAnnouncement);
        }

        public void DeleteAnnouncementFromList(int selectedAnnouncement)
        {
            // Remove selected announcement from list.
            announcementList.RemoveAt(selectedAnnouncement);
        }
    }
}

