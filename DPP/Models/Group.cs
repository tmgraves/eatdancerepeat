
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
    
public abstract partial class Group
{

    public Group()
    {

        this.Comments = new HashSet<Comment>();

        this.GroupEvents = new HashSet<GroupEvent>();

        this.GroupMembers = new HashSet<GroupMember>();

        this.Groups1 = new HashSet<Group>();

        this.GroupStyles = new HashSet<GroupStyle>();

        this.Pictures = new HashSet<Picture>();

        this.Reviews = new HashSet<Review>();

        this.Videos = new HashSet<Video>();

        this.Events = new HashSet<Event>();

        this.GroupRehearsals = new HashSet<GroupRehearsal>();

    }


    public int GroupID { get; set; }

    public string GroupName { get; set; }

    public string GroupDescription { get; set; }

    public int SkillLevel { get; set; }

    public string FacebookLink { get; set; }

    public bool Public { get; set; }

    public Nullable<int> ParentGroupID { get; set; }



    public virtual ICollection<Comment> Comments { get; set; }

    public virtual ICollection<GroupEvent> GroupEvents { get; set; }

    public virtual ICollection<GroupMember> GroupMembers { get; set; }

    public virtual ICollection<Group> Groups1 { get; set; }

    public virtual Group Group1 { get; set; }

    public virtual ICollection<GroupStyle> GroupStyles { get; set; }

    public virtual ICollection<Picture> Pictures { get; set; }

    public virtual ICollection<Review> Reviews { get; set; }

    public virtual ICollection<Video> Videos { get; set; }

    public virtual ICollection<Event> Events { get; set; }

    public virtual ICollection<GroupRehearsal> GroupRehearsals { get; set; }

}

}
