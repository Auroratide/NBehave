namespace Auroratide.NBehave.Core {
    public interface VerifierInteractions {
        void Once();
        void Twice();
        void Thrice();
        void Exactly(int expected);
        void AtLeast(int expected);
        void AtMost(int expected);
    }
}
