using System.Text.RegularExpressions;

namespace Auroratide.NBehave.Internal {
    using Core;

    public class RegexMatcher : Matcher {

        private Regex regex;

        public RegexMatcher(Regex regex) {
            this.regex = regex;
        }

        public bool Matches(object obj) {
            return regex.IsMatch((string)obj);
        }

        public bool Equals(Matcher other) {
            return regex.Equals(((RegexMatcher)other).regex);
        }

        override public int GetHashCode() {
            return regex.GetHashCode();
        }
    }
}
