using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCorcoranGroup.ApiApp.Models
{
    public class ContentItemApiResponse
    {
        public bool Success { get; set; }

        public string Messages { get; set; }

        public string Data { get; set; }

    }
}