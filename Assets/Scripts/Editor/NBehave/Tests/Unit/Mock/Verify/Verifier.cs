namespace Auroratide.NBehave.Unit.Mock {
    public class Verifier : Core.Verifier {

        public ReturnList Returns = new ReturnList();
        public CalledWithTracker CalledWith = new CalledWithTracker();

        public Core.VerifierInteractions IsCalled() {
            return Returns.IsCalled.Dequeue();
        }

        public void IsNotCalled() {}

        public void HasInteractions(Core.Times times) {
            CalledWith.HasInteractions.First = times;
        }

        public class ReturnList {
            public Queue<Core.VerifierInteractions> IsCalled = new Queue<Core.VerifierInteractions>();
        }

        public class CalledWithTracker {
            public Tuple<Core.Times> HasInteractions;
        }
    }
}
