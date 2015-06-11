using System;
using System.Collections.Generic;
using System.Linq;

namespace Elders.Firewall
{

    public class Feature : IFeature
    {
        public Feature(string name, List<Type> commands, string description)
        {
            Name = name;
            Commands = commands;
            restrictions = new List<IRestriction>();
            Description = description;
        }
        public string Name { get; set; }

        public List<Type> Commands { get; set; }

        public string Description { get; set; }

        public void AddRestriction(IRestriction restriction)
        {
            var existing = restrictions.Where(x => x.Effect == restriction.Effect).SingleOrDefault();
            if (existing != null)
                throw new InvalidOperationException("Already exists a restriction with name:" + restriction.Effect);
            restrictions.Add(restriction);
        }
        public List<IRestriction> restrictions;

        public IEnumerable<IRestriction> Restrictions { get { return restrictions.ToList(); } }
    }
}
