using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class MissingDocsDTO
    {
        public int M_ID { get; set; }
        public int A_ID { get; set; }
        public List<int> DocName { get; set; }
        public int DocNameEnumValueID { get; set; }
        public string DocNameValue { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
