using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elders.Firewall.Tests
{
    [Subject(typeof(TheFirewall))]
    public class when_rule_is_added_for_specific_accessor
    {
        const string FeatureName = "Feature";
        const string FeatureDescription = "Friendly description";

        Establish that = () =>
        {
            TheFirewall.Instance.AddRule(new FeatureFlagRule(InMemoryFeatureRepository.Instance));
        };

        Because of = () =>
        {
            var validCommands = new List<Type>();
            validCommands.Add(typeof(AllowedAccessor));
            var feature = new Feature(FeatureName, validCommands, FeatureDescription);
            InMemoryFeatureRepository.Instance.AddFeature(feature);
        };

        It should_not_allow_access_to_not_allowed_accessor = () =>
             TheFirewall.Instance.Check(new FeatureFlag(FeatureName, typeof(DisallowedAccessor))).IsOk.ShouldBeFalse();

        It should_allow_access_to_allowed_accessor = () =>
             TheFirewall.Instance.Check(new FeatureFlag(FeatureName, typeof(AllowedAccessor))).IsOk.ShouldBeTrue();

        Cleanup after = () =>
        {
            TheFirewall.Instance.ClearRules();
            InMemoryFeatureRepository.Instance.ClearFeatures();
        };

        class AllowedAccessor { }

        class DisallowedAccessor { }
    }
}