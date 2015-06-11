using System;
namespace Elders.Firewall
{
    public static class FirewallExetnsions
    {
        public static RuleResult FeatureCheck(this TheFirewall self, string feature, object accessor)
        {
            return self.Check(new FeatureFlag(feature, accessor));
        }

        public static RuleResult FeatureCheck<T>(this TheFirewall self, string feature)
        {
            return self.Check(new FeatureFlag(feature, typeof(T)));
        }


        public static void FeatureCheck(this TheFirewall self, string feature, object accessor, Action allow, Action block)
        {
            var result = self.Check(new FeatureFlag(feature, accessor));
            if (result.IsOk)
                allow();
            else if (block != null)
                block();
        }
        public static void FeatureCheck<T>(this TheFirewall self, string feature, Action allow)
        {
            FeatureCheck(self, feature, typeof(T), allow, null);
        }

    }
}
