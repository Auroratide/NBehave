namespace Auroratide.NBehave.Core {

/// <summary>
/// Used to remember what methods were called with what arguments.
/// </summary>
    public interface CallMemory {

    /// <summary>
    /// Returns the number of times a method was called with arguments that match the <c>MAtcherList</c>.
    /// </summary>
    /// <param name="method">Name of the method.</param>
    /// <param name="arguments">List of argument Matchers.</param>
        int TimesCalled(string method, MatcherList arguments);

    /// <summary>
    /// Registers a call to the given method with the given arguments.
    /// </summary>
    /// <param name="method">Name of the method.</param>
    /// <param name="arguments">List of arguments with which the method was called.</param>
        void Call(string method, object[] arguments);

    }
}
