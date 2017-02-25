namespace Auroratide.NBehave.Internal {

    public class MethodCall : Core.MethodCall {

        private Core.MethodStub stub;
        private object[] arguments;
        
        public MethodCall(Core.MethodStub stub, object[] arguments) {
            this.stub = stub;
            this.arguments = arguments;
        }

        public T AndReturn<T>() {
            Core.StubAction action = stub.NextReturnAction(arguments);
            if (action == null)
                return default(T);
            else 
                return (T)action.Return();
        }

        public void AndExecute() {
            Core.StubAction action = stub.NextReturnAction(arguments);
            if (action != null)
                action.Return();
        }

    }
}
