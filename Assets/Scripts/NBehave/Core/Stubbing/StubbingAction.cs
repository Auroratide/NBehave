namespace Auroratide.NBehave {
    public interface StubbingAction {
        OngoingStubbing Return(object obj);
        OngoingStubbing Throw(System.Exception exception);
        OngoingStubbing Execute(ExecutesDelegate function);
    }
}
