using System;
using System.Linq;
using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class MockProxy : Core.MockProxy {
        private CallMemory callMemory;
        private StubMemory stubs;

        public MockProxy() {
            callMemory = new CallMemory(new Dictionary<string, List<object[]>>());
            stubs = new StubMemory(new Dictionary<string, Core.MethodStub>());
        }

        public Core.CallMemory CallMemory {
            get { return callMemory; }
        }

        public Core.StubMemory StubMemory {
            get { return stubs; }
        }

        public Core.MethodCall Call(params object[] arguments) {
            string method = new Internal.MethodNamer(new System.Diagnostics.StackFrame(1).GetMethod()).Name();

            callMemory.Call(method, arguments);
            return new MethodCall(stubs.Get(method), arguments);
        }

    }

}