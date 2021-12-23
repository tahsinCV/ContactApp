using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contacts.Domain.Models
{
    public class UserDO
    {
        public UserDO()
        {

        }

        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CompanyName { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
