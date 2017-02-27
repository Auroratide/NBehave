using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class Always : Core.StubAction {
        private Core.StubAction previous;
        private List<Core.StubAction> returns;
        
        public Always(Core.StubAction previous, List<Core.StubAction> returns) {
            this.previous = previous;
            this.returns = returns;
        }

        public object Return() {
            returns.Add(this);
            return previous.Return();
        }
    }
}
