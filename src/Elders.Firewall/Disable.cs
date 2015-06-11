using System;
using System.Collections.Generic;
namespace Elders.Firewall
{
    public class Disable : IRestriction
    {
        public Disable()
        {
            Effect = "disabled";
            Value = true;
            Description = "Disables Feature";
            PrettyName = "Disable";
        }

        public string Effect { get; set; }

        public object Value { get; set; }

        public string Description { get; set; }

        public string PrettyName { get; set; }

        public RestrictionsResult Apply(object accessor)
        {
            return RestrictionsResult.Block("This feature is disabled");
        }
    }
}
