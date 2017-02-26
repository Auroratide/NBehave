using System.Text.RegularExpressions;

namespace Auroratide.NBehave.Internal {

    public class RegexMatcher : Core.Matcher {

        private Regex regex;

        public RegexMatcher(Regex regex) {
            this.regex = regex;
        }

        public bool Matches(object obj) {
            return regex.IsMatch((string)obj);
        }

        public bool Equals(Core.Matcher other) {
            return other.GetType() == typeof(RegexMatcher) && regex.Equals(((RegexMatcher)other).regex);
        }

        override public int GetHashCode() {
            return regex.GetHashCode();
        }
    }
}
