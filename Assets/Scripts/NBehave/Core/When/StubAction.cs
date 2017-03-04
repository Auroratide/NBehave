namespace Auroratide.NBehave.Core {

/// <summary>
/// An action to perform when a stubbed method is called.
/// </summary>
    public interface StubAction {

    /// <summary>
    /// Called when a stubbed method is called and was stubbed into the method via <c>When</c>.
    /// </summary>
    /// <returns>The stub will return what this method returns.</returns>
    /// <param name="arguments">The arguments the method was actually called with, as a list.</param>
        object Return(object[] arguments);

    }
}
