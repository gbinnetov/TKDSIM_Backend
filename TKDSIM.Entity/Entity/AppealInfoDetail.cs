using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TKDSIM.Entity.Entity
{
    public class AppealInfoDetail
    {
        public int ID { get; set; }
        public int A_ID { get; set; }
        public string DeqkisNo { get; set; }
        public int PropertType { get; set; }
        public int AppealType { get; set; }
        public int GrandCategory { get; set; }
        public int UqodiyaGC { get; set; }
        public DateTime? DeqkisDate { get; set; }
        public string Region { get; set; }
        public int IED_EV { get; set; }
        public string Address { get; set; }
        public int ApplicantType { get; set; }
        public string ApplicantName { get; set; }
        public string GrandAreaSize { get; set; }
        public int UqodyaWCC { get; set; }
        public int WillChangeCategory { get; set; }
        //public int Planting { get; set; }
        public int AppealReason { get; set; }
        public string MainApplicantName { get; set; }
        public string AppealContent { get; set; }


        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
