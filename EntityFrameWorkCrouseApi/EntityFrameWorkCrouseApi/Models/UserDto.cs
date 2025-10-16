using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameWorkCrouseApi.Models
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}