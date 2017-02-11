using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {
    
    public class MethodStub {

        private Dictionary<MatcherList, List<StubAction>> returns;

        public MethodStub() {
			this.returns = new Dictionary<MatcherList, List<StubAction>>();
			this.returns[new MatcherList()] = new List<StubAction>();
        }

		public OngoingStubbing With(params object[] arguments) {
			MatcherList matchers = new MatcherList(arguments);
			returns[matchers] = new List<StubAction>();

            return new OngoingStubbing(new StubbingAction(arguments, returns[matchers]), returns[matchers]);
        }
			
		public StubAction NextReturnAction(params object[] arguments) {
			List<StubAction> returnList = FindReturnList(arguments);
			if (returnList.Count <= 0)
				return null;
			
			StubAction action = returnList[0];
			returnList.RemoveAt(0);
			return action;
		}

		private List<StubAction> FindReturnList(object[] arguments) {
			foreach(MatcherList matchers in returns.Keys) {
				if (matchers.MatchesAll(arguments))
					return returns[matchers];
			}

			return new List<StubAction>();
		}

    }

}
