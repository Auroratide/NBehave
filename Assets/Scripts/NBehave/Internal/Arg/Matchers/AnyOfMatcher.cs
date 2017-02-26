namespace Auroratide.NBehave.Internal {

    public class AnyOfMatcher<T> : Core.Matcher {
        public AnyOfMatcher() {}

        public bool Matches(object obj) {
            return obj is T;
        }

        public bool Equals(Core.Matcher other) {
            return other.GetType() == typeof(AnyOfMatcher<T>);
        }

        override public int GetHashCode() {
            return typeof(T).GetHashCode();
        }
    }
}
