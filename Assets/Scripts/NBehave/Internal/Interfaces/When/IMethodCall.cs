namespace Auroratide.NBehave.Internal {
    public interface IMethodCall {
        T AndReturn<T>();
        void AndExecute();
    }
}
