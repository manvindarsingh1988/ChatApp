using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.ViewModel
{
    public class MessageDeatil
    {
        public int? Id { get; set; }

        public int? UserId { get; set; }

        public string Message { get; set; }

        public int? ToUserId { get; set; }

        public DateTime? MessageSentOn { get; set; }

        public string UserName { get; set; }

        public string ToUserName { get; set; }
        
        public IList<int?> LikerDetails { get; set; }        
    }
}