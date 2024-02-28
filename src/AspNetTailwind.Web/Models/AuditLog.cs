namespace AspNetTailwind.Web.Models
{
    public class AuditLog
    {
        private AuditLog() { }

        public AuditLog(
            string path,
            string method,
            string? ipAddress,
            string? userAgent,
            string? userName = null)
        {
            Path = path;
            Method = method;
            IPAddress = ipAddress;
            UserAgent = userAgent;
            UserName = userName;
            Created = DateTime.UtcNow;
        }

        public string Path { get; private set; } = null!;
        public string Method { get; private set; } = null!;
        public string? IPAddress { get; private set; }
        public string? UserAgent { get; private set; }
        public string? UserName { get; private set; }
        public DateTime Created { get; private set; }

        public override string ToString()
            => $"Method:{Method} Path:{Path} IP:{IPAddress} UA:{UserAgent} User:{UserName ?? "Anonymous"}";
    }
}
