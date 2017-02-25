namespace Auroratide.NBehave.Internal {

    public class MethodCall : IMethodCall {

        private IMethodStub stub;
        private object[] arguments;
        
        public MethodCall(IMethodStub stub, object[] arguments) {
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
