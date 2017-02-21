using System;
using System.Linq;
using System.Collections.Generic;

namespace Auroratide.NBehave.Core {
    using Internal;

    public class NBehave {
        private CallMemory callMemory;
        private MethodStubs stubs;

        public NBehave() {
            callMemory = new CallMemory(new Dictionary<string, List<object[]>>());
            stubs = new MethodStubs(new Dictionary<string, IMethodStub>());
        }

        public CallMemory CallMemory {
            get { return callMemory; }
        }

        public MethodStubs MethodStubs {
            get { return stubs; }
        }

        public MethodCall Call(params object[] arguments) {
            string method = new MethodNamer(new System.Diagnostics.StackFrame(1).GetMethod()).Name();

            callMemory.Call(method, arguments);
            return new MethodCall(stubs.Get(method), arguments);
        }

    }

}