using System;
using System.Linq;
using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class MockProxy : Core.MockProxy {
        private Core.CallMemory callMemory;
        private Core.StubMemory stubMemory;

        public MockProxy():this(new CallMemory(), new StubMemory()) {}

        public MockProxy(Core.CallMemory callMemory, Core.StubMemory stubMemory) {
            this.callMemory = callMemory;
            this.stubMemory = stubMemory;
        }

        public Core.CallMemory CallMemory {
            get { return callMemory; }
        }

        public Core.StubMemory StubMemory {
            get { return stubMemory; }
        }

        public Core.MethodCall Call(params object[] arguments) {
            string method = new MethodNamer(new System.Diagnostics.StackFrame(1).GetMethod()).Name();

            callMemory.Call(method, arguments);
            return new MethodCall(stubMemory.Get(method), arguments);
        }

    }

}