﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.Entity.Entity
{
    public class OrderProject
    {
        public int O_ID { get; set; }
        public int A_ID { get; set; }
        public string OrderNo { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusNote { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
