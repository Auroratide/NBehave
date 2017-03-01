namespace Auroratide.NBehave.Core {
    public interface StubbingAction {
        OngoingStubbing Return(object obj);
        OngoingStubbing Throw(System.Exception exception);
        OngoingStubbing Execute(ExecutesDelegate function);
        OngoingStubbing Do(StubAction action);
    }
}
