using System;

namespace Elders.Firewall
{
    public class DisableOnTimeInterval : IRestriction
    {
        private DateTime timestamp;

        private bool locked;

        DisableOnTimeIntervalConfiguration config;

        public DisableOnTimeInterval(DisableOnTimeIntervalConfiguration config)
        {
            this.config = config;
            Effect = "disabled";
            Description = "Disables Feature every five seconds ";
            PrettyName = "Scandal";
            timestamp = CaluculateDateTime();
            locked = false;

        }

        public DateTime CaluculateDateTime()
        {
            if (config.Switch)
                return DateTime.UtcNow.AddMinutes(config.periodInMinutes).AddSeconds(config.periodInSeconds);
            else
                return config.feature_start_date;

        }

        private bool IsLocked()
        {
            if (config.Switch)
            {
                if (locked && timestamp < DateTime.UtcNow)
                {
                    locked = false;
                    timestamp = CaluculateDateTime();
                }
                else
                {
                    if (locked == false && timestamp < DateTime.UtcNow)
                    {
                        locked = true;
                        timestamp = CaluculateDateTime();
                    }
                }
                return locked;
            }

            return timestamp > DateTime.UtcNow;
        }

        public RestrictionsResult Apply(object accessor)
        {
            if (IsLocked())
                return RestrictionsResult.Block(String.Format("You can not access at this time. Available after '{0}'", timestamp), accessor);
            else
                return RestrictionsResult.Allow();
        }

        public string Effect { get; private set; }

        public object Value { get { return IsLocked(); } }

        public string Description { get; private set; }

        public string PrettyName { get; private set; }
    }
}
