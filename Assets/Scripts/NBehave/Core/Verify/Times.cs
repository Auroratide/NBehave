namespace Auroratide.NBehave.Core {

/// <summary>
/// Base interface for verifying the number of times a method was called.
/// </summary>
    public interface Times {

    /// <summary>
    /// This message is printed to the error message to indicate why a method failed verification.
    /// </summary>
        string ToString();

    /// <summary>
    /// Returns <c>true</c> if the number of times a method was called satisfies the condition of this class.
    /// </summary>
    /// <param name="times">Number of times the method was called.</param>
        bool Matches(int times);
    }
}