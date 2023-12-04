using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Leave
{
    public class LeaveTypeModel
    {
        public int? ID { get; set; }
        public string TypeName { get; set; }
        public int MaxDays { get; set; }
        public int? Typeee { get; set; }
        public string Shortn { get; set; }
        public int GradeValue { get; set; }
        public int? SortOrder { get; set; }
        public int ApplyMax { get; set; }
        public int UserID { get; set; }
    }
}
