namespace Auroratide.NBehave.Core {
    public interface MockProxy {
        CallMemory CallMemory { get; }
        StubMemory MethodStubs { get; }

        MethodCall Call(params object[] arguments);
    }
}