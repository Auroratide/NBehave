namespace Auroratide.NBehave.Internal {
    using Core;

    public class MethodCall {

        private IMethodStub stub;
        private object[] arguments;
        
        public MethodCall(IMethodStub stub, object[] arguments) {
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
