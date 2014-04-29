using BetGenius.Domain;

namespace BetGenius
{
    public interface ISummaryBuilder
    {
        string FullTime(Match match);
        string HalfTime(Match match);
    }
}