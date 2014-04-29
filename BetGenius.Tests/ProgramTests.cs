using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetGenius.Domain;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BetGenius.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private Match _match;

        [TestFixtureSetUp]
        public void Setup()
        {
            var json = "{" +
                       " \"homeTeam\" : \"homename1\", " +
                       " \"awayTeam\" : \"awayname1\", " +
                       " \"matchEvents\" : " +
                       "[" +
                       "{ \"type\": \"goal\", \"team\": \"home\", \"minute\": 2 }," +
                       "{ \"type\": \"goal\", \"team\": \"home\", \"minute\": 60 }," +
                       "{ \"type\": \"yellowCard\", \"team\": \"away\", \"minute\": 5, \"player\": \"yellowcardplayer1\" }," +
                       "{ \"type\": \"yellowCard\", \"team\": \"away\", \"minute\": 6, \"player\": \"yellowcardplayer2\" }," +
                       "{ \"type\": \"redCard\", \"team\": \"away\", \"minute\": 10, \"player\": \"redcardplayer1\" }," +
                       "]" +
                       "}";

            _match = JsonConvert.DeserializeObject<Match>(json, new MatchEventConverter());
        }


        [Test]
        public void match_returns_correct_name_for_home_team()
        {
            Assert.AreEqual("homename1", _match.HomeTeam);
        }

        [Test]
        public void match_returns_correct_name_for_away_team()
        {
            Assert.AreEqual("awayname1", _match.AwayTeam);
        }

        [Test]
        public void match_returns_correct_goal_count_for_home_team()
        {
            Assert.AreEqual(2, _match.HomeTeamGoals);
        }

        [Test]
        public void match_returns_correct_goat_count_for_away_team()
        {
            Assert.AreEqual(0, _match.AwayTeamGoals);
        }

        [Test]
        public void match_returns_correct_player_for_first_yellowcard()
        {
            var card = _match.PenaltyCards.OrderBy(p => p.Minute).First();
            Assert.AreEqual("yellowcardplayer1" , card.Player);
        }

        [Test]
        public void match_returns_correct_minute_for_first_yellowcard()
        {
            var card = _match.PenaltyCards.OrderBy(p => p.Minute).First();
            Assert.AreEqual(5, card.Minute);
        }

        [Test]
        public void match_returns_correct_number_of_yellow_cards()
        {
            var cards = _match.PenaltyCards.OfType<YellowCardEvent>().Count();
            Assert.AreEqual(2, cards);
        }

        [Test]
        public void match_returns_correct_number_of_red_cards()
        {
            var cards = _match.PenaltyCards.OfType<RedCardEvent>().Count();
            Assert.AreEqual(1, cards);
        }

        [Test]
        public void match_returns_total_number_of_cards()
        {
            var cards = _match.PenaltyCards.Count();
            Assert.AreEqual(3, cards);
        }

        [Test]
        public void exception_thrown_for_unknown_matchevent_type()
        {
            var json = "{" +
                       " \"homeTeam\" : \"homename1\", " +
                       " \"awayTeam\" : \"awayname1\", " +
                       " \"matchEvents\" : " +
                       "[" +
                       "{ \"type\": \"notknown\", \"team\": \"home\", \"minute\": 2 }" +
                       "]" +
                       "}";

            Assert.Throws<NotSupportedException>(
                () => JsonConvert.DeserializeObject<Match>(json, new MatchEventConverter()));
        }

    }
}
