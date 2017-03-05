namespace Auroratide.NBehave.Core {

/// <summary>
/// A newly mocked type. The type cannot be used unless it is created first.
/// </summary>
    public interface MockedType<T> where T : class {

    /// <summary>
    /// The type, within which is encoded the <c>NBehaveMock</c> information.
    /// </summary>
        System.Type Type { get; }

    /// <summary>
    /// Create an instance of the mock.
    /// </summary>
        T Create();

    }
}