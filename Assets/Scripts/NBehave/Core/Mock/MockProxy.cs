namespace Auroratide.NBehave.Core {
    public interface MockProxy {
        CallMemory CallMemory { get; }
        StubMemory StubMemory { get; }

        MethodCall Call(params object[] arguments);
    }
}