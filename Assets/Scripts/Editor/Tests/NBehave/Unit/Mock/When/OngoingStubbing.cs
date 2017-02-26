namespace Auroratide.NBehave.Unit.Mock {
    public class OngoingStubbing : Core.OngoingStubbing {

        public ReturnList Returns = new ReturnList();
        public TimesCalledTracker TimesCalled = new TimesCalledTracker();

        public Core.StubbingAction Then {
            get {
                ++TimesCalled.Then;
                return Returns.Then.Dequeue();
            }
        }

        public void Always() {
            ++TimesCalled.Always;
        }

        public class ReturnList {
            public Queue<Core.StubbingAction> Then = new Queue<Core.StubbingAction>();
        }

        public class TimesCalledTracker {
            public int Then = 0;
            public int Always = 0;
        }
    }
}

