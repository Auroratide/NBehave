using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class MethodStub : IMethodStub {

        private Dictionary<MatcherList, List<Core.StubAction>> returns;

        public MethodStub(Dictionary<MatcherList, List<Core.StubAction>> returns) {
            this.returns = returns;
            this.returns[new MatcherList()] = new List<Core.StubAction>();
        }

        public Core.OngoingStubbing With(params object[] arguments) {
            MatcherList matchers = new MatcherList(arguments);
            returns[matchers] = new List<Core.StubAction>();

            return new OngoingStubbing(new StubbingAction(arguments, returns[matchers]), returns[matchers]);
        }
            
        public Core.StubAction NextReturnAction(params object[] arguments) {
            List<Core.StubAction> returnList = FindReturnList(arguments);
            if (returnList.Count <= 0)
                return null;
            
            Core.StubAction action = returnList[0];
            returnList.RemoveAt(0);
            return action;
        }

        private List<Core.StubAction> FindReturnList(object[] arguments) {
            foreach(MatcherList matchers in returns.Keys) {
                if (matchers.MatchesAll(arguments))
                    return returns[matchers];
            }

            return new List<Core.StubAction>();
        }

    }

}
