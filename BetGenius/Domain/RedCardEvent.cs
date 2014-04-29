namespace BetGenius.Domain
{
    [MatchEventType("redCard")]
    public class RedCardEvent : PenaltyCardEvent
    {
        public override string ToString()
        {
            return string.Format("{0} red card at {1} minute", Player, Minute);
        }
    }
}