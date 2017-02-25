namespace Auroratide.NBehave.Internal {
    using Core;

    public class AnyOfMatcher<T> : Matcher {
        public AnyOfMatcher() {}

        public bool Matches(object obj) {
            return obj is T;
        }

        public bool Equals(Matcher other) {
            return other.GetType() == typeof(AnyOfMatcher<T>);
        }

        override public int GetHashCode() {
            return typeof(T).GetHashCode();
        }
    }
}
