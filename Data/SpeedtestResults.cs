using System;

namespace BlazorVersa.Data
{
    public class SpeedtestResults
    {
        public DateTime timestamp { get; set; }
        public string upload_speed { get; set; }
        public string download_speed { get; set; }
        public string ping_speed { get; set; }
    }
}
