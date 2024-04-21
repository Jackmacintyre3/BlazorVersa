namespace BlazorVersa.Data
{
    public class RootObject
    {
        public DateTime Timestamp { get; set; }
        public List<ScanResults> Devices { get; set; }
    }
}
