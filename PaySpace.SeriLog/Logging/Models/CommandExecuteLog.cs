namespace PaySpace.Logging.Logging.Models
{
    public class CommandExecuteLog
    {
        public string Method { get; set; }
        public string CommandText { get; set; }
        public double DurationMs { get; set; }
    }
}
