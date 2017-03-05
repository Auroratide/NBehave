namespace Auroratide.NBehave.Core {

/// <summary>
/// Represents a simulated call to a method. This will perform actions stubbed into the method.
/// </summary>
    public interface MethodCall {

    /// <summary>
    /// Executes the next stub action and returns the result.
    /// </summary>
    /// <typeparam name="T">The return type of the stubbed method.</typeparam>
    /// <example>
    /// If you are manually stubbing a class, you would use this to indicate a method's return.
    /// <code>
    /// class MyMock : IMyInterface, NBehaveMock {
    ///     public string Method() {
    ///         NBehave.Call().AndReturn<string>();
    ///     }
    /// }
    /// </code>
    /// </example>
        T AndReturn<T>();

    /// <summary>
    /// Executes the stub action but returns nothing. Use this on void methods.
    /// </summary>
        void AndExecute();

    }
}
