using System;
using System.Linq;
using System.Collections.Generic;

namespace Auroratide.NBehave.Core {

    public class NBehave {
        private CallMemory callMemory;
        private StubMemory stubs;

        public NBehave() {
            callMemory = new Internal.CallMemory(new Dictionary<string, List<object[]>>());
            stubs = new Internal.StubMemory(new Dictionary<string, MethodStub>());
        }

        public CallMemory CallMemory {
            get { return callMemory; }
        }

        public StubMemory MethodStubs {
            get { return stubs; }
        }

        public MethodCall Call(params object[] arguments) {
            string method = new Internal.MethodNamer(new System.Diagnostics.StackFrame(1).GetMethod()).Name();

            callMemory.Call(method, arguments);
            return new Internal.MethodCall(stubs.Get(method), arguments);
        }

    }

}