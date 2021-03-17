using System;
using System.Collections.Generic;
using System.Text;

namespace TKDSIM.DTO.DTO
{
    public class ReportDto
    {
        public int O_ID { get; set; }
        public int A_ID { get; set; }
        public string Region { get; set; }
        public string GrandAreaSize { get; set; }
        public int GrandCategoryType { get; set; }
        public string GrandCategoryTypeName { get; set; }
        public int WillChangeCategory { get; set; }
        public string WillChangeCategoryName { get; set; }
        public string Address { get; set; }
        public string ApplicantName { get; set; }
        public int PlaceStructureOrderStatus { get; set; }
        public string PlaceStructureOrderStatusName { get; set; }
        public string MissingDocs { get; set; }
        public int AppealType { get; set; }
        public string AppealTypeName { get; set; }
        public int PropertType { get; set; }
        public string PropertyTypeName { get; set; }
        public string OrderNo { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusName { get; set; }
        public string OrderStatusNote { get; set; }
        public string MainApplicantName { get; set; }
        public string PlaceStructureOrderNote { get; set; }
    }
}
