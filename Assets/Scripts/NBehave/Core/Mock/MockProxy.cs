namespace Auroratide.NBehave.Core {

/// <summary>
/// Container for all mock-related information for a given type.
/// </summary>
    public interface MockProxy {

    /// <summary>
    /// Gets the call memory.
    /// </summary>
        CallMemory CallMemory { get; }

    /// <summary>
    /// Gets the stub memory.
    /// </summary>
    /// <value>The stub memory.</value>
        StubMemory StubMemory { get; }

    /// <summary>
    /// Simulates a call on the method that contains this method call.
    /// </summary>
    /// <param name="arguments">The arguments used on the calling method.</param>
    /// <example>
    /// If you are manually creating a mock, you would use this method to simulate calls on methods in the interface you are mocking.
    /// <code>
    /// class MyMock : IMyInterface, NBehaveMock {
    ///     public int Method(int arg1, string arg2) {
    ///         NBehave.Call(arg1, arg2).AndReturn<int>();
    ///     }
    /// }
    /// </code>
    /// </example>
        MethodCall Call(params object[] arguments);

    }
}