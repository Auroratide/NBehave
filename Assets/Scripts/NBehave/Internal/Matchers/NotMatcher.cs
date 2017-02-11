namespace Auroratide.NBehave.Internal {
    public class NotMatcher : Matcher {
        private Matcher matcher;

        public NotMatcher(Matcher matcher) {
            this.matcher = matcher;
        }

        public bool Matches(object obj) {
            return !matcher.Matches(obj);
        }

        public bool Equals(Matcher other) {
            return this.matcher.Equals(((NotMatcher)other).matcher);
        }

        override public int GetHashCode() {
            unchecked { return 23 * matcher.GetHashCode(); };
        }
    }
}
