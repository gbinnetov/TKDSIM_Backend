﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class WorkDoneFormDTO
    {
        public int WF_ID { get; set; }
        public int A_ID { get; set; }
        public string PlaceStructureOrderNo { get; set; }
        public int PlaceStructureOrderStatus { get; set; }
        public string PlaceStructureOrderStatusName { get; set; }
        public string PlaceStructureOrderNote { get; set; }
        public string PlaceStructurePlanDeqkisNo { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
}
