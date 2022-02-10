using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class UserResponseV1
    {
        public int UserID { get; set; }
        public string Names { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Enabled { get; set; }

    }
}
