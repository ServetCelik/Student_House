using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class HouseholdManager
    {
        // List of households.
        private static List<Household> householdList = new List<Household>();

        int householdId = 0;

        /* private List<object> parameterTest = new List<object>(new object 5)
         Household houseTest = new Household(5,)*/



        public void AddToHouseholdList(List<object> parameterList)
        {
            // Create new household, add to householdlist and increase the householdId by one.
            Household newHousehold = new Household(this.householdId, parameterList);
            householdList.Add(newHousehold);
            householdId += 1;
        }

        /*public void TestHouseholdId()
        {
            foreach (Household household in householdList)
            {
                System.Windows.Forms.MessageBox.Show(Convert.ToString(household.HouseholdId));

                *//*if (household.HouseholdId == selectedHousehold)
                {
                    household.AddTenantToHousehold(tenant);
                    break;
                }*//*
            }
        }*/

        public void DeleteFromHouseholdList(int selectedHousehold)
        {
            // Delete selected household.
            householdList.RemoveAt(selectedHousehold);
        }

        public void EditHouseholdList(List<object> parameterList, int selectedHousehold)
        {
            // Edit selected household.
            int selected = selectedHousehold;
            householdList.RemoveAt(selected);
            Household newHousehold = new Household(this.householdId, parameterList);
            householdList.Insert(selected, newHousehold);
        }

        public List<Household> GetList()
        {
            return householdList;
        }

        public void AddTenantList(int selectedHousehold, Tenant tenant)
        {
            // Add tenant to the selected household.
            foreach (Household household in householdList)
            {
                if (household.HouseholdId == selectedHousehold)
                {
                    household.AddTenantToHousehold(tenant);
                }
            }
        }

        public void EditTenantList(int selectedHousehold, int selectedTenant, Tenant tenant)
        {
            // Edit tenant in selected household.
            foreach (Household household in householdList)
            {
                if (household.HouseholdId == selectedHousehold)
                {
                    household.EditTenant(tenant, selectedTenant);
                }
            }
        }

        public void DeleteFromTenantList(int selectedHousehold, int selectedTenant)
        {
            // Delete tenant from selected household.
            foreach (Household household in householdList)
            {
                if (household.HouseholdId == selectedHousehold)
                {
                    household.DeleteTenant(selectedTenant);
                }
            }
        }

        public void DummyDataHouseholds()
        {
            // Make dummy data for households.
            List<object> householdParameter = new List<object>(new Object[5]);

            householdParameter[0] = "Burgundy Street";
            householdParameter[1] = 42;
            householdParameter[2] = "B";
            householdParameter[3] = "5584TR";
            householdParameter[4] = "Asgard";

            AddToHouseholdList(householdParameter);

            householdParameter[0] = "Toothbrushlane";
            householdParameter[1] = 86;
            householdParameter[2] = "D";
            householdParameter[3] = "6719BO";
            householdParameter[4] = "Brooklyn";

            AddToHouseholdList(householdParameter);
        }

        public Household GetHouseholdById(int selectedHouseholdId)
        {
            // Delete tenant from selected household.
            foreach (Household household in householdList)
            {
                if (household.HouseholdId == selectedHouseholdId)
                {
                    return household;
                }
            }
            return householdList[0];
        }

        public List<Tenant> GetAllTenantList()
        {
            List<Tenant> allTenantList = new List<Tenant>();
            // Delete tenant from selected household.
            foreach (Household household in householdList)
            {
                foreach (Tenant tenant in household.GetTenantList())
                {
                    allTenantList.Add(tenant);
                }
            }
            return allTenantList;
        }

    }
}
