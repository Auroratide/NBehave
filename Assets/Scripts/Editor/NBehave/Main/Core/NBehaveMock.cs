namespace Auroratide.NBehave.Core {

/// <summary>
/// Interface used to determine whether a type is mocked or not.
/// </summary>
/// <example>
/// You can manually create your own mocked types by implementing this interface.
/// <code>
/// class MyMock : IMyInterface, NBehaveMock {
///     private MockProxy proxy;
///     MockProxy NBehave {
///         get {
///             if(proxy == null)
///                 proxy = Mock.Proxy();
///             return proxy;
///         }
///     }
/// }
/// </code>
/// </example>
    public interface NBehaveMock {

    /// <summary>
    /// Gets the <c>MockProxy</c> used for tracking method calls and performing stub actions.
    /// </summary>
        MockProxy NBehave { get; }
    }
}
