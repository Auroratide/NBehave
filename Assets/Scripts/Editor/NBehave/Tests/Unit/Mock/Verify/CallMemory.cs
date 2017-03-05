namespace Auroratide.NBehave.Unit.Mock {
    public class CallMemory : Core.CallMemory {

        public ReturnList Returns = new ReturnList();
        public CalledWithTracker CalledWith = new CalledWithTracker();

        public int TimesCalled(string method, Core.MatcherList arguments) {
            CalledWith.TimesCalled = Tuple.Create(method, arguments);
            return Returns.TimesCalled.Dequeue();
        }

        public void Call(string method, object[] arguments) {
            CalledWith.Call = Tuple.Create(method, arguments);
        }

        public class ReturnList {
            public Queue<int> TimesCalled = new Queue<int>();
        }

        public class CalledWithTracker {
            public Tuple<string, Core.MatcherList> TimesCalled;
            public Tuple<string, object[]> Call;
        }
    }
}

