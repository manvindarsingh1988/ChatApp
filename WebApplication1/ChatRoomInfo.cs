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
    
    public partial class ChatRoomInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatRoomInfo()
        {
            this.ChatGroupInfoes = new HashSet<ChatGroupInfo>();
            this.ChatGroupInfoes1 = new HashSet<ChatGroupInfo>();
            this.MessageLikeDetails = new HashSet<MessageLikeDetail>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsGroup { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatGroupInfo> ChatGroupInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatGroupInfo> ChatGroupInfoes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageLikeDetail> MessageLikeDetails { get; set; }
    }
}
