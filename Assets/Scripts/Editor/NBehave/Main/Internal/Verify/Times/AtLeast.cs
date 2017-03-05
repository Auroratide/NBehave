namespace Auroratide.NBehave.Internal {

    public class AtLeast : Core.Times, System.IEquatable<AtLeast> {
        private int expected;

        public AtLeast(int expected) {
            this.expected = expected;
        }

        override public string ToString() {
            return "at least " + expected.ToString();
        }

        public bool Matches(int times) {
            return times >= expected;
        }

        public bool Equals(AtLeast other) {
            return this.expected == other.expected;
        }
    }
}
