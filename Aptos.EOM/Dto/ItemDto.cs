using Aptos.EOM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aptos.EOM.Dto
{
    public class ItemDto
    {
        public int SKUId { get; set; }
        public int NonMerchItem { get; set; }
        public int DigitalGood { get; set; }
        public int Quantity { get; set; }
        public int LineID { get; set; }
        public string ShippingMethod { get; set; }
        public int SupplierIdForPickUp { get; set; }
        public int SupplierIdDForShip { get; set; }
        public DateTime RequestedDeliveryDate { get; set; }
        public string RequestedDeliveryWindow { get; set; }
        public int QuantityRequested { get; set; }
        public int QuantityReserved { get; set; }
        public decimal ShippingCost { get; set; }
        public string CurrencyCode { get; set; }
        public ItemDimension ItemDimenstion { get; set; }
        public ShipToAddress ShipToAddress { get; set; }
        public ATPDate ItemDate { get; set; }
    }
}
