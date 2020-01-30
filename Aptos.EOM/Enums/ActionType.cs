using System;
using System.Collections.Generic;
using System.Text;

namespace Aptos.EOM.Enums
{
    public enum ActionType
    {
        CREATE = 1,
        CONFIRM,
        UPDATE,
        CANCEL
    }

    public enum RequestType
    {
        GetShippingDatesOnlyForSKUs = 1,
        GeShippingCostsOnlyForSKUs,
        GetShippingDatesAndShippingCosts
    }
    public enum ShippingMethod
    {
        ShipToHome = 1,
        PickupAtStore
    }
}
