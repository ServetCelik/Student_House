using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class Announcement
    {
        int announcementId;
        string title;
        string description;

        public Announcement(int announcementId, string title, string description)
        {
            this.announcementId = announcementId;
            this.title = title;
            this.description = description;
        }

        public int GetAnnouncementId()
        {
            return announcementId;
        }
        public string GetAnnouncementTitle()
        {
            return title;
        }

        public string GetAnnouncementDescription()
        {
            return description;
        }
        
    }
}
