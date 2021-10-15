using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.ViewModel
{
    public enum LikeStatus
    {
        Add,
        Delete
    }
    public class MessageLikeDetail
    {
        public int UserId { get; set; }
        public int ToUserId { get; set; }
        public int LikerId { get; set; }
        public int MessageId { get; set; }
        public LikeStatus LikeStatus { get; set; }
    }
}