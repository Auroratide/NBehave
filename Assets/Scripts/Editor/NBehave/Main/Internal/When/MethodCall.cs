namespace Auroratide.NBehave.Internal {

    public class MethodCall : Core.MethodCall, System.IEquatable<MethodCall> {

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
            else {
                object returnValue = action.Return(arguments);
                if(returnValue is T)
                    return (T)action.Return(arguments);
                else
                    throw new Exceptions.StubbingException(returnValue.GetType(), typeof(T));
            }
        }

        public void AndExecute() {
            Core.StubAction action = stub.NextReturnAction(arguments);
            if (action != null)
                action.Return(arguments);
        }

        public bool Equals(MethodCall other) {
            if(this.stub == other.stub) {
                if(this.arguments.Length == other.arguments.Length) {
                    for(int i = 0; i < this.arguments.Length; ++i)
                        if(!this.arguments[i].Equals(other.arguments[i]))
                            return false;
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
