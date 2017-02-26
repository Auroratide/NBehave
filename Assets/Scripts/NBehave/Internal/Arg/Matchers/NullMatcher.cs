namespace Auroratide.NBehave.Internal {

    public class NullMatcher : Core.Matcher {
        public NullMatcher() {}

        public bool Matches(object obj) {
            return obj == null;
        }

        public bool Equals(Core.Matcher other) {
            return other.GetType() == typeof(NullMatcher);
        }

        override public int GetHashCode() {
            return 2039389511;
        }
    }
}
