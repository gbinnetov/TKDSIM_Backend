using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class EnumValueDTO
    {
        public int EV_ID { get; set; }
        public int E_ID { get; set; }
        public string EnumValue { get; set; }
        public string Value { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
