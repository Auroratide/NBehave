using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Core {
    public abstract class MockEmitter<T> where T : class {
        protected Type type;
        protected ModuleBuilder moduleBuilder;

        public MockEmitter(ModuleBuilder moduleBuilder) {
            this.type = typeof(T);
            this.moduleBuilder = moduleBuilder;
        }

        public Type Emit() {
            Type cachedType = moduleBuilder.GetType(type.Name);

            if(cachedType != null)
                return cachedType;
            else
                return BuildType();
        }

        public abstract Type BuildType();
    }
}