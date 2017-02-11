using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {
    public class OngoingStubbing : Auroratide.NBehave.OngoingStubbing {
        private StubbingAction action;
        private List<StubAction> returns;

        public OngoingStubbing(StubbingAction action, List<StubAction> returns) {
            this.action = action;
            this.returns = returns;
        }

        public Auroratide.NBehave.StubbingAction Then {
            get { return action; }
        }

        public void Always() {
            returns.Add(new Always(returns[returns.Count - 1], returns));
        }

    }
}
