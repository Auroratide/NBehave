namespace Auroratide.NBehave.Core {

/// <summary>
/// Represents a method to be stubbed. This encapsulates the method and all possible calls to it.
/// </summary>
    public interface MethodStub {

    /// <summary>
    /// Sets up an <c>OngoingStubbing</c> instance stubbing this method with the given arguments.
    /// </summary>
    /// <param name="arguments">Arguments to use with the method. When the method is called with these arguments, then the resulting stub actions will occur.</param>
        OngoingStubbing With(params object[] arguments);

    /// <summary>
    /// Returns the next stub action to execute given the arguments.
    /// </summary>
    /// <param name="arguments">Arguments the stubbed method was called with.</param>
        StubAction NextReturnAction(params object[] arguments);

    }
}
