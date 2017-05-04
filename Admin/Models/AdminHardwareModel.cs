namespace Admin.Models
{
    public class AdminHardwareModel
    {

        public string ComputerName { get; set; }
        public string OsVersion { get; set; }
        public string ServicePack { get; set; }
        public string UserName { get; set; }
        public string Is64 { get; set; }
        public int TickCount { get; set; }
        public string LastUpdate { get; set; }
        public string UserDomain { get; set; }
        public CPU _cpu { get; set; }
        public GPU _gpu { get; set; }
        public Memory _memory { get; set; }
        public Motherboard _mb { get; set; }
        public HDD _hdd { get; set; }
    }
}