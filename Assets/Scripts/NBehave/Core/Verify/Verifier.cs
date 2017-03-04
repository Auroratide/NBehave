namespace Auroratide.NBehave.Core {

/// <summary>
/// Interface for verifying interactions on a method. When a method fails verification, a <c>VerificationException</c> is thrown.
/// </summary>
    public interface Verifier {

    /// <summary>
    /// Asserts whether a method was called or not. The method passes verification if it was called at least once.
    /// </summary>
    /// <example>Note that the following does not work since this method asserts at least one call:
    /// <code>
    /// Verify.That(() => mock.Method(2)).IsCalled().Exactly(0);
    /// </code>
    /// </example>
    /// <returns>A <c>VerifierInteractions</c> object to further specify the number of interactiosn with the method.</returns>
        VerifierInteractions IsCalled();

    /// <summary>
    /// Asserts if the method is not called. The method passes verification if it was never called.
    /// </summary>
        void IsNotCalled();

    /// <summary>
    /// Asserts the method has the interactions specified by the <c>Times</c> object.
    /// </summary>
    /// <param name="times"><c>Times</c> object representing how many interactions the method should have had.</param>
        void HasInteractions(Times times);

    }
}
