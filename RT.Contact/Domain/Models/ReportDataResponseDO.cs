using System.Collections.Generic;

namespace RT.Contacts.Domain.Models
{
    public class ReportDataResponseDO
    {
        public ReportDataResponseDO()
        {
            UserInformationList = new List<UserInformationDO>();
        }

        public int ReportID { get; set; }
        public List<UserInformationDO> UserInformationList { get; set; }
    }
}
