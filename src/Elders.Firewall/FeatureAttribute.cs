using System;

namespace Elders.Firewall
{
    public class FeatureAttribute : Attribute
    {
        public FeatureAttribute(string feautreName, object accessor = null)
        {
            FeautreName = feautreName;
            Accessor = accessor;
        }

        public object Accessor { get; private set; }

        public string FeautreName { get; private set; }
    }
}
