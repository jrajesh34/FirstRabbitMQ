using System;
using System.Collections.Generic;
using System.Text;

namespace Aptos.EOM.Model
{
    public class Item
    {
        public int SKUId { get; set; }
        public int NonMerchItem { get; set; }
        public int DigitalGood { get; set; }
        public int Quantity { get; set; }
        public int CartLineID { get; set; }
        public string ShippingMethod { get; set; }
        public int SupplierIdForPickUp { get; set; }
        public int SupplierIdDForShip { get; set; }
        public DateTime RequestedDeliveryDate { get; set; }
        public int QuantityRequested { get; set; }
        public int QuantityReserved { get; set; }
        public decimal ShippingCost { get; set; }
        public string CurrencyCode { get; set; }
    }
}
