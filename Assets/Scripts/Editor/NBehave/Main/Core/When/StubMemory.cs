namespace Auroratide.NBehave.Core {

/// <summary>
/// Used to remember the ways in which methods are stubbed.
/// </summary>
    public interface StubMemory {

    /// <summary>
    /// Gets a <c>MethodStub</c> instance corresponding to the method name.
    /// </summary>
    /// <param name="method">Method name.</param>
        MethodStub Get(string method);

    }
}
