namespace Auroratide.NBehave.Core {
    public interface Verifier {
        VerifierInteractions IsCalled();
        void IsNotCalled();
        void HasInteractions(Times times);
    }
}
