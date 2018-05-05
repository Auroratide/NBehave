namespace Auroratide.NBehave.Unit.Mock {
    public class StubMemory : Core.StubMemory {

        public ReturnList Returns = new ReturnList();

        public Core.MethodStub Get(string method) {
            return Returns.Get.Dequeue();
        }

        public class ReturnList {
            public Queue<Core.MethodStub> Get = new Queue<Core.MethodStub>();
        }

    }
}

