namespace BetGenius.Domain
{
    [MatchEventType("yellowCard")]
    public class YellowCardEvent : PenaltyCardEvent
    {
        public override string ToString()
        {
            return string.Format("{0} yellow card at {1} minute", Player, Minute);
        }
    }
}