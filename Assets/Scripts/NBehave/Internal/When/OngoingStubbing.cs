using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class OngoingStubbing : Core.OngoingStubbing, System.IEquatable<OngoingStubbing> {
        
        private object[] arguments;
        private List<Core.StubAction> returns;

        public OngoingStubbing(object[] arguments, List<Core.StubAction> returns) {
            this.arguments = arguments;
            this.returns = returns;
        }

        public Core.StubbingAction Then {
            get { return new StubbingAction(this, arguments, returns); }
        }

        public void Always() {
            returns.Add(new Always(returns[returns.Count - 1], returns));
        }

        public bool Equals(OngoingStubbing other) {
            return this.arguments == other.arguments && this.returns == other.returns;
        }

    }
}
