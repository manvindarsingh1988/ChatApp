using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.ViewModel
{
    public class ChatRoomInfoViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool? IsGroup { get; set; }
    }
}