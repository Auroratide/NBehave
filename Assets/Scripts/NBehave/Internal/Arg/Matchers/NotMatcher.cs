namespace Auroratide.NBehave.Internal {

    public class NotMatcher : Core.Matcher {
        private Core.Matcher matcher;

        public NotMatcher(Core.Matcher matcher) {
            this.matcher = matcher;
        }

        public bool Matches(object obj) {
            return !matcher.Matches(obj);
        }

        public bool Equals(Core.Matcher other) {
            return other.GetType() == typeof(NotMatcher) && this.matcher.Equals(((NotMatcher)other).matcher);
        }

        override public int GetHashCode() {
            unchecked { return 23 * matcher.GetHashCode(); };
        }
    }
}
