using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.Entity.Entity
{
    public class EnumValue
    {
        public int EV_ID { get; set; }
        public int E_ID { get; set; }
        public string Value { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
