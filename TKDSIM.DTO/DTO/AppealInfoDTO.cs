using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class AppealInfoDTO
    {
        public int A_ID { get; set; }
        public string Region { get; set; }
        public List<string> RegionList { get; set; }
        public string RegionName { get; set; }
        public int IED_EV { get; set; }
        public string IED_EVName { get; set; }
        public string Address { get; set; }
        public int ApplicantType { get; set; }
        public int UqodyaGC { get; set; }
        public int UqodyaWCC { get; set; }
        public string ApplicantTypeName { get; set; }
        public int PropertType { get; set; }
        public string PropertTypeName { get; set; }
        public int AppealType { get; set; }
        public string AppealTypeName { get; set; }
        public string ApplicantName { get; set; }
        public string DeqkisNo { get; set; }
        public string AppealNo { get; set; }
        public int OrderStatus { get; set; }
        public int PlaceStructureOrderStatus { get; set; }
        public string GrandAreaSize { get; set; }
        public int GrandCategory { get; set; }
        public int GrandCategoryType { get; set; }
        public string GrandCategoryTypeName { get; set; }
        public int WillChangeCategory { get; set; }
        public string WillChangeCategoryName { get; set; }
      //  public int Planting { get; set; }
        public string PlantingName { get; set; }
        public int AppealReason { get; set; }
        public string AppealReasonName { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpadateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string MainApplicantName { get; set; }
        public string AppealContent { get; set; }

        public string PlaceStructureOrderNo { get; set; }
        public string PlaceStructureOrderStatusName { get; set; }
        public int MissingDocName { get; set; }
        public string MissingDocNameName { get; set; }

        public string OrderNo { get; set; }
        public string OrderNoName { get; set; }

        public string LatterNo { get; set; }
    }
}
