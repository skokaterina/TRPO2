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
    
    public partial class User
    {
        public User()
        {
            this.Basket = new HashSet<Basket>();
            this.Project = new HashSet<Project>();
            this.Transaction = new HashSet<Transaction>();
        }
    
        public string Login { get; set; }
        public string RoleId { get; set; }
        public string Password { get; set; }
        public System.DateTime DateRegistrated { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ICollection<Basket> Basket { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
