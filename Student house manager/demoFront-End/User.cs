using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class User
    {
        protected string username { get; set; }
        protected string password { get; set; }
        protected string fullName { get; set; }
        protected usertype usertype { get; }
        protected int householdId { get; set; }

        public User(string username, string password, string fullName, usertype usertype)
        {
            this.householdId = householdId;
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.usertype = usertype;

        }

        public void SetUserName(string username)
        {
            this.username = username;
        }

        public string GetUserName()
        {
            return username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetFullName(string fullName)
        {
            this.fullName = fullName;
        }

        public string GetFullName()
        {
            return fullName;
        }

        public usertype GetUsertype()
        {
            return usertype;
        }
        public int GetHouseholdId()
        {
            return householdId;
        }
    }


    public class Tenant : User
    {
        private int tenantId = 0;
        private bool hasMail = false;

        public Tenant(string username, string password, string fullName, usertype usertype, int householdId, int tenantId) : base(username, password, fullName, usertype)
        {
            this.householdId = householdId;
            this.tenantId = tenantId;
            
        }

        public int GetTenantId()
        {
            return tenantId;
        }

        public void SetHasMail(bool hasMail)
        {
            this.hasMail = hasMail;
        }

        public bool GetHasMail()
        {
            return hasMail;
        }
    }
}
