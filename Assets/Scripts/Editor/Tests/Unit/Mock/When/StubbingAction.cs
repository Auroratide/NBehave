namespace Auroratide.NBehave.Unit.Mock {
    public class StubbingAction : Core.StubbingAction {

        public ReturnList Returns = new ReturnList();
        public TimesCalledTracker TimesCalled = new TimesCalledTracker();

        public Core.OngoingStubbing Return(object obj) {
            ++TimesCalled.Return;
            return Returns.Return.Dequeue();
        }

        public Core.OngoingStubbing Throw(System.Exception exception) {
            ++TimesCalled.Throw;
            return Returns.Throw.Dequeue();
        }

        public Core.OngoingStubbing Execute(Core.ExecutesDelegate function) {
            ++TimesCalled.Execute;
            return Returns.Execute.Dequeue();
        }

        public Core.OngoingStubbing Do(Core.StubAction StubAction) {
            ++TimesCalled.Do;
            return Returns.Do.Dequeue();
        }

        public class ReturnList {
            public Queue<Core.OngoingStubbing> Return = new Queue<Core.OngoingStubbing>();
            public Queue<Core.OngoingStubbing> Throw = new Queue<Core.OngoingStubbing>();
            public Queue<Core.OngoingStubbing> Execute = new Queue<Core.OngoingStubbing>();
            public Queue<Core.OngoingStubbing> Do = new Queue<Core.OngoingStubbing>();
        }

        public class TimesCalledTracker {
            public int Return = 0;
            public int Throw = 0;
            public int Execute = 0;
            public int Do = 0;
        }
    }
}
