using System.Collections.Generic;

namespace Elders.Firewall
{
    public class TheFirewall
    {
        private static TheFirewall instance;
        public static TheFirewall Instance { get { if (instance == null) instance = new TheFirewall(); return instance; } }

        private List<IRule> rules;

        private TheFirewall()
        {
            rules = new List<IRule>();
        }

        public RuleResult Check(object instance)
        {
            foreach (var rule in rules)
            {
                var result = rule.Check(instance);
                if (result.IsOk == false)
                    return result;
            }
            return RuleResult.Allow();
        }

        public void AddRule(IRule rule)
        {
            rules.Add(rule);
        }

        public void ClearRules()
        {
            rules.Clear();
        }
    }
}
