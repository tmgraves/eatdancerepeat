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
    
    public partial class GroupRehearsal
    {
        public int GroupRehearsalID { get; set; }
        public int GroupID { get; set; }
        public int PlaceID { get; set; }
        public string Day { get; set; }
        public System.TimeSpan Time { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Place Place { get; set; }
    }
}
