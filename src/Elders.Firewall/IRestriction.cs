using System;
using System.Collections.Generic;

namespace Elders.Firewall
{
    public interface IRestriction
    {
        RestrictionsResult Apply(object accessor);
        string Effect { get; }
        object Value { get; }
        string Description { get; }
        string PrettyName { get; }
    }
}
