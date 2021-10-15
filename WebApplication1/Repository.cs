using ChatAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI
{
    public interface IRepository
    {
        IList<ChatRoomInfoViewModel> GetChatRooms(int id);

        IList<int?> GetUserList(int id);

        void LogMessageDetail(MessageDeatil messageDeatil);

        IList<MessageDeatil> GetMessages(int id, int toId);

        void SaveMessageLike(ViewModel.MessageLikeDetail messageLikeDetail);
    }

    public class Repository : IRepository
    {
        public IList<ChatRoomInfoViewModel> GetChatRooms(int id)
        {            
            using (var ctx = new ChatEntities())
            {
                var result = ctx.usp_GetUsersAndGroups(id).Select(x => new ChatRoomInfoViewModel { ID = x.ID, IsGroup = x.IsGroup, Name = x.Name }) ;
                return result.ToList();
            }
        }

        public IList<int?> GetUserList(int id)
        {
            using (var ctx = new ChatEntities())
            {
                var isGroup = ctx.ChatRoomInfoes.FirstOrDefault(x => x.ID == id).IsGroup;
                if (isGroup.GetValueOrDefault())
                {
                    var userList = ctx.ChatGroupInfoes.Where(x => x.GroupId == id).Select(x => x.UserId).ToList();
                    return userList;
                }
                return new List<int?> { id };
            }
        }

        public void LogMessageDetail(MessageDeatil messageDeatil)
        {
            using (var ctx = new ChatEntities())
            {
                ctx.MessageInfoDetails.Add(new MessageInfoDetail { Message = messageDeatil.Message, MessageSentOn = DateTime.Now, Status = "Success", ToUserId = messageDeatil.ToUserId, UserId = messageDeatil.UserId });
                ctx.SaveChanges();
            }
        }

        public void SaveMessageLike(ViewModel.MessageLikeDetail messageLikeDetail)
        {
            using (var ctx = new ChatEntities())
            {
                if (messageLikeDetail.LikeStatus == LikeStatus.Delete)
                {
                    var msgLike = ctx.MessageLikeDetails.FirstOrDefault(x => x.MessageId == messageLikeDetail.MessageId && x.UserId == messageLikeDetail.LikerId);
                    ctx.MessageLikeDetails.Remove(msgLike);
                }
                else
                {
                    ctx.MessageLikeDetails.Add(new MessageLikeDetail { MessageId = messageLikeDetail.MessageId, UserId = messageLikeDetail.LikerId });
                }
                ctx.SaveChanges();
            }
        }

        public IList<MessageDeatil> GetMessages(int id, int toId)
        {
            using (var ctx = new ChatEntities())
            {
                var messageList = ctx.usp_GetMessageDetails(id, toId)
                .Select(x =>
                        new MessageDeatil
                        {
                            Id = x.ID, 
                            MessageSentOn = x.MessageSentOn,
                            Message = x.Message,
                            UserId = x.UserId,
                            ToUserId = x.ToUserId,
                            UserName = x.UserName,
                            ToUserName = x.ToUserName
                        }).ToList();
                var ids = messageList.Select(x => x.Id);
                var likerDetails = ctx.MessageLikeDetails.Where(t => ids.Contains(t.MessageId));
                foreach(var item in messageList)
                {
                    var likeDetails = likerDetails.Where(x => x.MessageId == item.Id);
                    item.LikerDetails = new List<int?>();
                    foreach(var ld in likeDetails)
                    {
                        item.LikerDetails.Add(ld.UserId);
                    }      
                }
                return messageList;
            }
        }

    }
}