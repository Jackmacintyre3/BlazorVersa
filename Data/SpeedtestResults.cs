using System;

namespace BlazorVersa.Data
{
    public class SpeedtestResults
    {
        public double UploadSpeed { get; set; }
        public double DownloadSpeed { get; set; }
        public double PingSpeed { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
