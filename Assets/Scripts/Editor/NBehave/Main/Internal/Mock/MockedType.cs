using System;

namespace Auroratide.NBehave.Internal {
    public class MockedType<T> : Core.MockedType<T> where T : class {
        private Type type;

        public MockedType(Type type) {
            this.type = type;
        }

        public T Create() {
            return (T)(Activator.CreateInstance(type));
        }
    }
}
