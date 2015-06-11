using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elders.Firewall.Tests
{
    [Subject(typeof(TheFirewall))]
    public class when_there_are_no_rules
    {
        const string FeatureName = "Feature";
        const string FeatureDescription = "Friendly description";

        Establish that = () =>
        {
            TheFirewall.Instance.ClearRules();
            InMemoryFeatureRepository.Instance.ClearFeatures();
        };

        Because of = () =>
        {
        };

        It should_allow_the_access = () =>
             TheFirewall.Instance.Check(new FeatureFlag(FeatureName, typeof(AllowedAccessor))).IsOk.ShouldBeTrue();

        Cleanup after = () =>
        {
            TheFirewall.Instance.ClearRules();
            InMemoryFeatureRepository.Instance.ClearFeatures();
        };

        class AllowedAccessor { }
    }
}