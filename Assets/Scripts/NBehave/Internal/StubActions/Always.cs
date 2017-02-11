using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {
	public class Always : StubAction {
		private StubAction previous;
		private List<StubAction> returns;
		
		public Always(StubAction previous, List<StubAction> returns) {
			this.previous = previous;
			this.returns = returns;
		}

		public object Return() {
			returns.Add(this);
			return previous.Return();
		}
	}
}
