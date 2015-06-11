using System.Collections.Generic;

namespace Elders.Firewall
{
    public interface IFeatureRepository
    {
        IEnumerable<IFeature> GetAllFeatures();
    }
}
