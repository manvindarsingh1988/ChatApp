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
    
    public partial class MessageInfoDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MessageInfoDetail()
        {
            this.MessageLikeDetails = new HashSet<MessageLikeDetail>();
        }
    
        public int ID { get; set; }
        public string Message { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ToUserId { get; set; }
        public Nullable<System.DateTime> MessageSentOn { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageLikeDetail> MessageLikeDetails { get; set; }
    }
}
