using System.Linq;

namespace Elders.Firewall
{
    public class FeatureFlagRule : IRule
    {
        private readonly IFeatureRepository featureRepository;


        public FeatureFlagRule(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public RuleResult Check(object instance)
        {
            var featureFlag = instance as FeatureFlag;
            if (featureFlag == null)
                return RuleResult.Allow();
            var feature = featureRepository.GetAllFeatures().Where(x => x.Name == featureFlag.FeatureName).SingleOrDefault();
            if (feature == null)
                return RuleResult.Allow();

            if (feature.Commands.Count > 0 && feature.Commands.Contains(featureFlag.Accessor) == false)
                return RuleResult.Block(string.Format("Accessor of type '{0}' is not allowed to access feature '{1}'", featureFlag.Accessor, featureFlag.FeatureName));

            foreach (var avail in feature.Restrictions)
            {
                var result = avail.Apply(featureFlag.Accessor);
                if (!result.Pass)
                    return RuleResult.Block(result.Message);
            }

            return RuleResult.Allow();
        }
    }
}
