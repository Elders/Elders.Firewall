using System.Linq;
using System;
using Elders.Firewall;
using System.Collections.Generic;

namespace Elders.Firewall.Tests
{
    public class InMemoryFeatureRepository : IFeatureRepository
    {
        private List<IFeature> features;

        private static InMemoryFeatureRepository instance;

        public InMemoryFeatureRepository()
        {
            features = new List<IFeature>();
        }

        public static InMemoryFeatureRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new InMemoryFeatureRepository();
                return instance;
            }
        }

        public IEnumerable<IFeature> GetAllFeatures()
        {
            return features.ToList();
        }

        public void AddFeature(IFeature feature)
        {
            if (features.Any(x => x.Name == feature.Name))
                throw new InvalidOperationException(string.Format("There is already a feature with name '{0}'.", feature.Name));

            features.Add(feature);
        }

        public void ClearFeatures()
        {
            features.Clear();
        }
    }
}
