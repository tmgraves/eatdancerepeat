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
    
    public partial class Style
    {
        public Style()
        {
            this.Comments = new HashSet<Comment>();
            this.EventStyles = new HashSet<EventStyle>();
            this.GroupStyles = new HashSet<GroupStyle>();
            this.Reviews = new HashSet<Review>();
            this.Videos = new HashSet<Video>();
        }
    
        public int StyleID { get; set; }
        public string Style1 { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<EventStyle> EventStyles { get; set; }
        public virtual ICollection<GroupStyle> GroupStyles { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
