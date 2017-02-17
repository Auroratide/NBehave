using System;

namespace Auroratide.NBehave.Internal {
    using Core;

    public class MatcherList : IEquatable<MatcherList> {

        private Matcher[] matchers;

        public MatcherList() {
            this.matchers = new Matcher[0];
        }

        public MatcherList(object[] objects) {
            this.matchers = new Matcher[objects.Length];
            for(int i = 0; i < objects.Length; ++i) {
                if(objects[i] is Matcher)
                    this.matchers[i] = objects[i] as Matcher;
                else
                    this.matchers[i] = new IsMatcher(objects[i]);
            }
        }

        public bool MatchesAll(object[] objects) {
            if (objects.Length != matchers.Length)
                return false;
            else {
                for (int i = 0; i < matchers.Length; ++i) 
                    if (!matchers[i].Matches(objects[i]))
                        return false;
                return true;
            }
        }

        public bool Equals(MatcherList other) {
            if (this.matchers.Length != other.matchers.Length)
                return false;

            for (int i = 0; i < this.matchers.Length; ++i) {
                if (!this.matchers[i].Equals(other.matchers[i]))
                    return false;
            }
            
            return true;
        }

        override public int GetHashCode() {
            int result = 17;
            for (int i = 0; i < matchers.Length; ++i) {
                unchecked {
                    result = result * 23 + matchers[i].GetHashCode();
                }
            }
                
            return result;
        }

    }
}
