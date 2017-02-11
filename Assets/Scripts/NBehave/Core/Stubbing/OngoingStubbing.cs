namespace Auroratide.NBehave {
    public interface OngoingStubbing {
        StubbingAction Then { get; }
        void Always();
    }
}
