namespace Auroratide.NBehave.Core {
    public interface MethodCall {
        T AndReturn<T>();
        void AndExecute();
    }
}
