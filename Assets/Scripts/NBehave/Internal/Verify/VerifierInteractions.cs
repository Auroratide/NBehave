namespace Auroratide.NBehave.Internal {
    public class VerifierInteractions : Auroratide.NBehave.VerifierInteractions {
        private Verifier verifier;

        public VerifierInteractions(Verifier verifier) {
            this.verifier = verifier;
        }

        public void Once()   {  Exactly(1); }
        public void Twice()  {  Exactly(2); }
        public void Thrice() {  Exactly(3); }
        public void Exactly(int expected) {  verifier.HasInteractions(new Exactly(expected)); }
        public void AtLeast(int expected) {  verifier.HasInteractions(new AtLeast(expected)); }
        public void AtMost(int expected)  {  verifier.HasInteractions(new AtMost(expected));  }
    }
}
