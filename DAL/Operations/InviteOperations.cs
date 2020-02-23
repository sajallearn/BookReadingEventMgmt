using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entity;

namespace DAL.Operations
{
    public class InviteOperations
    {
        private BookReadingEventManagementContext db = new BookReadingEventManagementContext();
        public void AddInvites(string[] inviteList, int eventID)
        {
            foreach (string email in inviteList)
            {
                Invite invite = new Invite(eventID, email);
                db.Invites.Add(invite);
            }
            db.SaveChanges();
        }

        public string[] GetInvitesForEvent(int eventID)
        {
            string[] InvitedList = db.Invites
                                .Where(Invite => Invite.EventID == eventID)
                                .Select(invite => invite.Email)
                                .ToArray();
            return InvitedList;
        }


        public IEnumerable<int> GetEventIds(string email)
        {
            return db.Invites.Where(invite => invite.Email == email)
                             .Select(invite => invite.EventID)
                             .ToArray();
        }

        public void RemoveInvitesForEvent(int eventID)
        {
            List<Invite> Invites = db.Invites.Where(invite => invite.EventID == eventID).ToList();
            
            foreach(Invite invite in Invites)
            {
                db.Invites.Remove(invite);
            }

            db.SaveChanges();
        }
    }
}