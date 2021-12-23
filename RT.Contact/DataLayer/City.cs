using System;
using System.Collections.Generic;

#nullable disable

namespace RT.Contact.DataLayer
{
    public partial class City
    {
        public City()
        {
            UserInformations = new HashSet<UserInformation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ExternalSystemCode { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserInformation> UserInformations { get; set; }
    }
}
