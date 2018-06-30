using System;

namespace VetisLog
{
    public class LogInfo
    {
        public DateTime Date { get; set; }
        public string Region { get; set; }
        public string Result { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
        public int HttpStatus { get; set; }
    }
}