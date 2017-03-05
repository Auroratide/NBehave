namespace Auroratide.NBehave.Core {

/// <summary>
/// Encapsulates a list of Matchers.
/// </summary>
    public interface MatcherList : System.IEquatable<MatcherList> {

    /// <summary>
    /// Checks whether all the objects in the given list match the corresponding Matchers.
    /// </summary>
    /// <param name="objects">List of arguments to match against.</param>
    /// <returns><c>true</c> if argument list matches all Matchers, <c>false</c> otherwise.</returns>
        bool MatchesAll(object[] objects);

    }
}
