using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {
    using Core;

    public class BasicEmitter<T> : MockEmitter<T> where T : class {

        public BasicEmitter(ModuleBuilder moduleBuilder):base(moduleBuilder) {}

        override public Type BuildType() {
            TypeBuilder typeBuilder = moduleBuilder.DefineType(type.Name, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass, null);
            typeBuilder.AddInterfaceImplementation(type);
            typeBuilder.AddInterfaceImplementation(typeof(NBehaveMock));

            NBehavePropertyBuilder nbehaveBuilder = new NBehavePropertyBuilder(typeBuilder);
            PropertyInfo nbehaveProperty = nbehaveBuilder.Build();

            BuildConstructor(typeBuilder, nbehaveBuilder);
            ImplementMethods(typeBuilder, nbehaveProperty);

            return typeBuilder.CreateType();
        }

        private ConstructorInfo BuildConstructor(TypeBuilder typeBuilder, NBehavePropertyBuilder nbehaveBuilder) {
            ConstructorBuilder constructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator cil = constructor.GetILGenerator();

            cil.Emit(OpCodes.Ldarg_0);
            nbehaveBuilder.Instantiate(cil);
            cil.Emit(OpCodes.Ret);

            return constructor;
        }

        private void ImplementMethods(TypeBuilder typeBuilder, PropertyInfo nbehaveProperty) {
            var implementor = new MockMethodImplementor(typeBuilder, nbehaveProperty);
            MethodInfo[] methods = type.GetMethods();
            for(int i = 0; i < methods.Length; ++i)
                implementor.Implement(methods[i]);
        }

    }
    
}
