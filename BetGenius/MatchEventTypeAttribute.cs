using System;

namespace BetGenius
{
    public class MatchEventTypeAttribute : Attribute
    {
        private readonly string _type;

        public MatchEventTypeAttribute(string type)
        {
            _type = type;
        }

        public string Type
        {
            get { return _type; }
        }
    }
}