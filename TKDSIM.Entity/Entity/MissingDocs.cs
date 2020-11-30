using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TKDSIM.Entity.Entity
{
    public class MissingDocs
    {
        public int M_ID { get; set; }
        public int A_ID { get; set; }
        public int DocName { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
