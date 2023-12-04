using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.HR
{
    public class EmpInfoModel
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Status { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string PreAddress { get; set; }
        public string ParAddress { get; set; }
        public string AnotherContact { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public int EmpGradeID { get; set; }
        public string ReportTo { get; set; }
    }
}
