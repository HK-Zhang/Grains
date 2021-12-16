using System;
using System.Collections.Generic;
using System.Text;

namespace Authorization.Entity
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VeracityId { get; set; }
        public string Description { get; set; }
        public string RoleId { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public string UpdatedBy { get; private set; }
        public DateTime UpdatedOnUtc { get; private set; }
    }
}
