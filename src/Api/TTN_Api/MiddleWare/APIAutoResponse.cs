using System;

namespace TTN_Tracker.MiddleWare
{
    public class ApiResponse
    {
        public bool status { get; set; }
        public int? code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}