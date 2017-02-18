namespace Auroratide.NBehave.Unit.Mock {
    public class MethodStub : Internal.IMethodStub {
        
        public static object[] ValidArguments() {
            return new object[] { 2, "hello" };
        }

        public ReturnList Returns = new ReturnList();

        public Core.OngoingStubbing With(params object[] arguments) {
            if(arguments.Length == 2 && (int)arguments[0] == 2 && arguments[1] == "hello")
                return Returns.With.Dequeue();
            else
                return null;
        }

        public Core.StubAction NextReturnAction(params object[] arguments) {
            if(arguments.Length == 2 && (int)arguments[0] == 2 && arguments[1] == "hello")
                return Returns.NextReturnAction.Dequeue();
            else
                return null;
        }

        public class ReturnList {
            public Queue<Core.OngoingStubbing> With = new Queue<Core.OngoingStubbing>();
            public Queue<Core.StubAction> NextReturnAction = new Queue<Core.StubAction>();
        }
    }
}