namespace Auroratide.NBehave.Unit.Mock {
    public class StubAction : Core.StubAction {

        public ReturnList Returns = new ReturnList();
        public TimesCalledTracker TimesCalled = new TimesCalledTracker();

        public object Return() {
            ++TimesCalled.Return;
            return Returns.Return.Dequeue();
        }

        public class ReturnList {
            public Queue<object> Return = new Queue<object>();
        }

        public class TimesCalledTracker {
            public int Return = 0;
        }
    }
}
