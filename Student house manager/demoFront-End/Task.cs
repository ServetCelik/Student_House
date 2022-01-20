using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class Task
    {
        private int houseHoldId;
        private int taskId;
        private string taskName;
        private string taskType;
        private string assignedTenant;
        private string agreeBy;


        public Task(int householdId, int taskId, string taskName, string taskType, string assignedTenant, string agreeBy)
        {
            this.houseHoldId = householdId;
            this.TaskId = taskId;
            this.TaskName = taskName;
            this.TaskType = taskType;
            this.AssignedTenant = assignedTenant;
            this.AgreeBy = agreeBy;
        }

        public int TaskId
        {
            get { return this.taskId; }
            set { this.taskId = value; }
        }
        public string TaskName
        {
            get { return this.taskName; }
            set { this.taskName = value; }
        }
        public string TaskType
        {
            get { return this.taskType; }
            set { this.taskType = value; }
        }
        public string AssignedTenant
        {
            get { return this.assignedTenant; }
            set { this.assignedTenant = value; }
        }
        public string AgreeBy
        {
            get { return this.agreeBy; }
            set { this.agreeBy = value; }
        }
    }
}
