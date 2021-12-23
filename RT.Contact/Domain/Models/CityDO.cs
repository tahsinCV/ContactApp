using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Contact.Domain.Models
{
    public class CityDO
    {
        public CityDO()
        {

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
    }
}
