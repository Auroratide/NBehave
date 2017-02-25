namespace Auroratide.NBehave.Internal {
    using Core;

    public class AtMost : Times {
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
    }
}
