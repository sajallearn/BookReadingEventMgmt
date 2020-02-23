
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class Invite
    {
        [Key, Column(Order = 0)]
        public int EventID { get; set; }

        [Key, Column(Order = 1)]
        public string Email { get; set; }

        public Invite(int eventID, string email)
        {
            this.EventID = eventID;
            this.Email = email;
        }

        public Invite()
        {

        }
    }
}
