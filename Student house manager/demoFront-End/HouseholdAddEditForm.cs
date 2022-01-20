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
    public partial class HouseholdAddEditForm : Form
    {
        public HouseholdManager householdManager = new HouseholdManager();
        int selectedHousehold;

        public HouseholdAddEditForm(HouseholdManager householdManager, int selectedHousehold)
        {
            InitializeComponent();
            this.householdManager = householdManager;
            this.selectedHousehold = selectedHousehold;
        }

        private void HouseholdAddEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btAddEditHousehold_Click(object sender, EventArgs e)
        {
            /* Make a list of parameters to pass on for address. 
               List needs to contain in order: streetname, houseNo, noAddition, postalcode, city. */
            List<object> parameterList = new List<object>(new object[5]);

            // Bools to set for error messages when textbox is empty or invalid.
            bool streetnameValid = false;
            bool postalcodeValid = false;
            bool cityValid = false;
            bool houseNoPositiveOrFilled = false;
            bool houseNoString = false;

            /* Check if textboxes are empty, if so set bool to show error message.
               If not empty add to parameterlist. */
            if (!String.IsNullOrEmpty(txbStreetname.Text))
            {
                parameterList[0] = txbStreetname.Text;
                streetnameValid = true;
            }
            else
            {
                streetnameValid = false;
            }

            if (!String.IsNullOrEmpty(txbNoAddition.Text))
            {
                parameterList[2] = txbNoAddition.Text;
            }
            else
            {
                parameterList[2] = "";
            }


            if (!String.IsNullOrEmpty(txbPostalcode.Text))
            {
                parameterList[3] = txbPostalcode.Text;
                postalcodeValid = true;
            }
            else
            {
                postalcodeValid = false;
            }

            if (!String.IsNullOrEmpty(txbCity.Text))
            {
                parameterList[4] = txbCity.Text;
                cityValid = true;
            }
            else
            {
                cityValid = false;
            }




            // Try to convert houseno to int and add to list, send message if failed.
            try
            {

                int houseNo = Int32.Parse(txbHouseNo.Text);

                if (houseNo >= 1 && !String.IsNullOrEmpty(txbHouseNo.Text))
                {
                    parameterList[1] = houseNo;
                    lblInfo.Text = "Household added/edited successfully.";
                    houseNoPositiveOrFilled = true;
                    houseNoString = true;

                }
                else
                {
                    lblInfo.Text = "Please fill in a number above 0 for houseNo.";
                    houseNoPositiveOrFilled = false;

                }
            }
            catch (FormatException)
            {
                lblInfo.Text = "Please fill in a valid number at houseNo.";
                houseNoString = false;
            }

            // If all parameters are valid add to householdlist else add error message(s).
            if (streetnameValid &&
                houseNoString &&
                houseNoPositiveOrFilled &&
                postalcodeValid &&
                cityValid)
            {
                householdManager.AddToHouseholdList(parameterList);
                this.Close();
            }
            else
            {
                if (!streetnameValid)
                {
                    lblInfo.Text = "Please fill in a streetname.";
                }
                if (!houseNoString)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in only numbers for house number.";
                }
                if (!houseNoPositiveOrFilled)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in a positive number for house number.";
                }
                if (!postalcodeValid)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in a postal code.";
                }
                if (!cityValid)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in a city.";
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            /* Make a list of parameters to pass on for address. 
               List needs to contain in order: streetname, houseNo, noAddition, postalcode, city. */
            List<object> parameterList = new List<object>(new object[5]);

            // Bools to set for error messages when textbox is empty or invalid.
            bool streetnameValid = false;
            bool postalcodeValid = false;
            bool cityValid = false;
            bool houseNoPositiveOrFilled = false;
            bool houseNoString = false;

            /* Check if textboxes are empty, if so set bool to show error message.
               If not empty add to parameterlist. */
            if (!String.IsNullOrEmpty(txbStreetname.Text))
            {
                parameterList[0] = txbStreetname.Text;
                streetnameValid = true;
            }
            else
            {
                streetnameValid = false;
            }

            if (!String.IsNullOrEmpty(txbNoAddition.Text))
            {
                parameterList[2] = txbNoAddition.Text;
            }
            else
            {
                parameterList[2] = "";
            }


            if (!String.IsNullOrEmpty(txbPostalcode.Text))
            {
                parameterList[3] = txbPostalcode.Text;
                postalcodeValid = true;
            }
            else
            {
                postalcodeValid = false;
            }

            if (!String.IsNullOrEmpty(txbCity.Text))
            {
                parameterList[4] = txbCity.Text;
                cityValid = true;
            }
            else
            {
                cityValid = false;
            }




            // Try to convert houseno to int and add to list, send message if failed.
            try
            {

                int houseNo = Int32.Parse(txbHouseNo.Text);

                if (houseNo >= 1 && !String.IsNullOrEmpty(txbHouseNo.Text))
                {
                    parameterList[1] = houseNo;
                    lblInfo.Text = "Household added/edited successfully.";
                    houseNoPositiveOrFilled = true;
                    houseNoString = true;

                }
                else
                {
                    lblInfo.Text = "Please fill in a number above 0 for houseNo.";
                    houseNoPositiveOrFilled = false;

                }
            }
            catch (FormatException)
            {
                lblInfo.Text = "Please fill in a valid number at houseNo.";
                houseNoString = false;
            }

            // If all parameters are valid edit householdlist else add error message(s).
            if (streetnameValid &&
                houseNoString &&
                houseNoPositiveOrFilled &&
                postalcodeValid &&
                cityValid)
            {
                // Edit list
                householdManager.EditHouseholdList(parameterList, selectedHousehold);
                this.Close();
            }
            else
            {
                if (!streetnameValid)
                {
                    lblInfo.Text = "Please fill in a streetname.";
                }
                if (!houseNoString)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in only numbers for house number.";
                }
                if (!houseNoPositiveOrFilled)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in a positive number for house number.";
                }
                if (!postalcodeValid)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in a postal code.";
                }
                if (!cityValid)
                {
                    lblInfo.Text += $"{System.Environment.NewLine}Please fill in a city.";
                }
            }
        }
    }
}
