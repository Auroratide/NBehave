namespace Auroratide.NBehave.Core {

/// <summary>
/// The list of ways in which you can stub a method. These can be chained with an <c>OngoingStubbing</c> object to specify what a method should do when called multiple times.
/// </summary>
    public interface StubbingAction {

    /// <summary>
    /// The stubbed method will return the given object.
    /// </summary>
    /// <param name="obj">Object to return. This should match the return type of the method, otherwise a <c>StubbingException</c> will be thrown when the method is eventually called.</param>
        OngoingStubbing Return(object obj);

    /// <summary>
    /// The stubbed method will throw the given exception.
    /// </summary>
    /// <param name="exception">Exception to throw.</param>
        OngoingStubbing Throw(System.Exception exception);

    /// <summary>
    /// The stubbed method will execute the following method, passing in the arguments the method was caleld with.
    /// </summary>
    /// <param name="function">Function to execute. Should return a type compatible with the method return type.</param>
    /// <example>
    /// <code>
    /// When.Called(() => mock.Method(1, 2)).Then.Execute(args => {
    ///     wasCalled = true;
    ///     return (int)args[0] + (int)args[1];
    /// });
    /// </code>
    /// </example>
        OngoingStubbing Execute(ExecutesDelegate function);

    /// <summary>
    /// The stubbed method will perform the customized <c>StubAction</c>.
    /// </summary>
    /// <param name="action">Action to perform.</param>
        OngoingStubbing Do(StubAction action);

    }
}
