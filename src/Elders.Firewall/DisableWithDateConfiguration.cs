using System;

namespace Elders.Firewall
{

    public class DisableOnTimeIntervalConfiguration
    {
        public bool turn_off_feature { get; set; }
        public bool Switch { get; set; }
        public int periodInMinutes { get; set; }

        public int periodInSeconds { get; set; }
        public DateTime feature_start_date { get; set; }
    }
}
