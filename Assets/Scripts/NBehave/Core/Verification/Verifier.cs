namespace Auroratide.NBehave {
    public interface Verifier {
        VerifierInteractions IsCalled();
        void IsNotCalled();
        void HasInteractions(Times times);
    }
}
