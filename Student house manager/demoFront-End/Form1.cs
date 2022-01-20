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
    public partial class Form1 : Form
    {
        public static List<User> lUser { get; set; } = new List<User>();
        public static List<Tenant> lTenant = new List<Tenant>();

        public User user;
        public HouseholdManager householdManager = new HouseholdManager();
        public List<Tenant> selectedHouseholdTenantlist = new List<Tenant>();
        public List<Task> selectedHouseholdTasklist = new List<Task>();
        public List<Houserule> selectedHouseholdRulelist = new List<Houserule>();
        public List<Announcement> selectedHouseholdAnnouncementsList = new List<Announcement>();
        public List<Household> householdList = new List<Household>();
        public Household selectedHousehold;        

        // Logged in tenant ID
        private int loggedInTenId;

        // Logged in tenant object
        private Tenant loggedInTen;
        // Logged in Admin object
        private User loggedInAdmin;

        public Form1()
        {
            InitializeComponent();
            
            // Create dummy data.
            householdManager.DummyDataHouseholds();
            householdList = householdManager.GetList();

            // adding tanant
            Tenant dummyTenant = new Tenant("Ash", "123", "Berend Bullebak", usertype.tenant, 0, 0);
            householdList[0].AddTenantToHousehold(dummyTenant);

            dummyTenant = new Tenant("KikkerKop", "1234", "Hagrid Tovenaar", usertype.tenant, 0, 1);
            householdList[0].AddTenantToHousehold(dummyTenant);

            dummyTenant = new Tenant("VisserMan", "1234", "Aal Visser", usertype.tenant, 1, 0);
            householdList[1].AddTenantToHousehold(dummyTenant);

            dummyTenant = new Tenant("LiveLaughLove", "1234", "Karen Ruiter", usertype.tenant, 1, 1);
            householdList[1].AddTenantToHousehold(dummyTenant);

            // adding tasks

            householdList[0].AddTaskToHousehold("Clean kitchen", "Cleaning", "Luka", "");

            householdList[0].AddTaskToHousehold("Buy gum", "Groceries", "Mike", "");

            householdList[1].AddTaskToHousehold("Take out garbage", "Garbage", "John", "");

            householdList[1].AddTaskToHousehold("Clean living room", "Cleaning", "Luke", "");

            // adding rules

            householdList[0].AddHouseRuleToHousehold("Don't smoke", "You can't smoke inside or near the entrance");

            householdList[0].AddHouseRuleToHousehold("Be quiet", "You can't make noise after 10pm");

            householdList[1].AddHouseRuleToHousehold("Don't smoke", "You can't smoke inside or near the entrance");

            householdList[1].AddHouseRuleToHousehold("Parking", "Park your bike in a parking space"); 

            // dummy data all set

            lUser.Add(new User("servet", "123", "servet", usertype.admin));
            lUser.Add(new User("cynthia", "123", "cynthia", usertype.admin));
            lUser.Add(new User("edvinas", "123", "edvinas", usertype.admin));

            foreach (Tenant tenant in householdManager.GetAllTenantList())
                {
                    lTenant.Add(tenant);
                }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (EmployeeCheck())
            {
                EmployeeForm employeeForm = new EmployeeForm(this);
                this.Hide();
                employeeForm.Show();                
            }
            else if (StudentCheck())
            {
                tbTenName tenantForm = new tbTenName(this);
                this.Hide();
                tenantForm.Show();                
            }
            else
            {
                LoginFormError();
            }
            tbPassword.Clear();
            tbUsername.Clear();

        }


        private bool EmployeeCheck()
        {
            string password = Convert.ToString(tbPassword.Text);
            string name = Convert.ToString(tbUsername.Text);

            foreach (User item in lUser)
            {
                if (item.GetUserName() == name & item.GetPassword() == password & item.GetUsertype() == usertype.admin)
                {
                    int selectHouseholdId = item.GetHouseholdId();
                    selectedHousehold = householdManager.GetHouseholdById(selectHouseholdId);
                    selectedHouseholdTenantlist = selectedHousehold.GetTenantList();
                    selectedHouseholdTasklist = selectedHousehold.GetTasktList();
                    selectedHouseholdRulelist = selectedHousehold.GetHouseRulesList();
                    loggedInAdmin = item;
                    return true;
                }
            }
            return false;
        }

        private bool StudentCheck()
        {
            string password = Convert.ToString(tbPassword.Text);
            string name = Convert.ToString(tbUsername.Text);

            foreach (Tenant item in lTenant)
            {
                if (item.GetUserName() == name & item.GetPassword() == password & item.GetUsertype() == usertype.tenant)
                {
                    int selectHouseholdId = item.GetHouseholdId();
                    selectedHousehold = householdManager.GetHouseholdById(selectHouseholdId);
                    selectedHouseholdTenantlist = selectedHousehold.GetTenantList();
                    selectedHouseholdTasklist = selectedHousehold.GetTasktList();
                    selectedHouseholdRulelist = selectedHousehold.GetHouseRulesList();
                    selectedHouseholdAnnouncementsList = selectedHousehold.GetAnnouncementList();
                    loggedInTenId = item.GetTenantId();
                    loggedInTen = item;
                    return true;
                }
            }
            return false;
        }


        private void ClearBtUsername(object sender, EventArgs e)
        {
            tbUsername.Clear();
        }
        private void ClearBtPassword(object sender, EventArgs e)
        {
            tbPassword.Clear();
        }

        public Tenant GetLoggedInTen()
        {
            return loggedInTen;
        }

        public User GetLoggedInAdmin()
        {
            return loggedInAdmin;
        }

        private void LoginFormError()
        {
            lbErrorUserName.Text = "Wrong username";
            lbErrorUserName.ForeColor = Color.Red;
            lbErrorUserName.BackColor = Color.Transparent;
            lbErrorPassword.Text = "Wrong password";
            lbErrorPassword.ForeColor = Color.Red;
            lbErrorPassword.BackColor = Color.Transparent;
            tbPassword.Clear();
            tbUsername.Clear();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int GetLoggedInTenId()
        {
            return loggedInTenId;
        }

    }
}
