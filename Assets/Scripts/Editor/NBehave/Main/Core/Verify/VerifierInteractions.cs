namespace Auroratide.NBehave.Core {

/// <summary>
/// Further specifies how often a method should have been called. Throws a <c>VerificationException</c> if the method fails verification.
/// </summary>
    public interface VerifierInteractions {

    /// <summary>
    /// The method must be called exactly once.
    /// </summary>
        void Once();

    /// <summary>
    /// The method must be called exactly twice.
    /// </summary>
        void Twice();

    /// <summary>
    /// The method must be called exactly three times.
    /// </summary>
        void Thrice();

    /// <summary>
    /// The method must be called exactly the given number of times.
    /// </summary>
    /// <param name="expected">Expected nunber of interactions with the method.</param>
        void Exactly(int expected);

    /// <summary>
    /// The method must be called at least the given number of times.
    /// </summary>
    /// <param name="expected">Lower bound for the number of interactions.  Passes verification if the number of calls is equal to this.</param>
        void AtLeast(int expected);

    /// <summary>
    /// The method must be called at most the given number of times.
    /// </summary>
    /// <param name="expected">Upper bound for the number of interactions. Passes verification if the number of calls is equal to this.</param>
        void AtMost(int expected);

    }
}
