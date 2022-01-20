using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoFront_End
{
    public class Form1Service
    {
        public Form1Service()
        {

        }

        public void AddDummyUser()
        {

            Form1.lUser.Add(new User("servet", "123", "servet", usertype.admin));
            Form1.lUser.Add(new User("cynthia", "123", "cynthia", usertype.admin));
            Form1.lUser.Add(new User("edvinas", "123", "edvinas", usertype.admin));
            Form1.lUser.Add(new User("regular", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular1", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular2", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular3", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular4", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular5", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular6", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular7", "123", "regular", usertype.tenant));
            Form1.lUser.Add(new User("regular8", "123", "regular", usertype.tenant));
        }



        public bool EmployeeCheck(string tbPassword, string tbUsername, List<User> lUser)
        {

            string password = Convert.ToString(tbPassword);
            string name = Convert.ToString(tbUsername);

            foreach (User item in lUser)
            {
                if (item.GetUserName() == name & item.GetPassword() == password & item.GetUsertype() == usertype.admin)
                {
                    return true;
                }
            }
            return false;
        }


        public bool StudentCheck(string tbPassword, string tbUsername, List<User> lUser)
        {
            string password = Convert.ToString(tbPassword);
            string name = Convert.ToString(tbUsername);

            foreach (User item in lUser)
            {
                if (item.GetUserName() == name & item.GetPassword() == password & item.GetUsertype() == usertype.tenant)
                {
                    return true;
                }
            }
            return false;
        }

        public void LoginFormError(Label lbErrorUserName, Label lbErrorPassword, TextBox tbPassword, TextBox tbUsername)
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




    }
}
