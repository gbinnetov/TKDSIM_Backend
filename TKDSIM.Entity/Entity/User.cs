using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.Entity.Entity
{
    public class User 
    {
        public int U_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
