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
    public partial class TenantAddEditForm : Form
    {
        int selectedHousehold;
        int selectedTenant;
        int tenantId = 0;
        HouseholdManager householdManager;
        
        
        public TenantAddEditForm(int selectedHousehold, int selectedTenant, HouseholdManager householdManager)
        {
            InitializeComponent();
            this.selectedHousehold = selectedHousehold;
            this.selectedTenant = selectedTenant;
            this.householdManager = householdManager;
        }

        private void btAddTenant_Click(object sender, EventArgs e)
        {
            // Turn first name and last name into full name.
            string fullName = txbFirstName.Text + " " + txbLastName.Text;

            // Save username.
            string username = txbUsername.Text;

            // Save password.
            string password = txbPassword.Text;

            // Usertype
            usertype tenantUser = usertype.tenant;

            // Make new tenant.
            Tenant tenant = new Tenant(username, password, fullName, tenantUser, selectedHousehold, tenantId);

            tenantId += 1;

            // Update tenant in household.
            householdManager.AddTenantList(selectedHousehold, tenant);

            this.Close();
            

        }

        private void btEditTenant_Click(object sender, EventArgs e)
        {
            // Get selected tenant index for tenant ID.
            int previousTenantId = selectedTenant;

            // Turn first name and last name into full name.
            string fullName = txbFirstName.Text + " " + txbLastName.Text;

            // Save username.
            string username = txbUsername.Text;

            // Save password.
            string password = txbPassword.Text;

            // Usertype
            usertype tenantUser = usertype.tenant;

            // Make new tenant.
            Tenant tenant = new Tenant(username, password, fullName, tenantUser, selectedHousehold, previousTenantId);

            householdManager.EditTenantList(selectedHousehold, selectedTenant, tenant);

            this.Close();
        }
    }
}
