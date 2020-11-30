using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class SubmittedDocsListDTO
    {
        public int S_ID { get; set; }
        public int A_ID { get; set; }
        public int DocName { get; set; }
        public string DocNameEnumVal { get; set; }
        public string DeqkisNo { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime? PresentationDate { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
