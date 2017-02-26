namespace Auroratide.NBehave.Internal {

    public class AnyMatcher : Core.Matcher {
        public AnyMatcher() {}

        public bool Matches(object obj) {
            return true;
        }

        public bool Equals(Core.Matcher other) {
            return other.GetType() == typeof(AnyMatcher);
        }

        override public int GetHashCode() {
            return 1819621459;
        }
    }

}
