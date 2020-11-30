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
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
