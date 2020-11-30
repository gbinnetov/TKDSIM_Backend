using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.Entity.Entity
{
    public class WorkDoneTable 
    {
        public int WT_ID { get; set; }
        public int A_ID { get; set; }
        public string LatterNo { get; set; }
        public string Content { get; set; }
        public string SendingToWhom { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
