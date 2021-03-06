//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class Place
    {
        public Place()
        {
            this.Comments = new HashSet<Comment>();
            this.Pictures = new HashSet<Picture>();
            this.Reviews = new HashSet<Review>();
            this.Videos = new HashSet<Video>();
            this.GroupRehearsals = new HashSet<GroupRehearsal>();
        }
    
        public int PlaceID { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<GroupRehearsal> GroupRehearsals { get; set; }
    }
}
