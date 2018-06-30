using System;

namespace VetisLog
{
    public class SendLogCommand
    {
        public DateTime Date1 { get; set; }
        public int Http { get; set; }
        public string Uuid { get; set; }
        public string Ip { get; set; }
        public double Msec { get; set; }
        public string Error { get; set; }
        public DateTime Date { get; set; }
        public string Region { get; set; }
    }
}