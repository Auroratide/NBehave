namespace Auroratide.NBehave.Core {
    public interface OngoingStubbing {
        StubbingAction Then { get; }
        void Always();
    }
}
