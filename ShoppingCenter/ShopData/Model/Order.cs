//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopData.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public string CartID { get; set; }
        public string OrderDate { get; set; }
        public string ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipMobile { get; set; }
        public string ShipEmail { get; set; }
        public string ShipNote { get; set; }
        public decimal ShipFee { get; set; }
        public short Status { get; set; }
    
        public virtual Cart Cart { get; set; }
    }
}
