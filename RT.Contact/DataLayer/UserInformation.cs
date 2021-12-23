using System;
using System.Collections.Generic;

#nullable disable

namespace RT.Contacts.DataLayer
{
    public partial class UserInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CityId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Information { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual City City { get; set; }
        public virtual User User { get; set; }
    }
}
