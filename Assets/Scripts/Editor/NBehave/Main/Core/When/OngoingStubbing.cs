namespace Auroratide.NBehave.Core {

/// <summary>
/// Allows for the specification of return actions on a method stubbed with certain argument matchers.
/// </summary>
/// <example>
/// You are able to store an <c>OngoingStubbing</c> reference to emulate complex behaviour.
/// <code>
/// OngoingStubbing stub = When.Called(() => mock.Method());
/// for(int i = 0; i < 100; ++i)
///     stub = stub.Then.Return(i);
/// </code>
/// </example>
    public interface OngoingStubbing {

    /// <summary>
    /// Presents the list of possible actions to perform when the stubbed method is later called.
    /// </summary>
        StubbingAction Then { get; }

    /// <summary>
    /// Specifies that the previous stub action should always occur when the method is called. Behaviour is unspecified if this is called before actually specifying stub actions with <c>Then</c>.
    /// </summary>
    /// <example>
    /// The following code will stub the method to always return 5 when called.
    /// <code>
    /// When.Called(() => mock.Method()).Then.Return(5).Always();
    /// </code>
    /// </example>
        void Always();

    }
}
