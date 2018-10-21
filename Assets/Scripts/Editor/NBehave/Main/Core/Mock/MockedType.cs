namespace Auroratide.NBehave.Core {

/// <summary>
/// A newly mocked type. The type cannot be used unless it is created first.
/// </summary>
    public interface MockedType<T> where T : class {
    /// <summary>
    /// Create an instance of the mock.
    /// </summary>
        T Create();

    }
}