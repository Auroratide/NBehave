namespace Auroratide.NBehave.Unit.Mock {
    public class StubAction : Core.StubAction {

        public ReturnList Returns = new ReturnList();
        public TimesCalledTracker TimesCalled = new TimesCalledTracker();

        public object Return(object[] args) {
            ++TimesCalled.Return;
            //return Returns.Return.Dequeue();
            return Returns.Return.Get(args);
        }

        public class ReturnList {
//            public Queue<object> Return = new Queue<object>();
            public Dictionary<object[], object> Return = new Dictionary<object[], object>();
        }

        public class TimesCalledTracker {
            public int Return = 0;
        }
    }
}
