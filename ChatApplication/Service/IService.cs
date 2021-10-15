using ChatApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Service
{
    public interface IService
    {
        Task<List<UserInfo>> GetUserInfo(int id);

        Task<bool> PostMessage(MessageDetail messageDetail);

        Task<List<MessageDetail>> GetMessages(int id, int toId);

        Task<bool> PostMessageLike(MessageLikeDetail messageLikeDetail);
    }
}
