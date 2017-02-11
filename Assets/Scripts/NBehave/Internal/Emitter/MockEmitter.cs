using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {

    public class MockEmitter<I> where I : class {
        
        private Type Interface;
        private ModuleBuilder moduleBuilder;

        private TypeBuilder typeBuilder;
        private FieldBuilder nbehaveFieldBuilder;

        public MockEmitter(ModuleBuilder moduleBuilder) {
            Interface = typeof(I);
            this.moduleBuilder = moduleBuilder;
            this.typeBuilder = moduleBuilder.DefineType(Interface.Name, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass, null);
            typeBuilder.AddInterfaceImplementation(Interface);
            typeBuilder.AddInterfaceImplementation(typeof(NBehaveMock));
        }

        public Type Emit() {
            CreateNBehaveField();
            CreateConstructor();

            ImplementMethods();

            return typeBuilder.CreateType();
        }


    /*  Copy Pasta
     *  =======================================================================================*/
        private void CreateNBehaveField() {
            nbehaveFieldBuilder = typeBuilder.DefineField("nbehave", typeof(NBehave), FieldAttributes.Private);
            PropertyBuilder pb = typeBuilder.DefineProperty("NBehave", PropertyAttributes.HasDefault, typeof(NBehave), null);
            MethodBuilder mb = typeBuilder.DefineMethod("get_NBehave", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(NBehave), Type.EmptyTypes);
            ILGenerator il = mb.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0); // this
            il.Emit(OpCodes.Ldfld, nbehaveFieldBuilder);
            il.Emit(OpCodes.Ret);

            pb.SetGetMethod(mb);

            typeBuilder.DefineMethodOverride(mb, typeof(NBehaveMock).GetMethod("get_NBehave"));
        }

        private void CreateConstructor() {
            ConstructorBuilder constructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            ILGenerator cil = constructor.GetILGenerator();

            cil.Emit(OpCodes.Ldarg_0);
            cil.Emit(OpCodes.Newobj, typeof(NBehave).GetConstructor(Type.EmptyTypes));
            cil.Emit(OpCodes.Stfld, nbehaveFieldBuilder);
            cil.Emit(OpCodes.Ret);
        }

        private void ImplementMethods() {
            MethodInfo[] methods = Interface.GetMethods();
            for(int i = 0; i < methods.Length; ++i) {
                MethodInfo method = methods[i];

                ParameterInfo[] parameters = method.GetParameters();
                Type[] paramTypes = new Type[parameters.Length];
                for(int p = 0; p < parameters.Length; ++p)
                    paramTypes[p] = parameters[p].ParameterType;

                MethodBuilder mb = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, method.ReturnType, paramTypes);
                MethodInfo nbehaveCall = typeof(NBehave).GetMethod("Call");
                ILGenerator generator = mb.GetILGenerator();

                LocalBuilder objArr = generator.DeclareLocal(typeof(object[]));
                generator.Emit(OpCodes.Ldc_I4_S, paramTypes.Length);
                generator.Emit(OpCodes.Newarr, typeof(object));
                generator.Emit(OpCodes.Stloc, objArr);

                for(int p = 0; p < paramTypes.Length; ++p) {
                    generator.Emit(OpCodes.Ldloc, objArr);
                    generator.Emit(OpCodes.Ldc_I4, p);
                    generator.Emit(OpCodes.Ldarg, p + 1);
                    if(paramTypes[p].IsValueType)
                        generator.Emit(OpCodes.Box, paramTypes[p]);
                    generator.Emit(OpCodes.Stelem, paramTypes[p]);
                }

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, nbehaveFieldBuilder);
                generator.Emit(OpCodes.Ldloc, objArr);

                generator.Emit(OpCodes.Call, nbehaveCall);

                MethodInfo returnCall = null;
                if(method.ReturnType != typeof(void))
                    returnCall = typeof(MethodCall).GetMethod("AndReturn", Type.EmptyTypes).MakeGenericMethod(new Type[]{method.ReturnType});
                else
                    returnCall = typeof(MethodCall).GetMethod("AndExecute");

                generator.Emit(OpCodes.Call, returnCall);
                generator.Emit(OpCodes.Ret);

                typeBuilder.DefineMethodOverride(mb, method);
            }
        }

    }
    
}
