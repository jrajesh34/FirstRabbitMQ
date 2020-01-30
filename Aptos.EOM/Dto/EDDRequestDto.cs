using Aptos.EOM.Enums;
using Aptos.EOM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aptos.EOM.Dto
{
    public class EDDRequestDto
    {
        public ActionType ActionType { get; set; }
        public int ATPId { get; set; }
        public int CartId { get; set; }
        public bool CreateReservation { get; set; }
        public bool GetDeliveryInfo { get; set; }
        public RequestType RequestType { get; set; }
        public string RoutingRuleId { get; set; }
        public string CustomData1 { get; set; }
        public string CustomData2 { get; set; }
        public string CustomData3 { get; set; }
        public string CustomData4 { get; set; }
        public string CustomData5 { get; set; }
        public List<ItemDto> Items { get; set; }
        public ShipToAddress ShipAddress { get; set; }
        public ItemDimension ItemDimension { get; set; }
    }
}
