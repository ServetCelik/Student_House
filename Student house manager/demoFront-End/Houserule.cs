using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class Houserule
    {
        private int houseHoldId;
        private string ruleId;
        private string content;


        public Houserule( int houseHoldId, string ruleId, string content)
        {
            this.houseHoldId = houseHoldId;
            this.RuleId = ruleId;
            this.Content = content;
        }
        
        public string RuleId
        {
            get { return this.ruleId; }
            set { this.ruleId = value; }
        }
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

    }
}
