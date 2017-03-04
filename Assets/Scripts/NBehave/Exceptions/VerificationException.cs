namespace Auroratide.NBehave.Exceptions {

/// <summary>
/// Exception used to indicate that something went wrong with the verification process.
/// </summary>
    public class VerificationException : System.Exception {

    /// <summary>
    /// Used when a method fails verification. Indicates to the user what was expected and what actually occurred.
    /// </summary>
    /// <param name="method">Method name.</param>
    /// <param name="timesInvoked">Times actually invoked.</param>
    /// <param name="expectedInvocations">Expected nature of the invocations.</param>
        public VerificationException(string method, string timesInvoked, string expectedInvocations) 
            :base("Expected " + expectedInvocations + " invocations of " + method + ", but got " + timesInvoked)
        {}

    /// <summary>
    /// Used when attempting to verify against a non-mock type.
    /// </summary>
    /// <param name="type">The type upon which verification was attempted.</param>
        public VerificationException(System.Type type) 
            :base("Cannot verify non-mock type " + type.Name)
        {}
    }
}
