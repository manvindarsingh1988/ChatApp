//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatGroupInfo
    {
        public int ID { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual ChatRoomInfo ChatRoomInfo { get; set; }
        public virtual ChatRoomInfo ChatRoomInfo1 { get; set; }
    }
}
