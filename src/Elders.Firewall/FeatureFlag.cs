namespace Elders.Firewall
{
    public class FeatureFlag
    {
        public FeatureFlag(string featureName, object accessor)
        {
            FeatureName = featureName;
            Accessor = accessor;
        }

        public string FeatureName { get; set; }

        public object Accessor { get; set; }

    }
}
