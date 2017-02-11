using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {

    public class MockEmitter<I> where I : class {
        
        private Type Interface;
        private ModuleBuilder moduleBuilder;

        public MockEmitter(ModuleBuilder moduleBuilder) {
            Interface = typeof(I);
            this.moduleBuilder = moduleBuilder;
        }

        public Type Emit() {
            Type cachedType = moduleBuilder.GetType(Interface.Name);

            if(cachedType != null)
                return cachedType;
            else
                return BuildType();
        }

        private Type BuildType() {
            TypeBuilder typeBuilder = moduleBuilder.DefineType(Interface.Name, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass, null);
            typeBuilder.AddInterfaceImplementation(Interface);
            typeBuilder.AddInterfaceImplementation(typeof(NBehaveMock));

            FieldInfo nbehaveField = new NBehaveFieldEmitter(typeBuilder).Emit();
            BuildConstructor(typeBuilder, nbehaveField);
            ImplementMethods(typeBuilder, nbehaveField);

            return typeBuilder.CreateType();
        }

        private ConstructorInfo BuildConstructor(TypeBuilder typeBuilder, FieldInfo nbehaveField) {
            ConstructorBuilder constructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator cil = constructor.GetILGenerator();

            cil.Emit(OpCodes.Ldarg_0);
            cil.Emit(OpCodes.Newobj, typeof(NBehave).GetConstructor(Type.EmptyTypes));
            cil.Emit(OpCodes.Stfld, nbehaveField);
            cil.Emit(OpCodes.Ret);

            return constructor;
        }

        private void ImplementMethods(TypeBuilder typeBuilder, FieldInfo nbehaveField) {
            var implementor = new MockMethodImplementor(typeBuilder, nbehaveField);
            MethodInfo[] methods = Interface.GetMethods();
            for(int i = 0; i < methods.Length; ++i)
                implementor.Implement(methods[i]);
        }

    }
    
}
