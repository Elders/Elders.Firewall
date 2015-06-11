namespace Elders.Firewall
{
    public class RuleResult
    {
        public bool IsOk { get; private set; }

        public string Message { get; private set; }

        public static RuleResult Allow()
        {
            return new RuleResult(true, null);
        }

        public static RuleResult Block(string message)
        {
            return new RuleResult(false, message);
        }

        private RuleResult(bool isOk, string message)
        {
            IsOk = isOk;
            Message = message;
        }
    }
}
