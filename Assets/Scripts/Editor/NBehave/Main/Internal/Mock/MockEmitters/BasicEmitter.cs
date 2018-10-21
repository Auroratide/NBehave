using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {
    using System.Collections.Generic;
    using System.Linq;
    using Core;

    public abstract class BasicEmitter<T> : MockEmitter<T> where T : class {

        public BasicEmitter(ModuleBuilder moduleBuilder):base(moduleBuilder) {}

        override public Type BuildType() {
            TypeBuilder typeBuilder = CreateTypeBuilder();
            typeBuilder.AddInterfaceImplementation(typeof(NBehaveMock));

            NBehavePropertyBuilder nbehaveBuilder = new NBehavePropertyBuilder(typeBuilder);
            PropertyInfo nbehaveProperty = nbehaveBuilder.Build();

            BuildConstructor(typeBuilder, nbehaveBuilder);
            OverrideMethods(typeBuilder, nbehaveProperty);

            return typeBuilder.CreateType();
        }

        protected abstract TypeBuilder CreateTypeBuilder();

        protected abstract IEnumerable<MethodInfo> GetMethodsToOverride();

        private ConstructorInfo BuildConstructor(TypeBuilder typeBuilder, NBehavePropertyBuilder nbehaveBuilder) {
            ConstructorBuilder constructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator cil = constructor.GetILGenerator();

            cil.Emit(OpCodes.Ldarg_0);
            nbehaveBuilder.Instantiate(cil);
            cil.Emit(OpCodes.Ret);

            return constructor;
        }

        private void OverrideMethods(TypeBuilder typeBuilder, PropertyInfo nbehaveProperty) {
            var implementor = new MockMethodImplementor(typeBuilder, nbehaveProperty);
            GetMethodsToOverride().ToList().ForEach(method => implementor.Implement(method));
        }

    }
    
}
