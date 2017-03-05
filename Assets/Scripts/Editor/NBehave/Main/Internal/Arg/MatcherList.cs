using System;

namespace Auroratide.NBehave.Internal {

    public class MatcherList : Core.MatcherList {

        private Core.Matcher[] matchers;

        public MatcherList():this(new Core.Matcher[0]) {}

        public MatcherList(Core.Matcher[] matchers) {
            this.matchers = matchers;
        }

        public MatcherList(object[] objects) {
            this.matchers = new Core.Matcher[objects.Length];
            for(int i = 0; i < objects.Length; ++i) {
                if(objects[i] is Core.Matcher)
                    this.matchers[i] = objects[i] as Core.Matcher;
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

        public bool Equals(Core.MatcherList other_) {
            MatcherList other = (MatcherList)other_;
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
