using System;
using System.Collections.Generic;
using System.Text;

namespace Aptos.EOM.Model
{
    public class EstimatedDeliveryDate
    {
        public int AtpId { get; set; }
        public int CartId { get; set; }
        public int SKUId { get; set; }
        public string ItemSupplierId { get; set; }
        public bool IsInventoryReserved { get; set; }
        public string DeliveryWindow { get; set; }
        public DateTime DeliveryDateTIme { get; set; }
        public DateTime PickingDateTime { get; set; }
        public DateTime ShippingDateTime { get; set; }
        public DateTime DCDeliveryDateTime { get; set; }
        public int LeadTimeDays { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
