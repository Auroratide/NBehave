using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {
    public class MethodStubs {
        private Dictionary<string, IMethodStub> methods;

        public MethodStubs(Dictionary<string, IMethodStub> methods) {
            this.methods = methods;
        }

        public IMethodStub Get(string method) {
            if(!methods.ContainsKey(method))
                methods[method] = new MethodStub(new Dictionary<MatcherList, List<Core.StubAction>>());
            return methods[method];
        }
    }
}
