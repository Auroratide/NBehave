namespace Auroratide.NBehave.Unit.Mock {
    public class MethodCall : Core.MethodCall {
        
        public ReturnList Returns = new ReturnList();

        public T AndReturn<T>() {
            return (T)Returns.AndReturn.Dequeue();
        }

        public void AndExecute() {}

        public class ReturnList {
            public Queue<object> AndReturn = new Queue<object>();
        }
    }
}
