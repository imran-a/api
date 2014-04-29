using System;
using System.Linq;
using BetGenius.Domain;
using Newtonsoft.Json.Linq;

namespace BetGenius
{
    public class MatchEventConverter : JsonCreationConverter<MatchEvent>
    {
        protected override MatchEvent Create(Type objectType, JObject jObject)
        {
            var jsonMatchType = jObject["type"].ToObject<string>();

            // may be overkill, but a switch statement on 'type' could suffice (breaks open/closed principle tho)
            // otherwise probably cache types

            foreach (var type in typeof (MatchEventTypeAttribute).Assembly.GetTypes())
            {
                var attrs = type.GetCustomAttributes(typeof(MatchEventTypeAttribute), false);
                if (attrs.Length > 0)
                {
                    if (jsonMatchType == ((MatchEventTypeAttribute) (attrs[0])).Type)
                    {
                        return Activator.CreateInstance(type) as MatchEvent;
                    }
                }
            }

            throw new NotSupportedException("Type " + jsonMatchType + " is not handled.");
        }
    }
}