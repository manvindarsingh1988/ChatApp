using ChatApplication.Model;
using ChatApplication.Service;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ChatApplication
{
    public class ChatAppViewModel : INotifyPropertyChanged
    {
        private readonly IService service;
        private UserInfo selectedUser;
        private UserInfo loginUser;
        private ObservableCollection<UserInfo> users;
        private ObservableCollection<UserInfo> allUsers;
        private ObservableCollection<MessageDetail> messages;
        private string message;
        private bool isUserSelected;

        public ChatAppViewModel(IService service)
        {
            this.service = service;            
            users = new ObservableCollection<UserInfo>();
            allUsers = new ObservableCollection<UserInfo>();
            messages = new ObservableCollection<MessageDetail>();
            SendMessage = new RelayCommand(ExecuteSendMessage, CanExecuteSendMessage);
            SendMessageLikeDetail = new RelayCommand(ExecuteSendMessageLikeDetail, CanExecuteSendMessageLikeDetail);
            LoadAllUsers();
        }

        private bool CanExecuteSendMessageLikeDetail(object arg)
        {
            return true;
        }

        private void ExecuteSendMessageLikeDetail(object obj)
        {
            var messageDetail = (MessageDetail)obj;

            var isLiked = messageDetail.LikerDetails != null && messageDetail.LikerDetails.Any(x => x == LoginUser.Id);
            service.PostMessageLike(new MessageLikeDetail { LikeStatus = (isLiked ? LikeStatus.Delete : LikeStatus.Add), MessageId = messageDetail.Id, UserId = messageDetail.UserId, LikerId = LoginUser.Id, ToUserId = messageDetail.ToUserId });
            LoadMessages(LoginUser.Id, selectedUser.Id);
        }

        private async void LoadAllUsers()
        {
            var list = await service.GetUserInfo(-1);
            foreach (var item in list)
            {
                allUsers.Add(item);
            }
        }

        public bool IsUserSelected
        {
            get
            {
                return isUserSelected;
            }

            set
            {
                isUserSelected = value;
                OnPropertyRaised("IsUserSelected");
            }
        }

        public ObservableCollection<UserInfo> AllUsers
        {
            get
            {
                return allUsers;
            }

            set
            {
                allUsers = value;
                OnPropertyRaised("AllUsers");
            }
        }

        public UserInfo LoginUser
        {
            get
            {
                return loginUser;
            }

            set
            {
                loginUser = value;
                IsUserSelected = true;
                LoadUsers(LoginUser.Id);
                ////LoadMessages(LoginUser.Id, selectedUser.Id);
                EnableSignalR();
                OnPropertyRaised("LoginUser");
            }
        }

        private void EnableSignalR()
        {
            var hubConnection = new HubConnection("https://localhost:44316");
            var myHubProxy = hubConnection.CreateHubProxy("Requestlog");

            myHubProxy.On<string>("PostToClient", (message) => ShoeMessage(message));

            hubConnection.Start().Wait();
        }

        private void ShoeMessage(string message)
        {
            var ids = message.Split('-').Select(x => int.Parse(x)).ToArray();
            var dispatcher = System.Windows.Application.Current.Dispatcher;
            if (ids[0] != LoginUser.Id)
            {
                if (ids[0] == SelectedUser.Id || (ids[1] == SelectedUser.Id && selectedUser.IsGroup))
                {
                    dispatcher.BeginInvoke((Action)(() =>
                        {
                            LoadMessages(LoginUser.Id, SelectedUser.Id);
                        }                    
                    ));
                }
            }            
        }

        private bool CanExecuteSendMessage(object arg)
        {
            return SelectedUser != null && !string.IsNullOrEmpty(Message);
        }

        private async void ExecuteSendMessage(object obj)
        {
            var result = await service.PostMessage(new MessageDetail { Message = Message, ToUserId = SelectedUser.Id, UserId = LoginUser.Id });
            if (result)
            {
                LoadMessages(LoginUser.Id, selectedUser.Id);
                Message = string.Empty;
            }
        }

        public ICommand SendMessage { get; set; }

        public ICommand SendMessageLikeDetail { get; set; }

        public ObservableCollection<UserInfo> Users
        {
            get
            {
                return users;
            }

            set
            {
                users = value;
                OnPropertyRaised("Users");
            }
        }

        public UserInfo SelectedUser
        {
            get
            {
                return selectedUser;
            }

            set
            {
                selectedUser = value;
                LoadMessages(LoginUser.Id, selectedUser.Id);
                OnPropertyRaised("SelectedUser");
            }
        }

        public ObservableCollection<MessageDetail> Messages
        {
            get
            {
                return messages;
            }

            set
            {
                messages = value;
                OnPropertyRaised("Messages");
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
                OnPropertyRaised("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadUsers(int id)
        {
            var list = await service.GetUserInfo(id);
            foreach(var item in list)
            {
                users.Add(item);
            }         
        }

        private async void LoadMessages(int id, int toId)
        {
            var list = await service.GetMessages(id, toId);
            messages.Clear();
            foreach (var item in list.OrderBy(x => x.MessageSentOn))
            {
                if(item.UserId == LoginUser.Id)
                {
                    item.IsSelf = true;
                    
                }
                if (item.LikerDetails != null && item.LikerDetails.Any(x => x == LoginUser.Id))
                {
                    item.ButtonContent = "Unlike";
                }
                else
                {
                    item.ButtonContent = "Like";
                }
                messages.Add(item);
            }
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
