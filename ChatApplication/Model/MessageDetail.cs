using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Model
{
    public class MessageDetail
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        public int ToUserId { get; set; }

        public DateTime? MessageSentOn { get; set; }

        public string UserName { get; set; }

        public string ToUserName { get; set; }

        public bool IsSelf { get; set; }

        public int LikerId { get; set; }

        public IList<int?> LikerDetails { get; set; }

        public int LikesCount
        {
            get
            {
                return LikerDetails != null ? LikerDetails.Count() : 0;
            }
        }

        public string ButtonContent { get; set; }
    }
}
