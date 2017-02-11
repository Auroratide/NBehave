namespace Auroratide.NBehave.Internal {
    public class MethodCall {

        private MethodStub stub;
        private object[] arguments;
        
        public MethodCall(MethodStub stub, object[] arguments) {
            this.stub = stub;
            this.arguments = arguments;
        }

        public T AndReturn<T>() {
            StubAction action = stub.NextReturnAction(arguments);
            if (action == null)
                return default(T);
            else 
                return (T)action.Return();
        }

        public void AndExecute() {
            StubAction action = stub.NextReturnAction(arguments);
            if (action != null)
                action.Return();
        }

    }
}
