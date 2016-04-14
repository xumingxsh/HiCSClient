using System;
using System.Data;

using OutWardProvid;
using OutWardModel;

namespace OutWardControl.Control
{
    public sealed class ProductionControl
    {
        public static DataTable GetProcessMaterial(string productID, string processID, ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            return ProductProvid.GetProcessMaterial(productID, processID, type);
        }
    }
}
