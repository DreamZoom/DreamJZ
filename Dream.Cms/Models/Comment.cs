using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Cms
{
    public class Comment : EntityBase
    {
        public string Title { get; set; }

        public string CommentText { get; set; }


        public string UserName { get; set; }

        public string NickName { get; set; }


        public int ReferenceID { get; set; }


    }
}
