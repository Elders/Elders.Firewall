using System;

namespace Elders.Firewall
{
    public class RestrictionsResult
    {
        public static RestrictionsResult Allow()
        {
            return new RestrictionsResult(true, null);
        }

        public static RestrictionsResult Block(string message)
        {
            return new RestrictionsResult(false, message);
        }

        public static RestrictionsResult Block(string message, object accessor)
        {
            var name = "";
            if (accessor is Type)
                name = (accessor as Type).Name;
            else
                name = accessor.GetType().Name;

            return new RestrictionsResult(false, message + "\r\nAccessor :" + name);
        }


        private RestrictionsResult(bool pass, string message)
        {
            Pass = pass;
            Message = message;
        }
        public bool Pass { get; private set; }
        public string Message { get; private set; }

    }
}
