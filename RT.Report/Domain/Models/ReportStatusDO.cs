using System;

namespace RT.Reports.Domain.Models
{
    public class ReportStatusDO
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
