namespace Auroratide.NBehave.Internal {
    using Core;
    using Exceptions;
    
    public class Verifier : Core.Verifier {

        private NBehaveMock mock;
        private string method;
        private MatcherList arguments;

        public Verifier(NBehaveMock mock, string method, MatcherList arguments) {
            this.mock = mock;
            this.method = method;
            this.arguments = arguments;
        }

        public Core.VerifierInteractions IsCalled() {
            HasInteractions(new AtLeast(1));
            return new VerifierInteractions(this);
        }

        public void IsNotCalled() {
            HasInteractions(new Exactly(0));
        }

        public void HasInteractions(Times times) {
            int actual = mock.NBehave.CallMemory.TimesCalled(method, arguments);
            if (!times.Matches(actual))
                throw new VerificationException(method, actual.ToString(), times.ToString());
        }

    }

}
    