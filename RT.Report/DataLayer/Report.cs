using System;
using System.Collections.Generic;

#nullable disable

namespace RT.Reports.DataLayer
{
    public partial class Report
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public int CityId { get; set; }
        public int RequestStatusId { get; set; }
        public int UsersCountInLocation { get; set; }
        public int PhoneCountInLocation { get; set; }
        public DateTime RequestTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual City City { get; set; }
        public virtual ReportStatus RequestStatus { get; set; }
    }
}
