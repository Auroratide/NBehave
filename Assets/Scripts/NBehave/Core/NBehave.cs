namespace Auroratide.NBehave {
    using Internal;

    public class NBehave {
        private CallMemory callMemory;
        private MethodStubs stubs;

        public NBehave() {
            callMemory = new CallMemory();
            stubs = new MethodStubs();
        }

        public CallMemory CallMemory {
            get { return callMemory; }
        }

        public MethodStubs MethodStubs {
            get { return stubs; }
        }

        public MethodCall Call(params object[] arguments) {
            string method = new System.Diagnostics.StackFrame(1).GetMethod().Name;

            callMemory.Call(method, arguments);
            return new MethodCall(stubs.Get(method), arguments);
        }

    }

}