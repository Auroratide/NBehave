namespace Auroratide.NBehave.Core {
    public interface MethodStub {
        OngoingStubbing With(params object[] arguments);
        StubAction NextReturnAction(params object[] arguments);
    }
}
