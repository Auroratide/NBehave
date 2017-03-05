using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {
    public class StubMemory : Core.StubMemory {
        
        private Dictionary<string, Core.MethodStub> methods;

        public StubMemory():this(new Dictionary<string, Core.MethodStub>()) {}

        public StubMemory(Dictionary<string, Core.MethodStub> methods) {
            this.methods = methods;
        }

        public Core.MethodStub Get(string method) {
            if(!methods.ContainsKey(method))
                methods[method] = new MethodStub();
            return methods[method];
        }
    }
}
