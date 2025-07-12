using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackIt.ViewModels
{
    public class NotificationViewModel
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}