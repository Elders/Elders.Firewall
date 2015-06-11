
namespace Elders.Firewall
{
    public interface IRule
    {
        RuleResult Check(object instance);
    }
}
