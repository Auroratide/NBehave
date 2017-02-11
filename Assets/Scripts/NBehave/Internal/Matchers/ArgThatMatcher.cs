using System;

namespace Auroratide.NBehave.Internal {
    public class ArgThatMatcher<T> : Matcher {

        private Predicate<T> predicate;

        public ArgThatMatcher(Predicate<T> predicate) {
            this.predicate = predicate;
        }

        public bool Matches(object obj) {
            return predicate((T)obj);
        }

        public bool Equals(Matcher other) {
            return this.predicate == ((ArgThatMatcher<T>)other).predicate;
        }

        override public int GetHashCode() {
            return predicate.GetHashCode();
        }
    }
}
