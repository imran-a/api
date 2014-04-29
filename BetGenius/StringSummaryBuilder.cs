using System;
using System.Text;
using BetGenius.Domain;

namespace BetGenius
{
    public class StringSummaryBuilder : ISummaryBuilder
    {
        public string FullTime(Match match)
        {
            var sb = new StringBuilder();

            // score
            sb.AppendFormat("{0} {1} : {2} {3}", match.HomeTeam, match.HomeTeamGoals, match.AwayTeamGoals, match.AwayTeam);
            
            // cards
            foreach (var card in match.PenaltyCards)
            {
                sb.Append("\n").Append(card);
            }

            return sb.ToString();

        }

        public string HalfTime(Match match)
        {
            throw new NotImplementedException();
        }
    }
}