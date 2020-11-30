using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class AppealInfoDetailDto
    {
        public int ID { get; set; }
        public int A_ID { get; set; }
        public string DeqkisNo { get; set; }
        public int PropertType { get; set; }
        public string PropertTypeName { get; set; }
        public int AppealType { get; set; }
        public string AppealTypeName { get; set; }
        public int GrandCategory { get; set; }
        public string GrandCategoryTypeName { get; set; }
        public int UqodiyaGC { get; set; }
        public string UqodyaGCName { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
