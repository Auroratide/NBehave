﻿namespace Auroratide.NBehave.Internal {
    using Core;

    public class Exactly : Times, System.IEquatable<Exactly> {
        private int expected;

        public Exactly(int expected) {
            this.expected = expected;
        }

        override public string ToString() {
            return "exactly " + expected.ToString();
        }

        public bool Matches(int times) {
            return times == expected;
        }

        public bool Equals(Exactly other) {
            return this.expected == other.expected;
        }

    }
}
