using ChatApplication.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Service
{
    public class ChatAppService : IService
    {
        public async Task<List<UserInfo>> GetUserInfo(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "api/home/linkedusersandgroups/" + id;
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();

                var userList = JsonConvert.DeserializeObject<List<UserInfo>>(resp);
                return userList;
            }            
        }

        public async Task<List<MessageDetail>> GetMessages(int id, int toId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "api/home/messages/" + id + "/" + toId;
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();

                var messageDetails = JsonConvert.DeserializeObject<List<MessageDetail>>(resp);
                return messageDetails;
            }
        }

        public async Task<bool> PostMessage(MessageDetail messageDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "api/home/message";
                var payload = JsonConvert.SerializeObject(messageDetail);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<bool>(resp);
                return result;
            }
        }

        public async Task<bool> PostMessageLike(MessageLikeDetail messageLikeDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "api/home/messagelike";
                var payload = JsonConvert.SerializeObject(messageLikeDetail);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<bool>(resp);
                return result;
            }
        }
    }
}
