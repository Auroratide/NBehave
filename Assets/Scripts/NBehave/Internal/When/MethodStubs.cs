using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {
    public class MethodStubs {
        private Dictionary<string, MethodStub> methods;

        public MethodStubs() {
            this.methods = new Dictionary<string, MethodStub>();
        }

        public MethodStub Get(string method) {
            if(!methods.ContainsKey(method))
                methods[method] = new MethodStub();
            return methods[method];
        }
    }
}
