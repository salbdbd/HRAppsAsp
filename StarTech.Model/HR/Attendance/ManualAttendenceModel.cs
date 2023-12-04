using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Attendance
{


    public class ManualAttendenceModel
    {
        public int ID { get; set; }
        public string EmpCod { get; set; }
        public string DDMMYYYY { get; set; }
        public string MachineName { get; set; }
        public int CompanyID { get; set; }
        public int Typee { get; set; }
        public DateTime? punch_time { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string GPRSLocation { get; set; }
        public string AppType { get; set; }
        public string ApplyTo { get; set; }
        public string Remarks { get; set; }

    }
}
