namespace Auroratide.NBehave.Exceptions {
    public class VerificationException : System.Exception {
        public VerificationException(string method, string timesInvoked, string expectedInvocations) 
            :base("Expected " + expectedInvocations + " invocations of " + method + ", but got " + timesInvoked)
        {}

        public VerificationException(System.Type type) 
            :base("Cannot verify non-mock type " + type.Name)
        {}
    }
}
