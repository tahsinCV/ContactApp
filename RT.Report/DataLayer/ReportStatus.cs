using System;
using System.Collections.Generic;

#nullable disable

namespace RT.Report.DataLayer
{
    public partial class ReportStatus
    {
        public ReportStatus()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
