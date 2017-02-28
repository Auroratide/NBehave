namespace Auroratide.NBehave.Internal {

    public class AtMost : Core.Times, System.IEquatable<AtMost> {
        private int expected;

        public AtMost(int expected) {
            this.expected = expected;
        }

        override public string ToString() {
            return "at most " + expected.ToString();
        }

        public bool Matches(int times) {
            return times <= expected;
        }

        public bool Equals(AtMost other) {
            return this.expected == other.expected;
        }
    }
}
