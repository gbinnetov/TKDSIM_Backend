using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class WorkDoneTableDTO
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
