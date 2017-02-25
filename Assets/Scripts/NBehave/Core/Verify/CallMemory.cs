namespace Auroratide.NBehave.Core {
    public interface CallMemory {
        int TimesCalled(string method, MatcherList arguments);
        void Call(string method, object[] arguments);
    }
}
