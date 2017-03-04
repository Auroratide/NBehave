namespace Auroratide.NBehave.Core {

/// <summary>
/// Base interface used for matching against method arguments.
/// </summary>
    public interface Matcher : System.IEquatable<Matcher> {

    /// <summary>
    /// Returns true when the given object matches the condition of this Matcher.
    /// </summary>
    /// <param name="obj">Object to match against.</param>
    /// <returns><c>true</c> if object matches, <c>false</c> otherwise.</returns>
        bool Matches(object obj);

    }
}