namespace Auroratide.NBehave.Core {
    public interface MockedType<T> where T : class {
        System.Type Type { get; }
        T Create();
    }
}