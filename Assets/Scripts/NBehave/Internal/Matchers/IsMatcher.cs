namespace Auroratide.NBehave.Internal {
    public class IsMatcher : Matcher {
        private object obj;

        public IsMatcher(object obj) {
            this.obj = obj;
        }

        public bool Matches(object obj) {
            return this.obj.Equals(obj);
        }

        public bool Equals(Matcher other) {
            return this.obj.Equals(((IsMatcher)other).obj);
        }

        override public int GetHashCode() {
            return obj.GetHashCode();
        }
    }
}