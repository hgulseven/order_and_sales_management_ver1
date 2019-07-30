using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order_And_Sales_Management_ver1.Models
{
    public class UserHubModels
    {
        public string UserName { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }
}