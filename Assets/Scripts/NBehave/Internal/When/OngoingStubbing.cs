using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class OngoingStubbing : Core.OngoingStubbing {
        private Core.StubbingAction action;
        private List<Core.StubAction> returns;

        public OngoingStubbing(Core.StubbingAction action, List<Core.StubAction> returns) {
            this.action = action;
            this.returns = returns;
        }

        public Core.StubbingAction Then {
            get { return action; }
        }

        public void Always() {
            returns.Add(new Always(returns[returns.Count - 1], returns));
        }

    }
}
