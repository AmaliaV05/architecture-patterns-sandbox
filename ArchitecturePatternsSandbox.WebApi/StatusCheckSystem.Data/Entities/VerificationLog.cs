using StatusCheckSystem.Data.Enums;

namespace StatusCheckSystem.Data.Entities
{
    public class VerificationLog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Status Status { get; set; }
        public string Latency { get; set; }
    }
}
