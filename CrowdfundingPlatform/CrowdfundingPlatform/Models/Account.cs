//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrowdfundingPlatform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public System.Guid Id { get; set; }
        public System.Guid Owner { get; set; }
        public string Status { get; set; }
        public Nullable<float> Balance { get; set; }
    }
}
