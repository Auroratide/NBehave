namespace Auroratide.NBehave.Internal {

    public class IsMatcher : Core.Matcher {
        private object obj;

        public IsMatcher(object obj) {
            this.obj = obj;
        }

        public bool Matches(object obj) {
            return this.obj.Equals(obj);
        }

        public bool Equals(Core.Matcher other) {
            return other.GetType() == typeof(IsMatcher) && this.obj.Equals(((IsMatcher)other).obj);
        }

        override public int GetHashCode() {
            return obj.GetHashCode();
        }
    }
}