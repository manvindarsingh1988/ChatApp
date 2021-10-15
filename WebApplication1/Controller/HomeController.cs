using ChatAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ChatAPI.Controller
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        private IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        [Route("linkedusersandgroups/{id:int}")]
        [HttpGet]
        public IList<ChatRoomInfoViewModel> GetLinkedUsersAndGroups(int id)
        {
            var data = repository.GetChatRooms(id);
            return data;
        }

        [Route("message")]
        [HttpPost]
        public bool PostMessage(MessageDeatil messageDeatil)
        {
            var userList = repository.GetUserList(messageDeatil.ToUserId.GetValueOrDefault());
            var subscribeUsers = userList.Where(x => x != messageDeatil.UserId);
            repository.LogMessageDetail(messageDeatil);
            Requestlog.PostToClient(string.Format("{0}-{1}", messageDeatil.UserId, messageDeatil.ToUserId));
            return true;
        }

        [Route("messagelike")]
        public bool PostMessageLike(ViewModel.MessageLikeDetail messageLikeDetail)
        {
            repository.SaveMessageLike(messageLikeDetail);
            Requestlog.PostToClient(string.Format("{0}-{1}", messageLikeDetail.UserId, messageLikeDetail.ToUserId));
            return true;
        }

        [Route("messages/{id:int}/{toid:int}")]
        [HttpGet]
        public IList<MessageDeatil> GetMessages(int id, int toId)
        {
            var messagesList = repository.GetMessages(id, toId);
            return messagesList;
        }
    }
}