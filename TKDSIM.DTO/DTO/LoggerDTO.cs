using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class LoggerDTO
    {
        public int L_ID { get; set; }
        public int U_ID { get; set; }
        public int T_ID { get; set; }
        public string TableName { get; set; }
        public string OperationType { get; set; }
        public DateTime? OperationDate { get; set; }
    }
}
