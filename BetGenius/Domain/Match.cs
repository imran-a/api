using System.Collections.Generic;
using System.Linq;

namespace BetGenius.Domain
{
    public class Match
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public List<MatchEvent> MatchEvents { get; set; }

        public int HomeTeamGoals
        {
            get { return GetGoals(true); }
        }

        public int AwayTeamGoals
        {
            get { return GetGoals(false); }
        }

        public IEnumerable<PenaltyCardEvent> PenaltyCards
        {
            get
            {
                var events = MatchEvents.Where(m => m.GetType() == typeof (RedCardEvent) || m.GetType() == typeof (YellowCardEvent));

                return events.Cast<PenaltyCardEvent>().ToList();
            }
        }

        private int GetGoals(bool isHome)
        {
            var side = isHome ? "home" : "away";

            return MatchEvents.OfType<GoalEvent>().Count(m => m.Team == side);
        }
        
    }
}