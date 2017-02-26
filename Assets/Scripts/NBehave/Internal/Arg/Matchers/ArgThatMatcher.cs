using System;

namespace Auroratide.NBehave.Internal {

    public class ArgThatMatcher<T> : Core.Matcher {

        private Predicate<T> predicate;

        public ArgThatMatcher(Predicate<T> predicate) {
            this.predicate = predicate;
        }

        public bool Matches(object obj) {
            return predicate((T)obj);
        }

        public bool Equals(Core.Matcher other) {
            return other.GetType() == typeof(ArgThatMatcher<T>) && this.predicate == ((ArgThatMatcher<T>)other).predicate;
        }

        override public int GetHashCode() {
            return predicate.GetHashCode();
        }
    }
}
