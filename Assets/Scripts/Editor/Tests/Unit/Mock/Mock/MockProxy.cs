namespace Auroratide.NBehave.Unit.Mock {
    public class MockProxy : Core.MockProxy {

        private Core.CallMemory callMemory;
        private Core.StubMemory stubMemory;

        public ReturnList Returns = new ReturnList();

        public Core.CallMemory CallMemory {
            get { return callMemory; }
            set { callMemory = value; }
        }

        public Core.StubMemory StubMemory {
            get { return stubMemory; }
            set { stubMemory = value; }
        }

        public Core.MethodCall Call(params object[] arguments) {
            return Returns.Call.Get(arguments);
        }
            
        public class ReturnList {
            public Dictionary<object[], Core.MethodCall> Call = new Dictionary<object[], Core.MethodCall>();
        }

    }
}

