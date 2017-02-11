namespace Auroratide.NBehave {
    public interface VerifierInteractions {
        void Once();
        void Twice();
        void Thrice();
        void Exactly(int expected);
        void AtLeast(int expected);
        void AtMost(int expected);
    }
}
