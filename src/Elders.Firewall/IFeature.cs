using System;
using System.Collections.Generic;
using System.Linq;

namespace Elders.Firewall
{
    public interface IFeature
    {
        string Name { get; }
        List<Type> Commands { get; }
        string Description { get; }
        IEnumerable<IRestriction> Restrictions { get; }

    }
}
